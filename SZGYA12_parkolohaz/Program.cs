namespace SZGYA12_parkolohaz
{
    internal class Program
    {
        static string F8(List<Emelet> e) => e.MinBy(d => d.Szektorok.Sum()).SzintNev;

        static Emelet F9(List<Emelet> e)
        {
            var x = e.First(d => d.Szektorok.Contains(0));
            return x;
        }

        static double F10(List<Emelet> e, double ave)
        {
            var x = e.Average(d => d.Szektorok.Average()).ToList();
            foreach(var i in x)
            {
                if()
            }
            return x;
        }

        static void Main(string[] args)
        {
            List<Emelet> emeletek = new List<Emelet>();
            var sr = new StreamReader(@"..\..\..\src\parkolohaz.txt");
            for (int i = 1; !sr.EndOfStream; i++)
            {
                emeletek.Add(new Emelet(i, sr.ReadLine()));
            }

            foreach (var i in emeletek)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("8. feladat");
            Console.WriteLine($"A legkevesebb autó a {F8(emeletek)} szinten van.");

            Console.WriteLine("9. feladat");
            var f9 = F9(emeletek).Szektorok.Select((v, i) => new { v, i }).First(sz => sz.v == 0).i;
            if (F9(emeletek) != null)
            {
                Console.WriteLine($"A {F9(emeletek).Szint}. szinten, a {f9}. szektorban nincs autó.");
            }
            else
            {
                Console.WriteLine("Hiba 404!!! nincs ilyen");
            }

            Console.WriteLine("10. feladat");
            var ave = emeletek.Average(d => d.Szektorok.Average());
            Console.WriteLine(F10(emeletek, ave));

        }
    }
}
