<%@ Page Title="" Language="C#" MasterPageFile="~/SoftCyberia.Master" AutoEventWireup="true" CodeBehind="detalle_producto.aspx.cs" Inherits="SoftCyberiaWA.detalle_producto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Detalle - Set de acrilicos 10X20 ml
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="/Content/sitedetprod.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="row align-items-center producto-detalle-container">
        <!-- Imagen del producto -->
        <div class="col-md-6 producto-imagen">
            <img src="/Imagenes/pinturas.jpg" alt="Set de acrílicos" class="img-fluid fixed-img">
        </div>

        <!-- Detalles del producto -->
        <div class="col-md-6 producto-detalles">
            <h2>Set de acrilicos 10X20 ml tubos</h2>

            <!-- Estado de disponibilidad -->
            <span class="badge disponible">Disponible</span>

            <!-- Precio del producto -->
            <h3 class="precio">S/36.70 soles</h3>
            <p class="sku">SKU: 4991232</p>

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
                    <li>Set de 10 Acrílicos 20 ml</li>
                    <li>Marca PEBEO</li>
                    <li>Limpieza de pinceles: agua</li>
                    <li>Soportes: Lienzos, cartón, madera, metal</li>
                    <li>Secado: Alejado del polvo entre 30 minutos y 1 hora, totalmente entre 1 y 8 días dependiendo del espesor.</li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
