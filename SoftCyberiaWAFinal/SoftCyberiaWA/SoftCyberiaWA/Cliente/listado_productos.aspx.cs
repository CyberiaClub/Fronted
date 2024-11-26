using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
using System;
using System.ComponentModel;
using System.Web.UI;
using System.Security.Cryptography;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA
{
    public partial class Listado_productos : Page
    {
        private readonly ProductoBO productoBO;
        private readonly TipoProductoBO tipoProductoBO;
        private readonly SedeBO sedeBO;
        private readonly MarcaBO marcaBO;

        public Listado_productos()
        {
            productoBO = new ProductoBO();
            tipoProductoBO = new TipoProductoBO();
            sedeBO = new SedeBO();
            marcaBO = new MarcaBO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSedes();
                CargarTiposDeProductos();
                CargarMarcas();
                // Obtiene el parámetro de la sede desde la URL
                string sedeSeleccionada = Request.QueryString["sede"];

                //del metodo 2 
                int? _idsede = null;
                int idsede2 = _idsede ?? 1;//por defecto sede 1

                // Si hay una sede en la URL, genera un script para seleccionar el checkbox de esa sede
                if (!string.IsNullOrEmpty(sedeSeleccionada))
                {
                    ClientScript.RegisterStartupScript(GetType(), "SelectSede",
                        $"document.addEventListener('DOMContentLoaded', function() {{ " +
                        $"    var sedeCheckbox = document.getElementById('sede{sedeSeleccionada}');" +
                        $"    if (sedeCheckbox) sedeCheckbox.checked = true;" +
                        $"}});", true);
                    //_idsede = int.Parse(Request.QueryString["idSede"]);
                    _idsede = int.Parse(Request.QueryString["idsede"] ?? "1");
                    idsede2 = _idsede ?? 1;
                }
                CargarProductos0(idsede2);
            }

        }

        private void CargarMarcas()
        {
            BindingList<marca> marcas = marcaBO.Marca_listar();
            if(marcas ==null || marcas.Count == 0)
            {
                Literal mensaje = new Literal
                {
                    Text = "<p class='text-muted'>No hay marcas disponibles.</p>"
                };
                listadoMarca.Controls.Add(mensaje);
                return;
            }

            foreach (marca _marca in marcas)
            {
                // Reemplazar espacios con guiones bajos en el nombre del tipo de producto para el valor del filtro
                string _marcaValue = _marca.nombre.Replace(" ", "_");

                // Crear el contenedor HTML del filtro de tipo de producto
                Literal marcaHtml = new Literal();
                marcaHtml.Text = $@"
                <div class='form-check'>
                    <input class='form-check-input' type='checkbox' name='categoria' value='{_marcaValue}' id='tipo{_marca.idMarca}' onchange='applyFilters()' data-categoria='{_marcaValue}'>
                    <label class='form-check-label' for='tipo{_marca.idMarca}'>{_marca.nombre}</label>
                </div>";
                // Agregar el HTML generado al contenedor de filtros en la página
                listadoMarca.Controls.Add(marcaHtml);
            }
        }

        private void CargarSedes()
        {
            if (!(Cache["sedes"] is BindingList<sede> sedes))
            {
                // Si no están en el caché, cargarlas desde la base de datos
                sedes = this.sedeBO.Sede_listar();
                // Guardar las sedes en el caché por 1 horas
                Cache.Insert("sedes", sedes, null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
            }

            if (sedes == null || sedes.Count == 0)
            {
                Literal mensaje = new Literal
                {
                    Text = "<p class='text-muted'>No hay sedes disponibles.</p>"
                };
                filtrosSedes.Controls.Add(mensaje);
                return;
            }
            bool isFirst = true; // Bandera para identificar la primera sede

            foreach (sede _sede in sedes)
            {
                // Reemplazar espacios con guiones bajos en el nombre del tipo de producto para el valor del filtro
                string sedeValue = _sede.nombre.Replace(" ", "_");
                string isChecked = isFirst ? "checked" : "";
                isFirst = false; // Después de la primera iteración, esto será falso
                                 // Crear el contenedor HTML del filtro de tipo de producto
                Literal tipoHtml = new Literal();
                tipoHtml.Text = $@"
                <div class='form-check'>
                    <input class='form-check-input' type='radio' name='sede' value='{sedeValue}' id='sede{sedeValue}' {isChecked} data-sede='{sedeValue}'>
                    <label class='form-check-label' for='sede{sedeValue}'>{_sede.nombre}</label>
                </div>";

                // Agregar el HTML generado al contenedor de filtros en la página    <label class='form-check-label' for='sede{sedeValue}'>{_sede.nombre} {_sede.idSede}</label>
                filtrosSedes.Controls.Add(tipoHtml);
            }
        }

        private void CargarTiposDeProductos()
        {
            if (!(Cache["TipoProductos"] is BindingList<tipoProducto> tiposDeProductos))
            {
                tiposDeProductos = this.tipoProductoBO.TipoProducto_listar();
                Cache.Insert("TipoProductos", tiposDeProductos, null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
            }


            foreach (tipoProducto tipo in tiposDeProductos)
            {
                // Reemplazar espacios con guiones bajos en el nombre del tipo de producto para el valor del filtro
                string tipoValue = tipo.tipo.Replace(" ", "_");

                // Crear el contenedor HTML del filtro de tipo de producto
                Literal tipoHtml = new Literal
                {
                    Text = $@"
        <div class='form-check'>
            <input class='form-check-input' type='checkbox' name='categoria' value='{tipoValue}' id='tipo{tipo.idTipoProducto}' onchange='applyFilters()' data-categoria='{tipoValue}'>
            <label class='form-check-label' for='tipo{tipo.idTipoProducto}'>{tipo.tipo}</label>
        </div>"
                };

                // Agregar el HTML generado al contenedor de filtros en la página                               
                filtrosTipoProducto.Controls.Add(tipoHtml);
            }
        }

        private void CargarProductos()
        {
            // Llama al método para obtener los productos desde el backend
            BindingList<producto> productos = productoBO.Producto_listar();
            // Recorre la lista de productos y genera el HTML para cada uno
            foreach (producto prod in productos)
            {
                // Convierte el arreglo de bytes de la imagen a una cadena en Base64
                string base64Image = Convert.ToBase64String(prod.imagen);
                string imageSrc = $"data:image/jpeg;base64,{base64Image}";

                // Crea el contenedor HTML del producto
                Literal productHtml = new Literal
                {
                    Text = $@"
                    <div class='col-md-4 mb-4' data-category='{prod.tipoProducto.idTipoProducto}' data-price='{prod.precio}'>
                        <a href='detalle_producto.aspx?sku={prod.sku}&sede={prod.idSede}' class='text-decoration-none'>
                            <div class='card'>
                                <div class='card-img-container'>
                                    <img src='{imageSrc}' class='card-img-top' alt='{prod.nombre}'>
                                </div>
                                <div class='card-body'>
                                    <h6 class='card-title'>{prod.nombre}</h6>
                                    
                                    <h6 class='card-title'>{prod.idSede}</h6>
                                    <h6 class='card-title'>{prod.idProducto}</h6>
                                    <h6 class='card-title'>{prod.sku}</h6>
                                    <p class='card-text'>S/{prod.precio:F2}</p>
                                </div>
                            </div>
                        </a>
                    </div>"
                };

                // Agrega el HTML generado al contenedor en la página
                productContainer.Controls.Add(productHtml);
            }
        }
        private void CargarProductos0(int _idSede)
        {
            // Llama al método para obtener los productos desde el backend
            BindingList<producto> productos = productoBO.Producto_listar();
            // Recorre la lista de productos y genera el HTML para cada uno
            foreach (producto prod in productos)
            {
                // Convierte el arreglo de bytes de la imagen a una cadena en Base64
                string base64Image = Convert.ToBase64String(prod.imagen);
                string imageSrc = $"data:image/jpeg;base64,{base64Image}";
                producto productoSedeSeleccionada = productoBO.Producto_buscar_sku(prod.sku, _idSede);//permite acceder a la cantidad

                // Crea el contenedor HTML del producto
                Literal productHtml = new Literal();
                //productHtml.Text = $@"
                //    <div class='col-md-4 mb-4' data-sede='{prod.idSede}' data-category='{prod.tipoProducto.tipo}' data-price='{prod.precio}'>
                //        <a href='detalle_producto.aspx?sku={prod.sku}&sede={_idSede}' class='text-decoration-none'>
                //            <div class='card'>
                //                <div class='card-img-container'>
                //                    <img src='{imageSrc}' class='card-img-top' alt='{prod.nombre}'>
                //                </div>
                //                <div class='card-body'>
                //                    <h6 class='card-title'>{prod.nombre}</h6>
                //                    <p class='card-text'>S/{prod.precio:F2}</p>
                //                </div>
                //            </div>
                //        </a>
                //    </div>";
                productHtml.Text = $@"
    <div class='col-md-4 mb-4'>
        <div class='card h-100'>
            <div class='card-img-container' style='height: 200px; overflow: hidden;'>
                <img src='{imageSrc}' class='card-img-top img-fluid' alt='{prod.nombre}' style='object-fit: cover; height: 100%;'>
            </div>
            <div class='card-body'>
                <h5 class='card-title'>{prod.nombre}</h5>
                <p class='card-text text-muted'>Stock: {productoSedeSeleccionada.cantidad}</p>
                <p class='card-text text-muted'>Precio: S/{prod.precio:F2}</p>
                <a href='detalle_producto.aspx?sku={prod.sku}&sede={_idSede}' class='btn btn-primary'>Ver Detalles</a>
            </div>
        </div>
    </div>";

                // Agrega el HTML generado al contenedor en la página
                productContainer.Controls.Add(productHtml);
            }
        }
        //private void CargarProductos3(int? _idSede = null)
        //{
        //    //Llama al método para obtener los productos desde el backend
        //    producto[] productos = this.productoBO.producto_listar();
        //    // Recorre la lista de productos y genera el HTML para cada uno
        //    foreach (producto prod in productos)
        //    {
        //        if (prod.idSede == _idSede)
        //        { //if(prod.idSede == _idSede) { // si es !0 no sale productos de la bd    si idSede==0 si muestra los productos de la bd
        //          // Convierte el arreglo de bytes de la imagen a una cadena en Base64
        //            producto productoSedeSeleccionada = productoBO.producto_buscar_sku(prod.sku, prod.idSede);//permite acceder a la cantidad

        //            string base64Image = Convert.ToBase64String(prod.imagen);
        //            string imageSrc = $"data:image/jpeg;base64,{base64Image}";

        //            // Crea el contenedor HTML del producto
        //            Literal productHtml = new Literal();
        //            productHtml.Text = $@"
        //                <div class='col-md-4 mb-4' data-category='{prod.tipoProducto.tipo}' data-price='{prod.precio}'>
        //                    <a href='detalle_producto.aspx?sku={prod.sku}&sede={prod.idSede}' class='text-decoration-none'>
        //                        <div class='card'>
        //                            <div class='card-img-container'>
        //                                <img src='{imageSrc}' class='card-img-top' alt='{productoSedeSeleccionada.nombre}'>
        //                            </div>
        //                            <div class='card-body'>
        //                                <h6 class='card-title'>{prod.nombre}</h6>
        //                                <h6 class='card-title'>{productoSedeSeleccionada.cantidad}</h6>
        //                                <p class='card-text'>S/{prod.precio:F2}</p>

        //                            </div>
        //                        </div>
        //                    </a>
        //                </div>";

        //            // Agrega el HTML generado al contenedor en la página                                                   //<h6 class='card-title'>{prod.idSede}</h6>
        //            productContainer.Controls.Add(productHtml);
        //        }
        //    }
        //}
        //private void CargarProductos2(int? _idSede = null)
        //{// pasar funcion buscar sku
        //    // Llama al método para obtener los productos desde el backend
        //    producto[] productos = this.productoBO.producto_listar();
        //    // Recorre la lista de productos y genera el HTML para cada uno
        //    foreach (producto prod in productos)
        //    {
        //        if(prod.idSede == 0)  
        //        { //if(prod.idSede == _idSede) { // si es !0 no sale productos de la bd    si idSede==0 si muestra los productos de la bd
        //          // Convierte el arreglo de bytes de la imagen a una cadena en Base64
        //            string base64Image = Convert.ToBase64String(prod.imagen);
        //        string imageSrc = $"data:image/jpeg;base64,{base64Image}";

        //        // Crea el contenedor HTML del producto
        //        Literal productHtml = new Literal();
        //        productHtml.Text = $@"
        //            <div class='col-md-4 mb-4' data-category='{prod.tipoProducto.idTipoProducto}' data-price='{prod.precio}'>
        //                <a href='detalle_producto.aspx?idprod={prod.idProducto}' class='text-decoration-none'>
        //                    <div class='card'>
        //                        <div class='card-img-container'>
        //                            <img src='{imageSrc}' class='card-img-top' alt='{prod.nombre}'>
        //                        </div>
        //                        <div class='card-body'>
        //                            <h6 class='card-title'>{prod.nombre}</h6>
        //                            <p class='card-text'>S/{prod.precio:F2}</p>

        //                        </div>
        //                    </div>
        //                </a>
        //            </div>";

        //        // Agrega el HTML generado al contenedor en la página                                                   //<h6 class='card-title'>{prod.idSede}</h6>
        //        productContainer.Controls.Add(productHtml);
        //        }
        //    }
        //}


        //public string convertirBindingListAJSON(BindingList<producto> bindingList)
        //{
        //    return JsonSerializer.Serialize(bindingList);
        //}
    }

}