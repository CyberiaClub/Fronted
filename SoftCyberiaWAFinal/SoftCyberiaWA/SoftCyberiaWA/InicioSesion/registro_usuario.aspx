<%@ Page Title="" Language="C#" MasterPageFile="~/InicioSesion/InicioSesion.Master" AutoEventWireup="true" CodeBehind="registro_usuario.aspx.cs" Inherits="SoftCyberiaWA.InicioSesion.registro_usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Registro Usuario
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteainiciosesion.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.min.js"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="container d-flex align-items-center justify-content-center min-vh-100" style="background-color: #f8f9fa;">
        <div class="card shadow-lg" style="max-width: 600px; width: 100%; height: auto;">
            <div class="card-header sticky-header text-center text-white" style="background-color: midnightblue;">
                <h2>Registro de Usuario</h2>
            </div>
            <div class="card-body">
                <!-- Campo Tipo de Documento -->
                <div class="mb-3">
                    <asp:Label ID="lblpersonaTipoDocumento" runat="server" Text="Tipo de Documento:" CssClass="form-label fw-bold"></asp:Label>
                    <asp:DropDownList ID="personaTipoDocumento" runat="server" CssClass="form-select">
                        <asp:ListItem Value="0">Seleccione el Tipo de Documento</asp:ListItem>
                        <asp:ListItem Value="1">DNI</asp:ListItem>
                        <asp:ListItem Value="2">Pasaporte</asp:ListItem>
                        <asp:ListItem Value="3">Carnet de Extranjería</asp:ListItem>
                    </asp:DropDownList>
                    <small id="tipoDocumentoMensaje" class="form-text text-danger" runat="server"></small>
                </div>
                <!-- Campo Documento -->
                <div class="mb-3">
                    <label for="personaDocumento" class="form-label">Documento de Identidad:</label>
                    <asp:TextBox ID="personaDocumento" runat="server" CssClass="form-control"></asp:TextBox>
                    <small id="documentoMensaje" class="form-text text-danger" runat="server"></small>
                </div>
                <!-- Campo Teléfono -->
                <div class="mb-3">
                    <label for="personaTelefono" class="form-label">Teléfono:</label>
                    <asp:TextBox ID="personaTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                    <small id="telefonoMensaje" class="form-text text-danger" runat="server"></small>
                </div>
                <!-- Campo Nombre -->
                <div class="mb-3">
                    <label for="personaNombre" class="form-label">Nombre:</label>
                    <asp:TextBox ID="personaNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    <small id="nombreMensaje" class="form-text text-danger" runat="server"></small>
                </div>
                <!-- Campo Apellidos -->
                <div class="mb-3">
                    <label for="personaPrimerAp" class="form-label">Primer Apellido:</label>
                    <asp:TextBox ID="personaPrimerAp" runat="server" CssClass="form-control"></asp:TextBox>
                    <small id="primerApMensaje" class="form-text text-danger" runat="server"></small>
                </div>
                <div class="mb-3">
                    <label for="personaSegundoAp" class="form-label">Segundo Apellido:</label>
                    <asp:TextBox ID="personaSegundoAp" runat="server" CssClass="form-control"></asp:TextBox>
                    <small id="segundoApMensaje" class="form-text text-danger" runat="server"></small>
                </div>
                <!-- Campo Fecha de Nacimiento -->
                <div class="mb-3">
                    <label for="personaFechaNac" class="form-label">Fecha de Nacimiento:</label>
                    <input id="personaFechaNac" runat="server" type="date" class="form-control" />
                    <small id="fechaNacMensaje" class="form-text text-danger" runat="server"></small>
                </div>
                <!-- Campo Sexo -->
                <div class="mb-3">
                    <asp:Label ID="lblpersonaSexo" runat="server" Text="Sexo:" CssClass="form-label"></asp:Label>
                    <asp:DropDownList ID="personaSexo" runat="server" CssClass="form-select">
                        <asp:ListItem Value="0">Seleccione su sexo</asp:ListItem>
                        <asp:ListItem Value="1">Masculino</asp:ListItem>
                        <asp:ListItem Value="2">Femenino</asp:ListItem>
                    </asp:DropDownList>
                    <small id="sexoMensaje" class="form-text text-danger" runat="server"></small>
                </div>
                <!-- Campo Dirección -->
                <div class="mb-3">
                    <label for="personaDireccion" class="form-label">Dirección:</label>
                    <asp:TextBox ID="personaDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                    <small id="direccionMensaje" class="form-text text-danger" runat="server"></small>
                </div>
                <!-- Campo Nacionalidad -->
                <div class="mb-3">
                    <label for="nacionalidad" class="form-label">Nacionalidad:</label>
                    <asp:TextBox ID="nacionalidad" runat="server" CssClass="form-control" placeholder="Escriba su nacionalidad"></asp:TextBox>
                    <small id="nacionalidadMensaje" class="form-text text-danger" runat="server"></small>
                </div>
                <!-- Campo Correo Electrónico -->
                <div class="mb-3">
                    <label for="personaCorreo" class="form-label">Correo Electrónico:</label>
                    <input type="email" class="form-control" id="personaCorreo" runat="server" placeholder="Ejemplo: ejemplo@gmail.com" />
                    <small id="correoMensaje" class="form-text text-danger" runat="server"></small>
                </div>
                <!-- Campo Contraseña -->
                <div class="mb-3">
                    <label for="personaContraseña" class="form-label">Contraseña:</label>
                    <input type="password" class="form-control" id="personaContraseña" runat="server" placeholder="Contraseña" />
                    <small id="contraseñaMensaje" class="form-text text-danger" runat="server"></small>
                </div>
                <div class="mb-3">
                    <label for="personaConfirmarContraseña" class="form-label">Confirmar Contraseña:</label>
                    <input type="password" class="form-control" id="personaConfirmarContraseña" runat="server" placeholder="Confirme su contraseña" />
                    <small id="confirmarContraseñaMensaje" class="form-text text-danger" runat="server"></small>
                </div>
                <!-- Botón de Registro -->
                <div class="text-center">
                    <asp:Button ID="registerButton" runat="server" Text="Registrar" CssClass="btn btn-primary w-100" Style="background-color: midnightblue;" OnClick="OnClickRegistrarPersona" />
                    <small id="successMessage" class="form-text" runat="server" style="font-size:medium; color:green"></small>

                </div>
                <!-- Iniciar Sesión -->
                <div class="text-center mt-3">
                    <a href="indexInicioSesion.aspx">¿Ya tienes cuenta? Inicia sesión</a>
                </div>
            </div>
        </div>
    </div>
    <script>
        $(function () {
            if (typeof nacionalidades !== "undefined" && Array.isArray(nacionalidades)) {
                $("#<%= nacionalidad.ClientID %>").autocomplete({
                    source: nacionalidades
                });
            } else {
                console.warn("La variable 'nacionalidades' no está definida o no es válida.");
            }
        });
    </script>
</asp:Content>

