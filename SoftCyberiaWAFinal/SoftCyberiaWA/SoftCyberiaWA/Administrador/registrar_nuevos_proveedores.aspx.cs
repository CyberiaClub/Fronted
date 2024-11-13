using SoftCyberiaWA.CyberiaWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class registrar_nuevos_proveedores : System.Web.UI.Page
    {
        private ProveedorWSClient daoProveedor = new ProveedorWSClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void providerButton_Click(object sender, EventArgs e)
        {
            proveedor _proveedor = new proveedor();
            _proveedor.ruc = providerRUC.Text.Trim();
            // falta validacion de RUC, por el momento puede poner cualquier cosa
            _proveedor.nombreContacto = providerName.Text.Trim();
            _proveedor.razonSocial = companyName.Text.Trim();
            _proveedor.telefono = phone.Text.Trim();
            _proveedor.correo = email.Text.Trim();
            _proveedor.direccion = address.Text.Trim();
            _proveedor.descripcion = description.Text.Trim();
            daoProveedor.proveedor_insertar(_proveedor);
        }
    }
}