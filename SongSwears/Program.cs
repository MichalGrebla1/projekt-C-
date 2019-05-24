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
            //var songAnalysis = new SongAnalysis("Kazik", "12 groszy");
            var text = "programowanie jest w chuj fajne";
            var censor = new Censor();
            Console.WriteLine(censor.Fix(text));

            Console.ReadLine();
        }
    }
}
