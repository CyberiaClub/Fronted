<%@ Page Title="" Language="C#" MasterPageFile="~/SoftCyberia.Master" AutoEventWireup="true" CodeBehind="detalle_carro_de_compras.aspx.cs" Inherits="SoftCyberiaWA.detalle_carro_de_compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Carro de compras
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteCliente.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="container mt-5">
        <!-- Título del carrito de compras -->
        <div class="d-flex justify-content-between align-items-center mb-4">
            <h1 class="cart-title">Carrito de compras <span>(0)</span></h1>
            <asp:Button ID="btnHistorialCompras" runat="server" Text="Historial de compras" CssClass="btn btn-history" OnClick="btnHistorialCompras_Click" />
        </div>

        <!-- Mensaje de carrito vacío -->
        <div class="cart-empty-message text-center">
            <img src="/Imagenes/empty-cart.png" alt="Carrito vacío" class="empty-cart-img mb-3">
            <p>Tu carro de compras está vacío</p>
        </div>

        <!-- Botón para seguir comprando -->
        <div class="text-center mt-5">
            <button class="btn btn-continue" disabled>Seguir comprando</button>
        </div>
    </div>
</asp:Content>
