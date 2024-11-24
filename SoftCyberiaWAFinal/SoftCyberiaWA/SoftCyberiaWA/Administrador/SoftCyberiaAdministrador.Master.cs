using SoftCyberiaBaseBO.CyberiaWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class SoftCyberiaAdministrador : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RolUsuario"] == null || Session["paginas"] == null)
            {
                Response.Redirect("~/InicioSesion/indexInicioSesion.aspx");
            }
            string currentPage = Request.Url.AbsolutePath;
            // Verificar si la página actual está permitida
            if (!(Session["AllowedPages"] is BindingList<pagina> allowedPages) || !allowedPages.Any(page => page.referencia.Equals(currentPage, StringComparison.OrdinalIgnoreCase)))
            {
                // Redirigir a la página 403 si no tiene acceso
                Response.Redirect("~/InicioSesion/403.aspx");
            }
        }
    }
}