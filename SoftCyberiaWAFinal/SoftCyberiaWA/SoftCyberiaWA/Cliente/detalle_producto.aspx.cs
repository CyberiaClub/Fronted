﻿using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

namespace SoftCyberiaWA
{
    public partial class detalle_producto : Page
    {
        private readonly ProductoBO productoBO;
        public detalle_producto()
        {
            productoBO = new ProductoBO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/InicioSesion/indexInicioSesion.aspx");
            }
            if (!IsPostBack)
            {
                // Obtén el SKU del producto y el ID de sede desde la URL
                string sku = Request.QueryString["sku"];
                int idSede = int.TryParse(Request.QueryString["sede"], out int sedeId) ? sedeId : 0;

                if (!string.IsNullOrEmpty(sku) && idSede > 0)
                {
                    CargarProducto(sku, idSede);
                }
            }
        }
        private void CargarProducto(string sku, int idSede)
        {
            // Llama al método para obtener los productos desde el backend
            //BindingList<producto> productos = productoBO.Producto_listar();
            producto productoSeleccionado = productoBO.Producto_buscar_sku(sku, idSede);

            // Recorre la lista de productos y busca el producto con el id especificado
            if (productoSeleccionado != null)
            {

                //  productoEncontrado1 = true; // Indicamos que encontramos el producto
                // Asigna la imagen del producto (debe estar en formato de bytes para el control Image)
                if (productoSeleccionado.imagen != null)
                {
                    string base64Image = Convert.ToBase64String(productoSeleccionado.imagen);
                    imgProducto.ImageUrl = $"data:image/jpeg;base64,{base64Image}"; // Cambia MIME si usas otro formato
                }

                // Asigna otros datos del producto a los controles Label
                lblNombreProducto.Text = productoSeleccionado.nombre;
                lblPrecioProducto.Text = productoSeleccionado.precio.ToString("F2"); // Precio con 2 decimales
                lblSkuProducto.Text = productoSeleccionado.sku;
                lblStockProducto.Text = productoSeleccionado.cantidad.ToString();
                lblDescripcionProducto.Text = productoSeleccionado.descripcion;

                // Establece el valor máximo para el campo de cantidad

                quantity.Attributes["max"] = productoSeleccionado.cantidad.ToString();

            }
            else
            {
                lblNombreProducto.Text = "Producto no encontrado sku";
                lblPrecioProducto.Text = sku;
                lblSkuProducto.Text = "- sede ";
                lblDescripcionProducto.Text = idSede.ToString();
            }
        }

        private void CargarProducto1(string sku, int idSede)
        {
            // Llama al método para obtener los productos desde el backend
            BindingList<producto> productos = productoBO.Producto_listar();

            // Variable para verificar si se encontró el producto
            bool productoEncontrado = false;

            // Recorre la lista de productos y busca el producto con el id especificado
            foreach (producto _prod in productos)
            {

                if (_prod.idSede == idSede && _prod.sku == sku)
                {
                    productoEncontrado = true; // Indicamos que encontramos el producto
                    producto productoSeleccionado = productoBO.Producto_buscar_sku(sku, idSede);
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
                    lblStockProducto.Text = productoSeleccionado.cantidad.ToString();
                    lblDescripcionProducto.Text = _prod.descripcion;

                    // Establece el valor máximo para el campo de cantidad

                    quantity.Attributes["max"] = productoSeleccionado.cantidad.ToString();

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
        protected void BtnAgregarCarrito_Click(object sender, EventArgs e)
        {
            BindingList<producto> productos = productoBO.Producto_listar();
            string sku = Request.QueryString["sku"];
            int idSede = int.TryParse(Request.QueryString["sede"], out int sedeId) ? sedeId : 0;

            if (string.IsNullOrEmpty(sku) || idSede == 0)
            {
                lblMensajeError.Text = "Error al agregar el producto al carrito. SKU o ID de sede no válidos.";
                return;
            }

            // Obtener la cantidad seleccionada por el usuario
            int cantidadSeleccionada = int.TryParse(quantity.Value, out int cantidad) ? cantidad : 1;

            foreach (producto _prod in productos)
            {
                producto productoSeleccionado = productoBO.Producto_buscar_sku(sku, idSede);
                if (productoSeleccionado == null)
                {
                    return;
                }

                producto productoConCantidad = new producto
                {
                    idProducto = productoSeleccionado.idProducto,
                    nombre = productoSeleccionado.nombre,
                    precio = productoSeleccionado.precio,
                    cantidad = cantidadSeleccionada,
                    idSede = idSede
                };

                // Obtener el carrito desde la sesión o inicializar uno nuevo si no existe
                List<producto> carrito = (List<producto>)Session["Carrito"] ?? new List<producto>();

                // Verificar si el producto ya está en el carrito para la misma sede
                producto itemExistente = carrito.Find(p => p.idProducto == productoConCantidad.idProducto && p.idSede == idSede);
                // Crear una copia del producto con la cantidad seleccionada

                if (itemExistente != null)
                {
                    // Si el producto ya existe en la misma sede, aumenta la cantidad
                    itemExistente.cantidad += cantidadSeleccionada;
                }
                else
                {
                    // Si no existe, agrega el producto al carrito
                    carrito.Add(productoConCantidad);
                }

                // Guardar el carrito actualizado en la sesión
                Session["Carrito"] = carrito;

                // Redirigir a la página del carrito de compras
                Response.Redirect("detalle_carro_de_compras.aspx");
            }
        }


        //funcionaria si a la funcion producto_buscar_sku retorna todo
        private void CargarProducto0(string sku, int idSede)
        {
            // Llama al método buscar_sku con el SKU y el idSede
            producto productoSeleccionado = productoBO.Producto_buscar_sku(sku, idSede);
            if (productoSeleccionado != null)
            {
                lblNombreProducto.Text = productoSeleccionado.nombre;
                lblPrecioProducto.Text = productoSeleccionado.precio.ToString("F2");
                lblSkuProducto.Text = productoSeleccionado.sku;
                lblStockProducto.Text = productoSeleccionado.cantidad.ToString();

                // Si tiene imagen, convertirla a Base64 para mostrarla
                if (productoSeleccionado.imagen != null)
                {
                    string base64Image = Convert.ToBase64String(productoSeleccionado.imagen);
                    imgProducto.ImageUrl = $"data:image/jpeg;base64,{base64Image}";
                }

                // Establecer la cantidad máxima basada en el stock en la sede seleccionada
                quantity.Attributes["max"] = productoSeleccionado.cantidad.ToString();
            }
            else
            {
                lblNombreProducto.Text = "Producto no encontrado.";
                lblPrecioProducto.Text = "-";
                lblSkuProducto.Text = "-";
                lblDescripcionProducto.Text = "Detalles no disponibles.";
            }
        }
        protected void BtnAgregarCarrito_Click0(object sender, EventArgs e)
        {
            string sku = Request.QueryString["sku"];
            int idSede = int.TryParse(Request.QueryString["sede"], out int sedeId) ? sedeId : 0;

            if (string.IsNullOrEmpty(sku) || idSede == 0)
            {
                lblMensajeError.Text = "Error al agregar el producto al carrito. SKU o ID de sede no válidos.";
                return;
            }

            // Llamar al método buscar_sku para obtener el producto
            producto productoSeleccionado = productoBO.Producto_buscar_sku(sku, idSede);
            if (productoSeleccionado == null)
            {
                return;
            }

            // Obtener la cantidad seleccionada por el usuario
            int cantidadSeleccionada = int.TryParse(quantity.Value, out int cantidad) ? cantidad : 1;

            // Crear una copia del producto con la cantidad seleccionada
            producto productoConCantidad = new producto
            {
                idProducto = productoSeleccionado.idProducto,
                nombre = productoSeleccionado.nombre,
                precio = productoSeleccionado.precio,
                cantidad = cantidadSeleccionada,
                idSede = idSede
            };

            // Obtener el carrito desde la sesión o inicializar uno nuevo si no existe
            List<producto> carrito = (List<producto>)Session["Carrito"] ?? new List<producto>();

            // Verificar si el producto ya está en el carrito para la misma sede
            producto itemExistente = carrito.Find(p => p.idProducto == productoConCantidad.idProducto && p.idSede == idSede);
            if (itemExistente != null)
            {
                // Si el producto ya existe en la misma sede, aumenta la cantidad
                itemExistente.cantidad += cantidadSeleccionada;
            }
            else
            {
                // Si no existe, agrega el producto al carrito
                carrito.Add(productoConCantidad);
            }

            // Guardar el carrito actualizado en la sesión
            Session["Carrito"] = carrito;

            // Redirigir a la página del carrito de compras
            Response.Redirect("detalle_carro_de_compras.aspx");
        }
    }
}