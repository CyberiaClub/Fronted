using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
using SoftCyberiaPersonaBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class registrar_nueva_categoria : System.Web.UI.Page
    {
        private TipoProductoBO tipoProductoBO;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            try
            {
                //metodo registrar categoria
                tipoProducto _tipoProducto = new tipoProducto();
                _tipoProducto.tipo = categoriaName.Text.Trim();
                byte[] imagenBytes;
                using (var binaryReader = new System.IO.BinaryReader(fileUploadNuevaCategoria.PostedFile.InputStream))
                {
                    imagenBytes = binaryReader.ReadBytes(fileUploadNuevaCategoria.PostedFile.ContentLength);
                }
                _tipoProducto.imagen = imagenBytes;

                this.tipoProductoBO.tipoProducto_insertar(_tipoProducto);



                // Mostrar el mensaje de éxito
                successMessage.Text = "Categoría registrada correctamente.";
                successMessage.Visible = true;
            }
            catch (Exception ex)
            {
                // Manejar errores (opcional)
                successMessage.Text = $"Error al registrar la categoría: {ex.Message}";
                successMessage.CssClass = "text-danger";
                successMessage.Visible = true;
            }

        }
    }
}