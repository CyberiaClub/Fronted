using SoftCyberiaBaseBO.CyberiaWS;
using System;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.IO;

namespace SoftCyberiaWA.Administrador
{
    public partial class SoftCyberiaAdministrador : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RolUsuario"] == null || Session["paginas"] == null)
            {
                Response.Redirect("~/InicioSesion/indexInicioSesion.aspx");
            }
            // Obtener la ruta completa
            string currentPage = Request.Url.AbsolutePath;

            // Extraer solo el archivo
            string fileName = Path.GetFileName(currentPage);

            // Verificar si la página actual está permitida
            if (!(Session["paginas"] is BindingList<pagina> allowedPages) || !allowedPages.Any(page => page.referencia.Equals(fileName, StringComparison.OrdinalIgnoreCase)))
            {
                // Redirigir a la página 403 si no tiene acceso
                Response.Redirect("~/InicioSesion/403.aspx");
            }
        }
    }
}