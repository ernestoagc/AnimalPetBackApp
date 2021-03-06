﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataTransferObject;
namespace Helper
{
    public static class UtilFunction
    {
        public static ParametroDTO getParametroDTO(ValorBE valorBE) {
            ParametroDTO parametroDTO = new ParametroDTO();
            parametroDTO.codigo = valorBE.codigo;
            parametroDTO.valor = valorBE.valor;
            parametroDTO.listaCodigo = valorBE.listaCodigo;
            parametroDTO.listaNombre = valorBE.listaNombre;
            parametroDTO.id = valorBE.id;
            return parametroDTO;
        }

        public static List<ParametroDTO> getListParametroDTO(List<ValorBE> listaValorBE)
        {
            List<ParametroDTO> resultado = new List<ParametroDTO>();
            if (listaValorBE != null) {
                foreach (ValorBE valorBE in listaValorBE)
                {
                    ParametroDTO parametroDTO = new ParametroDTO();
                    parametroDTO.codigo = valorBE.codigo;
                    parametroDTO.valor = valorBE.valor;
                    parametroDTO.listaCodigo = valorBE.listaCodigo;
                    parametroDTO.listaNombre = valorBE.listaNombre;
                    parametroDTO.id = valorBE.id;
                    resultado.Add(parametroDTO);
                }
            }
            return resultado;


        }

        public static PedidoSalidaDTO getPedidoSalidaDTO(PedidoBE pPedidoBE) {
            PedidoSalidaDTO pedidoSalidaDTO = new PedidoSalidaDTO();

            pedidoSalidaDTO.direccion = pPedidoBE.direccion;
            pedidoSalidaDTO.latitud = pPedidoBE.latitud;
            pedidoSalidaDTO.longitud = pPedidoBE.longitud;
            pedidoSalidaDTO.usuarioCodigo = pPedidoBE.usuarioCodigo;
            pedidoSalidaDTO.comentario = pPedidoBE.comentario;
            pedidoSalidaDTO.fecha = pPedidoBE.fecha;
            pedidoSalidaDTO.idPedido = pPedidoBE.id;
            pedidoSalidaDTO.estadoCodigo = pPedidoBE.estadoCodigo;
            pedidoSalidaDTO.estadoNombre = pPedidoBE.estadoNombre;

            if (pedidoSalidaDTO.fecha != null)
                pedidoSalidaDTO.fechaString = pPedidoBE.fecha.ToString();
            return pedidoSalidaDTO;

        }

        public static ServicioDTO getServicioDTO(ServicioBE pServicioBE) {
            ServicioDTO servicioDTO = new ServicioDTO();
            servicioDTO.idServicio = pServicioBE.id;
            servicioDTO.costo = pServicioBE.costo;
            //servicioDTO.idEvento = pServicioBE.idEvento;
            servicioDTO.servicioCodigo = pServicioBE.codigo;
            servicioDTO.servicioNombre = pServicioBE.nombre;
            servicioDTO.estadoEventoCodigo = pServicioBE.estadoEventoCodigo;
            servicioDTO.estadoEventoNombre = pServicioBE.estadoEventoNombre;
            servicioDTO.fecha = pServicioBE.fechaEvento;
            if(pServicioBE.fechaEvento!=null)
            servicioDTO.fechaString = pServicioBE.fechaEvento.ToString();

            servicioDTO.idPedidoServicio = pServicioBE.idPedidoServicio;
            return servicioDTO;
        }


        public static PedidoBE getPedidoBE(PedidoEntradaDTO pPedidoEntradaDTO) {
            PedidoBE pedidoBE = new PedidoBE();
            pedidoBE.usuario = pPedidoEntradaDTO.usuarioId;
            pedidoBE.comentario = pPedidoEntradaDTO.comentario;
            pedidoBE.fecha = pPedidoEntradaDTO.fecha;
            pedidoBE.latitud = pPedidoEntradaDTO.latitud;
            pedidoBE.longitud = pPedidoEntradaDTO.longitud;
            pedidoBE.id = pPedidoEntradaDTO.idPedido;
            pedidoBE.direccion = pPedidoEntradaDTO.direccion;
            //pedidoBE.servicios = new List<ServicioBE>();
            return pedidoBE;
        }

        public static ServicioBE getServicioBE(ServicioDTO pServicioDTO)
        {
            ServicioBE servicioBE = new ServicioBE();
            servicioBE.codigo = pServicioDTO.servicioCodigo;
            servicioBE.id = pServicioDTO.idServicio;
            return servicioBE;
        }

    }
}
