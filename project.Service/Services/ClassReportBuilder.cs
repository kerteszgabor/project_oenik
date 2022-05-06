using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Emit;
using project.Domain.DTO.ClassReport;
using project.Domain.Helpers.Exceptions;
using project.Domain.Helpers.ClassReportBuilder;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;
using project.Service.Interfaces;
using AutoMapper;

namespace project.Service.Services
{
    public class ClassReportBuilder : ICanCallBuild, ICanRequireCompilation, ICanCompile, IClassReportBuilder
    {
        public string CodeAsString
        {
            get
            {
                return codeAsString;
            }
            set
            {
                codeAsString = value;
                BuildAssets();
            }
        }

        private string codeAsString;
        private string compilationPath;
        private SyntaxTree tree;
        private List<string> methodsNotFound;
        private List<MethodDeclarationSyntax> methods;
        private MethodModel lastMethod;
        private Dictionary<MethodDeclarationSyntax, MethodModel> methodPairs;
        private ConcurrentBag<object> compilationResults;

        private ClassReportBuilder(string codeToAnalyze)
        {
            this.CodeAsString = codeToAnalyze;
            this.compilationPath = Path.Combine(Directory.GetCurrentDirectory(), "compilations", Guid.NewGuid().ToString());
            this.methodsNotFound = new List<string>();
            this.methodPairs = new Dictionary<MethodDeclarationSyntax, MethodModel>();
            this.compilationResults = new ConcurrentBag<object>();
            BuildAssets();
        }

        public ClassReportBuilder()
        {

        }

        public ICanCallBuild GetReportOf(string codeToAnalyze)
        {
            return new ClassReportBuilder(codeToAnalyze);
        }

        private void BuildAssets()
        {
            this.tree = GetSyntaxTree();
            this.methods = GetMethodDeclarationSyntaxes();
        }

        private SyntaxTree GetSyntaxTree()
        {
            return SyntaxFactory.ParseSyntaxTree(CodeAsString);
        }

        private List<MethodDeclarationSyntax> GetMethodDeclarationSyntaxes()
        {
            return tree
                .GetRoot()
                .DescendantNodes()
                .OfType<MethodDeclarationSyntax>()
                .ToList();
        }

        private MethodDeclarationSyntax FindMethod(MethodInfoData model)
        {
            var method = methods.FirstOrDefault(x => x.Identifier.ToString() == model.MethodName || x.ReturnType.ToString() == model.ExpectedReturnType);
            if (method != null)
            {
                return method;
            }
            else
            {
                throw new MethodNotFoundException();
            }
        }

        public ICanRequireCompilation WithMethod(MethodInfoData methodInfo)
        {
            try
            {
                var method = FindMethod(methodInfo);
                var model = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<MethodInfoData, MethodModel>();
                })
                    .CreateMapper()
                    .Map<MethodInfoData, MethodModel>(methodInfo);

                methodPairs.Add(method, model);
                lastMethod = model;
                return this;
            }
            catch (MethodNotFoundException)
            {
                methodsNotFound.Add(methodInfo.MethodName);
                return this;
            }
        }

        public ICanCompile AlsoCompile()
        {
            lastMethod.RequireCompilation = true;
            return this;
        }

        public ICanCompile WithParameters(object[] parameters)
        {
            lastMethod.Parameters = parameters;
            return this;
        }

        public ICanCompile SetExpectedStringOutput(string expectedStringOutput)
        {
            lastMethod.ExpectedStringOutput = expectedStringOutput;
            return this;
        }

        public ICanCompile SetExpectedValue(object expectedOutput)
        {
            lastMethod.ExpectedValue = expectedOutput;
            return this;
        }

        public ClassReport Build()
        {
            var classReport = new ClassReport();
            ValidateReturnTypes(classReport);
            ValidateParameterTypes(classReport);
            ValidateMethodsExisting(classReport);

            var methodsToCompile = from m in methodPairs
                                   where m.Value.RequireCompilation
                                   select m.Key;

            if (Directory.Exists(compilationPath))
            {
                HelperMethods.DeleteDirectory(compilationPath);
            }
            else
            {
                Directory.CreateDirectory(compilationPath);
            }

            Parallel.ForEach(methodsToCompile, (method) =>
            {
                var methodModel = methodPairs[method];
                var compilationResult = CompileMethod(method, methodModel.Parameters);
                compilationResults.Add(compilationResult);

                if (compilationResult.ToString().Contains("Error"))
                {
                    classReport.HadCompilationError = true;
                }

                if (
                 compilationResult.ToString() == methodModel.ExpectedValue?.ToString()
                || compilationResult.ToString() == methodModel.ExpectedStringOutput?.ToString())
                {
                    classReport.ValidMethodsByOutput.Add(method.Identifier.ValueText);
                }
                else
                {
                    classReport.MismatchingOutputMethods.Add(method.Identifier.ValueText);
                }
            });

            HelperMethods.DeleteDirectory(compilationPath);
            return classReport;
        }

        private ClassReport ValidateReturnTypes(ClassReport report)
        {
            foreach (var method in methodPairs.Keys)
            {
                var methodModel = methodPairs[method];
                if (methodModel.ExpectedReturnType != null)
                {
                    if (method.ReturnType.ToString().ToLower() == methodModel.ExpectedReturnType)
                    {
                        report.ValidMethodsByReturnType.Add(method.Identifier.ValueText);
                    }
                    else
                    {
                        report.MismatchingReturnTypeMethods.Add(method.Identifier.ValueText);
                    }
                }
            }
            return report;
        }

        private ClassReport ValidateParameterTypes(ClassReport report)
        {
            foreach (var method in methodPairs.Keys)
            {
                var methodModel = methodPairs[method];
                if (methodModel.ParameterList != null)
                {
                    var parameters = method.ParameterList.Parameters;
                    var expectedParameters = methodPairs[method].ParameterList;

                    var areMatching = parameters
                    .SelectMany(x => new ParamList { { x.Type.ToString(), x.Identifier.ToString() } })
                    .Intersect(expectedParameters)
                    .Count() == parameters.Count;

                    if (areMatching)
                    {
                        report.ValidMethodsByParameters.Add(method.Identifier.ValueText);
                    }
                    else
                    {
                        report.MismatchingParametersMethods.Add(method.Identifier.ValueText);
                    }
                }
            }
            return report;
        }

        private void ValidateMethodsExisting(ClassReport report)
        {
            report.MissingMethods = methodsNotFound;
            report.ValidMethodsByExistence = methodPairs.Keys.ToList().Select(x => x.Identifier.ValueText).ToList();
        }

        private object CompileMethod(MethodDeclarationSyntax method, object[] parameters)
        {
            string fileName = method.Identifier.ToString() + ".dll";
            var systemRefLocation = typeof(object).GetTypeInfo().Assembly.Location;
            var systemReference = MetadataReference.CreateFromFile(systemRefLocation);
            string path = Path.Combine(compilationPath, fileName);

            var compilation = CSharpCompilation.Create(fileName)
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddReferences(systemReference)
                .AddSyntaxTrees(tree);

            EmitResult compilationResult = compilation.Emit(path);

            if (compilationResult.Success)
            {
                Assembly asm = Assembly.Load(File.ReadAllBytes(path));
                var methodinfo = asm.GetType("RoslynCore.Helper").GetMethod(method.Identifier.ValueText);
                if (methodinfo.IsStatic)
                {
                    return methodinfo.Invoke(null, parameters);
                }
                else
                {
                    var classType = asm.DefinedTypes.FirstOrDefault();
                    var instance = Activator.CreateInstance(classType);
                    try
                    {
                        return methodinfo.Invoke(instance, parameters);
                    }
                    catch (ArgumentException)
                    {
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            parameters[i] = Convert.ToInt32(parameters[i]);
                        }

                        return methodinfo.Invoke(instance, parameters);
                    }  
                }
            }
            else
            {
                Diagnostic codeIssue = compilationResult.Diagnostics.FirstOrDefault();
                string issue = $"ID: {codeIssue.Id}, Message: {codeIssue.GetMessage()},\nLocation: { codeIssue.Location.GetLineSpan()},\nSeverity: { codeIssue.Severity}";
                return issue;
            }
        }
    }
}
