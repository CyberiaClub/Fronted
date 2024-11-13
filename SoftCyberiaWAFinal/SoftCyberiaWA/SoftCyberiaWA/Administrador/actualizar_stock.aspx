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
            <div class="card-header text-center" style="width: 800px">
                <h2>Actualizar Stock de Producto</h2>
            </div>
            <div class="card-body pb-2">
                <div class="row">

                    <!-- Sección para agregar productos al kit -->
                    <div class="col-md-13">
                        <div class="row">
                            <div class="pb-7">
                                <asp:Label ID="lblSearchSKU" runat="server" Text="Buscar Producto por SKU:" CssClass="col-form-label fw-bold"></asp:Label>
                                <div class="d-flex">
                                    <asp:TextBox ID="searchSKU" runat="server" CssClass="form-control mr-20"></asp:TextBox>
                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary mr-20" Style="background-color: #004EA8; border-color: #004EA8;" />
                                    <asp:Label ID="lblCantidadProducto" runat="server" Text="Cantidad:" CssClass="col-form-label fw-bold align-self-center mx-2"></asp:Label>
                                    <asp:TextBox ID="cantidadProducto" runat="server" CssClass="form-control mr-2" TextMode="Number" Style="width: 80px;" Min="0"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

                <!-- Botón para finalizar la creación del kit -->
                <div class="row mt-4">
                    <div class="col-md-12 text-center">
                        <asp:Button ID="btnActualizarStock" runat="server" Text="Actualizar Stock" CssClass="btn btn-primary" Style="background-color: #004EA8; border-color: #004EA8;" />
                    </div>
                </div>
            </div>
        </div>
    </div>




</asp:Content>
