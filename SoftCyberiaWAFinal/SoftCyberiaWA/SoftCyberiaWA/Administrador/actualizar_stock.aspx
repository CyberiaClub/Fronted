<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/SoftCyberiaAdministrador.Master" AutoEventWireup="true" CodeBehind="actualizar_stock.aspx.cs" Inherits="SoftCyberiaWA.Administrador.actualizar_stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Actualizar Stock
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteadmi.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex justify-content-center align-items-center vh-200">
        <div class="card" style="width: 120%; max-width: 800px; color: midnightblue">
            <div class="card-header text-center">
                <h2>Actualizar Stock de Producto</h2>
            </div>

            <div class="card-body align-items-lg-center pb-2 ">
                <div class="form-row">
                    <!-- Sección para el SKU y Botón Buscar -->
                    <div class="col-7">
                        <div class="form-row align-items-center pb-3">
                            <asp:Label ID="lblproductoSku" runat="server" Text="SKU del producto a actualizar stock:  " CssClass="col-form-label fw-bold"></asp:Label>
                            <!-- Ingresar el SKU para Buscar -->
                            <div class="d-flex">
                                <asp:TextBox ID="productoSku" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-20">
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" Style="background-color: #004EA8; border-color: #004EA8;" OnClick="onClickBuscar" />
                            <asp:Label ID="successMessage" runat="server" CssClass="text-success" Visible="false"></asp:Label>
                            <p> </p>
                            <p> </p>
                        </div>
                    </div>
                </div>


                <div class="row">
                    <div class="col-12 pb-3">
                        <asp:Label ID="lblNombreProducto" runat="server" Text="Nombre del Producto: " CssClass="col-form-label fw-bold"></asp:Label>
                        <asp:TextBox ID="nombreProducto" runat="server" CssClass="form-control" ReadOnly="true" Style=" background-color:silver"></asp:TextBox>
                    </div>

                    <div class="col-12 pb-3">
                        <asp:Label ID="lblDescripcionProducto" runat="server" Text="Descripción del Producto: " CssClass="col-form-label fw-bold"></asp:Label>
                        <asp:TextBox ID="descripcionProducto" runat="server" CssClass="form-control" ReadOnly="true" Style=" background-color:silver"></asp:TextBox>
                    </div>

                    <div class="col-12 pb-3">
                        <asp:Label ID="lblStockActual" runat="server" Text="Stock Actual del Producto: " CssClass="col-form-label fw-bold" Style=""></asp:Label>
                        <asp:TextBox ID="stockActual" runat="server" CssClass="form-control" ReadOnly="true" Style=" background-color:silver"></asp:TextBox>
                    </div>


                </div>
                <div class="col-12 pb-3">
                    <asp:Label ID="lblCantidadProducto" runat="server" Text="Cantidad a Agregar: " CssClass="col-form-label fw-bold " ></asp:Label>
                    <asp:TextBox ID="cantidadProducto" runat="server" CssClass="form-control" TextMode="Number" Style="width: 120px;" Min="0"></asp:TextBox>
                </div>

            </div>
            <!-- Botón para actulizar el stock -->
            <div class="row mt-4">
                <div class="col-md-12 text-center">
                    <asp:Button ID="btnActualizarStock" runat="server" Text="Actualizar Stock" CssClass="btn btn-primary" Style="background-color: #004EA8; border-color: #004EA8;" OnClick="onClickActualizarStock" />
                    <asp:Label ID="successActualizado" runat="server" CssClass="text-success" Visible="false"></asp:Label>
                    <p> </p>
                </div>
            </div>
        </div>

    </div>








</asp:Content>
