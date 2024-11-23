using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
using System.ComponentModel;

namespace SoftCyberiaWA.Administrador
{
    public partial class registrar_produtco_compuesto : System.Web.UI.Page
    {
        private ProductoBO productoBO;
        private TipoProductoBO tipoProductoBO;
        private MarcaBO marcaBO;
        private producto _producto = new producto();
        private producto _productoCompuesto = new producto();
        private BindingList<producto> _productosCompuestos;


        int cont = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarMarcas();
                CargarCategoria();
            }
        }

        private void CargarCategoria()
        {
            productoTipoProducto.DataSource = tipoProductoBO.tipoProducto_listar();
            productoTipoProducto.DataTextField = "tipo";
            productoTipoProducto.DataValueField = "idTipoProducto";
            productoTipoProducto.DataBind(); // Llenar el DropDownList
        }

        private void CargarMarcas()
        {
            productoMarca.DataSource = marcaBO.marca_listar();
            productoMarca.DataTextField = "nombre";
            productoMarca.DataValueField = "idMarca";
            productoMarca.DataBind(); // Llenar el DropDownList
        }

        protected void BuscarProducto_Click(object sender, EventArgs e)
        {
            _productoCompuesto = productoBO.producto_buscar_sku(productoSku.Text,1);
        }

        protected void AgregarProducto_Click(object sender, EventArgs e)
        {
            _productoCompuesto.cantidad = Convert.ToInt32(productoCantidad.Text);
            _productoCompuesto.cantidadSpecified = true;
            _productosCompuestos[cont] = _productoCompuesto;
            cont++;
        }

        protected void CrearKit_Click(object sender, EventArgs e)
        {
            _producto.nombre = productoNombre.Text;
            _producto.sku = productoSku.Text;
            _producto.precio = Convert.ToDouble(productoPrecio.Text);
            _producto.marca.idMarca = Convert.ToInt32(productoMarca.SelectedValue);
            _producto.marca.idMarcaSpecified = true;
            _producto.tipoProducto.idTipoProducto = Convert.ToInt32(productoTipoProducto.SelectedValue);
            _producto.tipoProducto.idTipoProductoSpecified = true;
            _producto.descripcion = productoDescripcion.Text;

            if (fileUploadProductImage.HasFile)
            {
                using (System.IO.Stream imageStream = fileUploadProductImage.PostedFile.InputStream)
                {
                    byte[] imageBytes = new byte[imageStream.Length];
                    imageStream.Read(imageBytes, 0, (int)imageStream.Length);
                    _producto.imagen = imageBytes; // Convertir a base64
                }
            }

            productoBO.producto_insertar(_producto);
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

        protected void registerButton_Click(object sender, EventArgs e)
        {

        }
    }
}