using System;
using System.Collections.Generic;
using System.Text;

namespace project.Domain.Helpers.ClassReportBuilder
{
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
        public bool HadDisallowedOrMissingWords { get; set; }
    }
}
