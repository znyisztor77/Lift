using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                Console.WriteLine($"{liftAdatok[i].idoPont}, {liftAdatok[i].kartyaSorszam}, {liftAdatok[i].indulasSzint}, {liftAdatok[1].celSzint}") ;
            }


            Console.ReadKey();
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
            
            
            
            sr.ReadToEnd();
            return liftadatok;
        }
    }
}
