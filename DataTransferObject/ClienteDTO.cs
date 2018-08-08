using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class ClienteDTO
    {
        public string usuarioCodigo { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string mascotaNombre { get; set; }
        public string mascotaRaza { get; set; }
        public string mascotaTipo { get; set; }
        public string perfilCodigo { get; set; }
    }
}
