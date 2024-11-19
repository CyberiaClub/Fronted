<%@ Page Title="" Language="C#" MasterPageFile="~/InicioSesion/InicioSesion.Master" AutoEventWireup="true" CodeBehind="registro_usuario.aspx.cs" Inherits="SoftCyberiaWA.InicioSesion.registro_usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Registro Usuario
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
     <link href="../Content/siteainiciosesion.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">

    <!-- Contenedor de registro -->
    <div class="container d-flex justify-content-center align-items-center" style="min-height: 80vh;">
        <div class="card p-4" style="width: 100%; max-width: 500px;">
            <h3 class="text-center">Registro de Usuario</h3>

            <!-- Campo Documento -->
            <div class="mb-3">
                <label for="documento" class="form-label">Documento</label>
                <input type="text" class="form-control" id="documento" placeholder="Ingrese su número de documento" maxlength="15" />
            </div>

            <!-- Campo Teléfono -->
            <div class="mb-3">
                <label for="telefono" class="form-label">Teléfono</label>
                <input type="text" class="form-control" id="telefono" placeholder="Ingrese su número de teléfono" maxlength="13" />
            </div>

            <!-- Campo Nombre -->
            <div class="mb-3">
                <label for="nombre" class="form-label">Nombre</label>
                <input type="text" class="form-control" id="nombre" placeholder="Ingrese su nombre" maxlength="100" />
            </div>

            <!-- Campo Apellido Paterno -->
            <div class="mb-3">
                <label for="apellidoPaterno" class="form-label">Apellido Paterno</label>
                <input type="text" class="form-control" id="apellidoPaterno" placeholder="Ingrese su apellido paterno" maxlength="100" />
            </div>

            <!-- Campo Apellido Materno -->
            <div class="mb-3">
                <label for="apellidoMaterno" class="form-label">Apellido Materno</label>
                <input type="text" class="form-control" id="apellidoMaterno" placeholder="Ingrese su apellido materno" maxlength="100" />
            </div>

            <!-- Campo Fecha de Nacimiento -->
            <div class="mb-3">
                <label for="fechaNacimiento" class="form-label">Fecha de Nacimiento</label>
                <input type="date" class="form-control" id="fechaNacimiento" />
            </div>

            <!-- Campo Sexo -->
            <div class="mb-3">
                <label for="sexo" class="form-label">Sexo</label>
                <select class="form-select" id="sexo">
                    <option value="" disabled selected>Seleccione su sexo</option>
                    <option value="M">Masculino</option>
                    <option value="F">Femenino</option>
                </select>
            </div>

            <!-- Campo Correo -->
            <div class="mb-3">
                <label for="correo" class="form-label">Correo Electrónico</label>
                <input type="email" class="form-control" id="correo" placeholder="Ingrese su correo electrónico" maxlength="120" />
            </div>

            <!-- Campo Dirección -->
            <div class="mb-3">
                <label for="direccion" class="form-label">Dirección</label>
                <input type="text" class="form-control" id="direccion" placeholder="Ingrese su dirección" maxlength="120" />
            </div>

            <!-- Campo Nacionalidad -->
            <div class="mb-3">
                <label for="nacionalidad" class="form-label">Nacionalidad</label>
                <input type="text" class="form-control" id="nacionalidad" placeholder="Ingrese su nacionalidad" maxlength="30" />
            </div>

            <!-- Campo Tipo de Documento -->
            <div class="mb-3">
                <label for="tipoDocumento" class="form-label">Tipo de Documento</label>
                <select class="form-select" id="tipoDocumento">
                    <option value="" disabled selected>Seleccione su tipo de documento</option>
                    <option value="DNI">DNI</option>
                    <option value="Pasaporte">Pasaporte</option>
                    <option value="Carnet de extranjería">Carnet de extranjería</option>
                </select>
            </div>

            <!-- Campo Contraseña -->
            <div class="mb-3">
                <label for="contrasena" class="form-label">Contraseña</label>
                <input type="password" class="form-control" id="contrasena" placeholder="Cree una contraseña" maxlength="128" />
            </div>

            <!-- Confirmar Contraseña -->
            <div class="mb-3">
                <label for="confirmarContrasena" class="form-label">Confirmar Contraseña</label>
                <input type="password" class="form-control" id="confirmarContrasena" placeholder="Confirme su contraseña" maxlength="128" />
            </div>

            <!-- Botón de registro -->
            <button type="button" class="btn btn-dark w-100" id="registerButton">Registrar</button>


            <!-- Iniciar Sesión -->
            <div class="text-center mt-3">
                <a href="indexInicioSesion.aspx">¿Ya tienes cuenta? Inicia sesión</a>
            </div>
        </div>
    </div>
</asp:Content>
