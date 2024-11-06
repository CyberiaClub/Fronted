<%@ Page Title="" Language="C#" MasterPageFile="~/SoftCyberiaAdmi.Master" AutoEventWireup="true" CodeBehind="registrar_nueva_marca.aspx.cs" Inherits="SoftCyberiaWA.registrarNuevaMarca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteadmi.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="form-container">
        <!-- Sección de formulario -->
        <div class="form-section">
            <label for="marcaName">Nombre de la Marca:</label>
            <asp:TextBox ID="marcaName" runat="server" CssClass="form-control"></asp:TextBox>

            <!-- Control para subir la imagen -->
            <label for="uploadImage">Subir Imagen (PNG):</label>
            <asp:FileUpload ID="uploadImage" runat="server" CssClass="form-control" />

            <%--<div class="col-md-6">
                <asp:Label ID="lblBannerPromocional" runat="server" Text="Banner Promocional:" CssClass="col-form-label fw-bold"></asp:Label>
                <asp:Image ID="imgBannerPromocional" runat="server" CssClass="img-fluid img-thumbnail" ImageUrl="/Images/placeholder.jpg" Height="235" Width="720" />
                <asp:FileUpload ID="fileUploadBannerPromocional" CssClass="form-control mb-2" runat="server" onchange="this.form.submit()" ClientIDMode="Static" />
            </div>--%>
        </div>

        <!-- Sección de información -->
        <div class="info-section">
            <h2>Registro Nueva Marca</h2>
            <img src="/Imagenes/marca.png" alt="Icono de marca" style="width: 160px;">
            <asp:Button ID="registerButton" runat="server" Text="Registrar" CssClass="register-button" OnClick="registerButton_Click" />
        </div>
    </div>
</asp:Content>
