using SoftCyberiaWA.CyberiaWS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA
{
    public partial class registrarNuevaMarca : System.Web.UI.Page
    {
        private MarcaWSClient daoMarca = new MarcaWSClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            //para que la fecha de registro lo tome automatico del sistema
            //registerDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            //Cargar_Foto(sender, e);
        }

        //protected void Cargar_Foto(object sender, EventArgs e)
        //{
        //    if (IsPostBack && fileUploadBannerPromocional.PostedFile != null && fileUploadBannerPromocional.HasFile)
        //    {
        //        string extension = System.IO.Path.GetExtension(fileUploadBannerPromocional.FileName);
        //        if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png" || extension.ToLower() == ".gif")
        //        {
        //            string filename = Guid.NewGuid().ToString() + extension;
        //            string filePath = Server.MapPath("~/Uploads/") + filename;
        //            fileUploadBannerPromocional.SaveAs(Server.MapPath("~/Uploads/") + filename);
        //            imgBannerPromocional.ImageUrl = "~/Uploads/" + filename;
        //            imgBannerPromocional.Visible = true;
        //            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        //            BinaryReader br = new BinaryReader(fs);
        //            Session["foto"] = br.ReadBytes((int)fs.Length);
        //            fs.Close();
        //        }
        //        else
        //        {
        //            Response.Write("Por favor, selecciona un archivo de imagen válido.");
        //        }
        //    }
        //}


        protected void registerButton_Click(object sender, EventArgs e)
        {
            marca marca = new marca();
            marca.nombre = marcaName.Text;

            if (uploadImage.HasFile)
            {
                using (System.IO.Stream imageStream = uploadImage.PostedFile.InputStream)
                {
                    byte[] imageBytes = new byte[imageStream.Length];
                    imageStream.Read(imageBytes, 0, (int)imageStream.Length);
                    marca.imagen = (byte[])Session["updloadImage"]; // Convertir a base64
                }
            }

            daoMarca.marca_insertar(marca);



        }
    }
}