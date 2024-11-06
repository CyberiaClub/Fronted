<%@ Page Title="" Language="C#" MasterPageFile="~/SoftCyberia.Master" AutoEventWireup="true" CodeBehind="detalle_producto14.aspx.cs" Inherits="SoftCyberiaWA.detalle_producto8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Detalle - Pack de Cartulinas de Colores (10 unidades)
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="row align-items-center producto-detalle-container">

        <div class="col-md-6 producto-imagen">
            <img src="/Imagenes/cartulinas.jpg" alt="Pack de Cartulinas de Colores" class="img-fluid fixed-img align-content-md-center">
        </div>

        <div class="col-md-6 producto-detalles">
            <h2>Pack de Cartulinas de Colores (10 unidades)</h2>
            <span class="badge disponible">Disponible</span>
            <h3 class="precio">S/15.00 soles</h3>
            <p class="sku">SKU: 4991236</p>
            <div class="cantidad-carrito my-3">
                <label for="quantity" class="form-label">Cantidad</label>
                <input type="number" id="quantity" class="form-control" value="1" style="width: 80px;">
            </div>
            <button class="btn btn-dark btn-lg">Añadir a la cesta</button>
            <div class="detalles-producto mt-4">
                <h4>Detalles del producto</h4>
                <ul>
                    <li>10 cartulinas de colores variados</li>
                    <li>Medida estándar (A4)</li>
                    <li>Perfectas para manualidades y proyectos escolares</li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>