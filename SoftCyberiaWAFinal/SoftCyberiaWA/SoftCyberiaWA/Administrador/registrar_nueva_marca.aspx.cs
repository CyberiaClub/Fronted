using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class registrar_nueva_marca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            try
            {

                //metodo para registrar una nueva marca




                // Mostrar el mensaje de éxito
                successMessage.Text = "Marca registrada correctamente.";
                successMessage.Visible = true;
            }
            catch (Exception ex)
            {
                // Manejar errores (opcional)
                successMessage.Text = $"Error al registrar la marca: {ex.Message}";
                successMessage.CssClass = "text-danger";
                successMessage.Visible = true;
            }
        }
    }
}