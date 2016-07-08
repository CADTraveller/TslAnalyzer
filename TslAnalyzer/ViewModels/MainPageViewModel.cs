using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using TslAnalyzer.Model;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using System.IO;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace TslAnalyzer.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        public MainPageViewModel()
        {
            DisplayedLines = new ObservableCollection<Line>();
            SelectedVariables = new ObservableCollection<Variable>();



            var lastScriptPath = getLastScriptPath();


        }

        string getLastScriptPath()
        {
            var appData = Windows.Storage.ApplicationData.Current.LocalSettings;
            var lastPath = appData.Values["lastScriptPath"]?.ToString();
            return lastPath;
        }

        private string windowTitle = "No File Loaded";
        public string WindowTitle
        {
            get { return windowTitle; }
            set { Set(ref windowTitle, value); }
        }

        private Script currentScript;
        public Script CurrentScript
        {
            get { return currentScript; }
            set
            {
                Set(ref currentScript, value);
                Variables = CurrentScript.Variables;
            }
        }

        private ObservableCollection<Variable> variables;
        public ObservableCollection<Variable> Variables
        {
            get { return variables; }
            set { Set(ref variables, value); }
        }
        public ObservableCollection<Variable> SelectedVariables;

        private ObservableCollection<Line> displayedLines;

        public ObservableCollection<Line> DisplayedLines
        {
            get { return displayedLines; }
            set { Set(ref displayedLines, value); }
        }

        private bool showMutated;
        public bool ShowMutated
        {
            get { return showMutated; }
            set { Set(ref showMutated, value); }
        }


        private bool showReferenced;
        public bool ShowReferenced
        {
            get { return showReferenced; }
            set { Set(ref showReferenced, value); }
        }



        DelegateCommand _refreshFromFile;
        public DelegateCommand RefreshFromFile
            => _refreshFromFile ?? (_refreshFromFile = new DelegateCommand(ExecuteRefresh, CanRefresh));

        private bool CanRefresh()
        {

            var lastScriptPath = getLastScriptPath();

            if (string.IsNullOrEmpty(lastScriptPath)) return false;

            return File.Exists(lastScriptPath);

        }

        private void ExecuteRefresh()
        {
            StorageFile lastFile = StorageFile.GetFileFromPathAsync(getLastScriptPath()).GetResults();
            CurrentScript = ScriptParser.parseFile(lastFile).Result;
        }

        DelegateCommand _browseForFileCommand;

        public DelegateCommand BrowseForFileCommand
            => _browseForFileCommand ?? (new DelegateCommand(executeBrowseForFile));



        private async void executeBrowseForFile()
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".mcr");

            StorageFile scriptFile = await picker.PickSingleFileAsync();

            if (scriptFile == null) return;

            CurrentScript = ScriptParser.parseFile(scriptFile).Result;
            ApplicationData.Current.LocalSettings.Values["lastScriptPath"] = scriptFile.Path;
        }





    }
}

