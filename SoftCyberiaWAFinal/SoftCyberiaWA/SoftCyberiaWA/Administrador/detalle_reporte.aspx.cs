using System;
using System.Web.UI;

namespace SoftCyberiaWA.Administrador
{
    public partial class detalle_reporte : Page
    {
        private ProductoBO productoBO;
        private PersonaBo personaBO;
        public reporte_producto()
        {
            this.productoBO = new ProductoBO();
            this.personaBO = new PersonaBo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarSedes();
           
        }
        private void CargarSedes()
        {
            sedeNombre.DataSource = sedeBO.sede_listar();
            sedeNombre.DataTextField = "nombre";
            sedeNombre.DataValueField = "idSede";
            sedeNombre.DataBind();

            sedeNombre.Items.Insert(0, new ListItem("Seleccione una Sede", "0"));
            sedeNombre.SelectedIndex = 0;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            byte[] reporte = this.productoBO.reporteProducto(sedeNombre.SelectedIndex);
            Reposnse.Clear();
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
}