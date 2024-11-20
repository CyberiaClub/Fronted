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
    public partial class listado_pedidos_almacen : System.Web.UI.Page
    {
        private ComprobantePagoWSClient daoComprobantePago = new ComprobantePagoWSClient();
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
            comprobantePago[] comprobantes = daoComprobantePago.comprobante_pago_listar();
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
    }
}