using System;
using System.Web.UI;
using SoftCyberiaPersonaBO;

namespace SoftCyberiaWA.InicioSesion
{
    public partial class verificacion_usuario : Page
    {
        private readonly PersonaBO personaBO;

        public verificacion_usuario()
        {
            personaBO = new PersonaBO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string token = Request.QueryString["token"];
            verificacionMensaje.InnerText = personaBO.Persona_verificar_correo(token) == -1
                ? "Hubo un error durante la verificación de su cuenta."
                : "Se verificó la cuenta con éxito. Puede cerrar esta ventana.";
        }
    }
}