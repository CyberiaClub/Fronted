using SoftCyberiaBaseBO.CyberiaWS;
using System;
using System.Web.UI;

namespace SoftCyberiaWA.InicioSesion
{
    public partial class Formulario_web1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/InicioSesion/indexInicioSesion.aspx");
            }
            persona p = Session["Usuario"] as persona;
            UserNameLiteral.Text = $"<h1>{p.primerApellido}, {p.nombre}</h1>";
            Session.Clear();
            Session.Abandon();
        }
    }
}