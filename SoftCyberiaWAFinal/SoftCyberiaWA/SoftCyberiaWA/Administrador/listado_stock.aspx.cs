using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
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
        private ProductoBO productoBO;
        private SedeBO sedeBO;
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarSedes();
        }

        protected void SearchProductHeadquarters_Click(object sender, EventArgs e)
        {
            //string sku = SKU.Text.Trim();

            //string sku = skuName.Text.Trim();

            //// falta validad el sku
            //producto[] productos = productoBO.producto_buscar_cantidad_sedes(sku);

            //if (productos != null && productos.Length > 0)
            //{
            //    gvInventarioSedes.DataSource = productos;
            //    gvInventarioSedes.DataBind();
            //    panelDetallesProducto.Visible = true;
            //}
            //else
            //{
            //    panelDetallesProducto.Visible = false;
            //    lblTitulo.Text = "Producto no encontrado";

            //}
        }
        private void CargarSedes()
        {
            sedeName.DataSource = sedeBO.sede_listar();
            sedeName.DataTextField = "nombre";
            sedeName.DataValueField = "idSede";
            sedeName.DataBind(); // Llenar el DropDownList
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            

        }
    }
}