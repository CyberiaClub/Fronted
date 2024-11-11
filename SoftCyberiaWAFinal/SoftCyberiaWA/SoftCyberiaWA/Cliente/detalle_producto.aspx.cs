using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA
{
    public partial class detalle_producto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 
            //producto produ;

            //if (!IsPostBack)
            //{
            //    // Obtener el idProducto de la URL
            //    string idProductoStr = Request.QueryString["id"];
            //    if (int.TryParse(idProductoStr, out int idProducto))
            //    {
            //        // Llama al método que obtiene el producto por ID desde el backend
            //        produ = this.daoProducto.producto_obtenerPorId(idProducto);

            //        if (produ != null)
            //        {
            //            // Asigna los datos del producto a los controles de la página
            //            lblNombreProducto.Text = produ.Nombre;
            //            lblPrecioProducto.Text = $"S/{produ.Precio:F2}";
            //            lblSkuProducto.Text = produ.SKU;
            //            lblDescripcionProducto.Text = produ.Descripcion;

            //            // Convierte la imagen en byte[] a una URL de base64 para mostrarla
            //            string base64Image = Convert.ToBase64String(produ.Imagen);
            //            imgProducto.ImageUrl = $"data:image/png;base64,{base64Image}";
            //        }
            //        else
            //        {
            //            // Manejar el caso donde el producto no se encuentre
            //            lblNombreProducto.Text = "Producto no encontrado";
            //        }
            //    }
            //}
        }

    }
    /*
     // Llama al método para obtener los productos desde el backend
            producto[] productos = this.daoProducto.producto_listar();
     */

}