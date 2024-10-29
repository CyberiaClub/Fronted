<%@ Page Title="" Language="C#" MasterPageFile="~/SoftCyberiaInicioSesion.Master" AutoEventWireup="true" CodeBehind="IndexInicioSesion.aspx.cs" Inherits="SoftCyberiaWA.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Contenedor de inicio de sesión -->
    <div class="container d-flex justify-content-center align-items-center" style="min-height: 80vh;">
        <div class="card p-4" style="width: 100%; max-width: 400px;">
            <h3 class="text-center">Iniciar Sesión</h3>
            <form runat="server">
                <!-- Campo Email -->
                <div class="mb-3">
                    <label for="email" class="form-label">Email</label>
                    <input type="text" class="form-control" id="email" placeholder="Ingrese su correo electrónico" />
                </div>

                <!-- Campo Password -->
                <div class="mb-3">
                    <label for="password" class="form-label">Contraseña</label>
                    <input type="password" class="form-control" id="password" placeholder="Ingrese su contraseña" />
                </div>

                <!-- Recordar cuenta -->
                <div class="form-check mb-3">
                    <input type="checkbox" class="form-check-input" id="rememberMe">
                    <label class="form-check-label" for="rememberMe">Recordar cuenta</label>
                </div>

                <!-- Botón de inicio de sesión -->
                <button type="submit" class="btn btn-dark w-100">Iniciar sesión</button>

                <!-- Registro -->
                <div class="text-center mt-3">
                    <a href="#">¿No tienes cuenta? Regístrate</a>
                </div>
            </form>
        </div>
    </div>

</asp:Content>
