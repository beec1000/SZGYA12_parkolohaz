namespace SZGYA12_parkolohaz
{
    internal class Program
    {
        static string F8(List<Emelet> e) => e.MinBy(d => d.Szektorok.Sum()).SzintNev;

        static IEnumerable<Emelet> F9(List<Emelet> e) => e.Where(d => d.Szektorok.Contains(0));

        static double F10(List<Emelet> e) => e.SelectMany(d => d.Szektorok).Average();

        static Emelet F12(List<Emelet> e) => e.MaxBy(d => d.Szektorok.Sum());

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
            foreach (var i in F9(emeletek))
            {
                var f9 = i.Szektorok.Select((v, i) => new { v, i }).First(sz => sz.v == 0).i + 1;
                if (i != null)
                {
                    Console.WriteLine($"A {i.Szint}. szinten, a(z) {f9}. szektorban nincs autó.");
                }
                else
                {
                    Console.WriteLine("Hiba 404!!! nincs ilyen");
                }

            }

            Console.WriteLine("10. feladat");
            double atlagos = emeletek.SelectMany(d => d.Szektorok).Count(dd => dd == F10(emeletek));
            double atlagAlatti = emeletek.SelectMany(d => d.Szektorok).Count(dd => dd < F10(emeletek));
            double atlagFolotti = emeletek.SelectMany(d => d.Szektorok).Count(dd => dd > F10(emeletek));
            Console.WriteLine($"Átlag: {Math.Round(F10(emeletek), 2)} \nÁtlagos: {atlagos} \nÁtlag alatti: {atlagAlatti} \nÁtlag fölötti: {atlagFolotti}");

            //11. feladat
            var sw = new StreamWriter(@"..\..\..\src\ujParkolohaz.txt");
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
            if (F12(emeletek).Szint == 1)
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
