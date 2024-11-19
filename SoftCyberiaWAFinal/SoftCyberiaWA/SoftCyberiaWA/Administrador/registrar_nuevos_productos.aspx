<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/SoftCyberiaAdministrador.Master" AutoEventWireup="true" CodeBehind="registrar_nuevos_productos.aspx.cs" Inherits="SoftCyberiaWA.Administrador.registrar_nuevos_productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Registrar Producto
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteadmi.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center align-items-center vh-200" style="color: slategrey">
        <div class="card" style="width: 100%; max-width: 1100px; color: midnightblue">
            <div class="card-header text-center" style="width: 1100px">
                <h2>Registro Nuevo Producto</h2>
            </div>
            <div class="card-body pb-2">
                <div class="row">
                    <!-- Columna de información del producto -->
                    <div class="col-md-6">
                        <div class="pb-3">
                            <asp:Label ID="lblProductName" runat="server" Text="Nombre del Producto:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="productName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="pb-3">
                            <asp:Label ID="lblSKU" runat="server" Text="SKU:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="sku" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="pb-3  col-md-6">
                            <asp:Label ID="lblMarca" runat="server" Text="Marca del Producto:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:DropDownList ID="marcaName" runat="server" AutoPostBack="true" CssClass="form-select"></asp:DropDownList>
                        </div>
                        <div class="pb-3  col-md-6">
                            <asp:Label ID="lblCategory" runat="server" Text="Categoría del Producto:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:DropDownList ID="categoriaName" runat="server" AutoPostBack="true" CssClass="form-select"></asp:DropDownList>
                        </div>

                        <div class="pb-3">
                            <asp:Label ID="lblPrice" runat="server" Text="Precio de Venta:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="price" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="pb-3">
                            <asp:Label ID="lblProviderPrice" runat="server" Text="Precio de Venta del Proveedor:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="providerPrice" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="pb-3">
                            <asp:Label ID="lblProvider" runat="server" Text="Proveedor:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:DropDownList ID="providerName" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>

                    </div>

                    <!-- Columna de proveedor e imagen -->
                    <div class="col-md-6">
                        <div class="pb-3">
                            <asp:Label ID="lblUnidades" runat="server" Text="Unidades:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="unidades" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="pb-3">
                            <asp:Label ID="lblSede" runat="server" Text="Sede:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:DropDownList ID="sedeName" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="pb-3">
                            <asp:Label ID="lblDescription" runat="server" Text="Descripción del Producto:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="description" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-6 text-center d-flex flex-column align-items-center justify-content-center align-content-center">
                            <asp:Label ID="lblImage" runat="server" Text="Imagen del Producto:" CssClass="col-form-label fw-bold"></asp:Label>
                            <img src="/Imagenes/producto.png" alt="Producto" class="img-fluid img-thumbnail mb-3" style="width: 160px;">
                            <asp:FileUpload ID="fileUploadProductImage" CssClass="form-control mb-2" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="card-footer text-center">
                <asp:Button ID="registerButton" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="registerButton_Click" />
                <asp:Label ID="successMessage" runat="server" CssClass="text-success" Visible="false"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
