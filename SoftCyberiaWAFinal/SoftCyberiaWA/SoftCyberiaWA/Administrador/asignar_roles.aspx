<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/SoftCyberiaAdministrador.Master" AutoEventWireup="true" CodeBehind="asignar_roles.aspx.cs" Inherits="SoftCyberiaWA.Administrador.asignar_roles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Asignar Rol
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteadmi.css" rel="stylesheet" />
    <%--<script src="../Scripts\validacion_rol.js"></script>--%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex justify-content-center align-items-center vh-200">
        <div class="card" style="width: 60vw;height:130vh;  color: midnightblue">
            <div class="card-header text-center" >
                <h2>Asignar Rol</h2>
            </div>
            <div class="card-body pb-2">
                <div class="row">
                    <!-- Columna de información de usuario -->
                    <div class="col-md-8">
                        <div class="pb-3">
                            <asp:Label ID="lblTipoDocumento" runat="server" Text="Tipo de documento de Identificación:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:DropDownList ID="tipo_documento" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0">Seleccione un tipo</asp:ListItem>
                                <asp:ListItem Value="1">DNI</asp:ListItem>
                                <asp:ListItem Value="2">Passaporte</asp:ListItem>
                                <asp:ListItem Value="3">Carnet de Extranjeria</asp:ListItem>
                            </asp:DropDownList>
                            <small id="tipoDocumentoMensaje" class="form-text text-danger" runat="server"></small>
                        </div>
                        <div class="pb-3">
                            <asp:Label ID="lblDocumento" runat="server" Text="Número de documento de identidad:" CssClass="col-form-label fw-bold"></asp:Label>

                            <asp:TextBox ID="dni" runat="server" CssClass="form-control mr-2"
                                AutoPostBack="True" OnTextChanged="dni_Ingresado"></asp:TextBox>
                            <small id="dniMensaje" class="form-text text-danger" runat="server"></small>
                        </div>

                        <div class="pb-3">
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="nombre" runat="server" CssClass="form-control mr-2" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="pb-3">
                            <asp:Label ID="lblCorreo" runat="server" Text="Correo Electrónico:" CssClass="col-form-label fw-bold "></asp:Label>
                            <asp:TextBox ID="correo" runat="server" CssClass="form-control" ReadOnly="true" TextMode="Email"></asp:TextBox>
                        </div>

                        <div class="pb-3">
                            <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:" CssClass="col-form-label fw-bold "></asp:Label>
                            <asp:TextBox ID="telefono" runat="server" CssClass="form-control" ReadOnly="true" TextMode="Phone"></asp:TextBox>
                        </div>
                        <div class="pb-3">
                            <asp:Label ID="lblDireccion" runat="server" Text="Dirección:" CssClass="col-form-label fw-bold "></asp:Label>
                            <asp:TextBox ID="direccion" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>

                        <div class="pb-3">
                            <asp:Label ID="lblRol" runat="server" Text="Asignar Rol:" CssClass="col-form-label fw-bold "></asp:Label>
                            <asp:DropDownList ID="rol" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0">Seleccione un rol</asp:ListItem>
                                <asp:ListItem Value="1">Vendedor</asp:ListItem>
                                <asp:ListItem Value="2">Almacén</asp:ListItem>
                            </asp:DropDownList>
                            <small id="rolMensaje" class="form-text text-danger" runat="server"></small>
                        </div>
                        <div class="pb-3">
                            <asp:Label ID="lblSueldo" runat="server" Text="Sueldo:" CssClass="col-form-label fw-bold "></asp:Label>
                            <asp:TextBox ID="sueldo" runat="server" CssClass="form-control numeric-input" TextMode="Number" min="0"></asp:TextBox>
                            <small id="sueldoMensaje" class="form-text text-danger" runat="server"></small>
                        </div>


                        <div class="pb-3">
                            <asp:Label ID="lblSede" runat="server" Text="Sede:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:DropDownList ID="sede" runat="server" CssClass="form-control"></asp:DropDownList>
                            <small id="sedeMensaje" class="form-text text-danger" runat="server"></small>
                        </div>


                    </div>

                    <!-- Columna de imagen y botón de asignación -->
                    <div class="col-md-4 d-flex flex-column align-items-center justify-content-center bg-light" style="border-radius: 0 1% 1% 0; margin-top:5%">
                        <h4 class="font-weight-bold mb-4" style="color: #004EA8;">Asignar Rol</h4>
                        <img src="/Imagenes/rol.png" alt="Icono de seguridad" class="img-fluid img-thumbnail mb-3" style="width: 40%;">
                        <asp:Button ID="btnAsignar" runat="server" Text="Asignar" CssClass="btn btn-primary mt-4" Style="background-color: #004EA8; border-color: #004EA8; width:80%" OnClick="btnAsignar_Click" />
                        <asp:Label ID="successMessage" runat="server" CssClass="text-success" Visible="false"></asp:Label>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
