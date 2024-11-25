
using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaVentaBO;
using System;
using System.ComponentModel;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class listado_pedidos_almacen : Page
    {
        private readonly ComprobantePagoBO comprobantePagoBO;

        public listado_pedidos_almacen()
        {
            comprobantePagoBO = new ComprobantePagoBO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGVPedidos();
            }
        }

        protected void DdlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            BindingList<comprobantePago> comprobantes = comprobantePagoBO.Comprobante_pago_listar();
            DataTable gv = new DataTable();

            gv.Columns.AddRange(new DataColumn[]{
                new DataColumn("NumeroPedido",typeof(string)),
                new DataColumn("FechaCreacion",typeof(string)),
                new DataColumn("Estado",typeof(string))
            });

            foreach (comprobantePago comprobante in comprobantes)
            {
                _ = gv.Rows.Add(comprobante.numero, comprobante.fecha, comprobante.estadoPedido);
            }

            gvPedidos.DataSource = gv;
            gvPedidos.DataBind();
            gvPedidos.Columns[2].Visible = false;
        }
    }
}