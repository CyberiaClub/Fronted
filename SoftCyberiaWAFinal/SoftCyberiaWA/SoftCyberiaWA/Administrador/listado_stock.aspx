<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/SoftCyberiaAdministrador.Master" AutoEventWireup="true" CodeBehind="listado_stock.aspx.cs" Inherits="SoftCyberiaWA.Administrador.listado_stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Stock de Producto Por Sede
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteadmi.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex justify-content-center align-items-center vh-200" style="color: slategrey">
        <div class="card" style="width: 100%; max-width: 900px; color: midnightblue">
            <div class="card-header text-center" style="width: 900px">
                <h2>
                    <!--El nombre puede cambiar, pero por mientras dejemoslo asi-->
                    <asp:Label ID="lblTitulo" runat="server" Text="Stock de un Producto"></asp:Label>
                </h2>
            </div>
            <div class="card-body align-content-xxl-center align-content-center" style="font: medium">
                <div class="row">

                    <div class="col-md-13">
                        <div class="row">
                            <div class="pb-7">
                                <asp:Label ID="lblSearchSKU" runat="server" Text="Buscar Producto por SKU:" CssClass="col-form-label fw-bold"></asp:Label>
                                <div class="d-flex">
                                    <asp:TextBox ID="searchSKU" runat="server" CssClass="form-control mr-20"></asp:TextBox>
                                    <p></p>
                                    <div class="pb-3">
                                        <asp:Label ID="lblSede" runat="server" Text="Sede:" CssClass="col-form-label fw-bold"></asp:Label>
                                        <asp:DropDownList ID="sedeName" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>

                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary mr-20" Style="background-color: #004EA8; border-color: #004EA8;" OnClick="btnBuscar_Click" />
                                    <asp:Label ID="successMessage" runat="server" CssClass="text-success" Visible="false"></asp:Label>
                                </div>

                            </div>
                        </div>
                    </div>

                </div>

            </div>
        </div>


        <!-- Panel para mostrar detalles del producto -->
        <asp:Panel ID="panelDetallesProducto" runat="server" Visible="false">
            <h3>Detalles del Producto</h3>
            <p>
                <strong>Nombre:</strong>
                <asp:Label ID="lblNombreProducto" runat="server"></asp:Label>
            </p>
            <p>
                <strong>Descripción:</strong>
                <asp:Label ID="lblDescripcionProducto" runat="server"></asp:Label>
            </p>
            <p><strong>Precio:</strong> S/<asp:Label ID="lblPrecioProducto" runat="server"></asp:Label></p>

            <!-- GridView para mostrar el inventario por sede -->
            <asp:GridView ID="gvInventarioSedes" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="NombreSede" HeaderText="Nombre de la Sede" />
                    <asp:BoundField DataField="CantidadEnStock" HeaderText="Cantidad en Stock" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>



</asp:Content>
