<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente/SoftCyberiaCliente.Master" AutoEventWireup="true" CodeBehind="detalle_carro_de_compras.aspx.cs" Inherits="SoftCyberiaWA.detalle_carro_de_compras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Carro de compras
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteCompras.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <%--<div class="container mt-5">
        <!-- Título del carrito de compras -->
        <div class="d-flex justify-content-between align-items-center mb-4">
            <h1 class="cart-title">Carrito de compras <span>(4)</span></h1>
            <asp:Button ID="btnHistorialCompras" runat="server" Text="Historial de compras" CssClass="btn btn-history" OnClick="btnHistorialCompras_Click" />
        </div>

        <!-- Producto 1 -->
        <div class="cart-item d-flex align-items-center border-bottom py-3">
            <img src="/Imagenes/lapiz-grafito.jpg" alt="Lápiz grafito Staedtler x 24" class="cart-image">
            <div class="cart-product-details flex-grow-1">
                <h6 class="mb-1">Lápiz grafito Staedtler x 24</h6>
                <p class="mb-1">Cantidad: 2</p>
                <p class="mb-0">Precio Unitario: S/146.40</p>
                <p class="mb-0">Subtotal: S/292.80</p>
            </div>
        </div>

        <!-- Producto 2 -->
        <div class="cart-item d-flex align-items-center border-bottom py-3">
            <img src="/Imagenes/papeles.jpg" alt="Hojas A4" class="cart-image">
            <div class="cart-product-details flex-grow-1">
                <h6 class="mb-1">Papel Adhesivo Blanco Brillante 180 G A4 100 Hojas</h6>
                <p class="mb-1">Cantidad: 1</p>
                <p class="mb-0">Precio Unitario: S/81.50</p>
                <p class="mb-0">Subtotal: S/81.50</p>
            </div>
        </div>

        <!-- Producto 3 -->
        <div class="cart-item d-flex align-items-center border-bottom py-3">
            <img src="/Imagenes/canva.jpg" alt="Lienzo 50X60 Cm Conda" class="cart-image">
            <div class="cart-product-details flex-grow-1">
                <h6 class="mb-1">Lienzo 50X60 Cm Conda</h6>
                <p class="mb-1">Cantidad: 3</p>
                <p class="mb-0">Precio Unitario: S/50.70</p>
                <p class="mb-0">Subtotal: S/152.10</p>
            </div>
        </div>

        <!-- Producto 4 -->
        <div class="cart-item d-flex align-items-center border-bottom py-3">
            <img src="/Imagenes/pinturas.jpg" alt="Set de acrilicos 10X20 ml tubos" class="cart-image">
            <div class="cart-product-details flex-grow-1">
                <h6 class="mb-1">Set de acrilicos 10X20 ml tubos</h6>
                <p class="mb-1">Cantidad: 1</p>
                <p class="mb-0">Precio Unitario: S/36.70</p>
                <p class="mb-0">Subtotal: S/36.70</p>
            </div>
        </div>

        <!-- Botón para seguir comprando -->
        <div class="text-center mt-5">
            <asp:Button ID="btnSeguirComprando" runat="server" Text="Seguir con el Pago" CssClass="btn btn-continue" OnClick="btnSeguirComprando_Click" />
        </div>

    </div>--%>
    <%--<div class="container mt-5">
        <h1 class="cart-title">Carrito de compras</h1>
        <asp:Repeater ID="rptCarrito" runat="server">
            <ItemTemplate>
                <div class="cart-item border-bottom py-3">
                    <h6><%# Eval("nombre") %></h6>
                    <p>Cantidad: <%# Eval("cantidad") %></p>
                    <p>Precio Unitario: S/<%# Eval("precio", "{0:F2}") %></p>
                    <p>Subtotal: S/<%# Convert.ToDouble(Eval("precio")) * Convert.ToInt32(Eval("cantidad")) %></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Label ID="lblMensajeCarrito" runat="server" CssClass="text-muted mt-4" />
        <asp:Button ID="btnFinalizarCompra" runat="server" Text="Finalizar Compra" CssClass="btn btn-primary mt-4" OnClick="btnFinalizarCompra_Click" />
    </div>--%>
    <%-- SI FUNCIONA PRUEBA 1     <div class="container mt-5">
    <h1 class="cart-title text-center">Carrito de compras</h1>
    <asp:Repeater ID="rptCarrito" runat="server">
        <ItemTemplate>
            <div class="cart-item d-flex align-items-center border-bottom py-3">
                <!-- Imagen del producto -->
                <div class="cart-image-container">
                    <img src="/Imagenes/producto.png" alt='<%# Eval("nombre") %>' class="cart-image" />
                </div>
                <!-- Detalles del producto -->
                <div class="cart-product-details flex-grow-1 ms-3">
                    <h6 class="mb-1"><%# Eval("nombre") %></h6>
                    <p class="mb-1">Cantidad: <%# Eval("cantidad") %></p>
                    <p class="mb-1">Precio Unitario: S/<%# Eval("precio", "{0:F2}") %></p>
                    <p class="mb-0">Subtotal: S/<%# Convert.ToDouble(Eval("precio")) * Convert.ToInt32(Eval("cantidad")) %></p>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <asp:Label ID="lblMensajeCarrito" runat="server" CssClass="text-muted mt-4 d-block text-center" />
    <div class="text-center mt-4">
        <asp:Button ID="btnFinalizarCompra" runat="server" Text="Finalizar Compra" CssClass="btn btn-primary btn-lg" OnClick="btnFinalizarCompra_Click" />
    </div>--%>

    <div class="container mt-5">
        <h1 class="cart-title text-center">Carrito de compras</h1>
        <asp:Repeater ID="rptCarrito" runat="server">
            <ItemTemplate>
                <div class="cart-item d-flex align-items-center border-bottom py-3">
                    <!-- Imagen del producto -->
                    <div class="cart-image-container">
                        <img src="/Imagenes/producto.png" alt='<%# Eval("nombre") %>' class="cart-image" />
                    </div>
                    <!-- Detalles del producto -->
                    <div class="cart-product-details flex-grow-1 ms-3">
                        <h6 class="mb-1"><%# Eval("nombre") %></h6>
                        <p class="mb-1">Cantidad: <%# Eval("cantidad") %></p>
                        <p class="mb-1">Precio Unitario: S/<%# Eval("precio", "{0:F2}") %></p>
                        <p class="mb-0">Subtotal: S/<%# Convert.ToDouble(Eval("precio")) * Convert.ToInt32(Eval("cantidad")) %></p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <asp:Label ID="lblMensajeCarrito" runat="server" CssClass="text-muted mt-4 d-block text-center" />
        <div class="text-center mt-4">
            <asp:Button ID="btnFinalizarCompra" runat="server" Text="Finalizar Compra" CssClass="btn btn-primary btn-lg" OnClick="btnFinalizarCompra_Click" />
        </div>

    </div>
</asp:Content>
