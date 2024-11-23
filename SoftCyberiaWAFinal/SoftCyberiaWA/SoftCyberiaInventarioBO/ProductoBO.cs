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
    public class ProductoBO : BaseBO
    {
        public int producto_insertar(producto _producto)
        {
            return this.WsProducto.producto_insertar(_producto);
        }
        public int producto_modificar(producto _producto)
        {
            return this.WsProducto.producto_modificar(_producto);
        }
        public BindingList<producto> producto_listar()
        {
            producto[] arreglo = this.WsProducto.producto_listar();
            return new BindingList<producto>(arreglo);
        }
        public producto producto_buscar_sku(string sku, int idSede)
        {
            return this.WsProducto.producto_buscar_sku(sku, idSede);
        }
        public int producto_aumentar_stock(int idProducto, int idSede, int Cantidad)
        {
            return this.WsProducto.producto_aumentar_stock(idProducto, idSede, Cantidad);
        }
    }
}