using SoftCyberiaWA.CyberiaWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class asignar_roles : System.Web.UI.Page
    { 
        private AlmaceneroWSClient daoAlmacenero = new AlmaceneroWSClient();
        private VendedorWSClient daoVendedor = new VendedorWSClient();
        private ClienteWSClient daoCliente = new ClienteWSClient();
        private cliente _cliente = new cliente();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dni_Ingresado(object sender, EventArgs e)
        {
            _cliente = daoCliente.cliente_buscar_por_documento(dni.Text.ToString());
            if(_cliente != null)
            {
                nombre.Text = _cliente.nombre;
                correo.Text = _cliente.correo;
                telefono.Text = _cliente.telefono;
                direccion.Text = _cliente.direccion;
            }
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {

            string rolSeleccionado = rol.SelectedValue.ToString();
            
            if(rolSeleccionado == "Almacén")
            {
                almacenero _almacenero = new almacenero();
                
            }
            else if(rolSeleccionado == "Vendedor")
            {

            }
            
        }
    }
}