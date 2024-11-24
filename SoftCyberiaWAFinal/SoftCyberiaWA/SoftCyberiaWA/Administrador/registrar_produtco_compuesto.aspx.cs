using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Data;
using System.Web.UI.HtmlControls;
using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
using System.ComponentModel;

namespace SoftCyberiaWA.Administrador
{
    public partial class registrar_produtco_compuesto : System.Web.UI.Page
    {
        private ProductoBO productoBO;
        private TipoProductoBO tipoProductoBO;
        private MarcaBO marcaBO;
        private producto _producto;
        private producto _productoCompuesto;
        private BindingList<producto> _productosCompuestos;


        int cont = 0;

        public registrar_produtco_compuesto()
        {
            productoBO = new ProductoBO();
            tipoProductoBO = new TipoProductoBO();
            marcaBO = new MarcaBO();
            _producto = new producto();
            _productoCompuesto = new producto();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarMarcas();
                CargarCategoria();
            }
        }

        private void CargarCategoria()
        {
            productoTipoProducto.DataSource = tipoProductoBO.tipoProducto_listar();
            productoTipoProducto.DataTextField = "tipo";
            productoTipoProducto.DataValueField = "idTipoProducto";
            productoTipoProducto.DataBind(); // Llenar el DropDownList

            productoTipoProducto.Items.Insert(0, new ListItem("Seleccione un Tipo de Producto", "0"));
        }

        private void CargarMarcas()
        {
            productoMarca.DataSource = marcaBO.marca_listar();
            productoMarca.DataTextField = "nombre";
            productoMarca.DataValueField = "idMarca";
            productoMarca.DataBind(); // Llenar el DropDownList
            productoMarca.Items.Insert(0, new ListItem("Seleccione una Marca", "0"));
        }

        protected void sku_TextChange(object sender, EventArgs e)
        {
            if (productoKitSKU.Text.Trim() != "")
            {
                gridViewProdBuscado.DataSource = null;
                gridViewProdBuscado.DataBind();

                producto _producto = productoBO.producto_buscar_sku(productoKitSKU.Text.Trim(), 1);
                if (_producto != null)
                {
                    productoKitSKUMensaje.Visible = false;
                    Session["producto"] = _producto;

                    DataTable datos = new DataTable();
                    datos.Columns.AddRange(new DataColumn[2] { new DataColumn("NOMBRE"), new DataColumn("DESCRIPCION") });
                    datos.Rows.Add(_producto.nombre, _producto.descripcion);
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
            producto _producto = Session["producto"] as producto;
            DataTable datos = new DataTable();
            Boolean duplicado = false;
            if (_producto != null)
            {
                if (gridProductosKit.Rows.Count != 0)
                    datos = Session["datosProductosKit"] as DataTable;
                else
                    datos.Columns.AddRange(new DataColumn[4] { new DataColumn("ID"), new DataColumn("SKU"), new DataColumn("NOMBRE"), new DataColumn("CANTIDAD") });

                if (datos.Rows.Count > 0)
                    duplicado = ComprobarDuplicidad(_producto.idProducto.ToString());

                if (!duplicado)
                {

                    productoKitSKUMensaje.Visible = false;
                    datos.Rows.Add(_producto.idProducto, _producto.sku, _producto.nombre, 0);
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

        protected Boolean ComprobarDuplicidad(String idProductoNuevo)
        {
            DataTable dt = Session["datosProductosKit"] as DataTable;
            string columna = "ID";
            string valorBuscado = idProductoNuevo;

            var indice = dt.AsEnumerable().ToDictionary(row => row.Field<string>(columna));

            if (indice.TryGetValue(valorBuscado, out DataRow fila))
                return true;
            else
                return false;
        }

        protected void gridProductosKit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridProductosKit.EditIndex = e.NewEditIndex;
            gridProductosKit.DataSource = Session["datosProductosKit"] as DataTable;
            gridProductosKit.DataBind();
        }

        protected void gridProductosKit_RowUpdating(object sender, GridViewUpdateEventArgs e)
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

        protected void gridProductosKit_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridProductosKit.EditIndex = -1;
            gridProductosKit.DataSource = Session["datosProductosKit"] as DataTable;
            gridProductosKit.DataBind();
        }

        protected void gridViewProductosKit_RowCommand(object sender, GridViewCommandEventArgs e)
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
                using (var binaryReader = new System.IO.BinaryReader(imagenProducto.PostedFile.InputStream))
                {
                    imagenBytes = binaryReader.ReadBytes(imagenProducto.PostedFile.ContentLength);
                }

                _producto.nombre = productoNombre.Text;
                _producto.sku = productoSku.Text;
                _producto.precio = Convert.ToDouble(productoPrecio.Text);
                _producto.precioSpecified = true;
                _producto.precioProveedor = 0;
                _producto.precioProveedorSpecified = true;
                marca _marca = new marca();
                _marca.idMarca = Convert.ToInt32(productoMarca.SelectedIndex);
                _marca.idMarcaSpecified = true;
                tipoProducto _tipoProd = new tipoProducto();
                _tipoProd.idTipoProducto = Convert.ToInt32(productoTipoProducto.SelectedIndex);
                _tipoProd.idTipoProductoSpecified = true;

                _producto.marca = _marca;
                _producto.tipoProducto = _tipoProd;
                
                _producto.descripcion = productoDescripcion.Text;
                _producto.imagen = imagenBytes;
                _producto.productosMiembros = ObtenerProductosComposicion();

                productoBO.producto_insertar(_producto);

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

            String id, cantidad;
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

        protected Boolean Validar()
        {
            productoSkuMensaje.Visible = true;
            Boolean validarNombre = ValidarCampo(productoNombre, productoNombreMensaje, "Por favor ingrese un nombre para el producto.");
            Boolean validarSku = ValidarCampo(productoSku, productoSkuMensaje, "Por favor ingrese un sku.");
            Boolean validarPrecio = ValidarCampo(productoPrecio, ProductoPrecioMensaje, "Por favor ingrese un precio.");
            Boolean validarMarca = ValidarCampo(null, productoMarcaMensaje, "Por favor seleccione una marca.", true, productoMarca);
            Boolean validarTipoProducto = ValidarCampo(null, ProductoTipoProductoMensaje, "Por favor seleccione un tipo de producto.", true, productoTipoProducto);
            Boolean validarDescripcion = ValidarCampo(productoDescripcion, productoDescripcionMensaje, "Por favor ingrese una descripción.");

            if (validarSku && productoSku.Text.Length > 8)
            {
                validarSku = false;
                productoSkuMensaje.InnerText = "Por favor ingrese un sku de 8 digitos.";
                productoSkuMensaje.Visible = true;
            }

            Boolean validarImagen = true;
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

            Boolean validarComposicion = true;
            
            if(gridProductosKit.Rows.Count == 0)
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

        private Boolean ValidarCampo(TextBox campo, HtmlGenericControl mensaje, string textoError, bool esCombo = false, DropDownList combo = null)
        {
            Boolean valido;
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