using SoftCyberiaWA.CyberiaWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Vendedor
{
    public partial class listado_pedidos : System.Web.UI.Page
    {
        //private PedidoWSClient daoPedido = new PedidoWSClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPedidos();
            }
        }

        private void CargarPedidos()
        {
            //gvPedidos.DataSource = daoPedido.pedido_listar();
            //gvPedidos.DataBind();
        }

        protected void gvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el número de pedido seleccionado
            GridViewRow row = gvPedidos.SelectedRow;
            string numeroPedido = row.Cells[1].Text;

            // Cargar el detalle del pedido seleccionado
            CargarDetallePedido(numeroPedido);
        }

        private void CargarDetallePedido(string numeroPedido)
        {
            //gvDetalleProductos.DataSource = daoPedido.obtenerDetallePedido(numeroPedido);
            gvDetalleProductos.DataBind();
            panelDetallePedido.Visible = true;
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;

            string numeroPedido = row.Cells[1].Text;
            string nuevoEstado = ddl.SelectedValue;

            // Actualizar el estado del pedido
            //daoPedido.actualizarEstadoPedido(numeroPedido, nuevoEstado);

            // Recargar la lista de pedidos para reflejar el cambio
            CargarPedidos();
        }

    }
}

