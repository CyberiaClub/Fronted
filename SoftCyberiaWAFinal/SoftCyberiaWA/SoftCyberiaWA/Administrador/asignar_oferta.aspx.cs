using SoftCyberiaWA.CyberiaWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class asignar_oferta : System.Web.UI.Page
    {
        private OfertaWSClient daoOferta = new OfertaWSClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAsignarOferta_Click(object sender, EventArgs e)
        {
            try
            {
                //metodo
                oferta _oferta = new oferta();
                _oferta.porcentaje = Int32.Parse(porcentajeOferta.Text.Trim());
                _oferta.porcentajeSpecified = true;
                _oferta.fechaDeInicio = DateTime.Parse(fechaInicio.Text.Trim());
                _oferta.fechaDeInicioSpecified = true;
                _oferta.fechaDeFin = DateTime.Parse(fechaFin.Text.Trim());
                _oferta.fechaDeFinSpecified = true;

                byte[] imagenBytes;
                using (var binaryReader = new System.IO.BinaryReader(fileUploadProductImage.PostedFile.InputStream))
                {
                    imagenBytes = binaryReader.ReadBytes(fileUploadProductImage.PostedFile.ContentLength);
                }
                _oferta.imagen = imagenBytes;

                producto _producto_oferta = new producto();
                _producto_oferta.idProducto = Int32.Parse(sku.Text.Trim());
                _producto_oferta.idProductoSpecified = true;

                _oferta.productos=_oferta.productos.Append(_producto_oferta).ToArray();

                this.daoOferta.oferta_insertar(_oferta);

                // Mostrar el mensaje de éxito
                successMessage.Text = "Oferta asignada correctamente.";
                successMessage.Visible = true;
            }
            catch (Exception ex)
            {
                // Manejar errores (opcional)
                successMessage.Text = $"Error al registrar el producto: {ex.Message}";
                successMessage.CssClass = "text-danger";
                successMessage.Visible = true;
            }
        

        }
    }
}