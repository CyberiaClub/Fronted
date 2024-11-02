using SoftCyberiaWA.ServicioWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private ProveedorWSClient daoProveedor = new ProveedorWSClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbGuardar_Click(object sender, EventArgs e)
        {
            proveedor proveedor = new proveedor();
            proveedor.ruc = providerRUC.Text;
            proveedor.nombreContacto = nombreProveedor.Text;
            proveedor.razonSocial = razonSocial.Text;
            proveedor.correo = email.Text;
            proveedor.telefono = phone.Text;
            proveedor.direccion = address.Text;
            proveedor.descripcion = products.Text;
            int resultado = daoProveedor.proveedor_insertar(proveedor.ruc, proveedor.nombreContacto, proveedor.razonSocial, proveedor.correo, proveedor.telefono, proveedor.direccion, proveedor.descripcion);
        }
    }
}   