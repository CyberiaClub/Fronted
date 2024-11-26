using SoftCyberiaBaseBO;
using SoftCyberiaBaseBO.CyberiaWS;
using System.ComponentModel;

namespace SoftCyberiaInventarioBO
{
    public class TipoProductoBO : BaseBO
    {
        public int TipoProducto_insertar(tipoProducto _tipoProducto)
        {
            return wsBase.tipoProducto_insertar(_tipoProducto);
        }

        public int TipoProducto_modificar(tipoProducto _tipoProducto)
        {
            return wsBase.tipoProducto_modificar(_tipoProducto);
        }
        public BindingList<tipoProducto> TipoProducto_listar()
        {
            tipoProducto[] arreglo = wsBase.tipoProducto_listar();
            return new BindingList<tipoProducto>(arreglo);
        }
        public int TipoProducto_eliminar(tipoProducto _tipoProducto)
        {
            return wsBase.tipoProducto_eliminar(_tipoProducto);
        }
    }
}