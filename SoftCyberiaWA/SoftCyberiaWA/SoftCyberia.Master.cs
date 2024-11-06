using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA
{
    public partial class SoftCyberia : System.Web.UI.MasterPage
    {
        public Label CartCountLabel
        {
            get { return cartCountLabel; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Inicializa el contador del carrito si ya tiene valores en la sesión
                CartCountLabel.Text = Session["CartCount"] != null ? Session["CartCount"].ToString() : "0";
            }
        }
    }
}