<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente/SoftCyberiaCliente.Master" AutoEventWireup="true" CodeBehind="detalle_historial_de_compras.aspx.cs" Inherits="SoftCyberiaWA.Detalle_historial_de_compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Historial de compras
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/sitedeCliente.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="container mt-5">
        <!-- Título del historial de compras -->
        <h1 class="text-center">Historial de compras</h1>

        <!-- Mensaje de historial vacío -->
        <div class="text-center mt-5">
            <p class="empty-history-message">Historial de compras vacío</p>
        </div>

        <!-- Botón para volver -->
        <div class="text-center mt-5">
            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-outline-return" OnClick="btnVolver_Click"/>
        </div>
    </div>
</asp:Content>
