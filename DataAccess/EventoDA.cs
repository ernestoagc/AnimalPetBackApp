﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace DataAccess
{
    public class EventoDA
    {
        private static EventoDA instanciaEventoDA = null;
        public static EventoDA getEventoDA
        {
            get
            {
                if (instanciaEventoDA == null)
                    instanciaEventoDA = new EventoDA();
                return instanciaEventoDA;
            }
        }


        public EventoBE Update(EventoBE pEventoBE)
        {

            using (dbVeterinariaEntities oModelo = new dbVeterinariaEntities())
            {
                var obj = (from elem in oModelo.EVENTO where elem.ID.Equals(pEventoBE.id) select elem).FirstOrDefault();

                obj.ESTADO_VAL = pEventoBE.estado;


                oModelo.SaveChanges();
            }
            return pEventoBE;
        }

        public EventoBE insert(EventoBE pEventoBE)
        {

            int resultado = 0;
            try
            {
                EVENTO oEVENTO = new EVENTO();
                oEVENTO.FECHA = DateTime.Now;
                oEVENTO.PEDIDO_SERVICIO = pEventoBE.idPedidoServicio;
                oEVENTO.ESTADO_VAL = pEventoBE.estado;

                using (dbVeterinariaEntities oModelo = new dbVeterinariaEntities())
                {
                    oModelo.EVENTO.Add(oEVENTO);
                    resultado = oModelo.SaveChanges();
                }

                pEventoBE.id = oEVENTO.ID;
            }
            catch (Exception ex)
            {
                throw;
            }

            return pEventoBE;
        }





    }

}
