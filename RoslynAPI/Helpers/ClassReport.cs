using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoslynAPITest.Helpers
{
    //TODO: Store dictonaries here
    class ClassReport
    {
        public List<MethodDeclarationSyntax> ValidMethodsByExistence { get; set; } = new List<MethodDeclarationSyntax>();
        public List<MethodDeclarationSyntax> ValidMethodsByReturnType { get; set; } = new List<MethodDeclarationSyntax>();
        public List<MethodDeclarationSyntax> ValidMethodsByParameters { get; set; } = new List<MethodDeclarationSyntax>();
        public List<MethodDeclarationSyntax> ValidMethodsByOutput { get; set; } = new List<MethodDeclarationSyntax>();

        public List<string> MissingMethods { get; set; } = new List<string>();
        public List<MethodDeclarationSyntax> MismatchingReturnTypeMethods { get; set; } = new List<MethodDeclarationSyntax>();
        public List<MethodDeclarationSyntax> MismatchingParametersMethods { get; set; } = new List<MethodDeclarationSyntax>();
        public Dictionary<MethodDeclarationSyntax, CompilationResult> CompiledMethods { get; set; } = new Dictionary<MethodDeclarationSyntax, CompilationResult>();
    }
}
