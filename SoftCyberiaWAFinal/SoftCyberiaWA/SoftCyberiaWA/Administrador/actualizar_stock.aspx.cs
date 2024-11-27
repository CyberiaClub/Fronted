using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
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
            if (Session["Usuario"] == null || Session["paginas"] == null)
            {
                Response.Redirect("~/InicioSesion/indexInicioSesion.aspx");
            }
            // Obtener la ruta completa
            string currentPage = Request.Url.AbsolutePath;

            // Extraer solo el archivo
            string fileName = Path.GetFileName(currentPage);
            if (!(Session["paginas"] is BindingList<pagina> allowedPages))
            {
                Response.Redirect("~/InicioSesion/indexInicioSesion.aspx");
            }
            else
            {
                if (!allowedPages.Any(page => page.referencia.Equals(fileName, StringComparison.OrdinalIgnoreCase)))
                {
                    // Redirigir a la página 403 si no tiene acceso
                    Response.Redirect("~/InicioSesion/403.aspx");
                }
            }
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
                persona usuario = Session["Usuario"] as persona;
                producto _producto = Session["producto"] as producto;
                _ = productoBO.Producto_aumentar_stock(Convert.ToInt32(_producto.idProducto), usuario.idSede, Convert.ToInt32(cantidadAgregar.Text));
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