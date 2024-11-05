<%@ Page Title="" Language="C#" MasterPageFile="~/SoftCyberiaAdmi.Master" AutoEventWireup="true" CodeBehind="registrar_nuevos_proveedores.aspx.cs" Inherits="SoftCyberiaWA.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphStyle" runat="server">
       <link href="../Content/siteadmi.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="form-container">
        <!-- Sección de formulario -->
        <div class="form-section">
            <label for="providerRUC">RUC del Proveedor:</label>
            <asp:TextBox ID="providerRUC" runat="server" CssClass="form-control"></asp:TextBox>

            <label for="providerName">Nombre del Proveedor:</label>
            <asp:TextBox ID="nombreProveedor" runat="server" CssClass="form-control"></asp:TextBox>

            <label for="providerName">Razón Social:</label>
            <asp:TextBox ID="razonSocial" runat="server" CssClass="form-control"></asp:TextBox>

            <label for="phone">Teléfono:</label>
            <asp:TextBox ID="phone" runat="server" CssClass="form-control"></asp:TextBox>

            <label for="email">Correo Electrónico:</label>
            <asp:TextBox ID="email" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>

            <label for="address">Dirección:</label>
            <asp:TextBox ID="address" runat="server" CssClass="form-control"></asp:TextBox>

            <label for="products">Descripción del Producto que Suministra:</label>
            <asp:TextBox ID="products" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>

        </div>

        <!-- Sección de información -->
        <div class="info-section">
            <h2>Nuevo Proveedor</h2>
            <img src="/Imagenes/proveedor.png" alt="Icono de seguridad" style="width: 160px;">
            <p> </p>
            <p> </p>

            <asp:Button ID="registerButton" runat="server" Text="Registrar" CssClass="register-button" OnClick="lbGuardar_Click"/>
        </div>
    </div>
</asp:Content>

