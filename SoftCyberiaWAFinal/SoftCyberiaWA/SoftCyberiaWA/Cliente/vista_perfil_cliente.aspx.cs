using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA
{
    public partial class vista_perfil_cliente_aspx : System.Web.UI.Page
    {
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
            string email = "vent1234@cyber.com";
            string phone = "942921807";

            txtEmail.Text = email;
            txtPhone.Text = phone;
        }
       
        protected void SaveChanges(object sender, EventArgs e)
        {
            string newEmail = txtEmail.Text;
            string newPhone = txtPhone.Text;

            // Validar los datos
            if (string.IsNullOrWhiteSpace(newEmail) || string.IsNullOrWhiteSpace(newPhone))
            {
                // Mostrar mensaje de error si es necesario
                return;
            }

            // Guardar los cambios en la base de datos aquí

            // Mostrar mensaje de confirmación
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Perfil actualizado con éxito');", true);

            // Deshabilitar los campos y alternar los botones
            txtEmail.Enabled = false;
            txtPhone.Enabled = false;
            editButtons.Style["display"] = "block";
            saveButtons.Style["display"] = "none";
        }

        //// Suponiendo que la actualización fue exitosa, redirige a la página del perfil
        //Response.Redirect("vista_perfil_cliente.aspx");

        //// Aquí se actualizarían los datos en la base de datos, por ejemplo:
        //string nuevoEmail = txtEmail.Text;
        //string nuevoTelefono = txtPhone.Text;

        //// Supongamos que tienes un método para actualizar el perfil del usuario
        //bool actualizado = ActualizarPerfilUsuario(nuevoEmail, nuevoTelefono);

        //if (actualizado)
        //{
        //    // Redirige al perfil para ver los cambios actualizados
        //    Response.Redirect("vista_perfil_cliente.aspx");
        //}
        //else
        //{
        //    // Manejo de error si no se pudo actualizar
        //    ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('No se pudo actualizar el perfil.');", true);
        //}
    //}

        
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Volver a deshabilitar los campos
            txtEmail.Enabled = false;
            txtPhone.Enabled = false;

            // Alternar la visibilidad de los botones
            editButtons.Style["display"] = "block";
            saveButtons.Style["display"] = "none";
        }

        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            // Hacer los campos editables
            txtEmail.Enabled = true;
            txtPhone.Enabled = true;

            // Alternar la visibilidad de los botones
            editButtons.Style["display"] = "none";
            saveButtons.Style["display"] = "block";
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

        }
    }
}