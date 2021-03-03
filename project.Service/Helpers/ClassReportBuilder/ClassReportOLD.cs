using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.Service.Helpers.ClassReportBuilder
{
    //TODO: Store dictonaries here
    public class ClassReportOLD
    {
        public List<MethodDeclarationSyntax> ValidMethodsByExistence { get; set; } = new List<MethodDeclarationSyntax>();
        public List<MethodDeclarationSyntax> ValidMethodsByReturnType { get; set; } = new List<MethodDeclarationSyntax>();
        public List<MethodDeclarationSyntax> ValidMethodsByParameters { get; set; } = new List<MethodDeclarationSyntax>();
        public List<MethodDeclarationSyntax> ValidMethodsByOutput { get; set; } = new List<MethodDeclarationSyntax>();

        public List<string> MissingMethods { get; set; } = new List<string>();
        public List<MethodDeclarationSyntax> MismatchingReturnTypeMethods { get; set; } = new List<MethodDeclarationSyntax>();
        public List<MethodDeclarationSyntax> MismatchingParametersMethods { get; set; } = new List<MethodDeclarationSyntax>();
        public List<Tuple<MethodDeclarationSyntax, CompilationResult>> CompiledMethods { get; set; } = new List<Tuple<MethodDeclarationSyntax, CompilationResult>>();
    }
}
