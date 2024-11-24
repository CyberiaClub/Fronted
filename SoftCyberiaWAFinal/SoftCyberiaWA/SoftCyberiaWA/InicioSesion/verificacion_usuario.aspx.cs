using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCyberiaPersonaBO;

namespace SoftCyberiaWA.InicioSesion
{
    public partial class verificacion_usuario : System.Web.UI.Page
    {
        private PersonaBO personaBO;

        public verificacion_usuario()
        {
            this.personaBO = new PersonaBO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string token = Request.QueryString["token"];
            if (personaBO.persona_verificar_correo(token) == -1)
            {
                verificacionMensaje.InnerText = "Hubo un error durante la verificación de su cuenta.";
            }
            else
            {
                verificacionMensaje.InnerText = "Se verificó la cuenta con éxito. Puede cerrar esta ventana.";
            }
        }
    }
}