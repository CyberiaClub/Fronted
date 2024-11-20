<%@ Page Title="" Language="C#" MasterPageFile="~/InicioSesion/InicioSesion.Master" AutoEventWireup="true" CodeBehind="registro_usuario.aspx.cs" Inherits="SoftCyberiaWA.InicioSesion.registro_usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Registro Usuario
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteainiciosesion.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="d-flex justify-content-center align-items-center vh-200" style="color: slategrey">
        <div class="card" style="width: 100%; max-width: 1100px; color: midnightblue">
            <div class="card-header text-center" style="width: 1100px">
                <h2>Registro de Usuario</h2>
            </div>
            <div class="card-body pb-2">
                <div class="row">
                    <!-- Contenedor de registro -->
                    <div class="container d-flex justify-content-center align-items-center" style="min-height: 80vh;">
                        <div class="card p-4" style="width: 100%; max-width: 400px;">
                            <h3 class="text-center">Iniciar Sesión</h3>

                            <!-- Campo Tipo de Documento -->
                            <div class="pb-3">
                                <asp:Label ID="lblpersonaTipoDocumento" runat="server" Text="Tipo de Documento:" CssClass="col-form-label fw-bold"></asp:Label>
                                <asp:DropDownList ID="personaTipoDocumento" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">Seleccione el Tipo de Documento</asp:ListItem>
                                    <asp:ListItem Value="1">DNI</asp:ListItem>
                                    <asp:ListItem Value="2">Pasaporte</asp:ListItem>
                                    <asp:ListItem Value="3">Carnet de Extranjeria</asp:ListItem>
                                </asp:DropDownList>
                                <small id="tipoDocumentoMensaje" class="form-text text-bg-danger" runat="server"></small>
                            </div>
                            <!-- Campo Documento -->
                            <div class="pb-3">
                                <label for="personaDocumento">Documento de Identidad:</label>
                                <asp:TextBox ID="personaDocumento" runat="server" CssClass="form-control"></asp:TextBox>
                                <small id="documentoMensaje" class="form-text text-bg-danger" runat="server"></small>
                            
                            </div>

                            <!-- Campo Teléfono -->
                            <div class="pb-3">
                                <label for="personaTelefono">Telefono:</label>
                                <asp:TextBox ID="personaTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                                <small id="telefonoMensaje" class="form-text text-bg-danger" runat="server"></small>
                            
                            </div>

                            <!-- Campo Nombre -->
                            <div class="pb-3">
                                <label for="personaNombre">Nombre:</label>
                                <asp:TextBox ID="personaNombre" runat="server" CssClass="form-control"></asp:TextBox>
                                <small id="nombreMensaje" class="form-text text-bg-danger" runat="server"></small>
                            
                            </div>

                            <!-- Campo Primer Apellido -->
                            <div class="pb-3">
                                <label for="personaPrimerAp">Primer Apellido:</label>
                                <asp:TextBox ID="personaPrimerAp" runat="server" CssClass="form-control"></asp:TextBox>
                                <small id="primerApMensaje" class="form-text text-bg-danger" runat="server"></small>
                       
                                </div>

                            <!-- Campo Segundo Apellido -->
                            <div class="pb-3">
                                <label for="personaSegundoAp">Segundo Apellido:</label>
                                <asp:TextBox ID="personaSegundoAp" runat="server" CssClass="form-control"></asp:TextBox>
                                <small id="segundoApMensaje" class="form-text text-bg-danger" runat="server"></small>
                            
                            </div>

                            <!-- Campo Fecha de Nacimiento -->
                            <div class="pb-3">
                                <label for="personaFechaNac">Fecha de Nacimiento:</label>
                                <input id="personaFechaNac" runat="server" type="date" class="form-control" />
                                <small id="fechaNacMensaje" class="form-text text-bg-danger" runat="server"></small>
                            </div>

                            <!-- Campo Sexo -->
                            <div class="pb-3">
                                <asp:Label ID="lblpersonaSexo" runat="server" Text="Sexo:" CssClass="col-form-label fw-bold"></asp:Label>
                                <asp:DropDownList ID="personaSexo" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">Seleccione su sexo</asp:ListItem>
                                    <asp:ListItem Value="1">Masculino</asp:ListItem>
                                    <asp:ListItem Value="2">Femenino</asp:ListItem>
                                </asp:DropDownList>
                                <small id="sexoMensaje" class="form-text text-bg-danger" runat="server"></small>
                            </div>

                            <!-- Campo Dirección -->
                            <div class="pb-3">
                                <label for="personaDireccion">Dirección:</label>
                                <asp:TextBox ID="personaDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                                <small id="direccionMensaje" class="form-text text-bg-danger" runat="server"></small>
                            </div>

                            <!-- Campo Nacionalidad -->
                            <div class="pb-3">
                                <label for="personaNacionalidad">Nacionalidad:</label>
                                <asp:TextBox ID="personaNacionalidad" runat="server" CssClass="form-control"></asp:TextBox>
                                <small id="nacionalidadMensaje" class="form-text text-bg-danger" runat="server"></small>
                            </div>

                            <div class="form-group">
                                <label for="personaCorreo">Correo Electrónico</label>
                                <input type="email" class="form-control" ID="personaCorreo" aria-describedby="emailHelp" placeholder="Ingrese su correo" runat="server">
                                <small id="correoMensaje" class="form-text text-bg-danger" runat="server"></small>
                            </div>

                            <div class="form-group">
                                <label for="personaContraseña">Contraseña</label>
                                <input type="password" class="form-control" id="personaContraseña" placeholder="Contraseña" runat="server">
                                <small id="contraseñaMensaje" class="form-text text-bg-danger" runat="server"></small>
                            </div>

                            <div class="form-group">
                                <label for="personaConfirmarContraseña">Confirmar Contraseña</label>
                                <input type="password" class="form-control" id="personaConfirmarContraseña" placeholder="Confirme su contraseña" runat="server">
                                <small id="confirmarContraseñaMensaje" class="form-text text-bg-danger" runat="server"></small>                            
                            </div>
                            <!-- Botón de registro -->
                            <div class="form-group">
                                <asp:Button ID="registerButton" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="onClickRegistrarPersona" />
                            </div>
                            <!-- Iniciar Sesión -->
                            <div class="text-center mt-3">
                                <a href="indexInicioSesion.aspx">¿Ya tienes cuenta? Inicia sesión</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
