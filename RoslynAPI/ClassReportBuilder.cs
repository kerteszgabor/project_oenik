using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Emit;
using RoslynAPITest.Exceptions;
using RoslynAPITest.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace RoslynAPITest
{
    class ClassReportBuilder : ICanCallBuild, ICanRequireCompilation, ICanCompile
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
        private SyntaxTree tree;
        private List<string> methodsNotFound;
        private List<MethodDeclarationSyntax> methods;
        private List<MethodDeclarationSyntax> methodsToAnalyze;
        private MethodModel lastMethod;
        private Dictionary<MethodDeclarationSyntax, MethodModel> methodPairs;
        private ConcurrentBag<object> compilationResults;

        // TODO: Move code string resource to somewhere else
        private ClassReportBuilder(string codeToAnalyze)
        {
            this.CodeAsString = codeToAnalyze;
            BuildAssets();
            this.methodsNotFound = new List<string>();
            this.methodsToAnalyze = new List<MethodDeclarationSyntax>();
            this.methodPairs = new Dictionary<MethodDeclarationSyntax, MethodModel>();
            this.compilationResults = new ConcurrentBag<object>();
        }

        public static ICanCallBuild GetReportOf(string codeToAnalyze)
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

        private MethodDeclarationSyntax FindMethod(string identifier)
        {
            var method = methods.FirstOrDefault(x => x.Identifier.ToString() == identifier);
            if (method != null)
            {
                return method;
            }
            else
            {
                throw new MethodNotFoundException();
            }
        }

        public ICanRequireCompilation WithMethod(string methodName)
        {
            try
            {
                var method = FindMethod(methodName);
                MethodModel model = new MethodModel()
                {
                    MethodName = methodName
                };
                methodPairs.Add(method, model);
                lastMethod = model;
                return this;
            }
            catch (MethodNotFoundException)
            {
                methodsNotFound.Add(methodName);
                return this;
            }
        }

        public ICanRequireCompilation WithMethod(string methodName, ParamList expectedParameters)
        {
            try
            {
                var method = FindMethod(methodName);
                MethodModel model = new MethodModel()
                {
                    MethodName = methodName,
                    ExpectedParameters = expectedParameters
                };
                methodPairs.Add(method, model);
                lastMethod = model;
                return this;
            }
            catch (MethodNotFoundException)
            {
                methodsNotFound.Add(methodName);
                return this;
            }
        }
        public ICanRequireCompilation WithMethod(string methodName, Type expectedReturnType)
        {
            try
            {
                var method = FindMethod(methodName);
                MethodModel model = new MethodModel()
                {
                    MethodName = methodName,
                    ExpectedReturnType = expectedReturnType
                };
                methodPairs.Add(method, model);
                lastMethod = model;
                return this;
            }
            catch (MethodNotFoundException)
            {
                methodsNotFound.Add(methodName);
                return this;
            }
        }

        public ICanRequireCompilation WithMethod(string methodName, ParamList expectedParameters, Type expectedReturnType)
        {
            try
            {
                var method = FindMethod(methodName);
                MethodModel model = new MethodModel()
                {
                    MethodName = methodName,
                    ExpectedParameters = expectedParameters,
                    ExpectedReturnType = expectedReturnType
                };
                methodPairs.Add(method, model);
                lastMethod = model;
                return this;
            }
            catch (MethodNotFoundException)
            {
                methodsNotFound.Add(methodName);
                return this;
            }
        }

        public ICanCompile AlsoCompile()
        {
            lastMethod.ToBeCompiled = true;
            return this;
        }

        public ICanCompile WithParameters(object[] parameters)
        {
            lastMethod.CompilationParameters = parameters;
            return this;
        }

        public ICanCompile SetExpectedStringOutput(string expectedStringOutput)
        {
            lastMethod.ExpectedStringOutput = expectedStringOutput;
            return this;
        }

        public ICanCompile SetExpectedValue(object expectedOutput)
        {
            lastMethod.ExpectedOutput = expectedOutput;
            return this;
        }

        public ClassReport Build()
        {
            var classReport = new ClassReport();
            ValidateReturnTypes(classReport);
            ValidateParameterTypes(classReport);
            ValidateMethodsExisting(classReport);

            var methodsToCompile = from m in methodPairs
                                   where m.Value.ToBeCompiled
                                   select m.Key;

            Parallel.ForEach(methodsToCompile, (method) =>
            {
                compilationResults.Add(CompileMethod(method, methodPairs[method].CompilationParameters));
            });

            ;

            return classReport;
        }

        private ClassReport ValidateReturnTypes(ClassReport report)
        {
            foreach (var method in methodPairs.Keys)
            {
                var methodModel = methodPairs[method];
                if (methodModel.ExpectedReturnType != null)
                {
                    if (method.ReturnType.ToString().ToLower() == methodModel.ExpectedReturnType?.Name.ToLower())
                    {
                        report.ValidMethodsByReturnType.Add(method);
                    }
                    else
                    {
                        report.MismatchingReturnTypeMethods.Add(method);
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
                if (methodModel.ExpectedParameters != null)
                {
                    var parameters = method.ParameterList.Parameters;
                    var expectedParameters = methodPairs[method].ExpectedParameters;

                    var areMatching = parameters
                    .SelectMany(x => new ParamList { { x.Type.ToString(), x.Identifier.ToString() } })
                    .Intersect(expectedParameters)
                    .Count() == parameters.Count;

                    if (areMatching)
                    {
                        report.ValidMethodsByParameters.Add(method);
                    }
                    else
                    {
                        report.MismatchingParametersMethods.Add(method);
                    }
                }
            }
            return report;
        }

        private void ValidateMethodsExisting(ClassReport report)
        {
            report.MissingMethods = methodsNotFound;
            report.ValidMethodsByExistence = methodPairs.Keys.ToList();
        }

        private object CompileMethod(MethodDeclarationSyntax method, object[] parameters)
        {
            string fileName = method.Identifier.ToString();
            // Detect the file location for the library that defines the object type
            var systemRefLocation = typeof(object).GetTypeInfo().Assembly.Location;
            // Create a reference to the library
            var systemReference = MetadataReference.CreateFromFile(systemRefLocation);
            // A single, immutable invocation to the compiler
            // to produce a library
            var compilation = CSharpCompilation.Create(fileName)
              .WithOptions(
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
              .AddReferences(systemReference)
              .AddSyntaxTrees(tree);
            string path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            EmitResult compilationResult = compilation.Emit(path);
            if (compilationResult.Success)
            {
                // Load the assembly
                Assembly asm =
                  AssemblyLoadContext.Default.LoadFromAssemblyPath(path);
                var methodinfo = asm.GetType("RoslynCore.Helper").GetMethod(method.Identifier.ValueText);
                if (methodinfo.IsStatic)
                {
                    return methodinfo.Invoke(null, parameters);
                }
                else
                {
                    Assembly assembly = Assembly.LoadFrom(fileName);
                    var classType = assembly.DefinedTypes.FirstOrDefault();
                    var instance = Activator.CreateInstance(classType);
                    return methodinfo.Invoke(instance, parameters);
                }
            }
            else
            {
                foreach (Diagnostic codeIssue in compilationResult.Diagnostics)
                {
                    string issue = $"ID: {codeIssue.Id}, Message: {codeIssue.GetMessage()},\nLocation: { codeIssue.Location.GetLineSpan()},\nSeverity: { codeIssue.Severity}";
                    Console.WriteLine(issue);

                    //TODO: On compilation error, write error message to methodModel, remove current method from compilation list, and recompile
                }
            }
            return null;
        }
    }
}
