﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DataTransferObject
{
    [DataContract]
    public class ServicioDTO
    {
        [DataMember(IsRequired = true)]
        public int idServicio { get; set; }

        [DataMember(IsRequired = true)]
        public string servicioCodigo { get; set; }

        [DataMember(IsRequired = true)]
        public string servicioNombre { get; set; }

        [DataMember(IsRequired = true)]
        public decimal costo { get; set; }

        [DataMember(EmitDefaultValue = false,IsRequired =false)]
        public DateTime? fecha {get;set;}


        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string estadoEventoCodigo { get; set; }


        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string estadoEventoNombre { get; set; }

    }
}