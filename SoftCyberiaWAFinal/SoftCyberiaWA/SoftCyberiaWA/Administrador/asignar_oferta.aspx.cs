using SoftCyberiaWA.CyberiaWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace SoftCyberiaWA.Administrador
{
    public partial class asignar_oferta : System.Web.UI.Page
    {
        private OfertaWSClient daoOferta = new OfertaWSClient();
        private ProductoWSClient daoProducto = new ProductoWSClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sku_TextChange(object sender, EventArgs e)
        {
            if (productoSKU.Text.Trim() != "")
            {
                gridViewProdBuscado.DataSource = null;
                gridViewProdBuscado.DataBind();

                producto _producto = daoProducto.producto_buscar_sku(productoSKU.Text.Trim(), 1);
                if (_producto != null)
                {
                    productoSKUMensaje.Visible = false;
                    Session["producto"] = _producto;

                    DataTable datos = new DataTable();
                    datos.Columns.AddRange(new DataColumn[2] { new DataColumn("NOMBRE"), new DataColumn("DESCRIPCION") });
                    datos.Rows.Add(_producto.nombre, _producto.descripcion);
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
            producto _producto = Session["producto"] as producto;
            DataTable datos = new DataTable();
            Boolean duplicado=false;
            if (_producto != null)
            {
                if (gridProductosOferta.Rows.Count != 0)
                    datos = Session["datosProductosOferta"] as DataTable;
                else
                    datos.Columns.AddRange(new DataColumn[4] { new DataColumn("ID"), new DataColumn("SKU"), new DataColumn("NOMBRE"), new DataColumn("DESCUENTO") });

                if (datos.Rows.Count > 0)
                    duplicado = ComprobarDuplicidad(_producto.idProducto.ToString());
                    
                if(!duplicado){

                    productoSKUMensaje.Visible = false;
                    datos.Rows.Add(_producto.idProducto, _producto.sku, _producto.nombre, 0);
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

        protected Boolean ComprobarDuplicidad(String idProductoNuevo)
        {
            DataTable dt = Session["datosProductosOferta"] as DataTable;
            string columna = "ID";
            string valorBuscado = idProductoNuevo;

            var indice = dt.AsEnumerable().ToDictionary(row => row.Field<string>(columna));

            if (indice.TryGetValue(valorBuscado, out DataRow fila))
                return true;
            else
                return false;
        }

        protected void gridProductosOferta_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridProductosOferta.EditIndex = e.NewEditIndex;
            gridProductosOferta.DataSource = Session["datosProductosOferta"] as DataTable;
            gridProductosOferta.DataBind();
        }

        protected void gridProductosOferta_RowUpdating(object sender, GridViewUpdateEventArgs e)
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

        protected void gridProductosOferta_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridProductosOferta.EditIndex = -1;
            gridProductosOferta.DataSource = Session["datosProductosOferta"] as DataTable;
            gridProductosOferta.DataBind();
        }

        protected void gridViewProductos_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void btnAsignarOferta_Click(object sender, EventArgs e)
        {
            oferta _oferta = new oferta();
            //_oferta.porcentaje = Int32.Parse(porcentajeOferta.Text.Trim());
            _oferta.porcentajeSpecified = true;
            _oferta.fechaDeInicio = DateTime.Parse(fechaInicio.Text.Trim());
            _oferta.fechaDeInicioSpecified = true;
            _oferta.fechaDeFin = DateTime.Parse(fechaFin.Text.Trim());
            _oferta.fechaDeFinSpecified = true;

            byte[] imagenBytes;
            using (var binaryReader = new System.IO.BinaryReader(fileUploadProductImage.PostedFile.InputStream))
            {
                imagenBytes = binaryReader.ReadBytes(fileUploadProductImage.PostedFile.ContentLength);
            }
            _oferta.imagen = imagenBytes;

            this.daoOferta.oferta_insertar(_oferta);

            // Mostrar el mensaje de éxito
            successMessage.Text = "Oferta asignada correctamente.";
            successMessage.Visible = true;
        }

    }
}