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
    internal class TipoComprobanteBO : BaseBO
    {
        public BindingList<tipoComprobante> tipo_comprobante_listar()
        {
            tipoComprobante[] arreglo  = this.WsTipoComprobante.tipo_comprobante_listar();
            return new BindingList<tipoComprobante>(arreglo);
        }
    }
}