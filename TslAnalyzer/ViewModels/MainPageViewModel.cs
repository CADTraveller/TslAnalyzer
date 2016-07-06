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
        string getLastScriptPath()
        {
            var appData = Windows.Storage.ApplicationData.Current.LocalSettings;
            var lastPath = appData.Values["lastScriptPath"]?.ToString();
            return lastPath;
        }

        public MainPageViewModel()
        {
            DisplayedLines = new ObservableCollection<Line>();
            SelectedVariables = new ObservableCollection<Variable>();



            var lastScriptPath = getLastScriptPath();


            //if ()
            ////__Try to load last file
            //try
            //{
            //    executeBrowseForFile();
            //    parseFile(lastScriptPath);
            //}
            //catch (Exception e)
            //{
            //    ApplicationData.Current.LocalSettings.Values["lastScriptPath"] = "";
            //    WindowTitle = "No Script Loaded, " + e.Message;
            //}

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
            set { Set(ref currentScript, value); }
        }
        public ObservableCollection<Line> DisplayedLines;
        public ObservableCollection<Variable> SelectedVariables;
        public bool ShowMutated;
        public bool ShowReferenced;

        DelegateCommand _RefreshFromFile;

        public DelegateCommand RefreshFromFile
            => _RefreshFromFile ?? (_RefreshFromFile = new DelegateCommand(ExecuteRefresh, CanRefresh));

        private bool CanRefresh()
        {

            var lastScriptPath = getLastScriptPath();

            if (string.IsNullOrEmpty(lastScriptPath)) return false;

            return File.Exists(lastScriptPath);

        }

        private void ExecuteRefresh()
        {
            StorageFile lastFile = StorageFile.GetFileFromPathAsync(getLastScriptPath()).GetResults();
            parseFile(lastFile);
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

            parseFile(scriptFile);
            ApplicationData.Current.LocalSettings.Values["lastScriptPath"] = scriptFile.Path;
        }

        private async void parseFile(string filePath)
        {
            try
            {
                StorageFile lastFile = await StorageFile.GetFileFromPathAsync(getLastScriptPath());
                parseFile(lastFile);

            }
            catch (Exception e)
            {
                WindowTitle = e.Message;
            }
        }

        private async void parseFile(StorageFile file)
        {
            try
            {
                if (CurrentScript == null) CurrentScript = new Script();
                CurrentScript.Clear();
                char[] delimiterChars = { ' ', ',', '.', ':', '\t', '=', '/', '(', ')', '[', ']', '*', '+', '>', '<', '?', '!' };
                var allLines = await FileIO.ReadLinesAsync(file);
                bool atContents = false;
                foreach (string line in allLines)
                {
                    string[] words = line.Split(delimiterChars);

                    if (words.Length == 0) continue;

                    //__check for end of content section
                    if (words.Length == 1 && words[0] == "#End" && atContents) break;

                    //__check for start of content section
                    if (words.Contains("#BeginContents") && !atContents)
                    {
                        atContents = true;
                        continue;
                    }

                    if (!atContents)//__only interested in version number from header contents
                    {
                        if (words.Contains("#MajorVersion"))
                        {
                            if (words.Length > 1) CurrentScript.Version = words[1];
                        }
                        if (words.Contains("#MinorVersion"))
                        {
                            if (words.Length > 1) CurrentScript.Version += "." + words[1];
                        }
                    }
                }

                WindowTitle = file.Name;
            }
            catch (Exception e)
            {
                WindowTitle = e.Message;
            }
        }



    }
}

