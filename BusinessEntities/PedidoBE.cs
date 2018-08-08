using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class PedidoBE
    {
        public int id { get; set; }
        public string usuarioCodigo { get; set; }
        public int usuario { get; set; }
        public int estado { get; set; }
        public string usuarioNombre { get; set; }
        public string estadoNombre { get; set; }
        public string estadoCodigo { get; set; }
        public DateTime fecha { get; set; }
        public string comentario { get; set; }
        public string direccion { get; set; }
        public List<ServicioBE> servicios {get;set;}
        public string latitud { get; set; }
        public string longitud { get; set; }

        public class Criterio
        {
            public string USUARIO_CODIGO { get; set; }
            public string ESTADO { get; set; }
            public bool OBTENER_SERVICIOS { get; set; }
        }
    }
}
