using System;
using System.Web.UI;

namespace SoftCyberiaWA.Almacenero
{
    public partial class Almacenero : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null || Session["paginas"] == null)
            {
                Response.Redirect("~/InicioSesion/indexInicioSesion.aspx");
            }
        }
    }
}