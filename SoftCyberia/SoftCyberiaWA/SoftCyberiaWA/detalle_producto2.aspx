<%@ Page Title="" Language="C#" MasterPageFile="~/SoftCyberia.Master" AutoEventWireup="true" CodeBehind="detalle_producto2.aspx.cs" Inherits="SoftCyberiaWA.detalle_producto2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Detalle - Lienzo 50X60 Cm Conda
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="Content/sitedetprod.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="row align-items-center producto-detalle-container">
        <!-- Imagen del producto -->
        <div class="col-md-6 producto-imagen">
            <img src="/Images/canva.jpg" alt="Canva Staedtler" class="img-fluid fixed-img">
        </div>

        <!-- Detalles del producto -->
        <div class="col-md-6 producto-detalles">
            <h2>Lienzo 50X60 Cm Conda</h2>

            <!-- Estado de disponibilidad -->
            <span class="badge disponible">Disponible</span>

            <!-- Precio del producto -->
            <h3 class="precio">S/50.70 soles</h3>
            <p class="sku">SKU: 4991222</p>

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
                    <li>Marca CONDA</li>
                    <li>Medidas: 60 x 60 cm.</li>
                    <li>Gramaje: 380G/M2</li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
