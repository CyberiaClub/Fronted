using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCyberiaWA.CyberiaWS;

namespace SoftCyberiaWA.InicioSesion
{
    public partial class indexInicioSesion : System.Web.UI.Page
    {
        PersonaWSClient daoPersona = new PersonaWSClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            persona _persona = new persona();
            _persona.correo = personaCorreo.Text;
            _persona.contrasena = personaContrasena.Text;

            string tipoPersona = daoPersona.inicioSesion(_persona);

            if (tipoPersona == null)
            {
                Response.Write("<script>alert('Registra tu Cuenta')</script>");
            }
            else if (tipoPersona == "Administrador" || tipoPersona == "Vendedor" || tipoPersona == "Almacenero")
            {
                Response.Redirect("~/Administrador/indexAdministrador.aspx");
                //metodo de back
                pagina[] paginasPersona = daoPersona.obtenerPaginasPersona(tipoPersona);

                //< a href = "detalle_reporte.aspx" >< i class="fa-solid fa-calendar-days pe-2"></i>Generar reporte</a>
                foreach(pagina _pagina in paginasPersona)
                {

                    Literal menuHtml = new Literal();
                    menuHtml.Text = $@"
                            
                    < a href = '{_pagina.referencia}' >< i class=""fa-solid fa-calendar-days pe-2""></i>'{_pagina.nombre}'</a>";
                    menuContainer.Controls.Add(menuHtml);
                }

            }
            else if (tipoPersona == "Cliente")
            {
                Response.Redirect("~/Cliente/indexCliente.aspx");

            }
        }





    }
}