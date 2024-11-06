using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCyberiaWA.CyberiaStoreWS;
using SoftCyberiaWA.CyberiaWS;


namespace SoftCyberiaWA
{
    public partial class WebForm1 : System.Web.UI.Page
        {
            private ProductoWSClient daoProducto = new ProductoWSClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
            }
            else
            {
                // Recibir los valores de los filtros desde los controles en la interfaz
                string sede = Request.Form["filterSede"] ?? "Todos";
                string categoria = Request.Form["filterCategoria"] ?? "Todos";
                string marca = Request.Form["filterMarca"] ?? "Todos";

                // Cargar productos aplicando los filtros
                CargarProductos(sede, categoria, marca);
            }
        }

        private void CargarProductos()
        {
            // Llama al método para obtener los productos desde el backend
            producto[] productos = this.daoProducto.producto_listar();

            // Recorre la lista de productos y genera el HTML para cada uno
            foreach (var prod in productos)
            {
                // Crear el contenedor HTML del producto
                Literal productHtml = new Literal();
                productHtml.Text = $@"
                    <div class='col-md-4 mb-4' data-category='{prod.Categoria}' data-price='{prod.Precio}'>
                        <a href='detalle_producto.aspx?id={prod.Id}' class='text-decoration-none'>
                            <div class='card'>
                                <img src='/Imagenes/{prod.Imagen}' class='card-img-top' alt='{prod.Nombre}'>
                                <div class='card-body'>
                                    <h6 class='card-title'>{prod.Nombre}</h6>
                                    <p class='card-text'>S/{prod.Precio:F2}</p>
                                </div>
                            </div>
                        </a>
                    </div>";

                // Agrega el HTML generado al contenedor en la página
                productContainer.Controls.Add(productHtml);
            }
        }

        private void CargarProductos(string sede = "Todos", string categoria = "Todos", string marca = "Todos")
        {
            producto[] productos = this.daoProducto.producto_listar();

            foreach (var prod in productos)
            {
                // Filtrar en el backend
                if ((sede != "Todos" && prod.Sede != sede) ||
                    (categoria != "Todos" && prod.Categoria != categoria) ||
                    (marca != "Todos" && prod.Marca != marca))
                {
                    continue; // Saltar productos que no cumplen los filtros
                }

                Literal productHtml = new Literal();
                productHtml.Text = $@"
            <div class='col-md-4 mb-4 product-item' 
                 data-sede='{prod.Sede}' data-category='{prod.Categoria}' data-marca='{prod.Marca}' data-price='{prod.Precio}'>
                <a href='detalle_producto.aspx?id={prod.Id}' class='text-decoration-none'>
                    <div class='card'>
                        <img src='/Imagenes/{prod.Imagen}' class='card-img-top' alt='{prod.Nombre}'>
                        <div class='card-body'>
                            <h6 class='card-title'>{prod.Nombre}</h6>
                            <p class='card-text'>S/{prod.Precio:F2}</p>
                        </div>
                    </div>
                </a>
            </div>";

                productContainer.Controls.Add(productHtml);
            }
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