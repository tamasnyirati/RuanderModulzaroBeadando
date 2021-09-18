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
        public int FuvarAra { get; set; }

        public Fuvar(string feladoUgyfel, string celCime, string feladasCime, string feladasDatuma, string csomagAdatai, bool prioritas, string kivantErkezesiDatum, int fuvarAra)
        {
            FeladoUgyfel = feladoUgyfel;
            CelCime = celCime;
            FeladasCime = feladasCime;
            FeladasDatuma = feladasDatuma;
            CsomagAdatai = csomagAdatai;
            Prioritas = prioritas;
            KivantErkezesiDatum = kivantErkezesiDatum;
            FuvarAra = fuvarAra;
        }

        public Fuvar(string feladoUgyfel, string celCime, string feladasCime, string feladasDatuma, string csomagAdatai, int fuvarAra)
        {
            FeladoUgyfel = feladoUgyfel;
            CelCime = celCime;
            FeladasCime = feladasCime;
            FeladasDatuma = feladasDatuma;
            CsomagAdatai = csomagAdatai;
            FuvarAra = fuvarAra;
        }

       

        public override string ToString()
        {
            return $"Feladó ügyfél: {FeladoUgyfel}, Cél címe: {CelCime}, Feladás címe: {FeladasCime}, " +
                $"Feladás dátuma: {FeladasDatuma}, Csomag adatai: {CsomagAdatai}";
        }

        public void fuvarAdataitCSVbeMent()
        {
            File.WriteAllText("fuvarinfo.csv", ToString());
            
            

        }
    }
}
