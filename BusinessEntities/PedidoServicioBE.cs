using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class PedidoServicioBE
    {
        public int id { get; set; }
        public int idPedido { get; set; }
        public int idEstadoEvento { get; set; }
        public int idServicio { get; set; }
        public decimal costo { get; set; }

    }
}
