﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Cliente
{
    public partial class SoftCyberiaCliente : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RolUsuario"] == null)
            {
                Response.Redirect("~/InicioSesion/indexInicioSesion.aspx");
            }
        }
    }
}