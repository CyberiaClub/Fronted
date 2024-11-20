using System;
using SoftCyberiaWA.CyberiaWS;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace SoftCyberiaWA.InicioSesion
{
    public partial class registro_usuario : System.Web.UI.Page
    {
        private PersonaWSClient daopersona = new PersonaWSClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void onClickRegistrarPersona(object sender, EventArgs e)
        {
            persona _persona = new persona();

            _persona.documento = personaDocumento.Text.Trim();
            _persona.telefono = personaTelefono.Text.Trim();
            _persona.nombre = personaNombre.Text.Trim();
            _persona.primerApellido = personaPrimerAp.Text.Trim();
            _persona.segundoApellido = personaSegundoAp.Text.Trim();
            _persona.fechaDeNacimiento = DateTime.Parse(personaFechaNac.Value);
            _persona.fechaDeNacimientoSpecified = true;
            _persona.sexo = personaSexo.Text;
            _persona.correo = personaCorreo.Value.Trim();
            _persona.direccion = personaDireccion.Text.Trim();
            _persona.nacionalidad = personaNacionalidad.Text.Trim();

            switch (Convert.ToInt32(personaTipoDocumento.SelectedValue))
            {
                case 1:
                    _persona.tipoDeDocumento = tipoDocumento.DNI;
                    break;
                case 2:
                    _persona.tipoDeDocumento = tipoDocumento.PASAPORTE;
                    break;
                case 3:
                    _persona.tipoDeDocumento = tipoDocumento.CARNET_DE_EXTRANJERIA;
                    break;

                default:
                    break;

            }
            _persona.tipoDeDocumentoSpecified = true;
            if(personaContraseña.Value == personaContraseña.Value)
            {
                _persona.contrasena = personaContraseña.Value;
            }
            _persona.idTipoPersona = 1;
            _persona.idTipoPersonaSpecified = true;

            daopersona.persona_insertar(_persona);

        }
    
    }
}