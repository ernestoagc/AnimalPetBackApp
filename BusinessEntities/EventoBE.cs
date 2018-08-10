using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class EventoBE
    {
        public int id { get; set; }
        public int idPedidoServicio { get; set; }
        public int estado { get; set; }
        public string estadoCodigo { get; set; }
        string estadoNombre { get; set; }
        public DateTime fecha { get; set; }
        public string fechaString { get; set; }

    }
}
