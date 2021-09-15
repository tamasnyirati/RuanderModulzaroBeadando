using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MZ_Beadando
{
    class FuvarLista
    {
        private List<Fuvar> fuvarLista;

        public delegate void listaValtozas(Fuvar fuvar);
        public event listaValtozas ujFuvar;
        public event listaValtozas Fuvartorlese;

        public FuvarLista()
        {
            fuvarLista = new List<Fuvar>();
        }

        public void felvesz (Fuvar fuvar)
        {
            fuvarLista.Add(fuvar);
            ujFuvar?.Invoke(fuvar);
        }

        public bool torles (Fuvar fuvar)
        {
            bool siker = fuvarLista.Remove(fuvar);
            Fuvartorlese?.Invoke(fuvar);
            return siker;
        }

        

        public List<Fuvar> getList() { return fuvarLista; }
        public Fuvar getFuvar(int index) { return fuvarLista[index]; }
    }
}
