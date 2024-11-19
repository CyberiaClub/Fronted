using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class registrar_produtco_compuesto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAsignarPrdocuto_Click(object sender, EventArgs e)
        {

        }

        protected void btnAsignarOferta_Click(object sender, EventArgs e)
        {

        }

        protected void btnCrearKit_Click(object sender, EventArgs e)
        {
            try
            {

                //metodo para registrar producto compuesto


                // Mostrar el mensaje de éxito
                successMessage.Text = "Producto Compuesto registrado correctamente.";
                successMessage.Visible = true;
            }
            catch (Exception ex)
            {
                // Manejar errores (opcional)
                successMessage.Text = $"Error al registrar el producto compuesto: {ex.Message}";
                successMessage.CssClass = "text-danger";
                successMessage.Visible = true;
            }
        

        }
    }
}