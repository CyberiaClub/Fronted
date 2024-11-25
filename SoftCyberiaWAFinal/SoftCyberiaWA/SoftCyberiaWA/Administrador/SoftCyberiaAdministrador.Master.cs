using SoftCyberiaBaseBO.CyberiaWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SoftCyberiaWA.Administrador
{
    public partial class SoftCyberiaAdministrador : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null || Session["paginas"] == null)
            {
                Response.Redirect("~/InicioSesion/indexInicioSesion.aspx");
            }
            // Obtener la ruta completa
            string currentPage = Request.Url.AbsolutePath;

            // Extraer solo el archivo
            string fileName = Path.GetFileName(currentPage);
            if (Session["paginas"] is BindingList<pagina> allowedPages)
            {
                if (!allowedPages.Any(page => page.referencia.Equals(fileName, StringComparison.OrdinalIgnoreCase)))
                {
                    // Redirigir a la página 403 si no tiene acceso
                    Response.Redirect("~/InicioSesion/403.aspx");
                }
                persona p = Session["Usuario"] as persona;
                UserNameLiteral.Text = $"<h5>{p.primerApellido},{p.nombre}</h5>";
                // Generar el menú dinámico
                GenerarMenu(allowedPages);
            }
            else
            {
                Response.Redirect("~/InicioSesion/indexInicioSesion.aspx");
            }

            // Verificar si la página actual está permitida
            //if (!(Session["paginas"] is BindingList<pagina> allowedPages) || !allowedPages.Any(page => page.referencia.Equals(fileName, StringComparison.OrdinalIgnoreCase)))
            //{
            //    // Redirigir a la página 403 si no tiene acceso
            //    Response.Redirect("~/InicioSesion/403.aspx");
            //}
            //GenerarMenu(allowedPages);
        }

        private void GenerarMenu(BindingList<pagina> allowedPages)
        {
            string menuHtml = "";
            persona p = Session["Usuario"] as persona;
            menuHtml += $"<p class='p-1 font-bold'>{p.tipoUsuario}</p>";
            foreach (var page in allowedPages)
            {
                menuHtml += $"<a href='{page.referencia}'><i class='fa-solid fa-calendar-days pe-2'></i>{page.nombre}</a>";
            }
            MenuLiteral.Text = menuHtml;
        }
    }
}