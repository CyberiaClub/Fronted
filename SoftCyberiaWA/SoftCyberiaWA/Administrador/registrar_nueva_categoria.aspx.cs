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
    public partial class registrarNuevaCategoria : System.Web.UI.Page
    {

        private TipoProductoWSClient daoTipoProducto= new TipoProductoWSClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            //para que la fecha de registro lo tome automatico del sistema
            //registerDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            tipoProducto tipoProducto = new tipoProducto();
            tipoProducto.tipo = categoriaName.Text;

            daoTipoProducto.tipoProducto_insertar(tipoProducto);

        }
    }
}