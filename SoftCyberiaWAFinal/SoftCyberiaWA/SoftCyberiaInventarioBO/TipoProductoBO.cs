using SoftCyberiaBaseBO;
using SoftCyberiaBaseBO.CyberiaWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCyberiaInventarioBO
{
    public class TipoProductoBO : BaseBO
    {
        public int tipoProducto_insertar(tipoProducto _tipoProducto)
        {
            return this.WsTipoProducto.tipoProducto_insertar(_tipoProducto);
        }

        public int tipoProducto_modificar(tipoProducto _tipoProducto)
        {
            return this.WsTipoProducto.tipoProducto_modificar(_tipoProducto);
        }
        public BindingList<tipoProducto> tipoProducto_listar()
        {
            tipoProducto[] arreglo = this.WsTipoProducto.tipoProducto_listar();
            return new BindingList<tipoProducto>(arreglo);
        }
        public void tipoProducto_eliminar(tipoProducto _tipoProducto)
        {
            this.WsTipoProducto.tipoProducto_eliminar(_tipoProducto);
        }
    }
}