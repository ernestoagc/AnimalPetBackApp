using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BusinessEntities;
using System.Transactions;

namespace BusinessLogic
{
   public class NegocioBL
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        EventoDA eventoDA = EventoDA.getEventoDA;
        ServicioDA servcioDA = ServicioDA.getServicioDA;
        UsuarioDA usuarioDA = UsuarioDA.getUsuarioDA;
        ValorDA valorDA = ValorDA.getValorDA;
        PedidoDA pedidoDA = PedidoDA.getPedidoDA;
        PedidoServicioDA pedidoServicioDA = PedidoServicioDA.getPedidoServicioDA;


        private static NegocioBL instanciaNegocioBL = null;
        public static NegocioBL getNegocioBL
        {
            get
            {
                if (instanciaNegocioBL == null)
                    instanciaNegocioBL = new NegocioBL();
                return instanciaNegocioBL;
            }
        }

        // Envio del Pedido al cliente
        public PedidoBE insert(PedidoBE pPedidoBE, List<PedidoServicioBE> pListaPedidoServicioBE) {
            string mensajeSalida = "";
            List <ValorBE> listaEstadoEvento = valorDA.Get(new ValorBE.Criterio() { CODIGO = "PP" ,LISTA_CODIGO= "ESTADO_EVENTO" });
            List<ValorBE> listaEstadoPedido = valorDA.Get(new ValorBE.Criterio() { CODIGO = "EP_PENDIENTE", LISTA_CODIGO = "ESTADO_PEDIDO" });
            List<UsuarioBE> listaUsuario = usuarioDA.get(new UsuarioBE.Criterio() { ID=pPedidoBE.usuario });


            ValorBE estadoEventoPendiente = listaEstadoEvento[0];
            ValorBE estadoPedidoPendiente = listaEstadoPedido[0];
            UsuarioBE usuarioBE = listaUsuario[0];
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
            {
                pPedidoBE.estado = estadoPedidoPendiente.id;
                pPedidoBE = pedidoDA.Insert(pPedidoBE);
              
                foreach (PedidoServicioBE obj in pListaPedidoServicioBE)
                {
                    obj.idPedido = pPedidoBE.id;
                    PedidoServicioBE pedidoServicioBE = pedidoServicioDA.insert(obj);
                   // pedidoServicioBE = pedidoServicioDA.insert(obj);

                    EventoBE eventoBE = new EventoBE();
                    eventoBE.idPedidoServicio = pedidoServicioBE.id;
                    eventoBE.estado = estadoEventoPendiente.id;
                    eventoBE.fecha = DateTime.Now;

                    eventoDA.insert(eventoBE);
                    ServicioBE servicioBE = servcioDA.get(new ServicioBE.Criterio() { ID = pedidoServicioBE.idServicio })[0];
                    mensajeSalida = "Registro,";
                    mensajeSalida = mensajeSalida + pPedidoBE.id + ",";
                    mensajeSalida = mensajeSalida + servicioBE.id + "," + servicioBE.nombre+",";
                    mensajeSalida = mensajeSalida + estadoEventoPendiente.valor + ",";
                    mensajeSalida = mensajeSalida + usuarioBE.usuario;
                    log.Info(mensajeSalida);
                    mensajeSalida = "";
                }


                
                transactionScope.Complete();
                
                return pPedidoBE;
            }
         
        }

        public List<PedidoBE> get(PedidoBE.Criterio pCriterio) {
            string mensajeSalida = "";
            if (pCriterio != null) {

                if (!string.IsNullOrEmpty(pCriterio.ID_PEDIDO))
                {
                    // log.Info("Solicitando los eventos del pedido: " + pCriterio.ID_PEDIDO);
                    mensajeSalida = "Consulta,"+mensajeSalida + pCriterio.ID_PEDIDO + ",,,,";
                }

                if (!string.IsNullOrEmpty(pCriterio.USUARIO_CODIGO))
                {
                    //  log.Info("Solicitando pedidos de: "+ pCriterio.USUARIO_CODIGO);
                    mensajeSalida = mensajeSalida+  "Listar," + ",,,,"+ pCriterio.USUARIO_CODIGO ;
                }

            }

            List < PedidoBE > resultado= pedidoDA.Get(pCriterio);

            if(!pCriterio.NO_PINTAR)
            log.Info(mensajeSalida);

            return resultado;
            
        }

        public List<EventoBE> insertEvento(PedidoBE pPedidoBE, List<PedidoServicioBE> pListaPedidoEvento) {
            string mensajeSalida = "";
            List<EventoBE> resultado = new List<EventoBE>();

            PedidoBE pedidoBE = pedidoDA.Get(new PedidoBE.Criterio() { NO_PINTAR = true, ID_PEDIDO = pPedidoBE.id.ToString(), OBTENER_SERVICIOS = false })[0];
            
            
            
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
            {
                foreach (PedidoServicioBE pedidoEvento in pListaPedidoEvento) {
                    EventoBE eventoBE = new EventoBE();
                    eventoBE.idPedidoServicio = pedidoEvento.id;
                    eventoBE.estado = pedidoEvento.idEstadoEvento;
                    eventoBE.fecha = DateTime.Now;
                    eventoBE = eventoDA.insert(eventoBE);
                    resultado.Add(eventoBE);
                    List<ValorBE> listaEstadoEvento = valorDA.Get(new ValorBE.Criterio() { ID= pedidoEvento .idEstadoEvento});
                    PedidoServicioBE pedidoServicioBE = pedidoServicioDA.get(new PedidoServicioBE.Criterio() {ID=eventoBE.idPedidoServicio })[0];
                    mensajeSalida = mensajeSalida + "Tracking," + pedidoBE.id + ","+pedidoServicioBE.idServicio+","+ pedidoServicioBE.servicioNombre+"," + listaEstadoEvento[0].valor+ ","+pedidoBE.usuarioCodigo;
                    log.Info(mensajeSalida);
                    mensajeSalida = "";
                }
                transactionScope.Complete();
            }

            
            return resultado;
        }

        }
    
}
