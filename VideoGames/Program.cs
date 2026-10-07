using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VideoGames
{
    internal class Program
    {
        static List<Games> jatekLista = new List<Games>();

        static void Main(string[] args)
        {
            Adatbeolvas();
            //AdatKiir();
            // 1. feladat
            Console.WriteLine("Magas (9-es) értékelésű játékok:");
            jatekLista.Where(x => x.Ertekeles >= 9).ToList().ForEach(x => Console.WriteLine($"{x.Nev,45} - Értékelés: {x.Ertekeles:f2}"));
            Console.ReadKey();
            // 2. feladat
            Console.WriteLine("Nintendo Switch-re 2015 után kiadott játékok minimum 8-as értékeléssel:");
            jatekLista.Where(x=>x.Platform == "Nintendo Switch" && x.Kiadas_eve > 2015 && x.Ertekeles >=8).ToList().ForEach(x => Console.WriteLine($"{x.Nev,45} ({x.Kiadas_eve}) - Értékelése: {x.Ertekeles:f2}"));
            Console.ReadKey();
            // 3. feladat
            Console.WriteLine("Játékok nevei és kiadási éve:");
            jatekLista.OrderByDescending(x => x.Kiadas_eve).ToList().ForEach(x => Console.WriteLine($"{x.Nev,45} ({x.Kiadas_eve})"));
            Console.ReadKey();
            // 4. feladat
            Console.WriteLine("A 10 legjobban értékelt játék:");
            jatekLista.OrderByDescending(x => x.Ertekeles).Take(10).ToList().ForEach(x => Console.WriteLine($"{x.Nev,25} - Értékelés: {x.Ertekeles:f2}"));
            Console.ReadKey();
            // 5. feladat
            Console.WriteLine("Kiadott játékok platformonként:");
            jatekLista.GroupBy(x => x.Platform).Select(x => new { kisbetusplatform = x.Key, jatekdb = x.Count() }).ToList().ForEach(x => Console.WriteLine($"{x.kisbetusplatform,15} - {x.jatekdb} kiadott játék"));
            Console.ReadKey();
            // 6. feladat
            jatekLista.GroupBy(x => x.Tipus).Select(x => new { kisbetustipus = x.Key, tipusdb = x.Count() }).OrderByDescending(x => x.kisbetustipus).Take(1).ToList().ForEach(x => Console.WriteLine($"A legtöbb játék ebbe a típusba sorolható:\n{x.kisbetustipus} - {x.tipusdb} kiadott játék"));
            Console.ReadKey();
            // 7. feladat
            Console.WriteLine($"A játékok átlag értékelése: {jatekLista.Average(x => x.Ertekeles):f2}");
            Console.ReadKey();
            // 8. feladat
            Console.WriteLine("Platformonkénti átlag értékelés:");
            jatekLista.GroupBy(x => x.Platform).Select(x => new { kisbetusplatform = x.Key, atlagertekeles = x.Average(y => y.Ertekeles) }).Take(1).ToList().ForEach(x => Console.WriteLine($"{x.kisbetusplatform} - A platform játékainak átlag értékelése: {x.atlagertekeles:f2}"));
            Console.ReadKey();
            // 9. feladat
            var maxertekeles = jatekLista.Max(x => x.Ertekeles);
            var minertekeles = jatekLista.Min(x => x.Ertekeles);
            jatekLista.Where(x => x.Ertekeles == maxertekeles).ToList().ForEach(x => Console.WriteLine($"A legmagasabb értékelésű játék: {x.Nev} - {x.Ertekeles:f2}"));
            jatekLista.Where(x => x.Ertekeles == minertekeles).ToList().ForEach(x => Console.WriteLine($"A legalacsonyabb értékelésű játék: {x.Nev} - {x.Ertekeles:f2}"));
            Console.ReadKey();
            // 10. feladat
            Console.WriteLine("A listában szereplő típusok:");
            jatekLista.Select(x => x.Tipus).Distinct().ToList().ForEach(x => Console.WriteLine($"{x}"));
            Console.ReadKey();
            // 11. feladat
            Console.WriteLine("Játékok nevei és kiadási éve (megint):");
            jatekLista.Select(x => new { nev = x.Nev, ev = x.Kiadas_eve }).ToList().ForEach(x => Console.WriteLine($"{x.nev,45} ({x.ev})"));
            Console.ReadKey();
            // 12. feladat
            Console.WriteLine("Akció játékok értékelés szerint csökkenő sorrendben:");
            jatekLista.Where(x=>x.Tipus=="Action").OrderByDescending(x => x.Ertekeles).ToList().ForEach(x => Console.WriteLine($"{x.Nev,45} ({x.Kiadas_eve}) - Értékelése: {x.Ertekeles:f2}"));
            Console.ReadKey();
            // 13. feladat
            Console.WriteLine("Típusonkénti átlag értékelés:");
            jatekLista.GroupBy(x => x.Tipus).Select(x => new { kisbetustipus = x.Key, atlagertekeles = x.Average(y => y.Ertekeles) }).ToList().ForEach(x => Console.WriteLine($"{x.kisbetustipus,15} - {x.atlagertekeles:f2}"));
            Console.ReadKey();
            // 14. feladat
            jatekLista.Where(x => x.Kiadas_eve < 2005).ToList().ForEach(x => Console.WriteLine($"{x.Nev,45} - {x.Platform}"));
            Console.ReadKey();
            // 15. feladat
            Console.WriteLine("Platformonként a legmagasabb értékelésű játékok:");
            jatekLista.GroupBy(x => x.Platform).Select(x => new { platform = x.Key, ertekeles = x.OrderByDescending(y => y.Ertekeles).FirstOrDefault() }).ToList().ForEach(x => Console.WriteLine($"{x.platform,15}: {x.ertekeles.Nev,25} - Értékelés: {x.ertekeles.Ertekeles:f2}"));
            Console.ReadKey();
        }

        private static void AdatKiir()
        {
            foreach (var item in jatekLista)
            {
                Console.WriteLine(item.Nev);
            }
        }

        private static void Adatbeolvas()
        {
            try
            {
                jatekLista = File.ReadAllLines("games_dataset.csv").Skip(1).Select(x => x.Split(';')).Select(x => new Games(x[0], x[1], x[2], int.Parse(x[3]), float.Parse(x[4]))).ToList();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
