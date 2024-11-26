using System;
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
        }
    }
}