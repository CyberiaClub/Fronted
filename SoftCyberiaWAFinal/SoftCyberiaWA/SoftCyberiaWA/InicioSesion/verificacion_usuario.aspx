<%@ Page Title="" Language="C#" MasterPageFile="~/InicioSesion/InicioSesion.Master" AutoEventWireup="true" CodeBehind="verificacion_usuario.aspx.cs" Inherits="SoftCyberiaWA.InicioSesion.verificacion_usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Iniciar Sesión
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteainiciosesion.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <div>
        <div class="container d-flex justify-content-center align-items-center" style="min-height: 80vh;">
            <div class="card" style="width: 18rem; max-width: 400px;">
                <div class="card-body">
                    <p class="card-text">Se verificó la cuenta con éxito</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

