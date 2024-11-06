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
            //para que la fecha de registro lo tome automatico del sistema
            //registerDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void lbGuardar_Click(object sender, EventArgs e)
        {
            producto producto = new producto();
            producto.nombre = productName.Text;
            producto.sku = sku.Text;
            producto.precio = Convert.ToDouble(price.Text);
            producto.descripcion = description.Text;
            
            double precioVendedor = Convert.ToDouble(providerPrice.Text);

            int resultado = daoProducto.producto_insertar(producto);

        }
    }
}