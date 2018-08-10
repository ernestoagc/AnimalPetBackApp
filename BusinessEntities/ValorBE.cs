using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class ValorBE
    {
        public int id {get;set;}
        public string codigo { get; set; }
        public string valor { get; set; }
        public string aux1 { get; set; }
        public string listaCodigo { get; set; }
        public string listaNombre { get; set; }


        public class Criterio {
            public string LISTA_CODIGO { get; set; }
            public string CODIGO { get; set; }
            public int ID { get; set; }
        }

    }
}
