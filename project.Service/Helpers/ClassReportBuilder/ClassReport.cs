using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.Service.Helpers.ClassReportBuilder
{
    //TODO: Store dictonaries here
    public class ClassReport
    {
        public List<string> ValidMethodsByExistence { get; set; } = new List<string>();
        public List<string> ValidMethodsByReturnType { get; set; } = new List<string>();
        public List<string> ValidMethodsByParameters { get; set; } = new List<string>();
        public List<string> ValidMethodsByOutput { get; set; } = new List<string>();

        public List<string> MissingMethods { get; set; } = new List<string>();
        public List<string> MismatchingReturnTypeMethods { get; set; } = new List<string>();
        public List<string> MismatchingOutputMethods { get; set; } = new List<string>();
        public List<string> MismatchingParametersMethods { get; set; } = new List<string>();

        public bool HadCompilationError { get; set; }
       // public List<Tuple<MethodDeclarationSyntax, CompilationResult>> CompiledMethods { get; set; } = new List<Tuple<MethodDeclarationSyntax, CompilationResult>>();
    }
}
