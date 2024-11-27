using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class Registrar_nuevos_productos : Page
    {

        private readonly SedeBO sedeBO;
        private readonly ProveedorBO proveedorBO;
        private readonly TipoProductoBO tipoProductoBO;
        private readonly MarcaBO marcaBO;
        private readonly ProductoBO productoBO;

        public Registrar_nuevos_productos()
        {
            sedeBO = new SedeBO();
            proveedorBO = new ProveedorBO();
            tipoProductoBO = new TipoProductoBO();
            marcaBO = new MarcaBO();
            productoBO = new ProductoBO();
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
            if (!IsPostBack)
            {
                CargarMarcas();
                CargarCategoria();
            }

        }

        private void CargarCategoria()
        {
            productoCategoria.DataSource = tipoProductoBO.TipoProducto_listar();
            productoCategoria.DataTextField = "tipo";
            productoCategoria.DataValueField = "idTipoProducto";
            productoCategoria.DataBind(); // Llenar el DropDownList
        }

        private void CargarMarcas()
        {
            productoMarca.DataSource = marcaBO.Marca_listar();
            productoMarca.DataTextField = "nombre";
            productoMarca.DataValueField = "idMarca";
            productoMarca.DataBind(); // Llenar el DropDownList
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            producto _producto = new producto();
            if (Validar())
            {

                using (System.IO.Stream imageStream = imagenProducto.PostedFile.InputStream)
                {
                    byte[] imageBytes = new byte[imageStream.Length];
                    _ = imageStream.Read(imageBytes, 0, (int)imageStream.Length);
                    _producto.imagen = imageBytes; // Convertir a base64
                }

                _producto.nombre = productoNombre.Text;
                _producto.sku = productoSku.Text;
                _producto.precio = Convert.ToDouble(productoPrecioVenta.Text);
                _producto.precioSpecified = true;
                _producto.precioProveedor = Convert.ToDouble(productoPrecioCompra.Text);
                _producto.precioProveedorSpecified = true;
                _producto.descripcion = productoDescripcion.Text;
                _producto.idSede = 1;
                _producto.idSedeSpecified = true;
                marca _marca = new marca
                {
                    idMarca = productoMarca.SelectedIndex + 1,
                    idMarcaSpecified = true
                };
                tipoProducto _tipoProducto = new tipoProducto
                {
                    idTipoProducto = productoCategoria.SelectedIndex + 1,
                    idTipoProductoSpecified = true
                };
                _producto.marca = _marca;
                _producto.tipoProducto = _tipoProducto;
                _producto.tipoProducto.idTipoProductoSpecified = true;
                _producto.cantidad = 0;
                _producto.cantidadSpecified = true;

                _ = productoBO.Producto_insertar(_producto);
            }
        }

        protected bool Validar()
        {
            bool validarNombre = ValidarCampo(productoNombre, productonombreMensaje, "Por favor ingrese un nombre para el producto.");
            bool validarSku = ValidarCampo(productoSku, productoSkuMensaje, "Por favor ingrese un sku.");
            bool validarPrecioVenta = ValidarCampo(productoPrecioVenta, productoPrecioVentaMensaje, "Por favor ingrese un precio.");
            _ = ValidarCampo(productoPrecioCompra, productoPrecioCompraMensaje, "Por favor ingrese un precio.");
            bool validarMarca = ValidarCampo(null, productoMarcaMensaje, "Por favor seleccione una marca.", true, productoMarca);
            bool validarTipoProducto = ValidarCampo(null, productoCategoriaMensaje, "Por favor seleccione un tipo de producto.", true, productoCategoria);
            bool validarDescripcion = ValidarCampo(productoDescripcion, productoDescripcionMensaje, "Por favor ingrese una descripción.");

            if (validarSku && productoSku.Text.Length > 8)
            {
                validarSku = false;
                productoSkuMensaje.InnerText = "Por favor ingrese un sku de 8 digitos.";
                productoSkuMensaje.Visible = true;
            }

            bool validarImagen = true;
            if (!imagenProducto.HasFile)
            {
                validarImagen = false;
                productoImagenMensaje.InnerText = "Por favor ingrese una imagen.";
                productoImagenMensaje.Visible = true;
            }
            else
            {
                productoImagenMensaje.Visible = false;
            }

            return validarNombre && validarSku && validarPrecioVenta && validarMarca && validarTipoProducto && validarDescripcion && validarImagen;
        }

        private bool ValidarCampo(TextBox campo, HtmlGenericControl mensaje, string textoError, bool esCombo = false, DropDownList combo = null)
        {
            bool valido;
            if (esCombo)
            {
                if (combo.SelectedIndex == 0)
                {
                    valido = false;
                    mensaje.InnerText = textoError;
                    mensaje.Visible = true;
                }
                else
                {
                    valido = true;
                    mensaje.Visible = false;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(campo.Text))
                {
                    valido = false;
                    mensaje.InnerText = textoError;
                    mensaje.Visible = true;
                }
                else
                {
                    valido = true;
                    mensaje.Visible = false;
                }
            }
            return valido;
        }

    }
}