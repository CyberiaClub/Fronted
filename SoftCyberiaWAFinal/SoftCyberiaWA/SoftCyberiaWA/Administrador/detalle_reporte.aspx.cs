using SoftCyberiaInventarioBO;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class detalle_reporte : Page
    {
        //private ProductoBO productoBO;
        //private PersonaBo personaBO;
        private SedeBO sedeBO;
        public detalle_reporte()
        {
            //this.productoBO = new ProductoBO();
            //this.personaBO = new PersonaBo();
            this.sedeBO = new SedeBO();
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

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            //byte[] reporte = this.productoBO.reporteStock(sedeNombre.SelectedIndex);
            //Response.Clear();
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("Content-Disposition", "inline;filename=ReporteStockProductos.pdf");
            //Response.BinaryWrite(reporte);
            //Response.End();
        }
        protected void BtnTop_Click(object sender, EventArgs e)
        {
            //byte[] reporte = this.personaBO.reporteClientes(sedeNombre.SelectedIndex);
            //Response.Clear();
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("Content-Disposition", "inline;filename=ReporteTopClientes.pdf");
            //Response.BinaryWrite(reporte);
            //Response.End();
        }



    }
}