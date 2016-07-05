using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TslAnalyzer.Model
{
    public class Script
    {
        public Script()
        {
            Lines = new List<Line>();
            Variables = new List<Variable>();
            Comments = new List<Line>();
        }
        public List<Line> Lines;
        public List<Variable> Variables;
        public List<Line> Comments;

        //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\
    }
}
