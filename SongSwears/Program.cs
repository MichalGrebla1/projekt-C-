using System;
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
            var EminemSwearStats = new SwearStats();
           var song = new Song("Eminem", "Rap god");
            EminemSwearStats.AddSwearsFrom(song);
           
            var censor = new Censor();
            Console.WriteLine(censor.Fix(song.lyric));

            Console.ReadLine();
        }
    }

     class SwearStats : Censor
    {
        Dictionary<string, int> przeklenstwa = new Dictionary<string, int>();
        public SwearStats()
        {
            
        }

        public void AddSwearsFrom(Song song)
        {
            foreach (var badwords in badwords)
            {
                song.CountOccurences(badwords);
            }
        }
    }
}
