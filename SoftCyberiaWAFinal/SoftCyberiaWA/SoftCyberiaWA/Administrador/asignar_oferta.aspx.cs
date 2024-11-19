using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class asignar_oferta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAsignarOferta_Click(object sender, EventArgs e)
        {
            try
            {
                //metodo

                // Mostrar el mensaje de éxito
                successMessage.Text = "Oferta asignada correctamente.";
                successMessage.Visible = true;
            }
            catch (Exception ex)
            {
                // Manejar errores (opcional)
                successMessage.Text = $"Error al registrar el producto: {ex.Message}";
                successMessage.CssClass = "text-danger";
                successMessage.Visible = true;
            }
        

        }
    }
}