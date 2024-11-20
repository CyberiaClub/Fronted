<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/SoftCyberiaAdministrador.Master" AutoEventWireup="true" CodeBehind="actualizar_stock.aspx.cs" Inherits="SoftCyberiaWA.Administrador.actualizar_stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Actualizar Stock
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteadmi.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex justify-content-center align-items-center vh-200">
    <div class="card" style="width: 100%; max-width: 800px; color: midnightblue">
        <div class="card-header text-center">
            <h2>Actualizar Stock de Producto</h2>
        </div>

        <div class="card-body pb-2">
            <div class="row">
                <!-- Sección para el SKU y Botón Buscar -->
                <div class="col-12">
                    <div class="form-row align-items-center pb-3">
                        <asp:Label ID="lblproductoSku" runat="server" Text="SKU:  " CssClass="col-form-label fw-bold"></asp:Label>
                        <!-- Ingresar el SKU para Buscar -->
                        <div class="d-flex">
                            <asp:TextBox ID="productoSku" runat="server" CssClass="form-control"></asp:TextBox>
                            <p></p>
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" Style="background-color: #004EA8; border-color: #004EA8;" OnClick="onClickBuscar" />
                        </div>
                    </div>
                </div>
                </div>

                <div class="row">

                <!-- Sección para los otros campos -->
                <div class="col-12 pb-3">
                    <asp:Label ID="lblCantidadProducto" runat="server" Text="Cantidad: " CssClass="col-form-label fw-bold"></asp:Label>
                    <asp:TextBox ID="cantidadProducto" runat="server" CssClass="form-control" TextMode="Number" Style="width: 80px;" Min="0"></asp:TextBox>
                </div>

                <div class="col-12 pb-3">
                    <asp:Label ID="lblNombreProducto" runat="server" Text="Nombre del Producto: " CssClass="col-form-label fw-bold"></asp:Label>
                    <asp:TextBox ID="nombreProducto" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-12 pb-3">
                    <asp:Label ID="lblDescripcionProducto" runat="server" Text="Descripción del Producto: " CssClass="col-form-label fw-bold"></asp:Label>
                    <asp:TextBox ID="descripcionProducto" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-12 pb-3">
                    <asp:Label ID="lblStockActual" runat="server" Text="Stock Actual del Producto: " CssClass="col-form-label fw-bold"></asp:Label>
                    <asp:TextBox ID="stockActual" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
</div>
    

    <!-- Botón para actulizar el stock -->
    <div class="row mt-4">
        <div class="col-md-12 text-center">
            <asp:Button ID="btnActualizarStock" runat="server" Text="Actualizar Stock" CssClass="btn btn-primary" Style="background-color: #004EA8; border-color: #004EA8;" OnClick="onClickActualizarStock"/>
        </div>
    </div>





</asp:Content>
