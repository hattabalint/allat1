using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allat
{

    public class Allat
    {
        private string nev;
        private int szuletesiEv;
        private int szepsegPont;
        private int viselkedesPont;
        private double vegsoPontszam;

        public static int AktualisEv { get; set; }
        public static int MaxKor { get; set; }

        public Allat(string nev, int szuletesiEv)
        {
            this.nev = nev;
            this.szuletesiEv = szuletesiEv;
        }

        public string Nev => nev;
        public int SzuletesiEv => szuletesiEv;
        public int SzepsegPont => szepsegPont;
        public int ViselkedesPont => viselkedesPont;
        public double VegsoPontszam => vegsoPontszam;

        public int Kor()
        {
            return AktualisEv - szuletesiEv;
        }

        public void Pontozzak(int szepsegPont, int viselkedesPont)
        {
            this.szepsegPont = szepsegPont;
            this.viselkedesPont = viselkedesPont;

            int kor = Kor();

            if (kor > MaxKor)
            {
                vegsoPontszam = 0;
            }
            else
            {
                vegsoPontszam = ((MaxKor - kor) * szepsegPont) + (kor * viselkedesPont);
            }
        }

        public override string ToString()
        {
            return $"Név: {nev}, Pontszám: {vegsoPontszam:F2}";
        }
    }

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Adja meg az aktuális évet:");
            Allat.AktualisEv = int.Parse(Console.ReadLine());

            Console.WriteLine("Adja meg a maximális korhatárt:");
            Allat.MaxKor = int.Parse(Console.ReadLine());

            List<Allat> allatok = new List<Allat>();
            Random random = new Random();

            while (true)
            {
                Console.WriteLine("Adja meg az állat nevét (vagy nyomja meg az Entert a verseny befejezéséhez):");
                string nev = Console.ReadLine();

                if (string.IsNullOrEmpty(nev))
                {
                    break;
                }

                Console.WriteLine("Adja meg az állat születési évét:");
                int szuletesiEv = int.Parse(Console.ReadLine());

                Allat allat = new Allat(nev, szuletesiEv);

                int szepsegPont = random.Next(1, 11);
                int viselkedesPont = random.Next(1, 11);

                allat.Pontozzak(szepsegPont, viselkedesPont);

                Console.WriteLine(allat.ToString());

                allatok.Add(allat);
            }

            if (allatok.Count > 0)
            {
                double atlagPontszam = 0;
                double legnagyobbPontszam = 0;

                foreach (var allat in allatok)
                {
                    atlagPontszam += allat.VegsoPontszam;
                    if (allat.VegsoPontszam > legnagyobbPontszam)
                    {
                        legnagyobbPontszam = allat.VegsoPontszam;
                    }
                }

                atlagPontszam /= allatok.Count;

                Console.WriteLine($"Versenyző állatok száma: {allatok.Count}");
                Console.WriteLine($"Átlagos pontszám: {atlagPontszam:F2}");
                Console.WriteLine($"Legnagyobb pontszám: {legnagyobbPontszam:F2}");
            }
            else
            {
                Console.WriteLine("Nem voltak versenyző állatok.");
            }
        }
    }
}