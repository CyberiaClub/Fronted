using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
using System.ComponentModel;

namespace SoftCyberiaWA.Administrador
{
    public partial class Registrar_produtco_compuesto : System.Web.UI.Page
    {
        private readonly ProductoBO productoBO;
        private readonly TipoProductoBO tipoProductoBO;
        private readonly MarcaBO marcaBO;
        private readonly producto _producto;
        private readonly producto _productoCompuesto;
        private readonly BindingList<producto> _productosCompuestos;

        public Registrar_produtco_compuesto()
        {
            productoBO = new ProductoBO();
            tipoProductoBO = new TipoProductoBO();
            marcaBO = new MarcaBO();
            _producto = new producto();
            _productoCompuesto = new producto();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMarcas();
                CargarCategoria();
            }
        }

        private void CargarCategoria()
        {
            productoTipoProducto.DataSource = tipoProductoBO.TipoProducto_listar();
            productoTipoProducto.DataTextField = "tipo";
            productoTipoProducto.DataValueField = "idTipoProducto";
            productoTipoProducto.DataBind(); // Llenar el DropDownList

            productoTipoProducto.Items.Insert(0, new ListItem("Seleccione un Tipo de Producto", "0"));
        }

        private void CargarMarcas()
        {
            productoMarca.DataSource = marcaBO.Marca_listar();
            productoMarca.DataTextField = "nombre";
            productoMarca.DataValueField = "idMarca";
            productoMarca.DataBind(); // Llenar el DropDownList
            productoMarca.Items.Insert(0, new ListItem("Seleccione una Marca", "0"));
        }

        protected void Sku_TextChange(object sender, EventArgs e)
        {
            if (productoKitSKU.Text.Trim() != "")
            {
                gridViewProdBuscado.DataSource = null;
                gridViewProdBuscado.DataBind();

                producto _producto = productoBO.Producto_buscar_sku(productoKitSKU.Text.Trim(), 1);
                if (_producto != null)
                {
                    productoKitSKUMensaje.Visible = false;
                    Session["producto"] = _producto;

                    DataTable datos = new DataTable();
                    datos.Columns.AddRange(new DataColumn[2] { new DataColumn("NOMBRE"), new DataColumn("DESCRIPCION") });
                    _ = datos.Rows.Add(_producto.nombre, _producto.descripcion);
                    gridViewProdBuscado.DataSource = datos;
                    gridViewProdBuscado.DataBind();
                }
                else
                {
                    productoKitSKUMensaje.InnerText = "No se econtró ningún producto para el sku ingresado.";
                    productoKitSKUMensaje.Visible = true;
                }
            }
            else
            {
                Session["producto"] = null;
                productoKitSKUMensaje.InnerText = "Por favor ingrese un sku.";
                productoKitSKUMensaje.Visible = true;
            }
        }

        protected void AgregarProducto_Click(object sender, EventArgs e)
        {
            DataTable datos = new DataTable();
            bool duplicado = false;
            if (Session["producto"] is producto _producto)
            {
                if (gridProductosKit.Rows.Count != 0)
                {
                    datos = Session["datosProductosKit"] as DataTable;
                }
                else
                {
                    datos.Columns.AddRange(new DataColumn[4] { new DataColumn("ID"), new DataColumn("SKU"), new DataColumn("NOMBRE"), new DataColumn("CANTIDAD") });
                }

                if (datos.Rows.Count > 0)
                {
                    duplicado = ComprobarDuplicidad(_producto.idProducto.ToString());
                }

                if (!duplicado)
                {

                    productoKitSKUMensaje.Visible = false;
                    _ = datos.Rows.Add(_producto.idProducto, _producto.sku, _producto.nombre, 0);
                    Session["datosProductosKit"] = datos;
                    gridProductosKit.DataSource = Session["datosProductosKit"] as DataTable;
                    gridProductosKit.DataBind();
                }
                else
                {
                    productoKitSKUMensaje.InnerText = "Este producto ya ha sido ingresado.";
                    productoKitSKUMensaje.Visible = true;
                }
            }
            else
            {
                Session["producto"] = null;
                productoKitSKUMensaje.InnerText = "No se ha encontrado ningún producto";
                productoKitSKUMensaje.Visible = true;
            }
        }

        protected bool ComprobarDuplicidad(string idProductoNuevo)
        {
            if (idProductoNuevo is null)
            {
                throw new ArgumentNullException(nameof(idProductoNuevo));
            }

            DataTable dt = Session["datosProductosKit"] as DataTable;
            string columna = "ID";
            string valorBuscado = idProductoNuevo;

            System.Collections.Generic.Dictionary<string, DataRow> indice = dt.AsEnumerable().ToDictionary(row => row.Field<string>(columna));

            return indice.TryGetValue(valorBuscado, out DataRow fila);
        }

        protected void GridProductosKit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridProductosKit.EditIndex = e.NewEditIndex;
            gridProductosKit.DataSource = Session["datosProductosKit"] as DataTable;
            gridProductosKit.DataBind();
        }

        protected void GridProductosKit_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataTable datos = Session["datosProductosKit"] as DataTable;

            string descuento = (gridProductosKit.Rows[rowIndex].FindControl("txtCantidad") as TextBox).Text;
            datos.Rows[rowIndex]["CANTIDAD"] = descuento;

            gridProductosKit.EditIndex = -1;
            Session["datosProductosKit"] = datos;
            gridProductosKit.DataSource = Session["datosProductosKit"] as DataTable;
            gridProductosKit.DataBind();
        }

        protected void GridProductosKit_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridProductosKit.EditIndex = -1;
            gridProductosKit.DataSource = Session["datosProductosKit"] as DataTable;
            gridProductosKit.DataBind();
        }

        protected void GridViewProductosKit_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EliminarProducto")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                EliminarProductoDeLaLista(id);
                gridProductosKit.DataSource = Session["datosProductosKit"] as DataTable;
                gridProductosKit.DataBind();
            }
        }

        private void EliminarProductoDeLaLista(int id)
        {
            DataTable datos = Session["datosProductosKit"] as DataTable;
            datos.Rows[id].Delete();
            Session["datosProductosKit"] = datos;
        }

        protected void RegistrarKit_Click(object sender, EventArgs e)
        {
            producto _producto = new producto();

            if (Validar())
            {
                byte[] imagenBytes;
                using (System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(imagenProducto.PostedFile.InputStream))
                {
                    imagenBytes = binaryReader.ReadBytes(imagenProducto.PostedFile.ContentLength);
                }

                _producto.nombre = productoNombre.Text;
                _producto.sku = productoSku.Text;
                _producto.precio = Convert.ToDouble(productoPrecio.Text);
                _producto.precioSpecified = true;
                _producto.precioProveedor = 0;
                _producto.precioProveedorSpecified = true;
                marca _marca = new marca
                {
                    idMarca = Convert.ToInt32(productoMarca.SelectedIndex),
                    idMarcaSpecified = true
                };
                tipoProducto _tipoProd = new tipoProducto
                {
                    idTipoProducto = Convert.ToInt32(productoTipoProducto.SelectedIndex),
                    idTipoProductoSpecified = true
                };

                _producto.marca = _marca;
                _producto.tipoProducto = _tipoProd;

                _producto.descripcion = productoDescripcion.Text;
                _producto.imagen = imagenBytes;
                _producto.productosMiembros = ObtenerProductosComposicion();

                _ = productoBO.Producto_insertar(_producto);

                successMessage.Text = "Producto compuesto asignada correctamente.";
                successMessage.Visible = true;
            }
        }

        protected producto[] ObtenerProductosComposicion()
        {
            DataTable datos = Session["datosProductosKit"] as DataTable;
            producto[] productosKit = new producto[datos.Rows.Count];
            producto productoKit;
            int cont = 0;

            string id, cantidad;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                productoKit = new producto();
                id = datos.Rows[i]["ID"].ToString();
                cantidad = datos.Rows[i]["CANTIDAD"].ToString();
                productoKit.idProducto = Convert.ToInt32(id);
                productoKit.idProductoSpecified = true;
                productoKit.cantidad = Convert.ToInt32(cantidad);
                productoKit.cantidadSpecified = true;
                productosKit[cont] = productoKit;
                cont++;
            }

            return productosKit;
        }

        protected bool Validar()
        {
            productoSkuMensaje.Visible = true;
            bool validarNombre = ValidarCampo(productoNombre, productoNombreMensaje, "Por favor ingrese un nombre para el producto.");
            bool validarSku = ValidarCampo(productoSku, productoSkuMensaje, "Por favor ingrese un sku.");
            bool validarPrecio = ValidarCampo(productoPrecio, ProductoPrecioMensaje, "Por favor ingrese un precio.");
            bool validarMarca = ValidarCampo(null, productoMarcaMensaje, "Por favor seleccione una marca.", true, productoMarca);
            bool validarTipoProducto = ValidarCampo(null, ProductoTipoProductoMensaje, "Por favor seleccione un tipo de producto.", true, productoTipoProducto);
            bool validarDescripcion = ValidarCampo(productoDescripcion, productoDescripcionMensaje, "Por favor ingrese una descripción.");

            if (validarSku && productoSku.Text.Length > 8)
            {
                validarSku = false;
                productoSkuMensaje.InnerText = "Por favor ingrese un sku de 8 digitos.";
                productoSkuMensaje.Visible = true;
            }

            bool validarImagen = true;
            if (!imagenProducto.HasFile)
            {
                validarImagen = false;
                productoImagenMensaje.InnerText = "Por favor ingrese una imagen.";
                productoImagenMensaje.Visible = true;
            }
            else
            {
                productoImagenMensaje.Visible = false;
            }

            bool validarComposicion = true;

            if (gridProductosKit.Rows.Count == 0)
            {
                validarComposicion = false;
                productoKitSKUMensaje.InnerText = "Por favor ingrese al menos dos productos al kit";
                productoKitSKUMensaje.Visible = true;
            }
            else
            {
                productoImagenMensaje.Visible = false;
            }


            return validarNombre && validarSku && validarPrecio && validarMarca && validarTipoProducto && validarDescripcion && validarImagen && validarComposicion;
        }

        private bool ValidarCampo(TextBox campo, HtmlGenericControl mensaje, string textoError, bool esCombo = false, DropDownList combo = null)
        {
            bool valido;
            if (esCombo)
            {
                if (combo.SelectedIndex == 0)
                {
                    valido = false;
                    mensaje.InnerText = textoError;
                    mensaje.Visible = true;
                }
                else
                {
                    valido = true;
                    mensaje.Visible = false;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(campo.Text))
                {
                    valido = false;
                    mensaje.InnerText = textoError;
                    mensaje.Visible = true;
                }
                else
                {
                    valido = true;
                    mensaje.Visible = false;
                }
            }
            return valido;
        }
    }
}