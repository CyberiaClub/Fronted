using SoftCyberiaBaseBO;
using SoftCyberiaBaseBO.CyberiaWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCyberiaVentaBO
{
    public class ComprobantePagoBO : BaseBO
    {
        public BindingList<comprobantePago> comprobante_pago_listar()
        {
            comprobantePago[] arreglo = this.WsComprobantePago.comprobante_pago_listar();
            return new BindingList<comprobantePago>(arreglo);
        }

        public BindingList<comprobantePago> comprobante_pago_listar_cliente(int idCliente)
        {
            comprobantePago[] arreglo = this.WsComprobantePago.comprobante_pago_listar_cliente(idCliente);
            return new BindingList<comprobantePago>(arreglo);
        }
        public comprobantePago comprobante_pago_obtener_por_id(int id_comprobante_pago)
        {
            return this.WsComprobantePago.comprobante_pago_obtener_por_id(id_comprobante_pago);
        }

        public int comprobante_pago_insertar(comprobantePago _comprobantePago)
        {
            return this.WsComprobantePago.comprobante_pago_insertar(_comprobantePago);
        }

        public int comprobante_pago_modificar(comprobantePago _comprobantePago)
        {
            return this.WsComprobantePago.comprobante_pago_modificar(_comprobantePago);
        }
    }
}