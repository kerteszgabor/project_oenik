using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kertesz_projekt_oenik.Models
{
    public class ProgrammingQuestion : Test
    {
        public int OptimalNumberOfLines { get; set; }

        public int ReferenceComplexityLevel { get; set; }

        public TimeSpan ReferenceRuntime { get; set; }

        public string ExpectedOutput { get; set; }
    }
}
