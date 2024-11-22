using SoftCyberiaWA.CyberiaWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class listado_stock : System.Web.UI.Page
    {
        ProductoWSClient daoProducto = new ProductoWSClient();
        SedeWSClient daoSede = new SedeWSClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSedes();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                producto _producto = daoProducto.producto_buscar_sku(productoSku.Text.Trim(), sedeNombre.SelectedIndex);
                if(_producto != null)
                {
                    productoSkuMensaje.Visible = false;
                    DataTable datos = new DataTable();
                    datos.Columns.AddRange(new DataColumn[5] { new DataColumn("ID"), new DataColumn("SKU"), new DataColumn("NOMBRE"), new DataColumn("DESCRIPCION"), new DataColumn("STOCK") });
                    datos.Rows.Add(_producto.idProducto, _producto.sku, _producto.nombre, _producto.descripcion, _producto.cantidad);
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

        protected Boolean Validar()
        {
            Boolean valido = true;
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
            sedeNombre.DataSource = daoSede.sede_listar();
            sedeNombre.DataTextField = "nombre";
            sedeNombre.DataValueField = "idSede";
            sedeNombre.DataBind();

            sedeNombre.Items.Insert(0, new ListItem("Seleccione una Sede", "0"));
            sedeNombre.SelectedIndex = 0;
        }
    }
}