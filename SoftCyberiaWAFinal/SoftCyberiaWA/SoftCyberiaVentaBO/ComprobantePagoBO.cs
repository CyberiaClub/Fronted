﻿using SoftCyberiaBaseBO;
using SoftCyberiaBaseBO.CyberiaWS;
using System.ComponentModel;
using System.Linq;

namespace SoftCyberiaVentaBO
{
    public class ComprobantePagoBO : BaseBO
    {
        public BindingList<comprobantePago> Comprobante_pago_listar()
        {
            comprobantePago[] arreglo = wsBase.comprobante_pago_listar();
            return new BindingList<comprobantePago>(arreglo);
        }

        public BindingList<comprobantePago> Comprobante_pago_listar_cliente(int idCliente)
        {
            comprobantePago[] arreglo = wsBase.comprobante_buscar_usuario(idCliente);
            return new BindingList<comprobantePago>(arreglo);
        }

        public BindingList<comprobantePago> Comprobante_pago_listar_sede(int idSede)
        {
            comprobantePago[] arreglo = wsBase.comprobante_buscar_sede(idSede);
            if (arreglo == null)
            {
                comprobantePago dummy = new comprobantePago
                {
                    idComprobantePago = 0
                };
                BindingList<comprobantePago> bindingList = new BindingList<comprobantePago>
                {
                    dummy
                };
                return bindingList;
            }
            return new BindingList<comprobantePago>(arreglo);
        }
        public comprobantePago Comprobante_pago_obtener_por_id(int id_comprobante_pago)
        {
            return wsBase.comprobante_pago_obtener_por_id(id_comprobante_pago);
        }

        public int Comprobante_pago_insertar(comprobantePago _comprobantePago)
        {
            return wsBase.comprobante_pago_insertar(_comprobantePago);
        }

        public int Comprobante_pago_modificar(comprobantePago _comprobantePago)
        {
            return wsBase.comprobante_pago_modificar(_comprobantePago);
        }
    }
}