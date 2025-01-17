﻿using SoftCyberiaWA.CyberiaWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class registrar_nuevos_productos : System.Web.UI.Page
    {

        private SedeWSClient daoSede = new SedeWSClient();
        private ProveedorWSClient daoProveedor = new ProveedorWSClient();
        private TipoProductoWSClient daoTipoProducto = new TipoProductoWSClient();
        private MarcaWSClient daoMarca = new MarcaWSClient();
        private ProductoWSClient daoProducto = new ProductoWSClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMarcas();
                CargarCategoria();
                CargarProveedores();
                CargarSedes();
            }

        }

        private void CargarCategoria()
        {
            categoriaName.DataSource = daoTipoProducto.tipoProducto_listar();
            categoriaName.DataTextField = "tipo";
            categoriaName.DataValueField = "idTipoProducto";
            categoriaName.DataBind(); // Llenar el DropDownList
        }

        private void CargarMarcas()
        {
            marcaName.DataSource = daoMarca.marca_listar();
            marcaName.DataTextField = "nombre";
            marcaName.DataValueField = "idMarca";
            marcaName.DataBind(); // Llenar el DropDownList
        }

        private void CargarProveedores()
        {
            providerName.DataSource = daoProveedor.proveedor_listar();
            providerName.DataTextField = "razonSocial";
            providerName.DataValueField = "idProveedor";
            providerName.DataBind(); // Llenar el DropDownList
        }

        private void CargarSedes()
        {
            sedeName.DataSource = daoSede.sede_listar();
            sedeName.DataTextField = "nombre";
            sedeName.DataValueField = "idSede";
            sedeName.DataBind(); // Llenar el DropDownList
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            producto producto = new producto();

            producto.nombre = productName.Text;
            producto.sku = sku.Text;
            producto.precio = Convert.ToDouble(price.Text);
            producto.precioSpecified = true;
            producto.precioProveedor = Convert.ToDouble(providerPrice.Text);
            producto.precioProveedorSpecified = true;
            producto.descripcion = description.Text;
            producto.idSede = Int32.Parse(sedeName.SelectedValue);
            producto.idSedeSpecified = true;
            producto.idMarca = Int32.Parse(marcaName.SelectedValue);
            producto.idMarcaSpecified = true;
            producto.idProveedor = Int32.Parse(providerName.SelectedValue);
            producto.idProveedorSpecified = true;
            producto.idTipo = Int32.Parse(categoriaName.SelectedValue);
            producto.idTipoSpecified = true;
            producto.cantidad = 0;
            producto.cantidadSpecified = true;

            if (fileUploadProductImage.HasFile)
            {
                using (System.IO.Stream imageStream = fileUploadProductImage.PostedFile.InputStream)
                {
                    byte[] imageBytes = new byte[imageStream.Length];
                    imageStream.Read(imageBytes, 0, (int)imageStream.Length);
                    producto.imagen = imageBytes; // Convertir a base64
                }
            }

            this.daoProducto.producto_insertar(producto);
        }
    }
}