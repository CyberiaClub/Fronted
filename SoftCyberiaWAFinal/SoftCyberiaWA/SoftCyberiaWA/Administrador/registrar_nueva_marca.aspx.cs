using SoftCyberiaWA.CyberiaWS;
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
        private MarcaWSClient daoMarca = new MarcaWSClient();
        private ProveedorWSClient daoProveedor = new ProveedorWSClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarProveedores();


        }

        private void CargarProveedores()
        {
            providerName.DataSource = daoProveedor.proveedor_listar();
            providerName.DataTextField = "razonSocial";
            providerName.DataValueField = "idProveedor";
            providerName.DataBind(); // Llenar el DropDownList
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            try
            {

                //metodo para registrar una nueva marca
                marca _marca = new marca();
                _marca.nombre = marcaName.Text.Trim();

                    
                byte[] imagenBytes;
                using (var binaryReader = new System.IO.BinaryReader(fileUploadNuevaMarca.PostedFile.InputStream))
                {
                    imagenBytes = binaryReader.ReadBytes(fileUploadNuevaMarca.PostedFile.ContentLength);
                }

                // Asignar el arreglo de bytes a la propiedad de imagen
                _marca.imagen = imagenBytes;

                proveedor _proveedor_marca = new proveedor();
                _proveedor_marca.idProveedor= Int32.Parse(providerName.SelectedValue);
                _marca.proveedor = _proveedor_marca;

                this.daoMarca.marca_insertar(_marca);


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