using System;
using System.Collections.Generic;
using System.Text;

namespace RoslynAPITest.Helpers
{
    class CompilationResult
    {
        public string Output { get; set; }
        public TimeSpan CompilationTime { get; set; }
        public int NumberOfLines { get; set; }

        public override string ToString()
        {
            return $"Results:\n*******\n{Output}\n\nCompilation time: {CompilationTime}\nNumber of lines: {NumberOfLines}";
        }
    }
}
