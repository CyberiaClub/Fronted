<%@ Page Title="" Language="C#" MasterPageFile="~/SoftCyberia.Master" AutoEventWireup="true" CodeBehind="detalle_producto4.aspx.cs" Inherits="SoftCyberiaWA.detalle_producto4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Detalle - Lápiz grafito Staedtler x 24
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="Content/siteProductos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="row align-items-center producto-detalle-container">
        <!-- Imagen del producto -->
        <div class="col-md-6 producto-imagen">
            <img src="/Imagenes/lapiz-grafito.jpg" alt="Lápiz grafito Staedtler" class="img-fluid fixed-img">
        </div>

        <!-- Detalles del producto -->
        <div class="col-md-6 producto-detalles">
            <h2>Lápiz grafito Staedtler x 24</h2>

            <!-- Estado de disponibilidad -->
            <span class="badge disponible">Disponible</span>

            <!-- Precio del producto -->
            <h3 class="precio">S/146.40 soles</h3>
            <p class="sku">SKU: 4991244</p>

            <!-- Selector de cantidad y botón para añadir al carrito -->
            <div class="cantidad-carrito my-3">
                <label for="quantity" class="form-label">Cantidad</label>
                <input type="number" id="quantity" class="form-control" value="1" style="width: 80px;">
            </div>
            <button class="btn btn-dark btn-lg">Añadir a la cesta</button>

            <!-- Detalles adicionales del producto -->
            <div class="detalles-producto mt-4">
                <h4>Detalles del producto</h4>
                <ul>
                    <li>Set de 24 lápices de grafito Staedtler Lumograph</li>
                    <li>Marca OFFICE PAPER</li>
                    <li>Incluye una variedad de grados de dureza para diferentes técnicas de dibujo</li>
                    <li>Alta resistencia a la rotura y calidad superior</li>
                    <li>Ideal para artistas, ilustradores y diseñadores</li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
