using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
using System;
using System.ComponentModel;
using System.Web.UI;
using System.Security.Cryptography;
using System.Web.UI.WebControls;
using System.Linq;
using System.Collections.Generic;

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
            //if (!IsPostBack)
            //{
            //    CargarSedes();
            //    CargarTiposDeProductos();
            //    CargarMarcas();
            //    // Obtiene el parámetro de la sede desde la URL
            //    string sedeSeleccionada = Request.QueryString["sede"];

            //    //del metodo 2 
            //    int? _idsede = null;
            //    int idsede2 = _idsede ?? 1;//por defecto sede 1 sede 1

            //    // Si hay una sede en la URL, genera un script para seleccionar el checkbox de esa sede
            //    if (!string.IsNullOrEmpty(sedeSeleccionada))
            //    {
            //        ClientScript.RegisterStartupScript(GetType(), "SelectSede",
            //            $"document.addEventListener('DOMContentLoaded', function() {{ " +
            //            $"    var sedeCheckbox = document.getElementById('sede{sedeSeleccionada}');" +
            //            $"    if (sedeCheckbox) sedeCheckbox.checked = true;" +
            //            $"}});", true);
            //        //_idsede = int.Parse(Request.QueryString["idSede"]);
            //        _idsede = int.Parse(Request.QueryString["idsede"] ?? "0");//sede
            //        idsede2 = _idsede ?? 1;
            //    }
            //    //CargarProductos0(idsede2);
            //    CargarProductosPorSede(idsede2);
            //    //CargarProductos();
            //}
            //2222
            if (!IsPostBack)
            {
                string sedeSeleccionada = Request.QueryString["sede"];
                int idSedeSeleccionada = int.TryParse(Request.QueryString["idSede"], out int idSede) ? idSede : 0;

                CargarSedes();
                CargarTiposDeProductos();
                CargarMarcas();

                if (idSedeSeleccionada > 0)
                {
                    CargarProductosPorSede(idSedeSeleccionada);
                }
                else
                {
                    CargarProductos(); // Cargar todos si no hay sede seleccionada
                }
            }
        }
        private void CargarTiposDeProductos()
        {
            BindingList<tipoProducto> tiposDeProductos = this.tipoProductoBO.TipoProducto_listar();

            foreach (tipoProducto tipo in tiposDeProductos)
            {
                // Reemplazar espacios con guiones bajos en el nombre del tipo de producto para el valor del filtro
                string tipoValue = tipo.tipo.Replace(" ", "_");

                // Crear el contenedor HTML del filtro de tipo de producto
                Literal tipoHtml = new Literal
                {
                    Text = $@"
        <div class='form-check'>
            <input class='form-check-input' type='checkbox' name='categoria' value='{tipo.tipo}' id='tipo{tipo.idTipoProducto}' onchange='applyFilters()' data-categoria='{tipo.tipo}'>
            <label class='form-check-label' for='tipo{tipo.idTipoProducto}'>{tipo.tipo}</label>
        </div>"
                };

                // Agregar el HTML generado al contenedor de filtros en la página                               
                filtrosTipoProducto.Controls.Add(tipoHtml);
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
                filtrosMarcas.Controls.Add(mensaje);
                return;
            }
            foreach (marca _marca in marcas)
            {
                // Reemplazar espacios con guiones bajos en el nombre del tipo de producto para el valor del filtro
                //string _marcaValue = _marca.nombre.Replace(" ", "_");
                // Crear el contenedor HTML del filtro de tipo de producto
                Literal marcaHtml = new Literal
                {
                    Text = $@"
                <div class='form-check'>
                    <input class='form-check-input' type='checkbox' name='marca' value='{_marca.nombre}' id='tipo{_marca.idMarca}' onchange='applyFilters()' data-brand='{_marca.nombre}'>
                    <label class='form-check-label' for='tipo{_marca.idMarca}'>{_marca.nombre}</label>
                </div>"
                };
                // Agregar el HTML generado al contenedor de filtros en la página
                filtrosMarcas.Controls.Add(marcaHtml);
            }
        }

        private void CargarSedes0()
        {
            BindingList<sede> sedes = this.sedeBO.Sede_listar();
            foreach (sede _sede in sedes)
            {
                // Reemplazar espacios con guiones bajos en el nombre del tipo de producto para el valor del filtro
                string sedeValue = _sede.nombre.Replace(" ", "_");
                string isChecked = isFirst ? "checked" : "";
                //First = false; // Después de la primera iteración, esto será falso     id='sede{sedeValue}' {isChecked} 
                // Crear el contenedor HTML del filtro de tipo de producto
                Literal tipoHtml = new Literal
                {
                    Text = $@"
                <div class='form-check'>
                    <input class='form-check-input' type='checkbox' name='sede' value='{sedeValue}' id='sede{sedeValue}' {isChecked}  onclick='selectOnlyOne(this)' data-sede='{sedeValue}'>
                    <label class='form-check-label' for='sede{sedeValue}'>{_sede.nombre}</label>
                </div>"
                };

                // Agregar el HTML generado al contenedor de filtros en la página    <label class='form-check-label' for='sede{sedeValue}'>{_sede.nombre} {_sede.idSede}</label>
                filtrosSedes.Controls.Add(tipoHtml);
            }
        }
        private void ManejarSeleccionSede(int idSedeSeleccionada)
        {
            // Redirigir con el parámetro de sede seleccionado
            Response.Redirect($"listado_productos.aspx?idSede={idSedeSeleccionada}");
        }
        private void DesmarcarOtrosCheckboxes(int idSedeSeleccionada)
        {
            foreach (Control control in filtrosSedes.Controls)
            {
                if (control is Panel panel && panel.Controls[0] is CheckBox checkBox)
                {
                    if (checkBox.ID != $"sede{idSedeSeleccionada}")
                    {
                        checkBox.Checked = false; // Desmarcar
                    }
                }
            }
        }
        private void CargarSedes()
        {
            BindingList<sede> sedes = this.sedeBO.Sede_listar();
            string sedeSeleccionada = Request.QueryString["sede"];

            foreach (sede _sede in sedes)
            {
                // Reemplazar espacios con guiones bajos en el nombre de la sede para el valor del filtro
                string sedeValue = _sede.nombre.Replace(" ", "_");
                bool isChecked = sedeSeleccionada != null && sedeSeleccionada == sedeValue;

                // Crear el contenedor HTML del filtro de sedes con redirección al cambiar
                Literal sedeHtml = new Literal
                {
                    Text = $@"
            <div class='form-check'>
                <input class='form-check-input' type='radio' name='sede' value='{sedeValue}' id='sede{sedeValue}' {(isChecked ? "checked" : "")} 
                       onchange='window.location.href=""listado_productos.aspx?sede={sedeValue}&idSede={_sede.idSede}""'>
                <label class='form-check-label' for='sede{sedeValue}'>{_sede.nombre}</label>
            </div>"
                };

                // Agregar el HTML generado al contenedor de filtros en la página
                filtrosSedes.Controls.Add(sedeHtml);
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
                    <div class='col-md-4 mb-4' data-sede='{prod.idSede}' data-category='{prod.tipoProducto.tipo}' data-price='{prod.precio}' data-brand='{prod.marca.nombre}'>
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
                                    <h6 class='card-title'>{prod.tipoProducto.tipo}</h6>
                                    <p class='card-text'>S/{prod.precio:F2}</p>
                                    <h6 class='card-title'>{prod.marca.nombre}</h6>
                                </div>
                            </div>
                        </a>
                    </div>"
                };

                // Agrega el HTML generado al contenedor en la página
                productContainer.Controls.Add(productHtml);
            }
        }


        private void CargarProductosPorSede(int _idSede)
        {
            // Obtener la lista de productos desde el backend
            BindingList<producto> productos = productoBO.Producto_listar();

            // Validar si hay productos para mostrar
            if (productos == null || productos.Count == 0)
            {
                Console.WriteLine("No se encontraron productos para listar.");
                return;
            }

            // Crear una lista de productos filtrados
            List<producto> productosFiltrados = productos
                .Where(prod =>
                {
                    producto productoSede = productoBO.Producto_buscar_sku(prod.sku, _idSede);
                    return productoSede != null &&
                           productoSede.cantidad > 0 &&
                           _idSede == prod.idSede;
                })
                .ToList();

            // Validar si no hay productos que cumplan con los filtros
            if (productosFiltrados.Count == 0)
            {
                Console.WriteLine("No hay productos con stock disponibles en esta sede.");
                return;
            }

            // Generar HTML para cada producto filtrado
            foreach (producto prod in productosFiltrados)
            {
                // Obtener los detalles del producto para la sede seleccionada
                producto productoSede = productoBO.Producto_buscar_sku(prod.sku, _idSede);
                if (productoSede == null)
                {
                    continue; // Validar nuevamente por seguridad
                }
                // Convertir la imagen a Base64
                string base64Image = Convert.ToBase64String(prod.imagen);
                string imageSrc = $"data:image/jpeg;base64,{base64Image}";

                // Crear el contenedor HTML
                Literal productHtml = new Literal
                {
                    Text = $@"
<div class='col-md-4 mb-4' data-sede='{prod.idSede}' data-category='{prod.tipoProducto.tipo}' data-price='{prod.precio}' data-brand='{prod.marca.nombre}'>
    <a href='detalle_producto.aspx?sku={prod.sku}&sede={_idSede}' class='text-decoration-none'>
        <div class='card'>
            <div class='card-img-container'>
                <img src='{imageSrc}' class='card-img-top' alt='{prod.nombre}' />
            </div>
            <div class='card-body'>
                <h6 class='card-title'>{prod.nombre}</h6>
                <p class='card-text'>SKU: {prod.sku}</p>
                <p class='card-text'>Stock: {productoSede.cantidad}</p>
                <p class='card-text'>Precio: S/{prod.precio:F2}</p>
            </div>
        </div>
    </a>
</div>"
                };

                // Agregar el HTML al contenedor en la página
                productContainer.Controls.Add(productHtml);
            }
        }
        private void CargarProductos0(int _idSede)
        {
            // Llama al método para obtener los productos desde el backend
            BindingList<producto> productos = productoBO.Producto_listar();

            // Valida si la lista de productos es null o está vacía
            if (productos == null || productos.Count == 0)
            {
                Console.WriteLine("No se encontraron productos para listar.");
                return;
            }

            // Recorre la lista de productos y genera el HTML para cada uno
            foreach (producto prod in productos)
            {
                // Convierte el arreglo de bytes de la imagen a una cadena en Base64
                string base64Image = Convert.ToBase64String(prod.imagen);
                string imageSrc = $"data:image/jpeg;base64,{base64Image}";

                // Busca el producto por SKU y sede
                producto productoSedeSeleccionada = productoBO.Producto_buscar_sku(prod.sku, _idSede);

                // Valida que productoSedeSeleccionada no sea null
                if (productoSedeSeleccionada != null && productoSedeSeleccionada.cantidad > 0 && _idSede == prod.idSede)
                {
                    // Crea el contenedor HTML del producto
                    Literal productHtml = new Literal
                    {
                        Text = $@"
    <div class='col-md-4 mb-4' data-sede='{prod.idSede}' data-category='{prod.tipoProducto.tipo}' data-price='{prod.precio}' data-brand='{prod.marca.nombre}'>
        <a href='detalle_producto.aspx?sku={prod.sku}&sede={_idSede}' class='text-decoration-none'>
            <div class='card'>
                <div class='card-img-container'>
                    <img src='{imageSrc}' class='card-img-top' alt='{prod.nombre}'>
                </div>
                <div class='card-body'>
                    <h6 class='card-title'>{prod.nombre}</h6>
                    
                    <h6 class='card-title'>idprod: {prod.idProducto}</h6>
                    <h6 class='card-title'>sku: {prod.sku}</h6>
                    <h6 class='card-title'>idsede fun: {_idSede}</h6>
                    <h6 class='card-title'>idsede prod: {prod.idSede}</h6>
                    <h6 class='card-title'>marca prod: {prod.marca.nombre}</h6>
                    <h6 class='card-title'>stock : {productoSedeSeleccionada.cantidad}</h6> 
                    <h6 class='card-title'>sku: {prod.sku}</h6>
                    <p class='card-text'>S/{prod.precio:F2}</p>
                </div>
            </div>
        </a>
    </div>"
                    };

                    // Agrega el HTML generado al contenedor en la página
                    productContainer.Controls.Add(productHtml);
                }
                else
                {
                    Console.WriteLine($"Producto con SKU {prod.sku} no tiene stock o no fue encontrado.");
                }
            }
        }


        //private void CargarProductos0(int _idSede)
        //{
        //    // Llama al método para obtener los productos desde el backend
        //    //BindingList<producto> productos = productoBO.Producto_listar();

        //    BindingList<producto> productos = productoBO.Producto_listar();
        //    // Recorre la lista de productos y genera el HTML para cada uno
        //    foreach (producto prod in productos)
        //    {
        //        // Convierte el arreglo de bytes de la imagen a una cadena en Base64
        //        string base64Image = Convert.ToBase64String(prod.imagen);
        //        string imageSrc = $"data:image/jpeg;base64,{base64Image}";
        //        producto productoSedeSeleccionada = productoBO.Producto_buscar_sku(prod.sku, _idSede);//permite acceder a la cantidad

        //        if (productoSedeSeleccionada.cantidad > 0)
        //        {
        //            // Crea el contenedor HTML del producto
        //            Literal productHtml = new Literal
        //            {
        //                Text = $@"
        //    <div class='col-md-4 mb-4' data-sede='{prod.idSede}' data-category='{prod.tipoProducto.tipo}' data-price='{prod.precio}' data-brand='{prod.marca.nombre}'>
        //        <a href='detalle_producto.aspx?sku={prod.sku}&sede={_idSede}' class='text-decoration-none'>
        //            <div class='card'>
        //                <div class='card-img-container'>
        //                    <img src='{imageSrc}' class='card-img-top' alt='{prod.nombre}'>
        //                </div>
        //                <div class='card-body'>
        //                    <h6 class='card-title'>{prod.nombre}</h6>

        //                    <h6 class='card-title'>idprod: {prod.idProducto}</h6>
        //                    <h6 class='card-title'>sku: {prod.sku}</h6>
        //                    <h6 class='card-title'>idsede fun: {_idSede}</h6>
        //                    <h6 class='card-title'>idsede prod: {prod.idSede}</h6>
        //                    <h6 class='card-title'>marca prod: {prod.marca.nombre}</h6>
        //                    <h6 class='card-title'>stock : {productoSedeSeleccionada.cantidad}</h6> 
        //                    <h6 class='card-title'>sku: {prod.sku}</h6>
        //                    <p class='card-text'>S/{prod.precio:F2}</p>
        //                </div>
        //            </div>
        //        </a>
        //    </div>"
        //            };
        //            //<h6 class='card-title'>stock : {productoSedeSeleccionada.cantidad}</h6>   
        //            // Agrega el HTML generado al contenedor en la página
        //            // if (productoSedeSeleccionada.cantidad > 0)

        //            productContainer.Controls.Add(productHtml);
        //        }
        //    }
        //}
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