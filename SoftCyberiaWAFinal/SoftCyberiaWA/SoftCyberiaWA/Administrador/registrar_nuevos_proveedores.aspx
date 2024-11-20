<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/SoftCyberiaAdministrador.Master" AutoEventWireup="true" CodeBehind="registrar_nuevos_proveedores.aspx.cs" Inherits="SoftCyberiaWA.Administrador.registrar_nuevos_proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Registrar Proveedores
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteadmi.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex justify-content-center align-items-center vh-200">
        <div class="card" style="width: 100%; max-width: 800px; color: midnightblue">
            <div class="card-header text-center" style="width: 800px">
                <h2>Registrar nuevo proveedor</h2>
            </div>

            <div class="card-body pb-2">
                <div class="row">
                    <div class="col-md-8">
                        <div class="pb-3">
                            <label for="providDerRUC">RUC del Proveedor:</label>
                            <asp:TextBox ID="providerRUC" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="companyName">Razón Social:</label>
                            <asp:TextBox ID="companyName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="providerName">Nombre del Proveedor:</label>
                            <asp:TextBox ID="providerName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="phone">Teléfono:</label>
                            <asp:TextBox ID="phone" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="email">Correo Electrónico:</label>
                            <asp:TextBox ID="email" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="address">Dirección:</label>
                            <asp:TextBox ID="address" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="description">Descripción del Producto que Suministra:</label>
                            <asp:TextBox ID="description" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-4 d-flex flex-column align-items-center justify-content-center bg-light" style="border-radius: 0 15px 15px 0;">
                        <asp:Label ID="lbnuevoProveedor" runat="server" Text="Nuevo Proveedor:" CssClass="fw-bold d-block mb-3"></asp:Label>
                        <asp:Image ID="imgNuevoProveedor" runat="server" CssClass="img-fluid img-thumbnail mb-3" ImageUrl="/Imagenes/proveedor.png" Height="250px" Width="250px" />

                        <asp:Button ID="registerButton" runat="server" Text="Registrar" CssClass="btn btn-primary w-75" OnClick="providerButton_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
