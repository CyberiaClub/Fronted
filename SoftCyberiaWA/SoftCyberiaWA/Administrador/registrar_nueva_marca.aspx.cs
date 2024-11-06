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
        private MarcaWSClient daoMarca = new MarcaWSClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            //para que la fecha de registro lo tome automatico del sistema
            //registerDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }


        protected void registerButton_Click(object sender, EventArgs e)
        {
            marca marca = new marca();
            marca.nombre = marcaTxt.Text;

            // Convertir la imagen a base64 y asignarla a la marca
            if (uploadImage.HasFile)
            {
                using (System.IO.Stream imageStream = uploadImage.PostedFile.InputStream)
                {
                    byte[] imageBytes = new byte[imageStream.Length];
                    imageStream.Read(imageBytes, 0, (int)imageStream.Length);
                    marca.imagen = Convert.ToBase64String(imageBytes); // Convertir a base64
                }
            }

            // Verificar si la marca existe
            int idMarca = daoMarca.marca_buscarIdPorNombre(marca, true);
            if (idMarca == 0) // Si la marca no existe, insertarla
            {
                idMarca = daoMarca.marca_insertar(marca); // Insertar la nueva marca con nombre e imagen
            }
            else
            {
                // Actualizar la marca si ya existe (opcional)
                daoMarca.marca_actualizarImagen(idMarca, marca.imagen);
            }
        }
    }
}