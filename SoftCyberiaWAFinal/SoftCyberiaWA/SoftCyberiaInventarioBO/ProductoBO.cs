using SoftCyberiaBaseBO;
using SoftCyberiaBaseBO.CyberiaWS;
using System.ComponentModel;

namespace SoftCyberiaInventarioBO
{
    public class ProductoBO : BaseBO
    {
        public int Producto_insertar(producto _producto)
        {
            return wsBase.producto_insertar(_producto);
        }
        public int Producto_modificar(producto _producto)
        {
            return wsBase.producto_modificar(_producto);
        }
        public BindingList<producto> Producto_listar()
        {
            producto[] arreglo = wsBase.producto_listar();
            return new BindingList<producto>(arreglo);
        }
        public producto Producto_buscar_sku(string sku, int idSede)
        {
            return wsBase.producto_buscar_sku(sku, idSede);
        }
        public int Producto_aumentar_stock(int idProducto, int idSede, int Cantidad)
        {
            return wsBase.producto_aumentar_stock(idProducto, idSede, Cantidad);
        }

        public BindingList<producto> Producto_buscar_pedido(int idPedido)
        {
            producto[] arreglo = wsBase.producto_lineas_pedido(idPedido);
            return new BindingList<producto>(arreglo);
        }

    }
}