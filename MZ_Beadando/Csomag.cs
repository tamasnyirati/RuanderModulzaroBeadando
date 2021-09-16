using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MZ_Beadando
{
    class Csomag
    {
        public int Szelesseg { get; set; } //cm
        public int Magassag { get; set; } //cm
        public int Melyseg { get; set; } //cm
        public int Suly { get; set; } //g
        public string Csomagfeladoja { get; set; }

        

        public Csomag(int szelesseg, int magassag, int melyseg, int suly, string csomagfeladoja)
        {
            Szelesseg = szelesseg;
            Magassag = magassag;
            Melyseg = melyseg;
            Suly = suly;
            Csomagfeladoja = csomagfeladoja;
        }

       

        public int arSzamitas()
        {
            int ar = (Szelesseg + Magassag + Melyseg) * Suly;
            return ar;
        }

        public override string ToString()
        {
            return $"Szélesség: {Szelesseg}, Magasság: {Magassag}, Mélység: {Melyseg}, Súly: {Suly}";
        }

        public void csomagAdataitCSVbeMent()
        {
            File.WriteAllText("csomaginfo.csv",ToString());
        }
    }
}
