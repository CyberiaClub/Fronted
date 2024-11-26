using System;
using System.Text.RegularExpressions;
using System.Web.UI;
using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaPersonaBO;


namespace SoftCyberiaWA.InicioSesion
{
    public partial class registro_usuario : Page
    {
        private readonly PersonaBO personaBO;
        // Clase para deserializar la respuesta de la API
        
        public registro_usuario()
        {
            personaBO = new PersonaBO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void onClickRegistrarPersona(object sender, EventArgs e)
        {
            try
            {
                persona _persona = new persona();
                bool valido = true;
                valido &= ValidarTipoDocument();
                valido &= ValidarDocument();
                valido &= ValidarTelefono();
                valido &= ValidarNombre();
                valido &= ValidarPrimerApellido();
                valido &= ValidarSegundoApellido();
                valido &= ValidarFecha();
                valido &= ValidarSexo();
                valido &= ValidarDireccion();
                valido &= ValidarNacionalidad();
                valido &= ValidarCorreo();
                valido &= ValidarContrasena();
                valido &= ValidarSegundaContrasena();
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
                    _persona.nacionalidad = nacionalidad.Text.Trim();
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
                    _ = personaBO.Persona_insertar(_persona);
                    successMessage.InnerText = "Se registró la persona con éxito. Revise su correo para validar su cuenta";
                    successMessage.Visible = true;
                }

            }
            catch (Exception ex)
            {
                successMessage.InnerText = $"Error: No se pudo registrar la cuenta {ex.Message}";
                //successMessage. = "text-danger";
                successMessage.Visible = true;
            }
        }

        private bool ValidarTipoDocument()
        {
            tipoDocumentoMensaje.InnerText = ""; // Limpia cualquier mensaje previo
            tipoDocumentoMensaje.Visible = false;
            // Verifica si el valor seleccionado es "0" (opción por defecto)
            if (personaTipoDocumento.SelectedValue == "0")
            {
                tipoDocumentoMensaje.InnerText = "Por favor, seleccione un tipo de documento válido.";
                tipoDocumentoMensaje.Visible = true;
                return false; // Retorna falso porque no es válido
            }

            return true; // Retorna verdadero si se seleccionó un valor válido
        }
        private bool ValidarDocument()
        {
            string documento = personaDocumento.Text.Trim();
            string pattern = @"^\d+$";
            bool isNumeric = Regex.IsMatch(documento, pattern);
            documentoMensaje.InnerText = "";
            documentoMensaje.Visible = false;
            if (!isNumeric)
            {
                documentoMensaje.InnerText = "Por favor, el documento solo puede contener números.";
                documentoMensaje.Visible = true;
            }
            return isNumeric;
        }
        private bool ValidarTelefono()
        {
            string telefono = personaTelefono.Text.Trim();
            string pattern = @"^\d{9}$";
            bool isNumeric = Regex.IsMatch(telefono, pattern);
            telefonoMensaje.InnerText = "";
            telefonoMensaje.Visible = false;
            if (!isNumeric)
            {
                telefonoMensaje.InnerText = "Por favor, ingrese un número de telefono valido";
                telefonoMensaje.Visible = true;
            }
            return isNumeric;
        }
        private bool ValidarNombre()
        {
            string nombre = personaNombre.Text.Trim();
            string pattern = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\s]+$";
            bool isNumeric = Regex.IsMatch(nombre, pattern);
            nombreMensaje.InnerText = "";
            nombreMensaje.Visible = false;
            if (!isNumeric || string.IsNullOrWhiteSpace(nombre))
            {
                nombreMensaje.InnerText = "Por favor, ingrese un nombre válido sin números ni símbolos especiales.";
                nombreMensaje.Visible = true;
            }
            return isNumeric;
        }
        private bool ValidarPrimerApellido()
        {
            string primerApellido = personaPrimerAp.Text.Trim();
            string pattern = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\s]+$";
            bool isNumeric = Regex.IsMatch(primerApellido, pattern);
            primerApMensaje.InnerText = "";
            primerApMensaje.Visible = false;
            if (!isNumeric || string.IsNullOrWhiteSpace(primerApellido))
            {
                primerApMensaje.InnerText = "Por favor, ingrese un apellido válido sin números ni símbolos especiales.";
                primerApMensaje.Visible = true;
            }
            return isNumeric;
        }
        private bool ValidarSegundoApellido()
        {
            string segundoApellido = personaSegundoAp.Text.Trim();
            string pattern = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\s]+$";
            bool isNumeric = Regex.IsMatch(segundoApellido, pattern);
            segundoApMensaje.InnerText = "";
            segundoApMensaje.Visible = false;
            if (!isNumeric)
            {
                segundoApMensaje.InnerText = "Por favor, ingrese un apellido válido sin números ni símbolos especiales.";
                segundoApMensaje.Visible = true;
            }
            return isNumeric;
        }
        private bool ValidarFecha()
        {
            fechaNacMensaje.InnerText = "";
            fechaNacMensaje.Visible = false;
            if (string.IsNullOrWhiteSpace(personaFechaNac.Value) || !DateTime.TryParse(personaFechaNac.Value, out DateTime fecha))
            {
                fechaNacMensaje.InnerText = "Por favor, ingrese una fecha válida.";
                fechaNacMensaje.Visible = true;
                return false;
            }

            //DateTime fecha = DateTime.Parse(personaFechaNac.Value);
            bool valido = false;
            if (personaFechaNac != null)
            {
                int edad = DateTime.Now.Year - fecha.Year;
                if (fecha > DateTime.Now.AddYears(-edad))
                {
                    edad--;
                }

                // Validar si la persona tiene al menos 15 años
                if (edad < 15)
                {
                    fechaNacMensaje.InnerText = "Tiene que ser mayor de 15 años.";
                    fechaNacMensaje.Visible = true;
                    return valido;
                }
                valido = true;
            }
            else
            {
                fechaNacMensaje.InnerText = "Tiene que ser mayor de 15 años.";
                fechaNacMensaje.Visible = true;
            }

            return valido;
        }
        private bool ValidarSexo()
        {
            sexoMensaje.InnerText = "";
            sexoMensaje.Visible = false;
            if (personaSexo.SelectedValue == "0")
            {
                sexoMensaje.InnerText = "Por favor, seleccione un sexo válido.";
                sexoMensaje.Visible = true;
                return false;
            }
            return true;
        }
        private bool ValidarDireccion()
        {
            direccionMensaje.InnerText = "";
            direccionMensaje.Visible = false;
            if (string.IsNullOrEmpty(personaDireccion.Text.Trim()))
            {
                direccionMensaje.InnerText = "Por favor, ingrese su direccion";
                direccionMensaje.Visible = true;
                return false;
            }
            return true;
        }
        private bool ValidarNacionalidad()
        {
            nacionalidadMensaje.InnerText = "";
            nacionalidadMensaje.Visible = false;
            if (string.IsNullOrWhiteSpace(nacionalidad.Text.Trim()) || string.IsNullOrEmpty(nacionalidad.Text))
            {
                nacionalidadMensaje.InnerText = "Por favor, seleccione o escriba una nacionalidad válida.";
                nacionalidadMensaje.Visible = true;
                return false;
            }
            return true;
        }
        private bool ValidarCorreo()
        {
            correoMensaje.InnerText = "";
            correoMensaje.Visible = false;
            if (string.IsNullOrWhiteSpace(personaCorreo.Value.Trim()))
            {
                correoMensaje.InnerText = "Por favor, ingresar un correo valido";
                correoMensaje.Visible = true;
            }
            return true;
        }
        private bool ValidarContrasena()
        {
            contraseñaMensaje.InnerText = "";
            contraseñaMensaje.Visible = false;
            if (string.IsNullOrWhiteSpace(personaContraseña.Value.Trim()))
            {
                contraseñaMensaje.InnerText = "La contraseñan no puede estar vacia";
                contraseñaMensaje.Visible = true;
                return false;
            }
            if (personaContraseña.Value.Length < 8)
            {
                contraseñaMensaje.InnerText = "La contraseña debe tener mínimo 8 caracteres";
                contraseñaMensaje.Visible = true;
                return false;
            }
            string pattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$";
            if (!Regex.IsMatch(personaContraseña.Value.Trim(), pattern))
            {
                contraseñaMensaje.InnerText = "El texto debe contener al menos una letra mayúscula, un carácter especial y un número.";
                contraseñaMensaje.Visible = true;
                return false;
            }
            return true;
        }

        private bool ValidarSegundaContrasena()
        {
            string contrasena = personaContraseña.Value; // Primera contraseña
            string confirmarContrasena = personaConfirmarContraseña.Value;// Segunda contraseña
            confirmarContraseñaMensaje.InnerText = "";
            confirmarContraseñaMensaje.Visible = false;
            if (string.IsNullOrWhiteSpace(contrasena) || string.IsNullOrWhiteSpace(confirmarContrasena))
            {
                confirmarContraseñaMensaje.InnerText = "Ambos campos de contraseña son obligatorios.";
                confirmarContraseñaMensaje.Visible = true;
                return false; // Detener ejecución si faltan contraseñas
            }
            if (contrasena != confirmarContrasena)
            {
                confirmarContraseñaMensaje.InnerText = "Las contraseñas no coinciden. Por favor, inténtelo nuevamente.";
                confirmarContraseñaMensaje.Visible = true;
                return false; // Detener ejecución si no coinciden
            }
            return true;
        }

    }
}