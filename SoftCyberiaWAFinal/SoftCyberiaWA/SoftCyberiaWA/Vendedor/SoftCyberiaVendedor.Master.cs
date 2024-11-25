using System;
using System.Web.UI;

namespace SoftCyberiaWA.Vendedor
{
    public partial class SoftCyberiaVendedor : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RolUsuario"] == null || Session["paginas"] == null)
            {
                Response.Redirect("~/InicioSesion/indexInicioSesion.aspx");
            }
        }
    }
}