using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lift
{
    internal class Program
    {
        struct Lift
        {
            public string idoPont { get; set; }
            public int kartyaSorszam { get; set; }
            public int indulasSzint { get; set; }
            public int celSzint { get; set; }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("2. feladat.");
            string fajlnev = "lift.txt";
            List<Lift> liftAdatok = new List<Lift>();
            liftAdatok =  fajlBeolvasas(fajlnev);
            for(int i = 0; i < liftAdatok.Count; i++)
            {
                Console.WriteLine($"{liftAdatok[i].idoPont} {liftAdatok[i].kartyaSorszam} {liftAdatok[i].indulasSzint} {liftAdatok[i].celSzint}") ;
            }

            Console.Write("3. feladat: ");
            Console.WriteLine($"Az összes lift használat: {liftAdatok.Count}");
            Console.Write("4. feladat: ");
            Console.WriteLine($"Időszak {liftAdatok[0].idoPont} - {liftAdatok[(liftAdatok.Count)-1].idoPont}");
            Console.Write($"5. feladat: ");           
            maxCelSzint(liftAdatok);
            Console.WriteLine("6. feladat: ");
            int kartya_szam = adatbeker("\t Kérem a kártya számát: ");
            int celszint = adatbeker("\t Kérem a szintet: ");
            utazasKeres(liftAdatok, kartya_szam, celszint);
            statisztika(liftAdatok);
            Console.ReadKey();
        }

        private static void statisztika(List<Lift> liftAdatok)
        {
            throw new NotImplementedException();
        }

        private static void utazasKeres(List<Lift> liftAdatok, int kartya_szam, int celszint)
        {
            bool l = false;
            for(int i = 0; i< liftAdatok.Count; i++)
            {
                if (liftAdatok[i].kartyaSorszam == kartya_szam && liftAdatok[i].celSzint == celszint)
                {
                    l = true; 
                }
                
                
            }
            if (l)
            {
                Console.WriteLine($"A(z) {kartya_szam} kártyával utaztak a {celszint}. emeletre");
            }
            else
            {
                Console.WriteLine($"A(z) {kartya_szam} kártyával nem utaztak a {celszint}. emeletre");
            }

            
        }

        private static int adatbeker(string v)
        {
            int szam;
            while (true)
            {
                Console.Write(v);
                try
                {
                    szam = Convert.ToInt32(Console.ReadLine());
                    break;

                }
                catch 
                {

                   szam = 5; break;
                }

            }
            return szam;

        }

        private static void maxCelSzint(List<Lift> liftAdatok)
        {
            
            int max_cel = liftAdatok[0].celSzint;
            for(int i = 0; i< liftAdatok.Count; i++)
            {
                if (liftAdatok[i].celSzint> max_cel)
                {
                    max_cel = liftAdatok[i].celSzint;
                }
            }

            Console.WriteLine($"Célszint max: {max_cel}");
        }

        private static List<Lift> fajlBeolvasas(string fajlnev)
        {
            string sor;
            List<Lift> liftadatok = new List<Lift>();
            StreamReader sr = new StreamReader(fajlnev); 
            while(!sr.EndOfStream)
            {
                Lift liftadat = new Lift();
                sor = sr.ReadLine();
                liftadat.idoPont = sor.Split(' ')[0];
                liftadat.kartyaSorszam =Convert.ToInt32(sor.Split(' ')[1]);
                liftadat.indulasSzint =Convert.ToInt32(sor.Split(' ')[2]);
                liftadat.celSzint = Convert.ToInt32(sor.Split(' ')[3]);
                liftadatok.Add(liftadat);
            }
            
            
            
            
            return liftadatok;
        }
    }
}
