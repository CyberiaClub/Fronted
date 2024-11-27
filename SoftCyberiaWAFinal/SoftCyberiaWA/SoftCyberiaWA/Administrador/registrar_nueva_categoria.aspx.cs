using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web.UI;

namespace SoftCyberiaWA.Administrador
{
    public partial class registrar_nueva_categoria : Page
    {
        private readonly TipoProductoBO tipoProductoBO;

        public registrar_nueva_categoria()
        {
            tipoProductoBO = new TipoProductoBO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null || Session["paginas"] == null)
            {
                Response.Redirect("~/InicioSesion/indexInicioSesion.aspx");
            }
            // Obtener la ruta completa
            string currentPage = Request.Url.AbsolutePath;

            // Extraer solo el archivo
            string fileName = Path.GetFileName(currentPage);
            if (!(Session["paginas"] is BindingList<pagina> allowedPages))
            {
                Response.Redirect("~/InicioSesion/indexInicioSesion.aspx");
            }
            else
            {
                if (!allowedPages.Any(page => page.referencia.Equals(fileName, StringComparison.OrdinalIgnoreCase)))
                {
                    // Redirigir a la página 403 si no tiene acceso
                    Response.Redirect("~/InicioSesion/403.aspx");
                }
            }
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            try
            {
                //metodo registrar categoria
                tipoProducto _tipoProducto = new tipoProducto
                {
                    tipo = categoriaName.Text.Trim()
                };
                byte[] imagenBytes;
                using (System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fileUploadNuevaCategoria.PostedFile.InputStream))
                {
                    imagenBytes = binaryReader.ReadBytes(fileUploadNuevaCategoria.PostedFile.ContentLength);
                }
                _tipoProducto.imagen = imagenBytes;

                _ = tipoProductoBO.TipoProducto_insertar(_tipoProducto);



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