<%@ Page Title="" Language="C#" MasterPageFile="~/SoftCyberia.Master" AutoEventWireup="true" CodeBehind="detalle_producto12.aspx.cs" Inherits="SoftCyberiaWA.detalle_producto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Detalle - Kit de Oficina Completo
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="row align-items-center producto-detalle-container">
        <div class="col-md-6 producto-imagen">
            <img src="/Imagenes/kit_escritorio.jpg" alt="Kit de Oficina Completo" class="img-fluid fixed-img align-content-md-center">
        </div>
        <div class="col-md-6 producto-detalles">
            <h2>Kit de Oficina Completo</h2>
            <span class="badge disponible">Disponible</span>
            <h3 class="precio">S/32.40 soles</h3>
            <p class="sku">SKU: 4991235</p>
            <div class="cantidad-carrito my-3">
                <label for="quantity" class="form-label">Cantidad</label>
                <input type="number" id="quantity" class="form-control" value="1" style="width: 80px;">
            </div>
            <button class="btn btn-dark btn-lg">Añadir a la cesta</button>
            <div class="detalles-producto mt-4">
                <h4>Detalles del producto</h4>
                <ul>
                    <li>Incluye grapadora, perforadora, clips, y más</li>
                    <li>Perfecto para tener todo lo necesario en tu escritorio</li>
                    <li>Material duradero y de alta calidad</li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>