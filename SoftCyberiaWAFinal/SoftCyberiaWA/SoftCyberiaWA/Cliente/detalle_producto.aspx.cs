using SoftCyberiaWA.CyberiaWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA
{

    public partial class detalle_producto : System.Web.UI.Page
    {
        private ProductoWSClient daoProducto = new ProductoWSClient(); // Cliente del servicio web

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtén el ID del producto desde la URL
                string productIdStr = Request.QueryString["idprod"];
                if (int.TryParse(productIdStr, out int productId))
                {
                    CargarProducto(productId); // Llama al método para cargar el producto
                }
            }
        }

        private void CargarProducto(int idProducto)
        {
            // Llama al método para obtener los productos desde el backend
            producto[] productos = this.daoProducto.producto_listar();

            // Variable para verificar si se encontró el producto
            bool productoEncontrado = false;

            // Recorre la lista de productos y busca el producto con el id especificado
            foreach (producto _prod in productos)
            {
                if (_prod.idProducto == idProducto)
                {
                    productoEncontrado = true; // Indicamos que encontramos el producto

                    // Asigna la imagen del producto (debe estar en formato de bytes para el control Image)
                    if (_prod.imagen != null)
                    {
                        string base64Image = Convert.ToBase64String(_prod.imagen);
                        imgProducto.ImageUrl = $"data:image/jpeg;base64,{base64Image}"; // Cambia MIME si usas otro formato
                    }

                    // Asigna otros datos del producto a los controles Label
                    lblNombreProducto.Text = _prod.nombre;
                    lblPrecioProducto.Text = _prod.precio.ToString("F2"); // Precio con 2 decimales
                    lblSkuProducto.Text = _prod.sku;
                    lblDescripcionProducto.Text = _prod.descripcion;

                    // Establece el valor máximo para el campo de cantidad
                    if (_prod.cantidad > 0) // Asegúrate de que haya stock disponible
                    {
                        quantity.Attributes["max"] = _prod.cantidad.ToString();
                    }

                    // Salimos del bucle ya que hemos encontrado el producto
                    break;
                }
            }

            // Si no se encontró el producto, mostramos el mensaje de "Producto no encontrado"
            if (!productoEncontrado)
            {
                lblNombreProducto.Text = "Producto no encontrado";
                lblPrecioProducto.Text = "-";
                lblSkuProducto.Text = "-";
                lblDescripcionProducto.Text = "Detalles no disponibles.";
            }
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            // Lógica para añadir el producto al carrito
            int cantidadSeleccionada = int.TryParse(quantity.Value, out int cantidad) ? cantidad : 1;

            // Ejemplo de redirección después de agregar al carrito
            Response.Redirect("detalle_carro_de_compras.aspx");
        }
    }
}