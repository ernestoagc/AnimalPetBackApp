using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace DataAccess
{
    public class PedidoDA
    {
        private static PedidoDA instanciaPedidoDA = null;
        public static PedidoDA getPedidoDA
        {
            get
            {
                if (instanciaPedidoDA == null)
                    instanciaPedidoDA = new PedidoDA();
                return instanciaPedidoDA;
            }
        }


        public List<PedidoBE> Get(PedidoBE.Criterio pCriterio)
        {
            List<PedidoBE> listado = new List<PedidoBE>();
            try
            {
                    
                    using (dbVeterinariaEntities db = new dbVeterinariaEntities())
                    {
                        var lstQuery = (from elem in db.PEDIDO
                                        select new PedidoBE()
                                        {
                                            id = elem.ID,
                                            estadoCodigo = elem.VALOR.VALOR1,
                                            estadoNombre = elem.VALOR.NOMBRE,
                                            fecha = elem.FECHA,
                                            direccion=elem.DIRECCION,
                                            comentario = elem.COMENTARIO,
                                            latitud = elem.LATITUD,
                                            longitud = elem.LONGITUD,
                                            usuario = elem.USUARIO,
                                            usuarioCodigo = elem.USUARIO1.USUARIO1,
                                            usuarioNombre = elem.USUARIO1.NOMBRE


                                        });

                        if (lstQuery != null)
                        {
                            listado.AddRange(lstQuery.ToList());
                        }



                    if (pCriterio != null)
                    {
                        if (!string.IsNullOrEmpty(pCriterio.USUARIO_CODIGO))
                        {
                            listado = listado.FindAll(t => t.usuarioCodigo.Equals(pCriterio.USUARIO_CODIGO));
                        }

                        if (!string.IsNullOrEmpty(pCriterio.ESTADO))
                        {
                            listado = listado.FindAll(t => t.estadoCodigo.Equals(pCriterio.ESTADO));
                        }

                        if (!string.IsNullOrEmpty(pCriterio.ID_PEDIDO))
                        {
                            listado = listado.FindAll(t => t.id.Equals(Convert.ToInt32(pCriterio.ID_PEDIDO)));
                        }

                        //if (pCriterio.ID_PEDIDO!=0)
                        //{
                        //    listado = listado.FindAll(t => t.id.Equals(pCriterio.ID_PEDIDO));
                        //}

                        if (pCriterio.OBTENER_SERVICIOS)
                        {
                            foreach (var obj in listado)
                            {
                                obj.servicios = new List<ServicioBE>();

                                var ltsDetalle = (from elem in db.PEDIDO_SERVICIO
                                                  join ser in db.SERVICIO on elem.SERVICIO equals ser.ID
                                                  join eve in db.EVENTO on elem.ID equals eve.PEDIDO_SERVICIO
                                                  where elem.PEDIDO.CompareTo(obj.id)==0
                                                  select new ServicioBE()
                                                  {
                                                      estadoEventoNombre =eve.VALOR.VALOR1,
                                                      estadoEventoCodigo=eve.VALOR.CODIGO,
                                                      nombre=ser.NOMBRE,
                                                      costo=ser.COSTO,
                                                      codigo=ser.CODIGO     ,
                                                      fechaEvento = eve.FECHA,
                                                      id=ser.ID,
                                                      idPedidoServicio = eve.PEDIDO_SERVICIO


                                                  });
                                if (ltsDetalle != null) {
                                    obj.servicios.AddRange(ltsDetalle.ToList());
                                }
                                

                            }
                        }



                        return listado;
                    }



                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return listado;
        }

        public PedidoBE Insert(PedidoBE pPedidoBE)
        {
            int resultado = 0;
            try
            {
                PEDIDO oPEDIDO = new PEDIDO();
                oPEDIDO.FECHA = pPedidoBE.fecha;
                oPEDIDO.ESTADO_VAL = pPedidoBE.estado;
                oPEDIDO.COMENTARIO = pPedidoBE.comentario;
                oPEDIDO.DIRECCION = pPedidoBE.direccion;
                oPEDIDO.USUARIO = pPedidoBE.usuario;
                oPEDIDO.DIRECCION = pPedidoBE.direccion;
                oPEDIDO.LATITUD = pPedidoBE.latitud;
                oPEDIDO.LONGITUD = pPedidoBE.longitud;
                using (dbVeterinariaEntities oModelo = new dbVeterinariaEntities())
                {
                    oModelo.PEDIDO.Add(oPEDIDO);
                    resultado = oModelo.SaveChanges();
                }

                pPedidoBE.id = oPEDIDO.ID;


            }
            catch (Exception ex)
            {
                throw;
            }


            return pPedidoBE;


        }

        public ServicioBE InsertPedidoServicio(ServicioBE pServicioBE) {

            int resultado = 0;
            try
            {
                PEDIDO_SERVICIO oPEDIDO_SERVICIO = new PEDIDO_SERVICIO();
                oPEDIDO_SERVICIO.SERVICIO = pServicioBE.id;
                oPEDIDO_SERVICIO.PEDIDO = pServicioBE.idPedido;
                oPEDIDO_SERVICIO.COSTO = pServicioBE.costo;

                using (dbVeterinariaEntities oModelo = new dbVeterinariaEntities())
                {
                    oModelo.PEDIDO_SERVICIO.Add(oPEDIDO_SERVICIO);
                    resultado = oModelo.SaveChanges();
                }

             


            }
            catch (Exception ex)
            {
                throw;
            }

            return pServicioBE;
        }

    }
}
