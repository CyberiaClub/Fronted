using SoftCyberiaWA.CyberiaWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Cliente
{
    public partial class IndexCliente : System.Web.UI.Page
    {
        private MarcaWSClient daoMarca = new MarcaWSClient();
        private TipoProductoWSClient daoTipoProducto = new TipoProductoWSClient();
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
            marca[] marcas = this.daoMarca.marca_listar();

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
                    Literal marcaHtml = new Literal();
                    marcaHtml.Text = $@"
                <div class='col-6 col-md-3 mb-3'>
                    <img src='{imageSrc}' alt='{m.nombre}' class='brand-img precisa-img'>
                    <p class='text-center'>{m.nombre}</p>
                </div>";

                    // Agrega el HTML generado al contenedor en la página
                    marcaContainer.Controls.Add(marcaHtml);
                }
                else
                {
                    // En caso de que no haya imagen, muestra un placeholder o solo el nombre de la marca
                    Literal marcaHtml = new Literal();
                    marcaHtml.Text = $@"
                <div class='col-6 col-md-3 mb-3'>
                    <img src='/Imagenes/canva.jpg' alt='Sin imagen' class='brand-img precisa-img'>
                    <p class='text-center'>{m.nombre}</p>
                </div>";
                    marcaContainer.Controls.Add(marcaHtml);
                }
            }
        }

        private void CargarTipoProductos()
        {
            // Llama al método para obtener los tipoProductos desde el backend
            tipoProducto[] tipoProductos = this.daoTipoProducto.tipoProducto_listar();

            // Recorre la lista de tipoProductos y genera el HTML para cada uno
            foreach (tipoProducto tp in tipoProductos)
            {
                // Verificar si la imagen existe
                string imageSrc;
                if (tp.imagen != null && tp.imagen.Length > 0)
                {
                    // Convertimos el arreglo de bytes de la imagen a Base64
                    string base64Image = Convert.ToBase64String(tp.imagen);
                    imageSrc = $"data:image/jpeg;base64,{base64Image}"; // Cambia a "image/png" si tus imágenes son PNG
                }
                else
                {
                    // Usa un placeholder si no hay imagen
                    imageSrc = "/Imagenes/placeholder.png";
                }

                // Crear el contenedor HTML del tipoProducto
                Literal tipoProductoHtml = new Literal();
                tipoProductoHtml.Text = $@"
            <div class='col-md-6 mb-4'>
                <div class='card border-0'>
                    <a href='listado_productos.aspx?categoria={tp.tipo.Replace(" ", "")}' class='text-decoration-none'> 
                        <img src='{imageSrc}' class='card-img-top rounded-img mx-auto' alt='{tp.tipo}'>
                        <div class='card-body'>
                            <h5 class='card-title category-title font-regular'>{tp.tipo}</h5>
                        </div>
                    </a>
                </div>
            </div>";

                // Agrega el HTML generado al contenedor en la página
                categoriaPanel.Controls.Add(tipoProductoHtml);
            }
        }
    }
    
}