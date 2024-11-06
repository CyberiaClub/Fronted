<%@ Page Title="" Language="C#" MasterPageFile="~/SoftCyberia.Master" AutoEventWireup="true" CodeBehind="boleta_pago.aspx.cs" Inherits="SoftCyberiaWA.boletaDePago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
   Boleta de Compra
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteCliente.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">

    <!-- QR del Pago -->
    <div class="qr-container" style="text-align: center;">
        <h3>Comprobante de Pago</h3>
        <img src="/Imagenes/qr_comprobante.png" alt="QR del Comprobante" class="img-fluid" />
        <p>Escanee este QR para recoger su compra en la tienda.</p>
    </div>

    <!-- Detalles del Producto -->
    <div class="product-details mt-4">
        <h3>Detalle de los Productos</h3>
        <ul>
            <li>Producto 1: Set de acrílicos - S/ 36.70</li>
            <li>Producto 2: Libreta de Notas - S/ 18.50</li>
            <li>Producto 3: Kit de Oficina Completo - S/ 32.40</li>
            <li>Producto 4: Pack de Cartulinas de Colores - S/ 15.00</li>
        </ul>
        <p><strong>Total:</strong> S/ 102.60</p>
    </div>

    <!-- Información de Recogida -->
    <div class="pickup-info mt-4">
        <h3>Información de Recogida</h3>
        <p>Recuerde que tiene hasta el final del día para recoger su producto.</p>
        <p><strong>Sede de Recogida:</strong> Tienda SoftCyberia, Av. Ejemplo 123, Lima</p>
    </div>

</asp:Content>
