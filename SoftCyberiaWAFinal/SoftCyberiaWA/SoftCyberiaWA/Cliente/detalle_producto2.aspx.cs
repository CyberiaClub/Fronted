using System;
using System.Web.UI;

namespace SoftCyberiaWA
{
    public partial class Detalle_producto2 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/InicioSesion/indexInicioSesion.aspx");
            }
        }
    }
}