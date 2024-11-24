<%@ Page Title="" Language="C#" MasterPageFile="~/InicioSesion/InicioSesion.Master" AutoEventWireup="true" CodeBehind="indexInicioSesion.aspx.cs" Inherits="SoftCyberiaWA.InicioSesion.indexInicioSesion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Iniciar Sesión
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteainiciosesion.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <div>
        <h1 class="p-5 text-black-50 text-center" style="font-size: 50px;">Bienvenido a Cyberia!</h1>
        <img src="/Imagenes/cyberia-logo.png" alt="CYBERIA Logo" style="height: 200px; display: block; margin-left: auto; margin-right: auto;">
    </div>
    <!-- Contenedor de inicio de sesión -->
    <div class="container d-flex justify-content-center align-items-center" style="min-height: 80vh;">
        <div class="card p-4" style="width: 100%; max-width: 400px;">
            <h3 class="text-center">Iniciar Sesión</h3>

            <!-- Campo Email -->
            <div class="mb-3">
                <label for="personaCorreo">Ingrese su correo electrónico:</label>
                <asp:TextBox ID="personaCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                <small id="emailError" runat="server" style="color: red;"></small>
                <!-- Espacio para el mensaje de error del email -->
            </div>

            <!-- Campo Password -->
            <div class="mb-3">
                <label for="personaContrasena">Ingrese su contraseña:</label>
                <asp:TextBox ID="personaContrasena" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                <small id="passwordError" runat="server" style="color: red;"></small>
                <!-- Espacio para el mensaje de error de la contraseña -->
            </div>



            <!-- Botón de inicio de sesión -->
            <asp:Button ID="loginButton" runat="server" Text="Iniciar sesión" CssClass="btn btn-dark w-100" OnClick="loginButton_Click" />

            <!-- Registro -->
            <div class="text-center mt-3">
                <a href="registro_usuario.aspx">¿No tienes cuenta? Regístrate</a>
            </div>

        </div>
    </div>
</asp:Content>
