using System;
using System.Collections.Generic;
using System.Text;

namespace project.Domain.DTO.ClassReport
{
    public class MyTuple : Tuple<string, string>
    {
        public MyTuple(string item1, string item2) : base(item1, item2)
        {
        }

        public MyTuple() : base(String.Empty, String.Empty)
        {

        }
    }
    public class ParamList : List<MyTuple>
    {
        public void Add(string type, string identifier)
        {
            Add(new MyTuple(type, identifier));
        }
    }
}
