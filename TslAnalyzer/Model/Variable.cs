using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;

namespace TslAnalyzer.Model
{
    public class Variable : BindableBase
    {
        public Variable(string type, string name)
        {
            Type = type;
            Name = name;
            Mutated = new ObservableCollection<Line>();
            Referenced = new ObservableCollection<Line>();
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { Set(ref type, value); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { Set(ref name, value); }
        }

        private ObservableCollection<Line> mutated;

        public ObservableCollection<Line> Mutated
        {
            get { return mutated; }
            set { Set(ref mutated, value); }
        }

        private ObservableCollection<Line> referenced;

        public ObservableCollection<Line> Referenced
        {
            get { return referenced; }
            set { Set(ref referenced, value); }
        }

        public override string ToString()
        {
            return Type + "." + Name;
        }
    }
}
