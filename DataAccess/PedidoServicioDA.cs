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


        public List<PedidoServicioBE> get(PedidoServicioBE.Criterio pCriterio)
        {
            try
            {
                List<PedidoServicioBE> listado = new List<PedidoServicioBE>();
                using (dbVeterinariaEntities db = new dbVeterinariaEntities())
                {
                    var lstQuery = (from elem in db.PEDIDO_SERVICIO
                                    join ser in db.SERVICIO on elem.SERVICIO equals ser.ID
                                    select new PedidoServicioBE()
                                    {
                                        id = elem.ID,
                                        idPedido=elem.PEDIDO,
                                        idServicio=ser.ID,
                                        servicioNombre=ser.NOMBRE,
                                        servicioCodigo=ser.CODIGO

                                    }).ToList();

                    if (lstQuery != null)
                    {
                        listado.AddRange(lstQuery.ToList());
                    }

                }


                if (pCriterio != null)
                {


                    if (pCriterio.SERVICIO != 0)
                    {
                        listado = listado.FindAll(t => t.idServicio.Equals(pCriterio.SERVICIO));
                    }

                    if (pCriterio.ID != 0)
                    {
                        listado = listado.FindAll(t => t.id.Equals(pCriterio.ID));
                    }

                }


                return listado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }

}
