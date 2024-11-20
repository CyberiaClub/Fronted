using SoftCyberiaWA.CyberiaWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA
{
    public partial class listado_productos : System.Web.UI.Page
    {
        private ProductoWSClient daoProducto = new ProductoWSClient();
        private TipoProductoWSClient daoTipoProducto = new TipoProductoWSClient();

        protected void Page_Load(object sender, EventArgs e)
        {


            //modo 2
            //if (!IsPostBack)
            //{
            //    int? idSede = null;
            //    if (Request.QueryString["idSede"] != null)
            //    {
            //        idSede = int.Parse(Request.QueryString["idSede"]);
            //    }

            //    CargarProductos(idSede);
            //}
            CargarTiposDeProductos();
            if (!IsPostBack)
            {
                // Obtiene el parámetro de la sede desde la URL
                string sedeSeleccionada = Request.QueryString["sede"];

                // Si hay una sede en la URL, genera un script para seleccionar el checkbox de esa sede
                if (!string.IsNullOrEmpty(sedeSeleccionada))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "SelectSede",
                        $"document.addEventListener('DOMContentLoaded', function() {{ " +
                        $"    var sedeCheckbox = document.getElementById('sede{sedeSeleccionada}');" +
                        $"    if (sedeCheckbox) sedeCheckbox.checked = true;" +
                        $"}});", true);
                }
                // Cargar tipos de productos en los filtros
                

                CargarProductos();
            }

        }

        private void CargarTiposDeProductos()
        {
            // Llama al método para obtener los tipos de productos desde el backend
            tipoProducto[] tiposDeProductos = this.daoTipoProducto.tipoProducto_listar();

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
        //modo 1
        //private void CargarProductos()
        //{
        //    // Llama al método para obtener los productos desde el backend
        //    producto[] productos = this.daoProducto.producto_listar();

        //    // Recorre la lista de productos y genera el HTML para cada uno

        //    foreach (producto prod in productos)
        //    {
        //        // Convierte el arreglo de bytes de la imagen a una cadena en Base64
        //        string base64Image = Convert.ToBase64String(prod.imagen);
        //        string imageSrc = $"data:image/jpeg;base64,{base64Image}";

        //        // Crea el contenedor HTML del producto
        //        Literal productHtml = new Literal();
        //        productHtml.Text = $@"
        //    <div class='col-md-4 mb-4' data-category='{prod.idTipo}' data-price='{prod.precio}'>
        //        <a href='detalle_producto.aspx?id={prod.idProducto}' class='text-decoration-none'>
        //            <div class='card'>
        //                <img src='{imageSrc}' class='card-img-top' alt='{prod.nombre}'>
        //                <div class='card-body'>
        //                    <h6 class='card-title'>{prod.nombre}</h6>
        //                    <p class='card-text'>S/{prod.precio:F2}</p>
        //                </div>
        //            </div>
        //        </a>
        //    </div>";

        //        // Agrega el HTML generado al contenedor en la página
        //        productContainer.Controls.Add(productHtml);
        //    }
        //}
        private void CargarProductos()
        {
            // Llama al método para obtener los productos desde el backend
            producto[] productos = this.daoProducto.producto_listar();
            // Recorre la lista de productos y genera el HTML para cada uno
            foreach (producto prod in productos)
            {
                // Convierte el arreglo de bytes de la imagen a una cadena en Base64
                string base64Image = Convert.ToBase64String(prod.imagen);
                string imageSrc = $"data:image/jpeg;base64,{base64Image}";

                // Crea el contenedor HTML del producto
                //Literal productHtml = new Literal();
                //productHtml.Text = $@"
                //    <div class='col-md-4 mb-4' data-category='{prod.idTipo}' data-price='{prod.precio}'>
                //        <a href='detalle_producto.aspx?id={prod.idProducto}' class='text-decoration-none'>
                //            <div class='card'>
                //                <div class='card-img-container'>
                //                    <img src='{imageSrc}' class='card-img-top' alt='{prod.nombre}'>
                //                </div>
                //                <div class='card-body'>
                //                    <h6 class='card-title'>{prod.nombre}</h6>
                //                    <p class='card-text'>S/{prod.precio:F2}</p>
                //                </div>
                //            </div>
                //        </a>
                //    </div>";

                // Agrega el HTML generado al contenedor en la página
                //productContainer.Controls.Add(productHtml);
            }
        }

        //modo 2
        //private void CargarProductos(int? idSede = null)
        //{
        //    Llama al método para obtener los productos desde el backend
        //    producto[] productos;

        //    if (idSede.HasValue)
        //    {
        //        Si hay un idSede, filtra los productos
        //        productos = this.daoProducto.producto_listarPorSede(idSede.Value);
        //    }
        //    else
        //    {
        //        Si no, carga todos los productos
        //       productos = this.daoProducto.producto_listar();
        //    }

        //    Limpia el contenedor de productos antes de añadir nuevos
        //    productContainer.Controls.Clear();

        //    Recorre la lista de productos y genera el HTML para cada uno
        //    foreach (producto prod in productos)
        //    {
        //        Crear el contenedor HTML del producto
        //        Literal productHtml = new Literal();
        //        productHtml.Text = $@"
        //    <div class='col-md-4 mb-4' data-category='{prod.idTipo}' data-price='{prod.precio}'>
        //        <a href='detalle_producto.aspx?id={prod.idProducto}' class='text-decoration-none'>
        //            <div class='card'>
        //                <img src='/Imagenes/{prod.imagen}' class='card-img-top' alt='{prod.nombre}'>
        //                <div class='card-body'>
        //                    <h6 class='card-title'>{prod.nombre}</h6>
        //                    <p class='card-text'>S/{prod.precio:F2}</p>
        //                </div>
        //            </div>
        //        </a>
        //    </div>";
        //        Agrega el HTML generado al contenedor en la página
        //        productContainer.Controls.Add(productHtml);
        //    }
        //}

        //metodo 2 o en el back
        //public producto[] producto_listarPorSede(int idSede)
        //{
        //    // Aquí creas una consulta para obtener productos que coincidan con idSede
        //    List<producto> productos = new List<producto>();

        //    string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        string query = "SELECT * FROM Productos WHERE idSede = @idSede";
        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("@idSede", idSede);

        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            // Crear una instancia de producto y asignar sus valores desde la base de datos
        //            producto prod = new producto
        //            {
        //                idProducto = Convert.ToInt32(reader["idProducto"]),
        //                nombre = reader["nombre"].ToString(),
        //                precio = Convert.ToDouble(reader["precio"]),
        //                // Asigna los demás atributos según tus necesidades
        //            };

        //            productos.Add(prod);
        //        }
        //    }

        //    return productos.ToArray();
        //}


        public string convertirBindingListAJSON(BindingList<producto> bindingList)
        {
            return JsonSerializer.Serialize(bindingList);
        }


        public static List<string> ObtenerMarcas()
        {
            List<string> marcas = new List<string>();

            string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                //????????????????????????????????????????????????????????????
                string query = "SELECT DISTINCT Marca FROM Productos";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    marcas.Add(reader["Marca"].ToString());
                }
            }

            return marcas;
        }
    }

}