using System;
using SoftCyberiaWA.CyberiaWS;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace SoftCyberiaWA.Administrador
{
    public partial class registrar_produtco_compuesto : System.Web.UI.Page
    {
        ProductoWSClient daoProducto = new ProductoWSClient();
        TipoProductoWSClient daoTipoProducto = new TipoProductoWSClient();
        MarcaWSClient daoMarca = new MarcaWSClient();
        producto _producto = new producto();
        producto _productoCompuesto = new producto();
        producto[] _productosCompuestos;


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
            productoTipoProducto.DataSource = daoTipoProducto.tipoProducto_listar();
            productoTipoProducto.DataTextField = "tipo";
            productoTipoProducto.DataValueField = "idTipoProducto";
            productoTipoProducto.DataBind(); // Llenar el DropDownList
        }

        private void CargarMarcas()
        {
            productoMarca.DataSource = daoMarca.marca_listar();
            productoMarca.DataTextField = "nombre";
            productoMarca.DataValueField = "idMarca";
            productoMarca.DataBind(); // Llenar el DropDownList
        }

        protected void BuscarProducto_Click(object sender, EventArgs e)
        {
            _productoCompuesto = daoProducto.producto_buscar_sku(productoSku.Text,1);
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

            daoProducto.producto_insertar(_producto);
        }
    }
}