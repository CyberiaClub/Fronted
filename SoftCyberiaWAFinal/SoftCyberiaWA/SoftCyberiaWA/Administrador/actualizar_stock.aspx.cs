using System;
using System.Web.UI;
using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
namespace SoftCyberiaWA.Administrador
{
    public partial class Actualizar_stock : Page
    {
        private readonly ProductoBO productoBO;
        private readonly producto _producto;
        public Actualizar_stock()
        {
            productoBO = new ProductoBO();
            _producto = new producto();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarProducto()
        {
            if (productoSku.Text != "")
            {
                producto _producto = productoBO.Producto_buscar_sku(productoSku.Text.ToString().Trim(), 1);
                if (_producto != null)
                {
                    Session["producto"] = _producto;
                    nombreProducto.Text = _producto.nombre;
                    descripcionProducto.Text = _producto.descripcion;
                    stockActual.Text = _producto.cantidad.ToString();
                }
            }
        }

        protected void OnClickBuscar(object sender, EventArgs e)
        {
            try
            {
                BuscarProducto();
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

        protected void OnClickActualizarStock(object sender, EventArgs e)
        {
            try
            {
                _ = productoBO.Producto_aumentar_stock(Convert.ToInt32(_producto.idProducto), 1, Convert.ToInt32(cantidadAgregar.Text));
                BuscarProducto();


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