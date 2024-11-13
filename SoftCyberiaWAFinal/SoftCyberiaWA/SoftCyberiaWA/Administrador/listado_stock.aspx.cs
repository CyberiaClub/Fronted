using SoftCyberiaWA.CyberiaWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class listado_stock : System.Web.UI.Page
    {
        ProductoWSClient daoProducto = new ProductoWSClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchProductHeadquarters_Click(object sender, EventArgs e)
        {
            string sku = SKU.Text.Trim();
            // falta validad el sku
            producto[] productos = daoProducto.producto_buscar_cantidad_sedes(sku);

            
            if (productos != null && productos.Length > 0) 
            {
                gvInventarioSedes.DataSource = productos;
                gvInventarioSedes.DataBind();
                panelDetallesProducto.Visible = true;
            }
            else
            {
                panelDetallesProducto.Visible = false;
                lblTitulo.Text = "Producto no encontrado";
            }
        }
    }
}