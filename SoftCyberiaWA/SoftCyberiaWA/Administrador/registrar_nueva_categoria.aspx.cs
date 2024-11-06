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

        private CategoriaWSClient daoMarca = new MarcaWSClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            //para que la fecha de registro lo tome automatico del sistema
            //registerDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {


        }
    }
}