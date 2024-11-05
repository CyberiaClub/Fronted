<%@ Page Title="" Language="C#" MasterPageFile="~/SoftCyberia.Master" AutoEventWireup="true" CodeBehind="vista_perfil_cliente.aspx.cs" Inherits="SoftCyberiaWA.vista_perfil_cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Perfil
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteCliente.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="container d-flex flex-column align-items-center mt-5">
        <!-- Título con nombre del usuario -->
        <h1>Mario Sulca Valverde</h1>
        <hr class="w-100 mb-4">

        <!-- Imagen de perfil -->
        <div class="profile-picture mb-4">
            <img src="../Imagenes/admin-user.png" alt="Profile" class="img-fluid rounded-circle">
            
        </div>

        <!-- Formulario de cierre de sesión -->
        <div class="card p-4 text-center" style="width: 100%; max-width: 400px;">
            <!-- Campo del correo electrónico -->
            <div class="mb-3">
                <label for="email" class="form-label">Correo electrónico</label>
                <input type="email" class="form-control text-center" id="email" value="vent1234@cyber.com" readonly>
            </div>

            <!-- Campo del número de teléfono -->
            <div class="mb-3">
                <label for="phone" class="form-label">Número de Teléfono</label>
                <input type="text" class="form-control text-center" id="phone" value="942921807" readonly>
            </div>

            <!-- Botón de cierre de sesión -->
            <button type="button" class="btn btn-dark w-100 mb-3">Cerrar Sesión</button>

            <!-- Botón de volver -->
            <button type="button" class="btn btn-secondary w-100">Volver</button>
        </div>
    </div>
</asp:Content>
