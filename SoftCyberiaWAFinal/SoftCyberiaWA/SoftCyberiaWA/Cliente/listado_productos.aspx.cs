﻿using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
//using System.Text.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA
{
    public partial class listado_productos : System.Web.UI.Page
    {
        private ProductoBO productoBO;
        private TipoProductoBO tipoProductoBO;
        private SedeBO sedeBO;
        private MarcaBO marcaBO;

        public listado_productos()
        {
            this.productoBO = new ProductoBO();
            this.tipoProductoBO = new TipoProductoBO();
            this.sedeBO = new SedeBO();
            this.marcaBO = new MarcaBO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarSedes();
            CargarTiposDeProductos();
            CargarMarcas();

            if (!IsPostBack)
            {
                // Obtiene el parámetro de la sede desde la URL
                string sedeSeleccionada = Request.QueryString["sede"];

                //del metodo 2 
                int? _idsede = null;
                int idsede2 = _idsede ?? 1;//por defecto sede 1

                // Si hay una sede en la URL, genera un script para seleccionar el checkbox de esa sede
                if (!string.IsNullOrEmpty(sedeSeleccionada))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "SelectSede",
                        $"document.addEventListener('DOMContentLoaded', function() {{ " +
                        $"    var sedeCheckbox = document.getElementById('sede{sedeSeleccionada}');" +
                        $"    if (sedeCheckbox) sedeCheckbox.checked = true;" +
                        $"}});", true);
                    //_idsede = int.Parse(Request.QueryString["idSede"]);
                    _idsede = int.Parse(Request.QueryString["idsede"] ?? "0");
                    idsede2 = _idsede ?? 1;
                }
                // Cargar tipos de productos en los filtros

                //del metodo 2 borrador no funciona, 1 sin pasar filtro de sede, 3 pasa el filtro
                //CargarProductos2(_idsede);
                //CargarProductos();
                CargarProductos0(idsede2);
            }

        }

        private void CargarMarcas()
        {
            throw new NotImplementedException();
        }

        private void CargarSedes()
        {
            // Llama al método para obtener los tipos de productos desde el backend
            BindingList<sede> sedes = this.sedeBO.sede_listar();
            
            foreach (sede _sede in sedes)
            {
                // Reemplazar espacios con guiones bajos en el nombre del tipo de producto para el valor del filtro
                string sedeValue = _sede.nombre.Replace(" ", "_");

                // Crear el contenedor HTML del filtro de tipo de producto
                Literal tipoHtml = new Literal();
                tipoHtml.Text = $@"
        <div class='form-check'>
            <input class='form-check-input' type='checkbox' name='sede' value='{sedeValue}' id='sede{sedeValue}' onclick='selectOnlyOne(this)' data-sede='{sedeValue}'>
            <label class='form-check-label' for='sede{sedeValue}'>{_sede.nombre}</label>
        </div>";


                // Agregar el HTML generado al contenedor de filtros en la página    <label class='form-check-label' for='sede{sedeValue}'>{_sede.nombre} {_sede.idSede}</label>
                filtrosSedes.Controls.Add(tipoHtml);
            }
        }

        private void CargarTiposDeProductos()
        {
            // Llama al método para obtener los tipos de productos desde el backend
            BindingList<tipoProducto> tiposDeProductos = this.tipoProductoBO.tipoProducto_listar();


            foreach (tipoProducto tipo in tiposDeProductos)
            {
                // Reemplazar espacios con guiones bajos en el nombre del tipo de producto para el valor del filtro
                string tipoValue = tipo.tipo.Replace(" ", "_");

                // Crear el contenedor HTML del filtro de tipo de producto
                Literal tipoHtml = new Literal();
                tipoHtml.Text = $@"
        <div class='form-check'>
            <input class='form-check-input' type='checkbox' name='categoria' value='{tipoValue}' id='tipo{tipo.idTipoProducto}' onchange='applyFilters()' data-categoria='{tipoValue}'>
            <label class='form-check-label' for='tipo{tipo.idTipoProducto}'>{tipo.tipo}</label>
        </div>";

                // Agregar el HTML generado al contenedor de filtros en la página                               
                filtrosTipoProducto.Controls.Add(tipoHtml);
            }
        }

        private void CargarProductos()
        {
            // Llama al método para obtener los productos desde el backend
            BindingList<producto> productos = this.productoBO.producto_listar();
            // Recorre la lista de productos y genera el HTML para cada uno
            foreach (producto prod in productos)
            {
                // Convierte el arreglo de bytes de la imagen a una cadena en Base64
                string base64Image = Convert.ToBase64String(prod.imagen);
                string imageSrc = $"data:image/jpeg;base64,{base64Image}";

                // Crea el contenedor HTML del producto
                Literal productHtml = new Literal();
                productHtml.Text = $@"
                    <div class='col-md-4 mb-4' data-category='{prod.tipoProducto.idTipoProducto}' data-price='{prod.precio}'>
                        <a href='detalle_producto.aspx?sku={prod.sku}&sede={prod.idSede}' class='text-decoration-none'>
                            <div class='card'>
                                <div class='card-img-container'>
                                    <img src='{imageSrc}' class='card-img-top' alt='{prod.nombre}'>
                                </div>
                                <div class='card-body'>
                                    <h6 class='card-title'>{prod.nombre}</h6>
                                    
                                    <h6 class='card-title'>{prod.idSede}</h6>
                                    <h6 class='card-title'>{prod.idProducto}</h6>
                                    <h6 class='card-title'>{prod.sku}</h6>
                                    <p class='card-text'>S/{prod.precio:F2}</p>
                                </div>
                            </div>
                        </a>
                    </div>";

                // Agrega el HTML generado al contenedor en la página
                productContainer.Controls.Add(productHtml);
            }
        }
        private void CargarProductos0(int _idSede )
        {
            // Llama al método para obtener los productos desde el backend
            BindingList<producto> productos = this.productoBO.producto_listar();
            // Recorre la lista de productos y genera el HTML para cada uno
            foreach (producto prod in productos)
            {
                // Convierte el arreglo de bytes de la imagen a una cadena en Base64
                string base64Image = Convert.ToBase64String(prod.imagen);
                string imageSrc = $"data:image/jpeg;base64,{base64Image}";
                producto productoSedeSeleccionada = productoBO.producto_buscar_sku(prod.sku, _idSede);//permite acceder a la cantidad

                // Crea el contenedor HTML del producto
                Literal productHtml = new Literal();
                productHtml.Text = $@"
                    <div class='col-md-4 mb-4' data-sede='{prod.idSede}' data-category='{prod.tipoProducto.tipo}' data-price='{prod.precio}'>
                        <a href='detalle_producto.aspx?sku={prod.sku}&sede={_idSede}' class='text-decoration-none'>
                            <div class='card'>
                                <div class='card-img-container'>
                                    <img src='{imageSrc}' class='card-img-top' alt='{prod.nombre}'>
                                </div>
                                <div class='card-body'>
                                    <h6 class='card-title'>{prod.nombre}</h6>
                                    <h6 class='card-title'>stock : {productoSedeSeleccionada.cantidad}</h6>
                                    <h6 class='card-title'>idprod: {prod.idProducto}</h6>
                                    <h6 class='card-title'>idsede: {_idSede}</h6>
                                    <h6 class='card-title'>sku: {prod.sku}</h6>
                                    <p class='card-text'>S/{prod.precio:F2}</p>
                                </div>
                            </div>
                        </a>
                    </div>";

                // Agrega el HTML generado al contenedor en la página
                productContainer.Controls.Add(productHtml);
            }
        }
        //private void CargarProductos3(int? _idSede = null)
        //{
        //    //Llama al método para obtener los productos desde el backend
        //    producto[] productos = this.productoBO.producto_listar();
        //    // Recorre la lista de productos y genera el HTML para cada uno
        //    foreach (producto prod in productos)
        //    {
        //        if (prod.idSede == _idSede)
        //        { //if(prod.idSede == _idSede) { // si es !0 no sale productos de la bd    si idSede==0 si muestra los productos de la bd
        //          // Convierte el arreglo de bytes de la imagen a una cadena en Base64
        //            producto productoSedeSeleccionada = productoBO.producto_buscar_sku(prod.sku, prod.idSede);//permite acceder a la cantidad

        //            string base64Image = Convert.ToBase64String(prod.imagen);
        //            string imageSrc = $"data:image/jpeg;base64,{base64Image}";

        //            // Crea el contenedor HTML del producto
        //            Literal productHtml = new Literal();
        //            productHtml.Text = $@"
        //                <div class='col-md-4 mb-4' data-category='{prod.tipoProducto.tipo}' data-price='{prod.precio}'>
        //                    <a href='detalle_producto.aspx?sku={prod.sku}&sede={prod.idSede}' class='text-decoration-none'>
        //                        <div class='card'>
        //                            <div class='card-img-container'>
        //                                <img src='{imageSrc}' class='card-img-top' alt='{productoSedeSeleccionada.nombre}'>
        //                            </div>
        //                            <div class='card-body'>
        //                                <h6 class='card-title'>{prod.nombre}</h6>
        //                                <h6 class='card-title'>{productoSedeSeleccionada.cantidad}</h6>
        //                                <p class='card-text'>S/{prod.precio:F2}</p>

        //                            </div>
        //                        </div>
        //                    </a>
        //                </div>";

        //            // Agrega el HTML generado al contenedor en la página                                                   //<h6 class='card-title'>{prod.idSede}</h6>
        //            productContainer.Controls.Add(productHtml);
        //        }
        //    }
        //}
        //private void CargarProductos2(int? _idSede = null)
        //{// pasar funcion buscar sku
        //    // Llama al método para obtener los productos desde el backend
        //    producto[] productos = this.productoBO.producto_listar();
        //    // Recorre la lista de productos y genera el HTML para cada uno
        //    foreach (producto prod in productos)
        //    {
        //        if(prod.idSede == 0)  
        //        { //if(prod.idSede == _idSede) { // si es !0 no sale productos de la bd    si idSede==0 si muestra los productos de la bd
        //          // Convierte el arreglo de bytes de la imagen a una cadena en Base64
        //            string base64Image = Convert.ToBase64String(prod.imagen);
        //        string imageSrc = $"data:image/jpeg;base64,{base64Image}";

        //        // Crea el contenedor HTML del producto
        //        Literal productHtml = new Literal();
        //        productHtml.Text = $@"
        //            <div class='col-md-4 mb-4' data-category='{prod.tipoProducto.idTipoProducto}' data-price='{prod.precio}'>
        //                <a href='detalle_producto.aspx?idprod={prod.idProducto}' class='text-decoration-none'>
        //                    <div class='card'>
        //                        <div class='card-img-container'>
        //                            <img src='{imageSrc}' class='card-img-top' alt='{prod.nombre}'>
        //                        </div>
        //                        <div class='card-body'>
        //                            <h6 class='card-title'>{prod.nombre}</h6>
        //                            <p class='card-text'>S/{prod.precio:F2}</p>

        //                        </div>
        //                    </div>
        //                </a>
        //            </div>";

        //        // Agrega el HTML generado al contenedor en la página                                                   //<h6 class='card-title'>{prod.idSede}</h6>
        //        productContainer.Controls.Add(productHtml);
        //        }
        //    }
        //}


        //public string convertirBindingListAJSON(BindingList<producto> bindingList)
        //{
        //    return JsonSerializer.Serialize(bindingList);
        //}


        //public static List<string> ObtenerMarcas()
        //{
        //    List<string> marcas = new List<string>();

        //    string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {

        //        //????????????????????????????????????????????????????????????
        //        string query = "SELECT DISTINCT Marca FROM Productos";
        //        SqlCommand command = new SqlCommand(query, connection);
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            marcas.Add(reader["Marca"].ToString());
        //        }
        //    }

        //    return marcas;
        //}
    }

}