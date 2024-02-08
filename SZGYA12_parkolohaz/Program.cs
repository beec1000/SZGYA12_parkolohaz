namespace SZGYA12_parkolohaz
{
    internal class Program
    {
        static string F8(List<Emelet> e) => e.MinBy(d => d.Szektorok.Sum()).SzintNev;

        static Emelet F9(List<Emelet> e) => e.First(d => d.Szektorok.Contains(0));

        static double F10(List<Emelet> e) => e.SelectMany(d => d.Szektorok).Average();

        static Emelet F12(List<Emelet> e) => e.First(d => d.Szektorok.Sum() == e.Max(dd => dd.Szektorok.Sum()));

        static int F14(List<Emelet> e) => e.SelectMany(e => e.Szektorok).Count(d => d == 0);

        static void Main(string[] args)
        {
            List<Emelet> emeletek = new List<Emelet>();
            using var sr = new StreamReader(@"..\..\..\src\parkolohaz.txt");
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
            double atlagAlatti = emeletek.SelectMany(d => d.Szektorok).Count(dd => dd < F10(emeletek));
            double atlagFolotti = emeletek.SelectMany(d => d.Szektorok).Count(dd => dd > F10(emeletek));
            Console.WriteLine($"Átlag: {F10(emeletek)} \nÁtlag alatti: {atlagAlatti} \nÁtlag fölötti: {atlagFolotti}");

            //11. feladat
            var sw = new StreamWriter(@"..\..\..\src\parkolohazF11.txt");
            sw.WriteLine("Emelet neve - Szektor sorszáma");
            foreach (var e in emeletek)
            {
                for (int i = 0; i < e.Szektorok.Count; i++)
                {
                    if (e.Szektorok[i] == 1)
                    {
                        sw.WriteLine($"{e.SzintNev, 11} - {i + 1, 1}.");
                    }
                }
            }

            Console.WriteLine("12. feladat");
            if (F12(emeletek).Szint == emeletek.Count)
            {
                Console.WriteLine("A legfelső emeleten van a legtöbb autó.");
            }
            else
            {
                Console.WriteLine($"A legtöbb autó a {F12(emeletek).SzintNev} szinten van.");
            }

            //13. feladat
            sw.WriteLine();
            sw.WriteLine($"13. FELADAT");
            foreach (var i in emeletek)
            {
                sw.WriteLine($"{i.Szint, 2}. szint: {i.Szektorok.Count(d => d == 0)} szabad hely");
            }
            sw.Close();

            Console.WriteLine("14. feladat");
            Console.WriteLine($"Összesen {F14(emeletek)} üres parkolóhely van.");

        }
    }
}
