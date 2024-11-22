using SoftCyberiaWA.Almacenero;
using SoftCyberiaWA.CyberiaWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class asignar_roles : System.Web.UI.Page
    {
        private PersonaWSClient daoPersona = new PersonaWSClient();
        private SedeWSClient daoSede = new SedeWSClient();
        private persona _persona = new persona();
     
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarSedes();
        }

        protected void dni_Ingresado(object sender, EventArgs e)
        {
            _persona = daoPersona.persona_buscar_por_documento(dni.Text.ToString());
            if (_persona != null)
            {
                nombre.Text = _persona.nombre;
                correo.Text = _persona.correo;
                telefono.Text = _persona.telefono;
                direccion.Text = _persona.direccion;
            }
        }

        private void CargarSedes()
        {
            sede.DataSource = daoSede.sede_listar();
            sede.DataTextField = "nombre";
            sede.DataValueField = "idSede";
            sede.DataBind();
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {

            string rolSeleccionado = rol.SelectedValue.ToString();
            
            
        }
    }
}