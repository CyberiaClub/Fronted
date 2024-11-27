using SoftCyberiaBaseBO.CyberiaWS;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web.UI;

namespace SoftCyberiaWA.Vendedor
{
    public partial class Listado_pedidos : Page
    {
        //private PedidoWSClient daoPedido = new PedidoWSClient();
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
                //CargarPedidos();
            }
        }

        private void CargarPedidos()
        {
            //gvPedidos.DataSource = daoPedido.pedido_listar();
            //gvPedidos.DataBind();
        }

        //protected void gvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // Obtener el número de pedido seleccionado
        //    GridViewRow row = gvPedidos.SelectedRow;
        //    string numeroPedido = row.Cells[1].Text;

        //    // Cargar el detalle del pedido seleccionado
        //    CargarDetallePedido(numeroPedido);
        //}

        //private void CargarDetallePedido(string numeroPedido)
        //{
        //    //gvDetalleProductos.DataSource = daoPedido.obtenerDetallePedido(numeroPedido);
        //    gvDetalleProductos.DataBind();
        //    panelDetallePedido.Visible = true;
        //}

        //protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DropDownList ddl = (DropDownList)sender;
        //    GridViewRow row = (GridViewRow)ddl.NamingContainer;

        //    string numeroPedido = row.Cells[1].Text;
        //    string nuevoEstado = ddl.SelectedValue;

        //    // Actualizar el estado del pedido
        //    //daoPedido.actualizarEstadoPedido(numeroPedido, nuevoEstado);

        //    // Recargar la lista de pedidos para reflejar el cambio
        //    CargarPedidos();
        //}

    }
}

