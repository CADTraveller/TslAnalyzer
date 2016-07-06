using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;

namespace TslAnalyzer.Model
{
    public class Script : BindableBase
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
        public string Version;

        public void Clear()
        {
            Lines.Clear();
            Variables.Clear();
            Comments.Clear();
        }

        //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\
    }
}
