using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SongSwears
{
   public class Censor
    {
       protected string[] badwords;
        public Censor()
        {
            var profanitiesfile = File.ReadAllText("profanities.txt");
            profanitiesfile = profanitiesfile.Replace("*", "");
            profanitiesfile = profanitiesfile.Replace(")", "");
            profanitiesfile = profanitiesfile.Replace("(", "");
            profanitiesfile = profanitiesfile.Replace("\"", "");
            badwords = profanitiesfile.Split(',');

           
                
        }

        public string Fix(string text)
        {
            foreach(var word in badwords)
            {
                text = RemoveBadWord(text, word);
            }
            return text;
        }

        private string RemoveBadWord(string text, string word)
        {
            var pattern = "\\b" + word + "\\b";
            return Regex.Replace(text, pattern, "* * *", RegexOptions.IgnoreCase);
        }
    }
    
}