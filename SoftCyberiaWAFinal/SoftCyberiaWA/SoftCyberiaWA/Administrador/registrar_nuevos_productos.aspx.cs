using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class registrar_nuevos_productos : System.Web.UI.Page
    {

        private SedeBO sedeBO;
        private ProveedorBO proveedorBO;
        private TipoProductoBO tipoProductoBO;
        private MarcaBO marcaBO;
        private ProductoBO productoBO;

        public registrar_nuevos_productos()
        {
            sedeBO = new SedeBO();
            proveedorBO = new ProveedorBO();
            tipoProductoBO = new TipoProductoBO();
            marcaBO = new MarcaBO();
            productoBO = new ProductoBO();
        }
        
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
            productoCategoria.DataSource = tipoProductoBO.tipoProducto_listar();
            productoCategoria.DataTextField = "tipo";
            productoCategoria.DataValueField = "idTipoProducto";
            productoCategoria.DataBind(); // Llenar el DropDownList
        }

        private void CargarMarcas()
        {
            productoMarca.DataSource = marcaBO.marca_listar();
            productoMarca.DataTextField = "nombre";
            productoMarca.DataValueField = "idMarca";
            productoMarca.DataBind(); // Llenar el DropDownList
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            producto _producto = new producto();
            if (Validar())
            {

                using (System.IO.Stream imageStream = imagenProducto.PostedFile.InputStream)
                {
                    byte[] imageBytes = new byte[imageStream.Length];
                    imageStream.Read(imageBytes, 0, (int)imageStream.Length);
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
                marca _marca = new marca();
                _marca.idMarca = productoMarca.SelectedIndex + 1;
                _marca.idMarcaSpecified = true;
                tipoProducto _tipoProducto = new tipoProducto();
                _tipoProducto.idTipoProducto = productoCategoria.SelectedIndex + 1;
                _tipoProducto.idTipoProductoSpecified = true;
                _producto.marca = _marca;
                _producto.tipoProducto = _tipoProducto;
                _producto.tipoProducto.idTipoProductoSpecified = true;
                _producto.cantidad = 0;
                _producto.cantidadSpecified = true;

                this.productoBO.producto_insertar(_producto);
            }
            // Mostrar el mensaje de éxito
            //successMessage.Text = "Producto registrado correctamente.";
            //successMessage.Visible = true;
        }

        protected Boolean Validar()
        {
            Boolean validarNombre = ValidarCampo(productoNombre, productonombreMensaje, "Por favor ingrese un nombre para el producto.");
            Boolean validarSku = ValidarCampo(productoSku, productoSkuMensaje, "Por favor ingrese un sku.");
            Boolean validarPrecioVenta = ValidarCampo(productoPrecioVenta, productoPrecioVentaMensaje, "Por favor ingrese un precio.");
            Boolean validarPrecioCompra = ValidarCampo(productoPrecioCompra, productoPrecioCompraMensaje, "Por favor ingrese un precio.");
            Boolean validarMarca = ValidarCampo(null, productoMarcaMensaje, "Por favor seleccione una marca.", true, productoMarca);
            Boolean validarTipoProducto = ValidarCampo(null, productoCategoriaMensaje, "Por favor seleccione un tipo de producto.", true, productoCategoria);
            Boolean validarDescripcion = ValidarCampo(productoDescripcion, productoDescripcionMensaje, "Por favor ingrese una descripción.");

            if (validarSku && productoSku.Text.Length > 8)
            {
                validarSku = false;
                productoSkuMensaje.InnerText = "Por favor ingrese un sku de 8 digitos.";
                productoSkuMensaje.Visible = true;
            }

            Boolean validarImagen = true;
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

        private Boolean ValidarCampo(TextBox campo, HtmlGenericControl mensaje, string textoError, bool esCombo = false, DropDownList combo = null)
        {
            Boolean valido;
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