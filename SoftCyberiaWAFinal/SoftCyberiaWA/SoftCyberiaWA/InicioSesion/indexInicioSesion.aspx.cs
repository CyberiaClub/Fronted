using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaPersonaBO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.InicioSesion
{
    public partial class indexInicioSesion : System.Web.UI.Page
    {
        private PersonaBO personaBO;
        private TipoPersonaBO tipoPersonaBO;

        public indexInicioSesion()
        {
            this.personaBO = new PersonaBO();
            this.tipoPersonaBO = new TipoPersonaBO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            string correo = personaCorreo.Text.Trim();
            string contrasena = personaContrasena.Text.Trim();
            bool valido = true;
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

            Session["RolUsuario"] = personaBO.persona_loguearse(correo, contrasena);
            persona usuario = Session["RolUsuario"] as persona;
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
                tipoPersona paginasPersona = this.tipoPersonaBO.tipopersona_listar_paginas(usuario.tipoUsuario);
                // Suponiendo que paginasPersona.paginas es un arreglo (pagina[])
                pagina[] paginasArray = paginasPersona.paginas;
                // Convertir el arreglo en una BindingList<pagina>
                BindingList<pagina> paginasBindingList = new BindingList<pagina>(paginasArray.ToList());
                // Guardar la BindingList en la sesión
                Session["Paginas"] = paginasBindingList;
                Response.Redirect("~/Administrador/indexAdministrador.aspx");
            }
        }

    }
}