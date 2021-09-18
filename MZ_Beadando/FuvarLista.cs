using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MZ_Beadando
{
    class FuvarLista
    {
        private List<Fuvar> fuvarLista;


        public FuvarLista()
        {
            fuvarLista = new List<Fuvar>();
        }

        public void felvesz(Fuvar fuvar)
        {
            fuvarLista.Add(fuvar);
            
        }

        public bool torles(Fuvar fuvar)
        {
            bool siker = fuvarLista.Remove(fuvar);
            return siker;
        }



        public List<Fuvar> getList() { return fuvarLista; }
        public Fuvar getFuvar(int index) { return fuvarLista[index]; }

       

    }
}