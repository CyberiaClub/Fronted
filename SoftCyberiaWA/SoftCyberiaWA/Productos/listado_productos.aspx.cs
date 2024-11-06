using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
            }
        }

        private void CargarProductos()
        {
            //aqui utiliza listar_productos de java

        }

        public IActionResult ObtenerProductos(string sede, string categoria, string marca)
        {
            // Inicializar el cliente del servicio conectado
            var cliente = new ProductoServiceClient();

            // Llamar al método del servicio conectado para obtener los productos
            var productos = cliente.productos_listar_todos();

            // Convertir la respuesta del servicio a JSON
            return Json(productos);
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