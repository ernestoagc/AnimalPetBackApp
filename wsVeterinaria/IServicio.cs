using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTransferObject;
using System.Runtime.Serialization;
using System.ServiceModel.Web;

namespace wsVeterinaria
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicio" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicio
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Parametria/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        List<ParametroDTO> getParametria(string codigo);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Servicio/", ResponseFormat = WebMessageFormat.Json)]
        List<ServicioDTO> getServicio();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Pedido?usuario={usuario}&estado={estado}&pedido={pedido}", ResponseFormat = WebMessageFormat.Json)]
        List<PedidoSalidaDTO> getPedido(string usuario, string estado, string pedido);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/PedidoInsert", ResponseFormat = WebMessageFormat.Json)]
        PedidoSalidaDTO InsertPedido(PedidoEntradaDTO pPedidoEntradaDTO);

    }
}
