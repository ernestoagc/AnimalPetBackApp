using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace DataTransferObject
{

    [DataContract]
    public class PedidoSalidaDTO
    {
        [DataMember(IsRequired = true)]
        public int idPedido { get; set; }

        [DataMember(IsRequired = false)]
        public string usuarioCodigo { get; set; }

        [DataMember(IsRequired = false,EmitDefaultValue =false)]
        public string usuarioNombres { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string usuarioApellidoPaterno { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string usuarioApellidoMaterno { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string actualizo { get; set; }


        [DataMember(IsRequired = false)]
        public string direccion { get; set; }

        [DataMember(IsRequired = false)]
        public string comentario { get; set; }

        [DataMember(IsRequired = false)]
        public string latitud { get; set; }

        [DataMember(IsRequired = false)]
        public string longitud { get; set; }

        [DataMember(IsRequired = false)]
        public string estadoCodigo { get; set; }

        [DataMember(IsRequired = false)]
        public string estadoNombre { get; set; }

        [DataMember(IsRequired = false)]
        public DateTime fecha { get; set; }


        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public List<ServicioDTO> servicios { get; set; }

    }
}
