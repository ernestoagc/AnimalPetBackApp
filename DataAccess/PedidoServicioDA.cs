using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace DataAccess
{
    public class PedidoServicioDA
    {
        private static PedidoServicioDA instanciaPedidoServicioDA = null;
        public static PedidoServicioDA getPedidoServicioDA
        {
            get
            {
                if (instanciaPedidoServicioDA == null)
                    instanciaPedidoServicioDA = new PedidoServicioDA();
                return instanciaPedidoServicioDA;
            }
        }

        public PedidoServicioBE insert(PedidoServicioBE pPedidoServicioBE) {

            int resultado = 0;
            try
            {
                PEDIDO_SERVICIO oPEDIDO_SERVICIO = new PEDIDO_SERVICIO();
                oPEDIDO_SERVICIO.SERVICIO = pPedidoServicioBE.idServicio;
                oPEDIDO_SERVICIO.PEDIDO = pPedidoServicioBE.idPedido;
                oPEDIDO_SERVICIO.COSTO = pPedidoServicioBE.costo;

                using (dbVeterinariaEntities oModelo = new dbVeterinariaEntities())
                {
                    oModelo.PEDIDO_SERVICIO.Add(oPEDIDO_SERVICIO);
                    resultado = oModelo.SaveChanges();
                }

                pPedidoServicioBE.id = oPEDIDO_SERVICIO.ID;
            }
            catch (Exception ex)
            {
                throw;
            }

            return pPedidoServicioBE;
        }

    }

}
