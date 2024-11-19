<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente/SoftCyberiaCliente.Master" AutoEventWireup="true" CodeBehind="index_iniciosesion.aspx.cs" Inherits="SoftCyberiaWA.index_iniciosesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Iniciar Sesion
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteainiciosesion.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <!-- Contenedor de inicio de sesión -->
    <div class="container d-flex justify-content-center align-items-center" style="min-height: 80vh;">
        <div class="card p-4" style="width: 100%; max-width: 400px;">
            <h3 class="text-center">Iniciar Sesión</h3>

            <!-- Campo Email -->
            <div class="mb-3">
                <label for="email" class="form-label">Email</label>
                <input type="text" class="form-control" id="email" placeholder="Ingrese su correo electrónico" />
                <small id="emailError" style="color: red;"></small>
                <!-- Espacio para el mensaje de error del email -->
            </div>

            <!-- Campo Password -->
            <div class="mb-3">
                <label for="password" class="form-label">Contraseña</label>
                <input type="password" class="form-control" id="password" placeholder="Ingrese su contraseña" />
                <small id="passwordError" style="color: red;"></small>
                <!-- Espacio para el mensaje de error de la contraseña -->
            </div>

            <!-- Recordar cuenta -->
            <div class="form-check mb-3">
                <input type="checkbox" class="form-check-input" id="rememberMe">
                <label class="form-check-label" for="rememberMe">Recordar cuenta</label>
            </div>

            <!-- Botón de inicio de sesión -->
            <button type="button" class="btn btn-dark w-100" id="loginButton">Iniciar sesión</button>

            <!-- Registro -->
            <div class="text-center mt-3">
                <a href="registro_usuario.aspx">¿No tienes cuenta? Regístrate</a>
            </div>

        </div>
    </div>

    
    <script src="../Scripts/validar_inicio_sesion.js"></script>
</asp:Content>

