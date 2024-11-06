<%@ Page Title="" Language="C#" MasterPageFile="~/SoftCyberia.Master" AutoEventWireup="true" CodeBehind="detalle_producto10.aspx.cs" Inherits="SoftCyberiaWA.detalle_producto6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Detalle - Set de Lápices de Dibujo 12 Piezas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="row align-items-center producto-detalle-container">
        <div class="col-md-6 producto-imagen">
            <img src="/Imagenes/lapices_dibujo.jpg" alt="Set de Lápices de Dibujo" class="img-fluid fixed-img align-content-md-center">
        </div>
        <div class="col-md-6 producto-detalles">
            <h2>Set de Lápices de Dibujo 12 Piezas</h2>
            <span class="badge disponible">Disponible</span>
            <h3 class="precio">S/45.00 soles</h3>
            <p class="sku">SKU: 4991234</p>
            <div class="cantidad-carrito my-3">
                <label for="quantity" class="form-label">Cantidad</label>
                <input type="number" id="quantity" class="form-control" value="1" style="width: 80px;">
            </div>
            <button class="btn btn-dark btn-lg">Añadir a la cesta</button>
            <div class="detalles-producto mt-4">
                <h4>Detalles del producto</h4>
                <ul>
                    <li>Incluye 12 lápices con diferentes durezas</li>
                    <li>Ideal para bocetos y trabajos artísticos</li>
                    <li>Marca conocida en el mundo del arte</li>
                    <li>Incluye estuche protector</li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>