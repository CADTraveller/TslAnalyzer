using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            Lines = new ObservableCollection<Line>();
            Variables = new ObservableCollection<Variable>();
            Comments = new ObservableCollection<string>();
        }


        private ObservableCollection<Line> lines;

        public ObservableCollection<Line> Lines
        {
            get { return lines; }
            set { Set(ref lines, value); }
        }


        private ObservableCollection<Variable> variables;
        public ObservableCollection<Variable> Variables
        {
            get { return variables; }
            set { Set(ref variables, value); }
        }


        private ObservableCollection<string> comments;
        public ObservableCollection<string> Comments
        {
            get { return comments; }
            set { Set(ref comments, value); }
        }

        private string version = "V1.0";

        public string Version
        {
            get { return version; }
            set { Set(ref version, value); }
        }

        public void Clear()
        {
            Lines.Clear();
            Variables.Clear();
            Comments.Clear();
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { Set(ref name, value); }
        }

        //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\
    }
}
