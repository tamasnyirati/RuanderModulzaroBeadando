using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MZ_Beadando
{
    class Cim
    {
        public int Iranyitoszam { get; set; }
        public string Varos { get; set; }
        public string Utca { get; set; }
        public int Hazszam { get; set; }

        public Cim(int iranyitoszam, string varos, string utca, int hazszam)
        {
            Iranyitoszam = iranyitoszam;
            Varos = varos;
            Utca = utca;
            Hazszam = hazszam;
        }

        public override string ToString()
        {
            return $"Irányítószám: {Iranyitoszam}, Város: {Varos}, Utca: {Utca}, Házszám: {Hazszam}";
        }

        public void cimAdataitCSVbeMent()
        {
            File.WriteAllText("cim.csv", ToString());
        }
    }
}
