using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaPersonaBO;

namespace SoftCyberiaWA.InicioSesion
{
    public partial class registro_usuario : System.Web.UI.Page
    {
        private PersonaBO personaBO;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void onClickRegistrarPersona(object sender, EventArgs e)
        {
            persona _persona = new persona();
            bool valido = true;

            if (personaTipoDocumento.SelectedIndex == 0)
            {
                tipoDocumentoMensaje.InnerText = $"Seleccione un tipo de documento.";
                valido = false;
            }
            else
            {
                tipoDocumentoMensaje.InnerText = "";
            }
            if (personaDocumento.Text.Trim() == "")
            {
                documentoMensaje.InnerText = $"Ingrese su documento de identidad.";
                valido = false;
            }
            else
            {
                documentoMensaje.InnerText = "";
            }
            if (personaTelefono.Text.Trim() == "")
            {
                telefonoMensaje.InnerText = $"Ingrese su telefono.";
                valido = false;
            }
            else
            {
                telefonoMensaje.InnerText = "";
            }
            if (personaNombre.Text.Trim() == "")
            {
                nombreMensaje.InnerText = $"Ingrese su nombre.";
                valido = false;
            }
            else
            {
                nombreMensaje.InnerText = "";
            }
            if(personaPrimerAp.Text.Trim()== "")
            {
                primerApMensaje.InnerText = $"Ingrese su primer apellido.";
                valido = false;
            }
            else
            {
                primerApMensaje.InnerText = "";
            }
            if (personaSexo.SelectedIndex== 0)
            {
                sexoMensaje.InnerText = $"Ingrese su sexo.";
                valido = false;
            }
            else
            {
                sexoMensaje.InnerText = "";
            }
            if (personaFechaNac.Value == "")
            {
                fechaNacMensaje.InnerText = $"Ingrese su fecha de nacimiento.";
                valido = false;
            }
            else
            {
                fechaNacMensaje.InnerText = "";
            }
            if (personaDireccion.Text.Trim()== "")
            {
                direccionMensaje.InnerText = $"Ingrese su direccion.";
                valido = false;
            }
            else
            {
                direccionMensaje.InnerText = "";
            }
            if (personaNacionalidad.Text.Trim()== "")
            {
                nacionalidadMensaje.InnerText = $"Ingrese su nacionalidad.";
                valido = false;
            }
            else
            {
                nacionalidadMensaje.InnerText = "";
            }
            if (personaCorreo.Value.Trim() == "")
            {
                correoMensaje.InnerText = $"Ingrese su correo.";
                valido = false;
            }
            else
            {
                correoMensaje.InnerText = "";
            }
            if (personaContraseña.Value.Trim() == "" || personaContraseña.Value.Length <= 5)
            {
                contraseñaMensaje.InnerText = $"Ingrese una contraseña valida.";
                valido = false;
            }
            else
            {
                contraseñaMensaje.InnerText = "";
            }
            if (personaConfirmarContraseña.Value.Trim() == "" && personaContraseña.Value.Trim() != "")
            {
                confirmarContraseñaMensaje.InnerText = $"Ingrese su contraseña nuevamente.";
            }
            else if (personaContraseña.Value.Trim() != personaConfirmarContraseña.Value.Trim())
            {
                confirmarContraseñaMensaje.InnerText = $"Las contraseñas no coinciden";
            }
            else
            {
                tipoDocumentoMensaje.InnerText = "";
            }
            
            if (valido)
            {
                _persona.documento = personaDocumento.Text.Trim();
                _persona.telefono = personaTelefono.Text.Trim();
                _persona.nombre = personaNombre.Text.Trim();
                _persona.primerApellido = personaPrimerAp.Text.Trim();
                _persona.segundoApellido = personaSegundoAp.Text.Trim();
                _persona.fechaDeNacimiento = DateTime.Parse(personaFechaNac.Value);
                _persona.fechaDeNacimientoSpecified = true;
                _persona.sexo = personaSexo.Text;
                _persona.correo = personaCorreo.Value.Trim();
                _persona.contrasena = personaContraseña.Value;
                _persona.direccion = personaDireccion.Text.Trim();
                _persona.nacionalidad = personaNacionalidad.Text.Trim();
                _persona.tipoDeDocumentoSpecified = true;
                _persona.idTipoPersona = 1;
                _persona.idTipoPersonaSpecified = true; 

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
                personaBO.persona_insertar(_persona);
            }

        }
    
    }
}