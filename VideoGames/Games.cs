using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGames
{
    internal class Games
    {
        public Games(string nev, string tipus, string platform, int kiadas_eve, float ertekeles)
        {
            Nev = nev;
            Tipus = tipus;
            Platform = platform;
            Kiadas_eve = kiadas_eve;
            Ertekeles = ertekeles;
        }

        public string Nev { get; set; }
        public string Tipus { get; set; }
        public string Platform { get; set; }
        public int Kiadas_eve { get; set; }
        public float Ertekeles { get; set; }
    }
}
