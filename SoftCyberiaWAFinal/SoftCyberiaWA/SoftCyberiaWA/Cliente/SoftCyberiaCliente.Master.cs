using System;
using System.Web;
using System.Web.UI;

namespace SoftCyberiaWA.Cliente
{
    public partial class SoftCyberiaCliente : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/InicioSesion/indexInicioSesion.aspx");
            }

            // Obtener el nombre de la página actual
            string currentPage = HttpContext.Current.Request.Url.AbsolutePath.ToLower();

            // Comprobar si la página actual es "listado_productos.aspx"
            if (currentPage.Contains("listado_productos.aspx") || currentPage.Contains("detalle_producto.aspx"))
            {
                footerMaster.Visible = false;
            }

        }
    }
}