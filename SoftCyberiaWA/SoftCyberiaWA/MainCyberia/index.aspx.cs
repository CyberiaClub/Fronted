using SoftCyberiaWA.CyberiaWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA
{
    public partial class index : System.Web.UI.Page
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
            // Llama al método para obtener los marcas desde el backend
            marca[] marcas = this.daoMarca.marca_listar();

            // Recorre la lista de marcas y genera el HTML para cada uno

            foreach (marca m in marcas)
            {
                // Crear el contenedor HTML del marca
                Literal marcaHtml = new Literal();
                marcaHtml.Text = $@"

                <div class='col - 6 col - md - 3 mb - 3'>
                <img src='/Imagenes/{m.imagen}' alt='{m.nombre}' class='brand-img precisa-img'>
                </div>";

                // Agrega el HTML generado al contenedor en la página
                marcaContainer.Controls.Add(marcaHtml);
            }
        }

        private void CargarTipoProductos()
        {
            // Llama al método para obtener los tipoProductos desde el backend
            tipoProducto[] tipoProductos = this.daoTipoProducto.tipoProducto_listar();

            // Recorre la lista de tipoProductos y genera el HTML para cada uno

            foreach (tipoProducto tp in tipoProductos)
            {
                // Crear el contenedor HTML del tipoProducto
                Literal tipoProductoHtml = new Literal();
                tipoProductoHtml.Text = $@"

                <div class='col - md - 6 mb - 4'>
                       <div class='card border-0'>
                           <a href = '../Productos/listado_productos.aspx?categoria='{tp.tipo}' class='text-decoration-none'> 
                               <img src = '../Imagenes/{tp.imagen}' class='card-img-top rounded-img mx-auto' alt='{tp.tipo}'>
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