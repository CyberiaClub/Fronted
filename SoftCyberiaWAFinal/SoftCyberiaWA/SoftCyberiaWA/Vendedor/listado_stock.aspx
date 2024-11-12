<%@ Page Title="" Language="C#" MasterPageFile="~/Vendedor/SoftCyberiaVendedor.Master" AutoEventWireup="true" CodeBehind="listado_stock.aspx.cs" Inherits="SoftCyberiaWA.Vendedor.listado_stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Stock de Producto Por Sede
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteadmi.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">


    <div class="d-flex justify-content-center align-items-center vh-200" style="color: slategrey">

        <div class="card" style="width: 100%; max-width: 900px; color: midnightblue">
            <div class="card-header text-center" style="width: 900px">
                <h2>
                    <asp:Label ID="lblTitulo" runat="server" Text="Stock de Productos por Sede"></asp:Label>
                </h2>
            </div>
            <div class="card-body align-content-xxl-center align-content-center" style="font: medium">
                <div class="row">
                    <div class="col-md-6 ">
                        <div class="col-md-10">
                            <label for="categoriaName">Buscar por SKU:</label>
                            <asp:TextBox ID="skuName" runat="server" CssClass="form-control" placeholder="Ingresa SKU"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6 ">
                        <div class="col-md-10">
                            <asp:Button ID="Button1" runat="server" Text="buscar" CssClass="btn btn-primary w-75 align-content-sm-center" OnClick="Button1_Click" />
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
                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>

        </div>
    </div>
</asp:Content>
