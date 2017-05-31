using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Coding
{
    class ForbiddenWords :Form1
    {
        public List<string> wordsNotToUse;
        public ForbiddenWords() {
            wordsNotToUse = new List<string>();
            getTheWords();


        }

        private void getTheWords(){
        wordsNotToUse = File.ReadAllLines("GRUBE.txt").ToList();
        
        }
        public string cenzor(string uncenzoredText) { 
            string finalText="";
        
            foreach (string s in wordsNotToUse) {
                
               

                    string nW = "";
                    nW = s.First().ToString();
                    for (int i = 0; i < s.Length-1; i++)
                    {
                        nW += '*';
                    }

                    uncenzoredText=Regex.Replace( uncenzoredText,s, nW, RegexOptions.IgnoreCase);
                    
                }

            
           
            finalText = uncenzoredText;

            return finalText;
        }
    }
}
