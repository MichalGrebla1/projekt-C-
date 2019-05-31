using Newtonsoft.Json;
using System;
using System.Net;
using System.Text.RegularExpressions;

namespace SongSwears
{
    internal class Song
    
      
    
        
    {
        public string title;
        public string artist;
        public string lyric;

        public Song(string band, string songName)
        {
            var browser = new WebClient();
            string url = "https://api.lyrics.ovh/v1/"+band+"/"+songName;
            var json = browser.DownloadString(url);
            var lyricsData = JsonConvert.DeserializeObject<LyricsovhResponse>(json);
            title = songName;
            artist = band;
            lyric = lyricsData.lyrics;
        }

        public int CountOccurences(string word)
        {
            var pattern = "\\b" + word + "\\b";
           return Regex.Match(lyric, pattern, RegexOptions.IgnoreCase).Length;
        }
    }
}