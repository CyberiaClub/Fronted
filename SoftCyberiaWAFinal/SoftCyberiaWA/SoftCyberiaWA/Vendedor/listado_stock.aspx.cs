using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
using System;
using System.Web.UI;

namespace SoftCyberiaWA.Vendedor
{
    public partial class listado_stock : Page
    {
        private readonly ProductoBO productoBO;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                panelDetallesProducto.Visible = false; // Oculta el panel al cargar la página
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sku = skuName.Text.Trim();

            if (!string.IsNullOrEmpty(sku))
            {
                // Buscar el _producto por SKU
                // falta implementar
                //producto _producto = productoBO.buscar_producto_sku(sku);
                producto _producto = new producto();
                if (_producto != null)
                {
                    // Mostrar detalles del _producto
                    //lblNombreProducto.Text = _producto.Sede;
                    //lblDescripcionProducto.Text = _producto.Cantidad;

                    // Cargar el inventario en el GridView
                    //gvInventarioSedes.DataSource = _producto.InventarioPorSede;
                    gvInventarioSedes.DataBind();

                    // Hacer visible el panel de detalles del _producto
                    panelDetallesProducto.Visible = true;
                }
                else
                {
                    // Ocultar el panel y mostrar mensaje si el _producto no se encuentra
                    panelDetallesProducto.Visible = false;
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Producto no encontrado');", true);
                }
            }
            else
            {
                // Mostrar una alerta si el SKU está vacío
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Ingrese un SKU válido');", true);
            }
        }
    }
}