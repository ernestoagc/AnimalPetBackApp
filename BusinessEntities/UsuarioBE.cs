using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class UsuarioBE
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string nombew { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public int perfil { get; set; }
        public string perfilCodigo { get; set; }
        public string perfilNombre { get; set; }

        public class Criterio {
            public string USUARIO { get; set; }
            public int ID { get; set; }
        }
    }
}
