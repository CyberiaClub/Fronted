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
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/InicioSesion/indexInicioSesion.aspx");
            }
        }

        private void CargarMarcas()
        {
            // Llama al método para obtener las marcas desde el backend
            BindingList<marca> marcas = marcaBO.Marca_listar();

            // Recorre la lista de marcas y genera el HTML para cada una
            foreach (marca m in marcas)
            {
                if (m.imagen != null && m.imagen.Length > 0)
                {
                    // Convertimos el arreglo de bytes de la imagen a Base64
                    string base64Image = Convert.ToBase64String(m.imagen);
                    // Ajusta el tipo MIME según el formato de las imágenes en tu base de datos (ej. image/png o image/jpeg)
                    string imageSrc = $"data:image/jpeg;base64,{base64Image}";

                    // Crea el contenedor HTML de la marca
                    Literal marcaHtml = new Literal
                    {
                        Text = $@"
                <div class='col-5 mb-3 align-content-center'>
                    <img src='{imageSrc}' class='img-fluid brand-img precisa-img' alt='{m.nombre}'>
                </div>"//alt='{m.nombre}'
                    };
                    //<p class='text-center'>{m.nombre}</p>
                    // Agrega el HTML generado al contenedor en la página
                    marcaContainer.Controls.Add(marcaHtml);


                }
                else
                {
                    // En caso de que no haya imagen, muestra un placeholder o solo el nombre de la marca
                    Literal marcaHtml = new Literal
                    {
                        Text = $@"
                <div class='col-6 col-md-3 mb-3'>
                    <img src='/Imagenes/canva.jpg' alt='Sin imagen' class='brand-img precisa-img'>
                    
                </div>"
                    };
                    marcaContainer.Controls.Add(marcaHtml);
                }
            }
        }
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