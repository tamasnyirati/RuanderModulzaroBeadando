using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MZ_Beadando
{
    class Fuvar
    {
        public string FeladoUgyfel { get; set; }
        public string CelCime { get; set; }
        public string FeladasCime { get; set; }
        public string FeladasDatuma { get; set; }
        public string CsomagAdatai { get; set; }
        public bool Prioritas { get; set; }
        public string KivantErkezesiDatum { get; set; }

        public Fuvar(string feladoUgyfel, string celCime, string feladasCime, string feladasDatuma, string csomagAdatai, bool prioritas, string kivantErkezesiDatum) : this(feladoUgyfel, celCime, feladasCime, feladasDatuma, csomagAdatai)
        {
            Prioritas = prioritas;
            KivantErkezesiDatum = kivantErkezesiDatum;
        }


        public Fuvar(string feladoUgyfel, string celCime, string feladasCime, string feladasDatuma, string csomagAdatai)
        {
            FeladoUgyfel = feladoUgyfel;
            CelCime = celCime;
            FeladasCime = feladasCime;
            FeladasDatuma = feladasDatuma;
            CsomagAdatai = csomagAdatai;
        }

        public Fuvar(string feladoUgyfel, string celCime, string feladasCime, string feladasDatuma, string csomagAdatai, bool prioritas) : this(feladoUgyfel, celCime, feladasCime, feladasDatuma, csomagAdatai)
        {
            Prioritas = prioritas;
        }

        public int FuvarAra(Csomag csomag)
        {
            int FuvarAra = csomag.arSzamitas();
            if (FeladasCime == CelCime)
            {
                FuvarAra += FuvarAra + 2000;
            }
            else
            {
                FuvarAra += FuvarAra + 10000;
            }
            return FuvarAra;
        }

        public override string ToString()
        {
            return $"Feladó ügyfél: {FeladoUgyfel}, Cél címe: {CelCime}, Feladás címe: {FeladasCime}, " +
                $"Feladás dátuma: {FeladasDatuma}, Csomag adatai: {CsomagAdatai}";
        }

        public void fuvarAdataitCSVbeMent()
        {
            File.WriteAllText("fuvar.csv", ToString());
        }
    }
}
