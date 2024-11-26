using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaPersonaBO;
using System;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.InicioSesion
{
    public partial class indexInicioSesion : Page
    {
        private readonly PersonaBO personaBO;
        private readonly TipoPersonaBO tipoPersonaBO;

        public indexInicioSesion()
        {
            personaBO = new PersonaBO();
            tipoPersonaBO = new TipoPersonaBO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string correo = personaCorreo.Text.Trim();
            string contrasena = personaContrasena.Text.Trim();
            bool valido = true;
            lblErrorMessage.Text = "";
            lblErrorMessage.Visible = false;
            emailError.InnerText = "";
            emailError.Visible = false;
            passwordError.InnerText = "";
            passwordError.Visible = false;
            if (string.IsNullOrEmpty(correo))
            {
                emailError.InnerText = "Ingrese su correo";
                emailError.Visible = true;
                valido = false;
            }
            if (string.IsNullOrEmpty(contrasena))
            {
                passwordError.InnerText = "Ingrese su contraseña";
                passwordError.Visible = true;
                valido = false;
            }

            if (!valido)
            {
                return;
            }

            Session["Usuario"] = personaBO.persona_loguearse(correo, contrasena);

            if (!(Session["Usuario"] is persona usuario))
            {
                lblErrorMessage.Text = "Usuario o contraseña incorrectos. Por favor, inténtalo nuevamente o regístrate.";
                lblErrorMessage.Visible = true;
                return;
            }

            if (usuario.idPersona == 0)
            {
                lblErrorMessage.Text = "Usuario o contraseña incorrectos. Por favor, inténtalo nuevamente o regístrate.";
                lblErrorMessage.Visible = true;
                return;
            }
            if (usuario.tipoUsuario == "CLIENTE")
            {
                Response.Redirect("~/Cliente/indexCliente.aspx");
            }
            else
            {
                //metodo de back
                tipoPersona paginasPersona = tipoPersonaBO.Tipopersona_listar_paginas(usuario.tipoUsuario);
                // Suponiendo que paginasPersona.paginas es un arreglo (pagina[])
                pagina[] paginasArray = paginasPersona.paginas;
                // Convertir el arreglo en una BindingList<pagina>
                BindingList<pagina> paginasBindingList = new BindingList<pagina>(paginasArray.ToList());
                // Guardar la BindingList en la sesión
                Session["Paginas"] = paginasBindingList;
                //Response.Redirect("~/Administrador/indexAdministrador.aspx");
                Response.Redirect("~/Administrador/registrar_nuevos_proveedores.aspx");
            }
        }

    }
}