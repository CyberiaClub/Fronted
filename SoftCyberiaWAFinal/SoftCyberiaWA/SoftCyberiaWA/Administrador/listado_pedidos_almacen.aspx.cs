
using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
using SoftCyberiaVentaBO;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class listado_pedidos_almacen : Page
    {
        private readonly ComprobantePagoBO comprobantePagoBO;
        private readonly ProductoBO productoBO;
        private BindingList<comprobantePago> comprobantes;
        private BindingList<producto> productos;
        private persona usuario;

        public listado_pedidos_almacen()
        {
            comprobantePagoBO = new ComprobantePagoBO();
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
                usuario = (persona)Session["Usuario"];
                LlenarGVPedidos();
            }
        }

        protected void DdlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            _ = Enum.TryParse(row.Cells[2].Text, out estadoPedido estado);
            comprobantePago comprobante = new comprobantePago
            {
                idComprobantePago = int.Parse(row.Cells[3].Text),
                estadoPedido = estado,
                estadoPedidoSpecified = true
            };
            _ = comprobantePagoBO.Comprobante_pago_modificar(comprobante);
        }

        protected void GvPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlEstado = (DropDownList)e.Row.FindControl("ddlEstado");
                if (ddlEstado != null)
                {
                    ddlEstado.SelectedValue = e.Row.Cells[2].Text; //Asigna EstadoPedido al DropDownList
                }
            }
        }

        protected void LlenarGVPedidos()
        {
            Debug.WriteLine(usuario.idSede);
            comprobantes = comprobantePagoBO.Comprobante_pago_listar_sede(usuario.idSede);
            DataTable gv = new DataTable();

            gv.Columns.AddRange(new DataColumn[]{
                new DataColumn("NumeroPedido",typeof(string)),
                new DataColumn("FechaCreacion",typeof(string)),
                new DataColumn("Estado",typeof(string)),
                new DataColumn("idPedido",typeof(string))
            });

            if (comprobantes.First().idComprobantePago != 0)
            {
                foreach (comprobantePago comprobante in comprobantes)
                {
                    _ = gv.Rows.Add(comprobante.numero, comprobante.fecha, comprobante.estadoPedido, comprobante.idComprobantePago);
                }
            }

            gvPedidos.DataSource = gv;
            gvPedidos.DataBind();
            gvPedidos.Columns[2].Visible = false;
            gvPedidos.Columns[3].Visible = false;
        }


        protected void GvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el número de pedido seleccionado
            int selectedIndex = gvPedidos.SelectedIndex;
            if (selectedIndex >= 0)
            {
                string idPedido = gvPedidos.Rows[selectedIndex].Cells[3].Text;

                // Llamar al método para llenar el detalle de productos
                LlenarGVDetalleProductos(idPedido);

                // Mostrar el panel de detalle y ocultar el de pedidos
                panelDetallePedido.Visible = true;
                panelPedidos.Visible = false;
            }
        }


        protected void LlenarGVDetalleProductos(string numeroPedido)
        {
            if (numeroPedido != null)
            {
                DataTable dtDetalles = new DataTable();
                dtDetalles.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("NombreProducto", typeof(string)),
                    new DataColumn("Precio", typeof(decimal)),
                    new DataColumn("Cantidad", typeof(int)),
                    new DataColumn("Subtotal", typeof(decimal))
                });

                productos = productoBO.Producto_buscar_pedido(int.Parse(numeroPedido));

                foreach (producto producto in productos)
                {
                    _ = dtDetalles.Rows.Add(producto.nombre, producto.precio, producto.cantidad, producto.precio * producto.cantidad);
                }
                gvDetalleProductos.DataSource = dtDetalles;
                gvDetalleProductos.DataBind();
            }
        }
    }
}