using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MZ_Beadando
{
    class Ugyfel
    {
        public string nev { get; set; }
        public bool CegesUgyfel { get; set; }

        public Ugyfel(string nev, bool cegesUgyfel)
        {
            this.nev = nev;
            CegesUgyfel = cegesUgyfel;
        }

        public override string ToString()
        {
            return $"Név: {nev}, Céges ügyfél: {CegesUgyfel}";
        }

        public void ugyfelAdataitCSVbeMent()
        {
            File.WriteAllText("ugyfel.csv", ToString());
        }
    }
}
