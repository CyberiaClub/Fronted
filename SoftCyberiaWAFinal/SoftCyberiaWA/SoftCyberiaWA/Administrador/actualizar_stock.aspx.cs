using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
namespace SoftCyberiaWA.Administrador
{
    public partial class actualizar_stock : System.Web.UI.Page
    {
        private ProductoBO productoBO;
        private producto _producto;
        public actualizar_stock()
        {
            this.productoBO = new ProductoBO();
            this._producto = new producto();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buscarProducto()
        {
            if (productoSku.Text != "")
            {
                producto _producto = productoBO.producto_buscar_sku(productoSku.Text.ToString().Trim(), 1);
                if (_producto != null)
                {
                    Session["producto"] = _producto;
                    nombreProducto.Text = _producto.nombre;
                    descripcionProducto.Text = _producto.descripcion;
                    stockActual.Text = _producto.cantidad.ToString();
                }
            }
        }

        protected void onClickBuscar(object sender, EventArgs e)
        {
            try
            {
                this.buscarProducto();
                successMessage.InnerText = "Detalle del Producto buscado.";
                successMessage.Visible = true;
            }
            catch (Exception ex)
            {
                successMessage.InnerText = $"Error al buscar producto: {ex.Message}";
                //successMessage. = "text-danger";
                successMessage.Visible = true;
            }

        }

        protected void onClickActualizarStock(object sender, EventArgs e)
        {
            try
            {
                _ = productoBO.producto_aumentar_stock(Convert.ToInt32(_producto.idProducto), 1, Convert.ToInt32(cantidadAgregar.Text));
                this.buscarProducto();


                successActualizado.Text = "Stock Actualizado correctamente.";
                successActualizado.Visible = true;
            }
            catch (Exception ex)
            {
                successActualizado.Text = $"Error al actualizar stock: {ex.Message}";
                successActualizado.CssClass = "text-danger";
                successActualizado.Visible = true;
            }
        }
    }
}