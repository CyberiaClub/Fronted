using System;
using SoftCyberiaWA.CyberiaWS;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Configuration;
using System.Xml.Linq;
using System.Text.Json;


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
        }

        private void CargarProductos()
        {
            // Llama al método para obtener los productos desde el backend
            producto[] productos = this.daoProducto.producto_listar();

            // Recorre la lista de productos y genera el HTML para cada uno

            foreach (producto prod in productos)
            {
                // Crear el contenedor HTML del producto
                Literal productHtml = new Literal();
                productHtml.Text = $@"

                    <div class='col-md-4 mb-4' data-category='{prod.idTipo}' data-price='{prod.precio}'>
                        <a href='detalle_producto.aspx?id={prod.idProducto}' class='text-decoration-none'>
                            <div class='card'>
                                <img src='/Imagenes/{prod.imagen}' class='card-img-top' alt='{prod.nombre}'>
                                <div class='card-body'>
                                    <h6 class='card-title'>{prod.nombre}</h6>
                                    <p class='card-text'>S/{prod.precio:F2}</p>
                                </div>
                            </div>
                        </a>
                    </div>";

                // Agrega el HTML generado al contenedor en la página
                productContainer.Controls.Add(productHtml);
            }
        }

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