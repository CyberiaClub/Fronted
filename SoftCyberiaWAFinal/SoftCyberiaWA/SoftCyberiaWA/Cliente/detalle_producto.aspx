<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente/SoftCyberiaCliente.Master" AutoEventWireup="true" CodeBehind="detalle_producto.aspx.cs" Inherits="SoftCyberiaWA.detalle_producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Detalle del Productol
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteProductos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
     <div class="container mt-5">
        <div class="row align-items-center producto-detalle-container">
            <!-- Imagen del producto -->
            <div class="col-md-6 producto-imagen">
                <asp:Image ID="imgProducto" runat="server" CssClass="img-fluid fixed-img" />
            </div>
            <!-- Detalles del producto -->
            <div class="col-md-6 producto-detalles">
                <!-- Nombre del producto -->
                <h2>
                    <asp:Label ID="lblNombreProducto" runat="server" CssClass="product-name"></asp:Label>
                </h2>
                <!-- Precio del producto -->
                <h3 class="precio">
                    <asp:Label ID="lblPrecioProducto" runat="server"></asp:Label> soles
                </h3>
                <!-- SKU del producto -->
                <p class="sku">
                    <asp:Label ID="lblSkuProducto" runat="server"></asp:Label>  
                </p>
                <p class="stock">
                    <asp:Label ID="lblStockProducto" runat="server"></asp:Label>
                </p>
                <!-- Selector de cantidad -->
                <div class="cantidad-carrito my-3">
                    <label for="quantity" class="form-label">Cantidad</label>
                    <input type="number" id="quantity" class="form-control" value="1" min="1" runat="server" style="width: 80px;" />
                </div>
                <!-- Botón para añadir al carrito -->
                <asp:Button ID="btnAgregarCarrito" runat="server" CssClass="btn btn-dark btn-lg" Text="Añadir a la cesta" OnClick="BtnAgregarCarrito_Click" />

                <!-- Mensaje de error si no se encuentra el producto -->
                <asp:Label ID="lblMensajeError" runat="server" CssClass="text-danger mt-3" Visible="false"></asp:Label>
                <!-- Detalles adicionales del producto -->
                <div class="detalles-producto mt-4">
                    <h4>Detalles del producto</h4>
                    <asp:Label ID="lblDescripcionProducto" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
