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

            // Crear una lista para almacenar la información que se mostrará en el Repeater
            var listaSedes = new List<SedeInfo>();

            foreach (var sede in sedes)
            {

                // Agregar cada sede a la lista, formateando el horario como texto
                listaSedes.Add(new SedeInfo
                {
                    Nombre = sede.nombre,
                    Descripcion = sede.descripcion,
                    HorarioApertura = sede.horarioApertura,
                    //HorarioApertura = sede.horarioApertura.ToString("HH:mm"), // Asegúrate de que horarioApertura sea DateTime
                    HorarioCierre = sede.horarioCierre,     // Asegúrate de que horarioCierre sea DateTime
                    
                    Telefono = sede.telefono,
                    LinkUrl = $"../Cliente/listado_productos.aspx?sede={sede.nombre.Replace(" ", "_")}&idSede={sede.idSede}"
                }); // Aquí cerramos el paréntesis
            }

            // Asigna la lista de sedes al Repeater y realiza la vinculación de datos
            repeaterSedes.DataSource = listaSedes;
            repeaterSedes.DataBind();
        }
       
        // Clase auxiliar para pasar la información al Repeater
        public class SedeInfo
        {
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public localTime HorarioApertura { get; set; }
            public localTime HorarioCierre { get; set; }
            public string Telefono { get; set; }
            public string LinkUrl { get; set; }
        }
    }
}