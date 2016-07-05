using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TslAnalyzer.Model
{
    public class Variable
    {
        public Variable(string type, string name)
        {
            Type = type;
            Name = name;
            Mutated = new List<Line>();
            Referenced = new List<Line>();
        }

        public string Type;
        public string Name;

        public List<Line> Mutated;
        public List<Line> Referenced;

        public override string ToString()
        {
            return Type + "." + Name;
        }
    }
}
