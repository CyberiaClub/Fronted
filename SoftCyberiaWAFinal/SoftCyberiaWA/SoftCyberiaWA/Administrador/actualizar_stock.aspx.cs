using System;
using SoftCyberiaWA.CyberiaWS;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class actualizar_stock : System.Web.UI.Page
    {
        ProductoWSClient daoProducto = new ProductoWSClient();
        producto _producto = new producto();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buscarProducto()
        {
            if (productoSku.Text != "")
            {
                this._producto = daoProducto.producto_buscar_sku(productoSku.Text.ToString(), 1);
                if (this._producto != null)
                {
                    nombreProducto.Text = this._producto.idProducto.ToString();
                    descripcionProducto.Text = this._producto.descripcion;
                    stockActual.Text = this._producto.cantidad.ToString();
                }
            }
        }

        protected void onClickBuscar(object sender, EventArgs e)
        {
            this.buscarProducto();
        }

        protected void onClickActualizarStock(object sender, EventArgs e)
        {
            daoProducto.producto_aumentar_stock(Convert.ToInt32(this._producto.idProducto), 1, Convert.ToInt32(cantidadProducto.Text));
            this.buscarProducto();
        }
    }
}