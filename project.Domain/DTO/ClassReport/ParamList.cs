using System;
using System.Collections.Generic;
using System.Text;

namespace project.Domain.DTO.ClassReport
{
    public class ParamList : List<Tuple<string, string>>
    {
        public void Add(string type, string identifier)
        {
            Add(new Tuple<string, string>(type, identifier));
        }
    }
}
