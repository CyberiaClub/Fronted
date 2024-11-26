using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaVentaBO;
using SoftCyberiaInventarioBO;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.IO;


namespace SoftCyberiaWA.Administrador
{
    public partial class Asignar_oferta : Page
    {
        private readonly OfertaBO ofertaBO;
        private readonly ProductoBO productoBO;

        public Asignar_oferta()
        {
            ofertaBO = new OfertaBO();
            productoBO = new ProductoBO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null || Session["paginas"] == null)
            {
                Response.Redirect("~/InicioSesion/indexInicioSesion.aspx");
            }
            // Obtener la ruta completa
            string currentPage = Request.Url.AbsolutePath;

            // Extraer solo el archivo
            string fileName = Path.GetFileName(currentPage);
            if (!(Session["paginas"] is BindingList<pagina> allowedPages))
            {
                Response.Redirect("~/InicioSesion/indexInicioSesion.aspx");
            }
            else
            {
                if (!allowedPages.Any(page => page.referencia.Equals(fileName, StringComparison.OrdinalIgnoreCase)))
                {
                    // Redirigir a la página 403 si no tiene acceso
                    Response.Redirect("~/InicioSesion/403.aspx");
                }
            }


            if (!IsPostBack)
            {
                productoSKU.Text = "";
                gridProductosOferta.DataSource = Session["datosProductosOferta"] as DataTable; // Asigna tu origen de datos
                gridProductosOferta.DataBind();
            }
        }

        protected void Sku_TextChange(object sender, EventArgs e)
        {
            if (productoSKU.Text.Trim() != "")
            {
                gridViewProdBuscado.DataSource = null;
                gridViewProdBuscado.DataBind();

                producto _producto = productoBO.Producto_buscar_sku(productoSKU.Text.Trim(), 1);
                if (_producto != null)
                {
                    productoSKUMensaje.Visible = false;
                    Session["producto"] = _producto;

                    DataTable datos = new DataTable();
                    datos.Columns.AddRange(new DataColumn[2] { new DataColumn("NOMBRE"), new DataColumn("DESCRIPCION") });
                    _ = datos.Rows.Add(_producto.nombre, _producto.descripcion);
                    gridViewProdBuscado.DataSource = datos;
                    gridViewProdBuscado.DataBind();
                }
                else
                {
                    productoSKUMensaje.InnerText = "No se econtró ningún producto para el sku ingresado.";
                    productoSKUMensaje.Visible = true;
                }
            }
            else
            {
                Session["producto"] = null;
                productoSKUMensaje.InnerText = "Por favor ingrese un sku.";
                productoSKUMensaje.Visible = true;
            }
        }

        protected void AgregarProducto_Click(object sender, EventArgs e)
        {
            DataTable datos = new DataTable();
            bool duplicado = false;
            if (Session["producto"] is producto _producto)
            {
                if (gridProductosOferta.Rows.Count != 0)
                {
                    datos = Session["datosProductosOferta"] as DataTable;
                }
                else
                {
                    datos.Columns.AddRange(new DataColumn[4] { new DataColumn("ID"), new DataColumn("SKU"), new DataColumn("NOMBRE"), new DataColumn("DESCUENTO") });
                }

                if (datos.Rows.Count > 0)
                {
                    duplicado = ComprobarDuplicidad(_producto.idProducto.ToString());
                }

                if (!duplicado)
                {

                    productoSKUMensaje.Visible = false;
                    _ = datos.Rows.Add(_producto.idProducto, _producto.sku, _producto.nombre, 0);
                    Session["datosProductosOferta"] = datos;
                    gridProductosOferta.DataSource = Session["datosProductosOferta"] as DataTable;
                    gridProductosOferta.DataBind();
                }
                else
                {
                    productoSKUMensaje.InnerText = "Este producto ya ha sido ingresado.";
                    productoSKUMensaje.Visible = true;
                }
            }
            else
            {
                Session["producto"] = null;
                productoSKUMensaje.InnerText = "No se ha encontrado ningún producto";
                productoSKUMensaje.Visible = true;
            }
        }

        protected bool ComprobarDuplicidad(string idProductoNuevo)
        {
            DataTable dt = Session["datosProductosOferta"] as DataTable;
            string columna = "ID";
            string valorBuscado = idProductoNuevo;

            System.Collections.Generic.Dictionary<string, DataRow> indice = dt.AsEnumerable().ToDictionary(row => row.Field<string>(columna));

            return indice.TryGetValue(valorBuscado, out DataRow fila);
        }

        protected void GridProductosOferta_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridProductosOferta.EditIndex = e.NewEditIndex;
            gridProductosOferta.DataSource = Session["datosProductosOferta"] as DataTable;
            gridProductosOferta.DataBind();
        }

        protected void GridProductosOferta_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataTable datos = Session["datosProductosOferta"] as DataTable;

            string descuento = (gridProductosOferta.Rows[rowIndex].FindControl("txtDescuento") as TextBox).Text;
            datos.Rows[rowIndex]["DESCUENTO"] = descuento;

            gridProductosOferta.EditIndex = -1;
            Session["datosProductosOferta"] = datos;
            gridProductosOferta.DataSource = Session["datosProductosOferta"] as DataTable;
            gridProductosOferta.DataBind();
        }

        protected void GridProductosOferta_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridProductosOferta.EditIndex = -1;
            gridProductosOferta.DataSource = Session["datosProductosOferta"] as DataTable;
            gridProductosOferta.DataBind();
        }

        protected void GridViewProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EliminarProducto")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                EliminarProductoDeLaLista(id);
                gridProductosOferta.DataSource = Session["datosProductosOferta"] as DataTable;
                gridProductosOferta.DataBind();
            }
        }

        private void EliminarProductoDeLaLista(int id)
        {
            DataTable datos = Session["datosProductosOferta"] as DataTable;
            datos.Rows[id].Delete();
            Session["datosProductosOferta"] = datos;
        }

        protected void BtnAsignarOferta_Click(object sender, EventArgs e)
        {
            oferta _oferta = new oferta();

            if (Validar())
            {
                byte[] imagenBytes;
                using (System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fileUploadProductImage.PostedFile.InputStream))
                {
                    imagenBytes = binaryReader.ReadBytes(fileUploadProductImage.PostedFile.ContentLength);
                }

                _oferta.fechaDeInicio = DateTime.Parse(fechaInicio.Text.Trim());
                _oferta.fechaDeInicioSpecified = true;
                _oferta.fechaDeFin = DateTime.Parse(fechaFin.Text.Trim());
                _oferta.fechaDeFinSpecified = true;
                _oferta.imagen = imagenBytes;
                producto[] productosOferta = ObtenerProductosOferta();

                _ = ofertaBO.Oferta_insertar(_oferta, productosOferta);

                successMessage.Text = "Oferta asignada correctamente.";
                successMessage.Visible = true;
            }
        }

        protected producto[] ObtenerProductosOferta()
        {
            DataTable datos = Session["datosProductosOferta"] as DataTable;
            producto[] productosOferta = new producto[datos.Rows.Count];
            producto productoOferta;
            int cont = 0;

            string id, descuento;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                productoOferta = new producto();
                id = datos.Rows[i]["ID"].ToString();
                descuento = datos.Rows[i]["DESCUENTO"].ToString();
                productoOferta.idProducto = Convert.ToInt32(id);
                productoOferta.idProductoSpecified = true;
                productoOferta.oferta = Convert.ToInt32(descuento);
                productoOferta.ofertaSpecified = true;
                productosOferta[cont] = productoOferta;
                cont++;
            }

            return productosOferta;
        }

        protected bool Validar()
        {
            bool validarFechaInicio = ValidarCampo(fechaInicio, fechaInicioMensaje, "Por favor seleccione una fecha de inicio.");
            bool validarFechaFin = ValidarCampo(fechaFin, fechaFinMensaje, "Por favor seleccione una fecha de fin.");

            if (validarFechaInicio && validarFechaFin)
            {
                if (DateTime.Parse(fechaFin.Text.Trim()) < DateTime.Parse(fechaInicio.Text.Trim()))
                {
                    fechaFinMensaje.InnerText = "La fecha de fin no puede ser menor a la fecha de inicio.";
                    fechaFin.Visible = true;
                }

                if (DateTime.Parse(fechaInicio.Text.Trim()) < DateTime.Today)
                {
                    fechaInicioMensaje.InnerText = "La fecha de inicio no puede ser menor a la fecha actual.";
                    fechaInicioMensaje.Visible = true;
                }

                if (DateTime.Parse(fechaFin.Text.Trim()) < DateTime.Today)
                {
                    fechaFinMensaje.InnerText = "La fecha de fin  no puede ser menor a la fecha actual.";
                    fechaFinMensaje.Visible = true;
                }
            }

            bool validarProductos = true;

            if (gridProductosOferta.Rows.Count <= 0)
            {
                validarProductos = false;
                productoSKUMensaje.InnerText = "Ingrese al menos un producto.";
                productoSKUMensaje.Visible = true;
            }
            else
            {
                productoSKUMensaje.Visible = false;
            }

            return validarFechaFin && validarFechaInicio && validarProductos;
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