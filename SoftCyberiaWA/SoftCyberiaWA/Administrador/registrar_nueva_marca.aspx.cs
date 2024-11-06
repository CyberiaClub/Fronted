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

            if (uploadImage.HasFile)
            {
                // Verificar que el archivo subido es PNG
                string fileExtension = System.IO.Path.GetExtension(uploadImage.FileName).ToLower();
                if (fileExtension == ".png")
                {
                    // Guardar el archivo en el servidor
                    string filePath = Server.MapPath("~/Imagenes/") + uploadImage.FileName;
                    uploadImage.SaveAs(filePath);

                    marca.nombre = marcaName.Text;

                    this.daoMarca.marca_insertar(marca);
                    // Lógica adicional para registrar el producto
                }
                else
                {

                }
            }
            else
            {
                // Mostrar mensaje de error si no se seleccionó ningún archivo

            }

        }
    }
}