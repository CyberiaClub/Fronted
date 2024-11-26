<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/SoftCyberiaAdministrador.Master" AutoEventWireup="true" CodeBehind="actualizar_stock.aspx.cs" Inherits="SoftCyberiaWA.Administrador.Actualizar_stock" %>

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
            <div class="card-body align-items-lg-center p-2 ">
                <div class="form-row">
                    <!-- Sección para el SKU y Botón Buscar -->
                    <label for="basic-url" class="form-label">SKU del producto a actualizar stock:</label>
                    <div class="input-group mb-3">
                        <asp:TextBox ID="productoSku" runat="server" CssClass="form-control" aria-describedby="basic-addon3"></asp:TextBox>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" Style="background-color: #004EA8; border-color: #004EA8;" OnClick="OnClickBuscar" />
                    </div>
                    <small id="successMessage" runat="server" style="color: red;"></small>
                </div>

                <label for="basic-url" class="form-label">Nombre del producto</label>
                <div class="input-group mb-3">
                    <asp:TextBox ID="nombreProducto" runat="server" CssClass="form-control" ReadOnly="true" Style="background-color: silver" Placeholder="Producto Cyberia"> </asp:TextBox>
                </div>

                <label for="basic-url" class="form-label">Descripción del Producto:</label>
                <div class="input-group mb-3">
                    <asp:TextBox ID="descripcionProducto" runat="server" CssClass="form-control form-control-lg" ReadOnly="true" Style="background-color: silver" Placeholder="Descripcion Cyberia"></asp:TextBox>
                </div>

                <label for="basic-url" class="form-label">Stock Actual del Producto:</label>
                <div class="input-group mb-3">
                    <asp:TextBox ID="stockActual" runat="server" CssClass="form-control form-control-lg" ReadOnly="true" Style="background-color: silver" Placeholder="Stock Actual: 0"></asp:TextBox>
                </div>


                <div class="form-group row">
                    <label for="cantidadAgregar" class="col-sm-2 col-form-label">Cantidad a Agregar:</label>
                    <div class="col-sm-10">
                        <asp:TextBox
                            ID="cantidadAgregar"
                            runat="server"
                            CssClass="form-control"
                            TextMode="Number"
                            Style="background-color: white; width: 150px;"
                            min="0"></asp:TextBox>
                    </div>
                </div>

            </div>
            <!-- Botón para actulizar el stock -->
            <div class="row mt-4">
                <div class="col-md-12 text-center">
                    <asp:Button ID="btnActualizarStock" runat="server" Text="Actualizar Stock" CssClass="btn btn-primary" Style="background-color: #004EA8; border-color: #004EA8;" OnClick="OnClickActualizarStock" />
                    <asp:Label ID="successActualizado" runat="server" CssClass="text-success" Visible="false"></asp:Label>
                    <p></p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
