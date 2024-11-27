using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Cliente
{
    public partial class IndexCliente : Page
    {
        private readonly MarcaBO marcaBO;
        private readonly TipoProductoBO tipoProductoBO;

        public IndexCliente()
        {
            marcaBO = new MarcaBO();
            tipoProductoBO = new TipoProductoBO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMarcas();
                CargarTipoProductos();
            }
        }

        private void CargarMarcas()
        {
            // Llama al método para obtener las marcas desde el backend
            BindingList<marca> marcas = marcaBO.Marca_listar();

            // Recorre la lista de marcas y genera el HTML para cada una
            foreach (marca m in marcas)
            {
                string imageSrc = m.imagen != null && m.imagen.Length > 0
                    ? $"data:image/jpeg;base64,{Convert.ToBase64String(m.imagen)}"
                    : "/Imagenes/canva.jpg"; // Imagen por defecto

                    // Crea el contenedor HTML de la marca
                    Literal marcaHtml = new Literal
                    {
                        Text = $@"
                <div class='col-6 col-md-3 mb-3'>
                    <img src='{imageSrc}' alt='{m.nombre}' class='brand-img precisa-img'>
                    <p class='text-center'></p>
                </div>"
                    };

                    // Agrega el HTML generado al contenedor en la página
                    marcaContainer.Controls.Add(marcaHtml);

                }
            //else
            //{
            //    // En caso de que no haya imagen, muestra un placeholder o solo el nombre de la marca
            //    Literal marcaHtml = new Literal
            //    {
            //        Text = $@"
            //<div class='col-6 col-md-3 mb-3'>
            //    <img src='/Imagenes/canva.jpg' alt='Sin imagen' class='brand-img precisa-img'>
            //    <p class='text-center'>{m.nombre}</p>
            //</div>"
            //    };
            //    marcaContainer.Controls.Add(marcaHtml);
            //}
        }

        //private void CargarTipoProductos()
        //{
        //    // Llama al método para obtener los tipoProductos desde el backend
        //    tipoProducto[] tipoProductos = this.tipoProductoBO.tipoProducto_listar();

        //    // Recorre la lista de tipoProductos y genera el HTML para cada uno
        //    foreach (tipoProducto tp in tipoProductos)
        //    {
        //        // Verificar si la imagen existe
        //        string imageSrc;
        //        if (tp.imagen != null && tp.imagen.Length > 0)
        //        {
        //            // Convertimos el arreglo de bytes de la imagen a Base64
        //            string base64Image = Convert.ToBase64String(tp.imagen);
        //            imageSrc = $"data:image/jpeg;base64,{base64Image}"; // Cambia a "image/png" si tus imágenes son PNG
        //        }
        //        else
        //        {
        //            // Usa un placeholder si no hay imagen
        //            imageSrc = "/Imagenes/placeholder.png";
        //        }

        //        // Crear el contenedor HTML del tipoProducto
        //        Literal tipoProductoHtml = new Literal();
        //        tipoProductoHtml.Text = $@"
        //    <div class='col-md-6 mb-4'>
        //        <div class='card border-0'>
        //            <a href='listado_productos.aspx?categoria={tp.tipo.Replace(" ", "_")}' class='text-decoration-none'> 
        //                <img src='{imageSrc}' class='card-img-top rounded-img mx-auto' alt='{tp.tipo}'>
        //                <div class='card-body'>
        //                    <h5 class='card-title category-title font-regular'>{tp.tipo}</h5>
        //                </div>
        //            </a>
        //        </div>
        //    </div>";

        //        // Agrega el HTML generado al contenedor en la página
        //        categoriaPanel.Controls.Add(tipoProductoHtml);
        //    }
        //}
        //private void CargarTipoProductos()
        //{
        //    tipoProducto[] tipoProductos = this.tipoProductoBO.tipoProducto_listar();
        //    int totalCategorias = tipoProductos.Length;
        //    int categoriasPorSlide = 4;
        //    int totalSlides = (int)Math.Ceiling((double)totalCategorias / categoriasPorSlide);

        //    for (int i = 0; i < totalSlides; i++)
        //    {
        //        // Crear el contenedor del slide (carousel-item)
        //        Literal slideItem = new Literal();
        //        string activeClass = i == 0 ? " active" : ""; // El primer slide será activo
        //        slideItem.Text = $"<div class='carousel-item{activeClass}'><div class='row text-center'>";

        //        // Generar HTML para hasta cuatro categorías en el slide actual
        //        for (int j = i * categoriasPorSlide; j < Math.Min((i + 1) * categoriasPorSlide, totalCategorias); j++)
        //        {
        //            tipoProducto tp = tipoProductos[j];
        //            string imageSrc = tp.imagen != null && tp.imagen.Length > 0
        //                ? $"data:image/jpeg;base64,{Convert.ToBase64String(tp.imagen)}"
        //                : "/Imagenes/placeholder.png";

        //            slideItem.Text += $@"
        //        <div class='col-md-3 mb-4'>
        //            <div class='card border-0'>
        //                <a href='listado_productos.aspx?categoria={tp.tipo.Replace(" ", "_")}' class='text-decoration-none'> 
        //                    <img src='{imageSrc}' class='card-img-top rounded-img mx-auto' alt='{tp.tipo}' style='width: 100px; height: 100px; object-fit: cover;'>
        //                    <div class='card-body'>
        //                        <h5 class='card-title category-title font-regular'>{tp.tipo}</h5>
        //                    </div>
        //                </a>
        //            </div>
        //        </div>";
        //        }

        //        slideItem.Text += "</div></div>"; // Cerrar el row y el carousel-item
        //        carouselItemsContainer.Controls.Add(slideItem); // Agregar el slide al contenedor del carrusel
        //    }
        //}
        private void CargarTipoProductos()
        {
            BindingList<tipoProducto> tipoProductos = tipoProductoBO.TipoProducto_listar();
            int count = 0;
            Literal carouselGroup = new Literal
            {
                Text = "<div class='carousel-item active'><div class='row justify-content-center'>"
            };

            foreach (tipoProducto tp in tipoProductos)
            {
                string imageSrc = tp.imagen != null && tp.imagen.Length > 0
                    ? $"data:image/jpeg;base64,{Convert.ToBase64String(tp.imagen)}"
                    : "/Imagenes/placeholder.png";

                carouselGroup.Text += $@"
            <div class='col-md-6 mb-4'>
                <div class='card border-0'>
                    <a href='listado_productos.aspx?categoria={tp.tipo.Replace(" ", "_")}' class='text-decoration-none'>
                        <img src='{imageSrc}' class='card-img-top rounded-circle mx-auto d-block' alt='{tp.tipo}' style='width:150px; height:150px; object-fit:cover;'>
                        <div class='card-body'>
                            <h5 class='card-title category-title font-regular'>{tp.tipo}</h5>
                        </div>
                    </a>
                </div>
            </div>";

                count++;

                // Cada 4 productos (2x2), cierra el grupo actual y abre uno nuevo
                if (count % 4 == 0)
                {
                    carouselGroup.Text += "</div></div>";
                    categoriaPanel.Controls.Add(carouselGroup);
                    carouselGroup = new Literal
                    {
                        Text = "<div class='carousel-item'><div class='row justify-content-center'>"
                    };
                }
            }

            // Si el último grupo no se cerró debido a que no alcanzó 4 productos, ciérralo aquí
            if (count % 4 != 0)
            {
                carouselGroup.Text += "</div></div>";
                categoriaPanel.Controls.Add(carouselGroup);
            }
        }



    }

}