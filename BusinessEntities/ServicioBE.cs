using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class ServicioBE
    {
        public int id { get; set; }
        public int idEstadoEvento { get; set; }
        public int idPedido { get; set; }
        public decimal costo { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public DateTime? fechaEvento { get; set; }
        public string estadoEventoCodigo { get; set; }
        public string estadoEventoNombre { get; set; }
        public int idPedidoServicio { get; set; }

        public class Criterio {
            public string CODIGO { get; set; }
            public int ID { get; set; }
        }
    }
}
