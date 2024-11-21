using SoftCyberiaWA.CyberiaWS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class listado_pedidos : System.Web.UI.Page
    {
        private ComprobantePagoWSClient daoComprobantePago = new ComprobantePagoWSClient();
        private ProductoWSClient daoProducto = new ProductoWSClient();
        private comprobantePago[] comprobantes;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarGVPedidos();
            }
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void llenarGVPedidos()
        {
            comprobantes = daoComprobantePago.comprobante_pago_listar();
            DataTable gv = new DataTable();

            gv.Columns.AddRange(new DataColumn[]{
                new DataColumn("NumeroPedido",typeof(string)),
                new DataColumn("FechaCreacion",typeof(string)),
                new DataColumn("Estado",typeof(string))
            });

            foreach (comprobantePago comprobante in comprobantes)
            {
                gv.Rows.Add(comprobante.numero, comprobante.fecha, comprobante.estadoPedido);
            }

            gvPedidos.DataSource = gv;
            gvPedidos.DataBind();
            gvPedidos.Columns[2].Visible = false;
        }


        protected void gvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el número de pedido seleccionado
            int selectedIndex = gvPedidos.SelectedIndex;
            if (selectedIndex >= 0)
            {
                string numeroPedido = gvPedidos.Rows[selectedIndex].Cells[0].Text;

                // Llamar al método para llenar el detalle de productos
                llenarGVDetalleProductos(numeroPedido);

                // Mostrar el panel de detalle y ocultar el de pedidos
                panelDetallePedido.Visible = true;
                panelPedidos.Visible = false;
            }
        }


        protected void llenarGVDetalleProductos(string numeroPedido)
        {
            // Buscar el pedido correspondiente en la lista de comprobantes
            //comprobantePago pedidoSeleccionado = comprobantes.FirstOrDefault(c => c.numero == numeroPedido);

            //if (pedidoSeleccionado != null)
            //{
            //    // Crear un DataTable para almacenar los detalles del pedido
            //    DataTable dtDetalles = new DataTable();
            //    dtDetalles.Columns.AddRange(new DataColumn[]
            //    {
            //        new DataColumn("NombreProducto", typeof(string)),
            //        new DataColumn("Precio", typeof(decimal)),
            //        new DataColumn("Cantidad", typeof(int)),
            //        new DataColumn("Subtotal", typeof(decimal))
            //    });

                //// Recorrer los productos asociados al comprobante
                //foreach (var linea in pedidoSeleccionado.lineaPedido) // Suponiendo que lineaPedido es un array de "COMPROBANTE_PAGO_X_PRODUCTO"
                //{
                //    // Obtener la información del producto usando el ID del producto
                //    producto _producto = daoProducto.producto_buscar_sku(linea.id_producto); // Método que consulta el producto por su ID

                //    if (_producto != null)
                //    {
                //        decimal precio = _producto.precio; // Precio del producto
                //        int cantidad = linea.cantidad; // Cantidad de producto en el pedido
                //        decimal subtotal = precio * cantidad;

                //        // Agregar una fila con los datos al DataTable
                //        dtDetalles.Rows.Add(_producto.nombre, precio, cantidad, subtotal);
                //    }
                //}

                // Asignar el DataTable como fuente de datos del GridView
                //gvDetalleProductos.DataSource = dtDetalles;
                //gvDetalleProductos.DataBind();
            }
        }


        //protected void btnRegresar_Click(object sender, EventArgs e)
        //{
        //    // Mostrar el panel de pedidos y ocultar el de detalle
        //    panelDetallePedido.Visible = false;
        //    panelPedidos.Visible = true;
        //}

    

}