using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class listado_stock : Page
    {
        private readonly ProductoBO productoBO;
        private readonly SedeBO sedeBO;

        public listado_stock()
        {
            productoBO = new ProductoBO();
            sedeBO = new SedeBO();
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
                CargarSedes();
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                producto _producto = productoBO.Producto_buscar_sku(productoSku.Text.Trim(), sedeNombre.SelectedIndex);
                if (_producto != null)
                {
                    productoSkuMensaje.Visible = false;
                    DataTable datos = new DataTable();
                    datos.Columns.AddRange(new DataColumn[5] { new DataColumn("ID"), new DataColumn("SKU"), new DataColumn("NOMBRE"), new DataColumn("DESCRIPCION"), new DataColumn("STOCK") });
                    _ = datos.Rows.Add(_producto.idProducto, _producto.sku, _producto.nombre, _producto.descripcion, _producto.cantidad);
                    gridStockProducto.DataSource = datos;
                    gridStockProducto.DataBind();
                }
                else
                {
                    productoSkuMensaje.InnerText = "Por favor ingrese un valido.";
                    productoSkuMensaje.Visible = true;
                }
            }
        }

        protected bool Validar()
        {
            bool valido = true;
            if (string.IsNullOrWhiteSpace(productoSku.Text.Trim()))
            {
                valido = false;
                productoSkuMensaje.InnerText = "Por favor ingrese un sku.";
                productoSkuMensaje.Visible = true;
            }
            else
            {
                productoSkuMensaje.Visible = false;
            }

            return valido;
        }
        private void CargarSedes()
        {
            sedeNombre.DataSource = sedeBO.Sede_listar();
            sedeNombre.DataTextField = "nombre";
            sedeNombre.DataValueField = "idSede";
            sedeNombre.DataBind();

            sedeNombre.Items.Insert(0, new ListItem("Seleccione una Sede", "0"));
            sedeNombre.SelectedIndex = 0;
        }
    }
}