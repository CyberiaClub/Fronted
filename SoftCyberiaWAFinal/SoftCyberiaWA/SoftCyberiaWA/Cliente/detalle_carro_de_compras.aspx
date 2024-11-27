<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente/SoftCyberiaCliente.Master" AutoEventWireup="true" CodeBehind="detalle_carro_de_compras.aspx.cs" Inherits="SoftCyberiaWA.Detalle_carro_de_compras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Carro de compras
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteCompras.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
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
            <asp:Button ID="btnFinalizarCompra" runat="server" Text="Finalizar Compra" CssClass="btn btn-primary btn-lg" OnClick="BtnFinalizarCompra_Click" />
        </div>
    </div>
</asp:Content>
