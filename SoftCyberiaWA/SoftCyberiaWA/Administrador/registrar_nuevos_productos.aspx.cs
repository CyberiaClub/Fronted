using SoftCyberiaWA.CyberiaWS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA
{
    public partial class registrarNuevosProductos : System.Web.UI.Page
    {
        private ProductoWSClient daoProducto = new ProductoWSClient();
        private SedeWSClient daoSede = new SedeWSClient();
        private ProveedorWSClient daoProveedor = new ProveedorWSClient();
        private TipoProductoWSClient daoTipoProducto = new TipoProductoWSClient();
        

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
            List<string> marcas = listar_categorias(); // Llamar al método que obtiene las marcas
            marcaName.DataSource = marcas; // Asignar la lista como fuente de datos
            marcaName.DataBind(); // Llenar el DropDownList
        }

        private void CargarMarcas()
        {
            List<string> marcas = listar_marcas(); // Llamar al método que obtiene las marcas
            marcaName.DataSource = marcas; // Asignar la lista como fuente de datos
            marcaName.DataBind(); // Llenar el DropDownList
        }


        protected void lbGuardar_Click(object sender, EventArgs e)
        {
            producto producto = new producto();

            producto.nombre = productName.Text;
            producto.sku = sku.Text;
            Double p = 2.0;
            producto.precio = p;
            producto.precioProveedor = p;
            System.Console.WriteLine(producto.precio);
            producto.descripcion = description.Text;
            producto.idSede = 1;
            producto.idMarca = 1;
            producto.idProveedor = 1;
            producto.idTipo = 1;

            //double precioVendedor = Convert.ToDouble(providerPrice.Text);

            this.daoProducto.producto_insertar2(producto, p);

        }











    }


}