using System;
using SearchingCurses;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongSwears
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //var EminemSwearStats = new SwearStats();

            var EminemSwearStats = new RapperSwearStats("eminem");
            EminemSwearStats.AddSong("Billy");
            EminemSwearStats.AddSong("Lose Yourself");
            EminemSwearStats.AddSong("Without me");
            EminemSwearStats.AddSong("Fall");
          //  EminemSwearStats.AddSwearsFrom(song);
           
            var twopacstats = new RapperSwearStats ("2pac");
            twopacstats.AddSong("Changes");
            twopacstats.AddSong("Hail mary");
            var rapper = new List<RapperSwearStats>();
            rapper.Add(EminemSwearStats);
            rapper.Add(twopacstats);
           
            var unknownsong = new Song("Eminem", "Monster");
            var tinder = new RapperTinder(rapper, unknownsong);
          //  var censor = new Censor();
            //Console.WriteLine(censor.Fix(song.lyric));

            Console.ReadLine();
         
           // Console.WriteLine(WebCache.GetOrDownload("https://wtfismyip.com/text"));
               // Console.ReadKey();
        }
    }
   public class RapperTinder
    {
        private List<RapperSwearStats> rappers;
        private Song unknowsong;
        public RapperTinder(List<RapperSwearStats> rappers, Song unknowsong)
        {
            this.rappers = rappers;
            this.unknowsong = unknowsong;
            var songSwearStats = new SwearStats();
            songSwearStats.AddSwearsFrom(unknowsong);
            foreach(var rapper in rappers)
            {
                var score = rapper.CompareWith(songSwearStats);
                Console.WriteLine(rapper.name + ":" + score + "points");
            }
        }
    }
    public class RapperSwearStats: SwearStats
    {
        public string name;
        public RapperSwearStats(string name)
        {
           this.name = name;
        }
       public void AddSong(string tittle)
        {
            var song = new Song(name, tittle);
            AddSwearsFrom(song);
        }
    }

    public class SwearStats : Censor
    {
        Dictionary<string, int> przeklenstwa = new Dictionary<string, int>();
        public SwearStats()
        {
            
        }

        public void AddSwearsFrom(Song song)
        {
            foreach (var word in badwords)
            {
                var occurences = song.CountOccurences(word);
                var occurrances = song.CountOccurences(word);
                if (occurences > 0)
                {
                 if (!przeklenstwa.ContainsKey(word))
                                    przeklenstwa[word] = 0;
                                przeklenstwa[word] += occurences;
                }
               
            }
          
        }

        public void ShowSummery()
        {
            foreach (var word in przeklenstwa) 
            Console.WriteLine(word.Key + "" + word.Value);
        }

        public int CompareWith(SwearStats eminemSwearStats)
        {
            int score=0;
            foreach (var myword in przeklenstwa)
            {
                  if (eminemSwearStats.przeklenstwa.ContainsKey(myword.Key))
                            score++;
                Console.WriteLine(myword.Key);
                        
            }
          return score;
        }
        
    }
}
