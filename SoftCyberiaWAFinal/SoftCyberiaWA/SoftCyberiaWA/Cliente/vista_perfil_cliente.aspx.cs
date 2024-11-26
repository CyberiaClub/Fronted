using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaPersonaBO;
using System;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace SoftCyberiaWA
{
    public partial class Vista_perfil_cliente_aspx : Page
    {
        private readonly PersonaBO personaBO;

        public Vista_perfil_cliente_aspx()
        {
            personaBO = new PersonaBO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserProfile();
            }
            ////Carga los datos del perfil sin verificar `IsPostBack`
            //CargarDatosPerfil();
        }


        private void LoadUserProfile()
        {
            // Ejemplo de carga de datos del usuario. Aquí deberías llamar a tu servicio o base de datos.
            persona usuario = Session["Usuario"] as persona;
            txtEmail.Text = usuario.correo;
            txtPhone.Text = usuario.telefono;
            txtDireccion.Text = usuario.direccion;
        }

        protected void SaveChanges(object sender, EventArgs e)
        {
            bool validacion = ValidarDatos();

            // Guardar los cambios en la base de datos aquí
            if (validacion)
            {
                persona usuario = Session["Usuario"] as persona;
                usuario.telefono = txtPhone.Text.Trim();
                usuario.direccion = txtDireccion.Text.Trim();
                usuario.correo = txtEmail.Text.Trim();
                _ = personaBO.Persona_modificar(usuario);
                // Mostrar mensaje de confirmación
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Perfil actualizado con éxito');", true);

                // Deshabilitar los campos y alternar los botones
                txtEmail.Enabled = false;
                txtPhone.Enabled = false;
                txtDireccion.Enabled = false;
                editButtons.Style["display"] = "block";
                saveButtons.Style["display"] = "none";
            }
        }
        private bool ValidarDatos()
        {
            bool v = true;
            v &= ValidarTelefono();
            v &= ValidarEmail();
            v &= ValidarDireccion();
            return v;
        }
        private bool ValidarTelefono()
        {
            string telefono = txtPhone.Text.Trim();
            string pattern = @"^\d{9}$";
            bool isNumeric = Regex.IsMatch(telefono, pattern);
            errorPhone.InnerText = "";
            errorPhone.Visible = false;
            if (!isNumeric && telefono.Length == 9)
            {
                errorPhone.InnerText = "Por favor, ingrese un número de telefono valido";
                errorPhone.Visible = true;
            }
            return isNumeric;
        }
        private bool ValidarEmail()
        {
            errorEmail.InnerText = "";
            errorEmail.Visible = false;
            if (string.IsNullOrWhiteSpace(txtEmail.Text.Trim()))
            {
                errorEmail.InnerText = "Por favor, ingresar un correo valido";
                errorEmail.Visible = true;
            }
            return true;
        }

        private bool ValidarDireccion()
        {
            errorDireccion.InnerText = "";
            errorDireccion.Visible = false;
            if (string.IsNullOrEmpty(txtDireccion.Text.Trim()))
            {
                errorDireccion.InnerText = "Por favor, ingrese su direccion";
                errorDireccion.Visible = true;
                return false;
            }
            return true;
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            // Volver a deshabilitar los campos
            txtEmail.Enabled = false;
            txtPhone.Enabled = false;
            txtDireccion.Enabled = false;

            // Alternar la visibilidad de los botones
            editButtons.Style["display"] = "block";
            saveButtons.Style["display"] = "none";
        }

        protected void BtnEditProfile_Click(object sender, EventArgs e)
        {
            // Hacer los campos editables
            txtEmail.Enabled = true;
            txtPhone.Enabled = true;
            txtDireccion.Enabled = true;

            // Alternar la visibilidad de los botones
            editButtons.Style["display"] = "none";
            saveButtons.Style["display"] = "block";
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {

        }
    }
}