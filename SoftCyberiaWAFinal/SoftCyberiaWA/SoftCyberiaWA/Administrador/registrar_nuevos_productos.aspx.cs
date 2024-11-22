using SoftCyberiaWA.CyberiaWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class registrar_nuevos_productos : System.Web.UI.Page
    {


        private SedeWSClient daoSede = new SedeWSClient();
        private ProveedorWSClient daoProveedor = new ProveedorWSClient();
        private TipoProductoWSClient daoTipoProducto = new TipoProductoWSClient();
        private MarcaWSClient daoMarca = new MarcaWSClient();
        private ProductoWSClient daoProducto = new ProductoWSClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMarcas();
                CargarCategoria();
            }

        }

        private void CargarCategoria()
        {
            categoriaName.DataSource = daoTipoProducto.tipoProducto_listar();
            categoriaName.DataTextField = "tipo";   
            categoriaName.DataValueField = "idTipoProducto";
            categoriaName.DataBind(); // Llenar el DropDownList
        }

        private void CargarMarcas()
        {
            marcaName.DataSource = daoMarca.marca_listar();
            marcaName.DataTextField = "nombre";
            marcaName.DataValueField = "idMarca";
            marcaName.DataBind(); // Llenar el DropDownList
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            producto _producto = new producto();

            _producto.nombre = productName.Text;
            _producto.sku = sku.Text;
            _producto.precio = Convert.ToDouble(price.Text);
            _producto.precioSpecified = true;
            _producto.precioProveedorSpecified = true;
            _producto.descripcion = description.Text;
            _producto.idSede = 1;
            _producto.idSedeSpecified = true;
            marca _marca = new marca();
            _marca.idMarca = marcaName.SelectedIndex+1;
            _marca.idMarcaSpecified = true;
            tipoProducto _tipoProducto = new tipoProducto();
            _tipoProducto.idTipoProducto = categoriaName.SelectedIndex+1;
            _tipoProducto.idTipoProductoSpecified = true;
            _producto.marca = _marca;
            _producto.tipoProducto = _tipoProducto;
            _producto.tipoProducto.idTipoProductoSpecified = true;
            _producto.cantidad = 0;
            _producto.cantidadSpecified = true;

            if (fileUploadProductImage.HasFile)
            {
                using (System.IO.Stream imageStream = fileUploadProductImage.PostedFile.InputStream)
                {
                    byte[] imageBytes = new byte[imageStream.Length];
                    imageStream.Read(imageBytes, 0, (int)imageStream.Length);
                    _producto.imagen = imageBytes; // Convertir a base64
                }
            }

            this.daoProducto.producto_insertar(_producto);

            // Mostrar el mensaje de éxito
            successMessage.Text = "Producto registrado correctamente.";
            successMessage.Visible = true;
        }
    }
}