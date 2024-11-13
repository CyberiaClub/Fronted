using SoftCyberiaWA.CyberiaWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA
{
    public partial class listado_sedes : System.Web.UI.Page
    {
        private SedeWSClient daoSede = new SedeWSClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSedes();
            }
        }
        
        private void CargarSedes()
        {
            // Llama al método para obtener las sedes desde el servicio web
            sede[] sedes = this.daoSede.sede_listar();

            foreach (sede sede in sedes)
            {
                // Formatea horarioApertura y horarioCierre utilizando la función personalizada
                // Verifica si localTime tiene una propiedad o método que devuelva un DateTime o TimeSpan
                

                string horaApertura = sede.horarioApertura.ToString();
                string horaCierre = sede.horarioCierre.ToString();
                // Genera el HTML para cada sede
                Literal sedeHtml = new Literal();
                sedeHtml.Text = $@"
            <a href='../Cliente/listado_productos.aspx?sede={sede.nombre.Replace(" ", "_")}&idSede={sede.idSede}' class='text-decoration-none text-dark'>
                <div class='store border rounded p-3 m-2' style='width: 300px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);'>
                    <h5>{sede.nombre}</h5>
                    <p>{sede.descripcion}</p>
                    <p><strong>LUN - VIE</strong><br>
                        {horaApertura} - {horaCierre}</p>
                    <div class='contact-info d-flex justify-content-between align-items-center'>
                        <img src='/Imagenes/whatsapp.png' alt='WhatsApp' style='width: 20px; height: 20px;'>
                        <span>{sede.telefono}</span>
                    </div>
                </div>
            </a>";

                // Agrega el HTML generado al contenedor en la página
                storeList.Controls.Add(sedeHtml);
            }
        }
    }
}