using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Emit;
using RoslynAPITest.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace RoslynAPITest
{
    class Program
    {
        static void Main(string[] args)
        {
            string CODE_RESOURCE = @"using System;
using System.IO;
namespace RoslynCore
{
 public class Helper
 {
  public static double CalculateCircleArea(double radius)
  {
    return Math.Round(radius * radius * Math.PI, 2);
  }
    public string Greet(string myName)
     {
            return @$""Hello, {myName}!"";
    }
  }
}";
            var classReport = ClassReportBuilder
                .GetReportOf(CODE_RESOURCE)
                .WithMethod("CalculateCircleArea", new ParamList { { "double", "radius" } })
                    .AlsoCompile()
                        .WithParameters(new object[] {5})
                        .SetExpectedValue(78.54)
                .WithMethod("Greet", new ParamList { {"string", "myName" } }, typeof(string))
                    .AlsoCompile()
                        .WithParameters(new object[] { "Gábor"})
                        .SetExpectedStringOutput("Hello, Gábor!")
                .Build();

            Console.ReadLine();
        }

        public static void GenerateAssembly()
        {
            const string code = @"using System;
using System.IO;
namespace RoslynCore
{
 public static class Helper
 {
  public static double CalculateCircleArea(double radius)
  {
    return radius * radius * Math.PI;
  }
  }
}";
            var tree = SyntaxFactory.ParseSyntaxTree(code);
            string fileName = "mylib.dll";
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
                // Invoke the RoslynCore.Helper.CalculateCircleArea method passing an argument
                double radius = 10;
                object result =
                  asm.GetType("RoslynCore.Helper").GetMethod("CalculateCircleArea").
                  Invoke(null, new object[] { radius });
                Console.WriteLine($"Circle area with radius = {radius} is {result}");
            }
            else
            {
                foreach (Diagnostic codeIssue in compilationResult.Diagnostics)
                {
                    string issue = $"ID: {codeIssue.Id}, Message: {codeIssue.GetMessage()},\nLocation: { codeIssue.Location.GetLineSpan()},\nSeverity: { codeIssue.Severity}";
                  Console.WriteLine(issue);
                }
            }
        }
    }
}
