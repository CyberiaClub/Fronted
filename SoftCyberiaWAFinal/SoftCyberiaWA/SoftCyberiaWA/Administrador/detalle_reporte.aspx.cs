using SoftCyberiaInventarioBO;
using SoftCyberiaPersonaBO;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{/*
    public partial class detalle_reporte : Page
    {
        private readonly ProductoBO productoBO;
        private readonly PersonaBO personaBO;
        private readonly SedeBO sedeBO;
        public detalle_reporte()
        {
            productoBO = new ProductoBO();
            personaBO = new PersonaBO();
            sedeBO = new SedeBO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarSedes();  
        }
        private void CargarSedes()
        {
            sedeNombre.DataSource = sedeBO.Sede_listar();
            sedeNombre.DataTextField = "nombre";
            sedeNombre.DataValueField = "idSede";
            sedeNombre.DataBind();

            sedeNombre.Items.Insert(0, new ListItem("Seleccione una Sede", "0"));
            sedeNombre.SelectedIndex = 0;
        }
        
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            byte[] reporte = this.productoBO.ReporteProducto(sedeNombre.SelectedIndex);
            Response.Clear();
            Response.ContenType = "application/pdf";
            Response.AddHeader("Content-Disposition", "inline;filename=ReporteStockProductos.pdf");
            Response.BinaryWrite(reporte);
            Response.End();
        }
        protected void btnTop_Click(object sender, EventArgs e)
        {
            byte[] reporte = this.personaBO.reporteTopClientes();
            Reposnse.Clear();
            Response.ContenType = "application/pdf";
            Response.AddHeader("Content-Disposition", "inline;filename=ReporteTopClientes.pdf");
            Response.BinaryWrite(reporte);
            Response.End();
        }
    }
    */
}