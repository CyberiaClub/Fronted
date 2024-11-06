using SoftCyberiaWA.CyberiaStoreWS;
using SoftCyberiaWA.ServicioWS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        private ProductoWSClient daoProducto = new ProductoWSClient();
        private SedeWSClient daoSede = new SedeWSClient();
        private ProveedorWSClient daoProveedor = new ProveedorWSClient();
        private TipoProductoWSClient daoTipoProducto = new TipoProductoWSClient();
        private MarcaWSClient daoMarca = new MarcaWSClient();

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
            producto.unidad = unidades.Text;
            producto.descripcion = description.Text;
            
            double precioVendedor = Convert.ToDouble(providerPrice.Text);

            sede sede = new sede();
            sede.nombre = sedeTxt.Text;
            producto.idSede = daoSede.sede_buscarIdPorNombre(sede, true);

            proveedor proveedor = new proveedor();
            proveedor.razonSocial = providerTxt.Text;
            producto.idProveedor= daoProveedor.proveedor_buscarIdPorNombre(proveedor, true);

            marca marca = new marca();
            marca.nombre = marcaTxt.Text;
            producto.idMarca = daoMarca.marca_buscarIdPorNombre(marca, true);
                
            tipoProducto tipoProducto = new tipoProducto();
            tipoProducto.tipo = category.SelectedValue;
            int idTipoProducto = daoTipoProducto.tipoProducto_buscarIdPorNombre(tipoProducto, true);

            int resultado = daoProducto.producto_insertar(producto.sku,producto.nombre,producto.descripcion,producto.precio,producto.unidad,producto.idMarca,producto.idMarca,producto.idProveedor,producto.idTipoProducto, precioVendedor);

        }
    }
}