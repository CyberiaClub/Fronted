<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente/SoftCyberiaCliente.Master" AutoEventWireup="true" CodeBehind="listado_productos.aspx.cs" Inherits="SoftCyberiaWA.Listado_productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Productos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="Content/siteProductos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">


    <div class="container mt-5">

        <!-- Filtros LATERAL IZQUIERDO-->

        <div class="container mt-5">
            <!-- Filtros -->
            <div class="row">
                <div class="col-md-3">
                    <h5>Filtros</h5>
                    <h6 class="mt-3">Sedes</h6>
                    <asp:Panel ID="filtrosSedes" runat="server">
                    </asp:Panel>
                    <!-- Rango de precios -->
                    <label for="priceRange">Precio: S/<span id="priceValue">0</span></label>
                    <input type="range" id="priceRange" min="0" max="300" class="form-range" oninput="applyFilters()">

                    <!-- Categorías -->
                    <h6 class="mt-3">Categoría</h6>
                    <asp:Panel ID="filtrosTipoProducto" runat="server" CssClass="overflow-auto p-2" Style="max-height: 200px;">
                    </asp:Panel>
                    <!-- Marcas -->
                    <h6 class="mt-3">Marca</h6>
                    <asp:Panel ID="listadoMarca" runat="server" CssClass="overflow-auto p-2" Style="max-height: 200px;">
                    </asp:Panel>

                </div>

                <!-- Listado de Productos -->
                <div class="col-md-9">
                    <div class="row" id="product-list">
                        <asp:Panel ID="productContainer" runat="server" CssClass="row">
                        </asp:Panel>
                    </div>
                </div>

            </div>
        </div>

        <%--<div class="row">
            <div class="col-md-3">
                <h5>Filtros</h5>
                <!-- Sedes -->
                <h6 class="mt-3">Sedes</h6>
                <asp:Panel ID="filtrosSedes" runat="server">
                </asp:Panel>

                <!-- Rango de precios -->
                <label for="priceRange">Precio: S/<span id="priceValue">500</span></label>
                <input type="range" id="priceRange" min="0" max="500" value="500" class="form-range" oninput="applyFilters()">

                <!-- Categorías -->
                <h6 class="mt-3">Categoría</h6>
                <asp:Panel ID="filtrosTipoProducto" runat="server" CssClass="overflow-auto p-2" Style="max-height: 200px;">
                </asp:Panel>

                <!-- Listado Marcas FALTA-->
                <h6 class="mt-5 ">Marca</h6>
                <asp:Panel ID="listadoMarca" runat="server" CssClass="overflow-auto p-2" Style="max-height: 200px;">
                </asp:Panel>
            </div>
            <!-- Listado de Productos -->
            <div class="col-md-9">
                <div class="row row-cols-1 row-cols-md-3 g-4" id="product-list">
                    <asp:Panel ID="productContainer" runat="server" CssClass="row">
                    </asp:Panel>
                </div>
            </div>
        </div>--%>
        <script src="/Scripts/filtrar_listado_productos.js"></script>
    </div>




</asp:Content>


