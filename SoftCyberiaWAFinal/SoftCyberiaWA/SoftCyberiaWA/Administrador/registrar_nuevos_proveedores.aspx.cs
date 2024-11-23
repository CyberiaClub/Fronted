using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
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
        private ProveedorBO proveedorBO;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void providerButton_Click(object sender, EventArgs e)
        {
            try
            {
                proveedor _proveedor = new proveedor();
                _proveedor.ruc = providerRUC.Text.Trim();
                _proveedor.nombreContacto = providerName.Text.Trim();
                _proveedor.razonSocial = companyName.Text.Trim();
                _proveedor.telefono = phone.Text.Trim();
                _proveedor.correo = email.Text.Trim();
                _proveedor.direccion = address.Text.Trim();
                _proveedor.descripcion = description.Text.Trim();

                this.proveedorBO.proveedor_insertar(_proveedor);

                // Mostrar el mensaje de éxito
                successMessage.Text = "Producto registrado correctamente.";
                successMessage.Visible = true;
            }
            catch (Exception ex)
            {
                // Manejar errores (opcional)
                successMessage.Text = $"Error al registrar el producto: {ex.Message}";
                successMessage.CssClass = "text-danger";
                successMessage.Visible = true;
            }

        }
    }
}