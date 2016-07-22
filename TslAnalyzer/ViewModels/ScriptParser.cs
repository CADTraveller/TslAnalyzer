using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using TslAnalyzer.Model;

namespace TslAnalyzer.ViewModels
{
    public static class ScriptParser
    {

        public static async Task<Script> parseFile(string filePath)
        {
            
            try
            {
                StorageFile lastFile = await StorageFile.GetFileFromPathAsync(filePath);
                return await parseFile(lastFile);

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static async Task<Script> parseFile(StorageFile file)
        {
            try
            {
                Script script = new Script();
                script.Clear();
                char[] delimiterChars = { ' ', ',', '.', ':', '\t', '=', '/', '(', ')', '[', ']', '*', '+', '>', '<', '?', '!' };
                IList<string> allLines = await FileIO.ReadLinesAsync(file);
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
                            if (words.Length > 1) script.Version = words[1];
                        }
                        if (words.Contains("#MinorVersion"))
                        {
                            if (words.Length > 1) script.Version += "." + words[1];
                        }
                    }
                }

                return script;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static async Task<Script> GetNewScriptFromFile()
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".mcr");

            StorageFile scriptFile = await picker.PickSingleFileAsync();
            try
            {
                Script script = new Script();
                script.Clear();
                char[] delimiterChars = { ' ', ',', '.', ':', '\t', '=', '/', '(', ')', '[', ']', '*', '+', '>', '<', '?', '!' };
                IList<string> allLines = await FileIO.ReadLinesAsync(scriptFile);
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
                            if (words.Length > 1) script.Version = words[1];
                        }
                        if (words.Contains("#MinorVersion"))
                        {
                            if (words.Length > 1) script.Version += "." + words[1];
                        }
                    }
                }

                script.Name = scriptFile.DisplayName;

                return script;
            }
            catch (Exception e)
            {
                return null;
            }


            // Script newScript = parseFile(scriptFile)?.Result;
           // return script;
        }
    }
}
