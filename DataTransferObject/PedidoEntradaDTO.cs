using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace DataTransferObject
{
    [DataContract]
    public class PedidoEntradaDTO
    {
        [DataMember]
        public int usuarioId { get; set; }

        [DataMember]
        public string usuarioCodigo { get; set; }

        [DataMember]
        public DateTime fecha { get; set; }

        [DataMember]
        public string direccion { get; set; }

        [DataMember]
        public List<ServicioDTO> servicios { get; set; }

        [DataMember]
        public string comentario { get; set; }

        [DataMember]
        public string estadoCodigo { get; set; }

        [DataMember]
        public string latitud { get; set; }

        [DataMember]
        public string longitud { get; set; }
    }
}
