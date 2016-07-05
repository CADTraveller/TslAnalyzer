using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using TslAnalyzer.Model;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

namespace TslAnalyzer.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel()
        {
            DisplayedLines = new ObservableCollection<Line> ();
            SelectedVariables = new ObservableCollection<Variable>();

            var appData = Windows.Storage.ApplicationData.Current.LocalSettings;
            var lastScriptPath = appData.Values["lastScriptPath"].ToString();
            bool foundLastFile = false;
            if (string.IsNullOrEmpty(lastScriptPath))
            {
                //__browse for file and set current
            }
            else
            {
                //__Try to load last file
            }
        }
        public Script CurrentScript;
        public ObservableCollection<Line> DisplayedLines;
        public ObservableCollection<Variable> SelectedVariables;
        public bool ShowMutated;
        public bool ShowReferenced;
    }
}

