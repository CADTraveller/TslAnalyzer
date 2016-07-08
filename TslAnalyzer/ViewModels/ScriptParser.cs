using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using TslAnalyzer.Model;
using System.Collections.ObjectModel;

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
                
                char[] delimiterChars = { ' ', ',', '.', ':', '\t', '=', '/', '(', ')', '[', ']', '*', '+', '>', '<', '?', '!' };
                System.Collections.Generic.IList<string> allLines = await FileIO.ReadLinesAsync(file);
                allLines.breakLinesAtSemicolons();
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

                    //__now done with header section, extract Variables & lines
                }

                return script;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private static void breakLinesAtSemicolons(this IList<string> lines)
        {
            List<string> newList = new List<string>();

            foreach (string line in lines)
            {
                string newLine = "";
                List<char> letters = line.ToList<char>();
                for (int i = 0; i < letters.Count; i++)
                {
                    char c = letters[i];
                    if (c == ':')
                    {
                        //__might be escaped in a string literal
                        if (i > 1 && letters[i - 1] == '\')
                    }
                }
            }

            lines = newList;
        }
    }
}
