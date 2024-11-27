using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web.UI;

namespace SoftCyberiaWA.Administrador
{
    public partial class registrar_nueva_marca : Page
    {
        private readonly MarcaBO marcaBO;
        private readonly ProveedorBO proveedorBO;

        public registrar_nueva_marca()
        {
            marcaBO = new MarcaBO();
            proveedorBO = new ProveedorBO();
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
            CargarProveedores();
        }

        private void CargarProveedores()
        {
            providerName.DataSource = proveedorBO.Proveedor_listar();
            providerName.DataTextField = "razonSocial";
            providerName.DataValueField = "idProveedor";
            providerName.DataBind(); // Llenar el DropDownList
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            try
            {

                //metodo para registrar una nueva marca
                marca _marca = new marca
                {
                    nombre = marcaName.Text.Trim()
                };


                byte[] imagenBytes;
                using (System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fileUploadNuevaMarca.PostedFile.InputStream))
                {
                    imagenBytes = binaryReader.ReadBytes(fileUploadNuevaMarca.PostedFile.ContentLength);
                }
                _marca.imagen = imagenBytes;

                proveedor _proveedor_marca = new proveedor();

                if (!string.IsNullOrEmpty(providerName.SelectedValue))
                {
                    _proveedor_marca.idProveedor = int.Parse(providerName.SelectedValue);
                    _proveedor_marca.idProveedorSpecified = true;
                    _marca.proveedor = _proveedor_marca;

                    _ = marcaBO.Marca_insertar(_marca);
                }
                else
                {
                    // Manejar el caso donde no se selecciona un proveedor
                    throw new Exception("Debe seleccionar un proveedor válido.");
                }

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