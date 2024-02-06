using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZGYA12_parkolohaz
{
    internal class Emelet
    {
        public int Szint { get; set; }
        public string SzintNev { get; set; }
        public List<int> Szektorok { get; set; }

        public Emelet(int n, string s)
        {
            string[] v = s.Split("; ");
            Szint = n;
            SzintNev = v[0];
            Szektorok = new List<int>();
            for (int i = 1; i < v.Length; i++)
            {
                Szektorok.Add(int.Parse(v[i]));
            }

        }

        public override string ToString()
        {
            return $"{Szint, 2}. szint | {SzintNev, 8}: {string.Join("; ", Szektorok)}";
        }
    }
}
