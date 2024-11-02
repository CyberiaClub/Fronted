using System;
using System.Collections;
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
        /*añadir parametro categoria para filtrar los productos por la categoria selecionada*/
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
    }

}