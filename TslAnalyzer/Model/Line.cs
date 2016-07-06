using Windows.UI.Xaml.Controls;
using Template10.Mvvm;

namespace TslAnalyzer.Model
{
    public class Line :BindableBase
    {
        private int location;

        public int Location
        {
            get { return location; }
            set { Set(ref location, value ); }
        }


        private string  content;

        public string  Content
        {
            get { return content; }
            set { Set(ref content, value); }
        }

        
    }
}
