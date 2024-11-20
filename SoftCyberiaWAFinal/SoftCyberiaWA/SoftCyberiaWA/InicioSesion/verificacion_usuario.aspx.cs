using System;
using SoftCyberiaWA.CyberiaWS;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.InicioSesion
{
    public partial class verificacion_usuario : System.Web.UI.Page
    {
        private PersonaWSClient daoPersona = new PersonaWSClient();
        private String mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string token = Request.QueryString["token"];
            daoPersona.persona_verificar_correo(token);
        }
    }
}