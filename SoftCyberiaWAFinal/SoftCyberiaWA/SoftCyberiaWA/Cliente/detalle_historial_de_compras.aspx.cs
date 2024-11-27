using System;
using System.Web.UI;

namespace SoftCyberiaWA
{
    public partial class Detalle_historial_de_compras : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/InicioSesion/indexInicioSesion.aspx");
            }
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("detalle_carro_de_compras.aspx");
        }
    }
}