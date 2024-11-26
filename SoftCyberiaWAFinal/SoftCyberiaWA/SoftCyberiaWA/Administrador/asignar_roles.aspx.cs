using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
using SoftCyberiaPersonaBO;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class Asignar_roles : Page
    {
        private readonly PersonaBO personaBO;
        private readonly SedeBO sedeBO;
        private persona _persona = new persona();

        public Asignar_roles()
        {
            personaBO = new PersonaBO();
            sedeBO = new SedeBO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSedes();
            }
        }

        protected void Dni_Ingresado(object sender, EventArgs e)
        {
            bool validar = true;
            nombre.Text = "";
            correo.Text = "";
            telefono.Text = "";
            direccion.Text = "";

            bool validarTipoDoc = ValidarCampo(null, tipoDocumentoMensaje, "Por seleccionetipo de documento.", true, tipo_documento);
            bool validarDni = ValidarCampo(dni, dniMensaje, "Por favor ingrese un dni.");

            if (validarTipoDoc && validarDni)
            {

                switch (tipo_documento.SelectedIndex)
                {
                    case 1:
                        validar = dni.Text.Length == 8;
                        break;
                    case 2:
                        validar = dni.Text.Length <= 20;
                        break;
                    case 3:
                        validar = dni.Text.Length <= 20;
                        break;
                    default:
                        break;
                }
                if (validar)
                {
                    dniMensaje.Visible = false;
                    _persona = personaBO.Persona_buscar_por_documento(dni.Text.ToString());
                    if (_persona != null)
                    {
                        nombre.Text = _persona.nombre;
                        correo.Text = _persona.correo;
                        telefono.Text = _persona.telefono;
                        direccion.Text = _persona.direccion;
                    }
                    else
                    {
                        dniMensaje.InnerText = "Ingrese un dni valido.";
                        dniMensaje.Visible = true;
                    }
                }
            }
        }

        private void CargarSedes()
        {
            sede.DataSource = sedeBO.Sede_listar();
            sede.DataTextField = "nombre";
            sede.DataValueField = "idSede";
            sede.DataBind();
        }

        protected void BtnAsignar_Click(object sender, EventArgs e)
        {

            persona _persona = new persona();
            successMessage.Visible = false;
            successMessage.Text = "";
            if (Validar())
            {
                string rolSeleccionado = rol.SelectedValue.ToString();
                _persona.idTipoPersona = rolSeleccionado == "Almacén" ? 4 : 3;
                _persona.idTipoPersonaSpecified = true;
                _persona.sueldo = Convert.ToDouble(sueldo.Text);
                _persona.sueldoSpecified = true;
                _persona.idSede = Convert.ToInt32(sede.SelectedValue);
                _persona.idSedeSpecified = true;
                _persona.nombre = nombre.Text;
                _persona.correo = correo.Text;
                _persona.telefono = telefono.Text;
                _persona.direccion = direccion.Text;
                _persona.documento = dni.Text;
                _persona.tipoDeDocumento = (tipoDocumento)Enum.Parse(typeof(tipoDocumento), tipo_documento.SelectedValue);
                _persona.tipoDeDocumentoSpecified = true;

                _ = personaBO.Persona_insertar(_persona);
                successMessage.Visible = true;
                successMessage.Text = "Rol asignado exitosamente.";
            }
        }

        protected bool Validar()
        {
            bool validarTipoDoc = ValidarCampo(null, tipoDocumentoMensaje, "Por favor seleccione un tipo de documento.", true, tipo_documento);
            bool validarDni = ValidarCampo(dni, dniMensaje, "Por favor ingrese un dni.");
            bool validaRol = ValidarCampo(null, rolMensaje, "Por favor seleccione un rol para el trabajador.", true, rol);
            bool validarSueldo = ValidarCampo(sueldo, sueldoMensaje, "Por favor ingrese un sueldo válido.");
            bool validarSede = ValidarCampo(null, sedeMensaje, "Por favor seleccione una sede.", true, sede);

            return validarTipoDoc && validarDni && validaRol && validarSueldo && validarSede;
        }

        private bool ValidarCampo(TextBox campo, HtmlGenericControl mensaje, string textoError, bool esCombo = false, DropDownList combo = null)
        {
            bool valido;
            if (esCombo)
            {
                if (combo.SelectedIndex == 0)
                {
                    valido = false;
                    mensaje.InnerText = textoError;
                    mensaje.Visible = true;
                }
                else
                {
                    valido = true;
                    mensaje.Visible = false;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(campo.Text))
                {
                    valido = false;
                    mensaje.InnerText = textoError;
                    mensaje.Visible = true;
                }
                else
                {
                    valido = true;
                    mensaje.Visible = false;
                }
            }
            return valido;
        }
    }
}