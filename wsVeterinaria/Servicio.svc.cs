using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTransferObject;
using BusinessLogic;
using BusinessEntities;
using DataTransferObject;
using Helper;
namespace wsVeterinaria
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Servicio" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Servicio.svc o Servicio.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Servicio : IServicio
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        ConfiguracionBL configuracionBL = ConfiguracionBL.getConfiguracionBL;
        NegocioBL negocioBL = NegocioBL.getNegocioBL;

        public List<ParametroDTO> getParametria(string codigo)
        {
            List<ParametroDTO> resultado = null;
            ValorBE.Criterio criterio = new ValorBE.Criterio();
            criterio.LISTA_CODIGO = codigo;
            resultado = Helper.UtilFunction.getListParametroDTO(   configuracionBL.getValor(criterio));
            return resultado;
        }

        public List<PedidoSalidaDTO> getPedido(string usuario,string estado,string pedido)
        {
            PedidoBE.Criterio criterio = new PedidoBE.Criterio();
            criterio.OBTENER_SERVICIOS = true;
            criterio.USUARIO_CODIGO = usuario;
            criterio.ESTADO = estado;
            criterio.ID_PEDIDO = pedido;
            log.Debug("pruebaLOGGG");
            log.Debug("pruebaINFO");
            List<PedidoSalidaDTO> resultado = new List<PedidoSalidaDTO>();
            List<PedidoBE> listaPedido = negocioBL.get(criterio);

            foreach (PedidoBE pedidoBE in listaPedido) {
                
                PedidoSalidaDTO pedidoSalidaDTO = UtilFunction.getPedidoSalidaDTO(pedidoBE);
                resultado.Add(pedidoSalidaDTO);
                if (pedidoBE.servicios.Count > 0) {
                    pedidoSalidaDTO.servicios = new List<ServicioDTO>();
                    foreach (ServicioBE servicioBE in pedidoBE.servicios) {
                        ServicioDTO servicioDTO=UtilFunction.getServicioDTO(servicioBE);
                        pedidoSalidaDTO.servicios.Add(servicioDTO);
                    }
                                                                                                              
                }
            }

            
            return resultado;
        }

        public List<ServicioDTO> getServicio()
        {
            List<ServicioDTO> resultado = new List<ServicioDTO>();
            List<ServicioBE> listaServicioBE = configuracionBL.getServicio(null);

            foreach (ServicioBE servicioBE in listaServicioBE) {
                resultado.Add(UtilFunction.getServicioDTO(servicioBE));
            }
            return resultado;
        }

        public PedidoSalidaDTO InsertEvento(PedidoEntradaDTO pPedidoEntradaDTO)
        {
            PedidoBE pedidoBE = UtilFunction.getPedidoBE(pPedidoEntradaDTO);

            foreach (ServicioDTO servicioDTO in pPedidoEntradaDTO.servicios) {
                ServicioBE servicioBE = UtilFunction.getServicioBE(servicioDTO);

            }

            PedidoSalidaDTO pedidoSalidaDTO = new PedidoSalidaDTO();
            return pedidoSalidaDTO;
        }

        public PedidoSalidaDTO InsertPedido(PedidoEntradaDTO pPedidoEntradaDTO)
        {
            PedidoBE pedidoBE = UtilFunction.getPedidoBE(pPedidoEntradaDTO);

            List<PedidoServicioBE> listaPedidoServicioBE = new List<PedidoServicioBE>();

            if (pPedidoEntradaDTO.servicios != null) {
                foreach (ServicioDTO servicioDTO in pPedidoEntradaDTO.servicios) {
                    //ServicioBE servicioBE = UtilFunction.getServicioBE(servicioDTO);
                    //serviciosBE.Add(servicioBE);
                    PedidoServicioBE pedidoServicioBE = new PedidoServicioBE();
                    pedidoServicioBE.idServicio = servicioDTO.idServicio;
                    pedidoServicioBE.costo = servicioDTO.costo;
                    listaPedidoServicioBE.Add(pedidoServicioBE);
                }
            }

            negocioBL.insert(pedidoBE, listaPedidoServicioBE);

            PedidoSalidaDTO pedidoSalidaDTO = new PedidoSalidaDTO();
            return pedidoSalidaDTO;
        }
    }
}
