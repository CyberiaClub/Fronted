using SoftCyberiaWA.CyberiaWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Vendedor
{
    public partial class listado_stock : System.Web.UI.Page
    {
        private ProductoWS daoProducto = new ProductoWS();
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
                // Buscar el producto por SKU
                Producto producto = daoProducto.buscar_producto_sku(sku);

                if (producto != null)
                {
                    // Mostrar detalles del producto
                    lblNombreProducto.Text = producto.Sede;
                    lblDescripcionProducto.Text = producto.Cantidad;

                    // Cargar el inventario en el GridView
                    gvInventarioSedes.DataSource = producto.InventarioPorSede;
                    gvInventarioSedes.DataBind();

                    // Hacer visible el panel de detalles del producto
                    panelDetallesProducto.Visible = true;
                }
                else
                {
                    // Ocultar el panel y mostrar mensaje si el producto no se encuentra
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