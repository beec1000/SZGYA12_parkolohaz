namespace SZGYA12_parkolohaz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static string F8(List<Emelet> e) => e.MinBy(d => d.Szektorok.Sum()).SzintNev;

            static IEnumerable<Emelet> F9(List<Emelet> e)
            {
                var x = e.Where(d => d.Szektorok.Contains(0));
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

                //Console.WriteLine("9. feladat");
                //if (F9(emeletek) != null)
                //{
                //    Console.WriteLine($"A {}. szinten, a {}. szektorban nincs autó.");
                //}
                //else
                //{
                //    Console.WriteLine("Hiba 404!!! nincs ilyen");
                //}
            }
        }
    }
}
