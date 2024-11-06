using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA
{
    public partial class detalle_carro_de_compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnHistorialCompras_Click(object sender, EventArgs e)
        {
            // Redirigir a la página del historial de compras
            Response.Redirect("detalle_historial_de_compras.aspx");
        }
    }
}