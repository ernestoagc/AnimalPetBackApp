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
        EventoDA eventoDA = EventoDA.getEventoDA;
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
            List<ValorBE> listaEstadoEvento = valorDA.Get(new ValorBE.Criterio() { CODIGO = "PP" ,LISTA_CODIGO= "ESTADO_EVENTO" });
            List<ValorBE> listaEstadoPedido = valorDA.Get(new ValorBE.Criterio() { CODIGO = "EP_PENDIENTE", LISTA_CODIGO = "ESTADO_PEDIDO" });

            
            ValorBE estadoEventoPendiente = listaEstadoEvento[0];
            ValorBE estadoPedidoPendiente = listaEstadoEvento[0];

            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
            {
                pPedidoBE.estado = estadoPedidoPendiente.id;
                pPedidoBE = pedidoDA.Insert(pPedidoBE);
                
                foreach (PedidoServicioBE obj in pListaPedidoServicioBE)
                {
                    obj.idPedido = pPedidoBE.id;
                    PedidoServicioBE pedidoServicioBE = pedidoServicioDA.insert(obj);
                    pedidoServicioBE = pedidoServicioDA.insert(obj);

                    EventoBE eventoBE = new EventoBE();
                    eventoBE.idPedidoServicio = pedidoServicioBE.id;
                    eventoBE.estado = estadoEventoPendiente.id;
                    eventoBE.fecha = DateTime.Now;

                    eventoDA.insert(eventoBE);
                }
                return pPedidoBE;
            }
         
        }

        public List<PedidoBE> get(PedidoBE.Criterio pCriterio) {
            return pedidoDA.Get(pCriterio);

        }

    }
}
