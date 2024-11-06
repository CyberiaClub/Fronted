<%@ Page Title="" Language="C#" MasterPageFile="~/SoftCyberia.Master" AutoEventWireup="true" CodeBehind="detalle_producto9.aspx.cs" Inherits="SoftCyberiaWA.detalle_producto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Detalle - Libreta de Notas A5 con Tapa Dura
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="row align-items-center producto-detalle-container">
        <div class="col-md-6 producto-imagen">
            <img src="/Imagenes/libreta.jpg" alt="Libreta de Notas" class="img-fluid fixed-img align-content-md-center">
        </div>
        <div class="col-md-6 producto-detalles">
            <h2>Libreta de Notas A5 con Tapa Dura</h2>
            <span class="badge disponible">Disponible</span>
            <h3 class="precio">S/18.50 soles</h3>
            <p class="sku">SKU: 4991233</p>
            <div class="cantidad-carrito my-3">
                <label for="quantity" class="form-label">Cantidad</label>
                <input type="number" id="quantity" class="form-control" value="1" style="width: 80px;">
            </div>
            <button class="btn btn-dark btn-lg">Añadir a la cesta</button>
            <div class="detalles-producto mt-4">
                <h4>Detalles del producto</h4>
                <ul>
                    <li>Tamaño A5</li>
                    <li>Tapa dura con diseño elegante</li>
                    <li>96 páginas rayadas</li>
                    <li>Ideal para notas y bocetos</li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>