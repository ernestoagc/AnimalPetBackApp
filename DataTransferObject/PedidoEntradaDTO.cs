using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class PedidoEntradaDTO
    {
        public int usuarioId { get; set; }
        public string usuarioCodigo { get; set; }
        public DateTime fecha { get; set; }
        public string direccion { get; set; }
        public List<ServicioDTO> servicios { get; set; }
        public string comentario { get; set; }
        public string estadoCodigo { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
    }
}
