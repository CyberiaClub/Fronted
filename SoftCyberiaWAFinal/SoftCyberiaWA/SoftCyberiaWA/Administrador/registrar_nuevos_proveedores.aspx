<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/SoftCyberiaAdministrador.Master" AutoEventWireup="true" CodeBehind="registrar_nuevos_proveedores.aspx.cs" Inherits="SoftCyberiaWA.Administrador.registrar_nuevos_proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Registrar Proveedores
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteadmi.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex flex-column justify-content-center align-items-center">
        <div class="card mx-auto" style="width: 60vw; height: 120vh; color: midnightblue;">
            <div class="card-header text-center">
                <h2>Registrar nuevo proveedor</h2>
            </div>
            <div class="card-body pb-2">
                <div class="row g-3">
                    <!-- Columna del formulario -->
                    <div class="d-flex flex-column col-12 col-md-8" style="height: 100vh; width: 100%">
                        <div class="d-flex">
                            <div class="pb-3" style="width: 50%">
                                <label for="lblproveedorRUC">RUC del Proveedor:</label>
                                <asp:TextBox ID="proveedorRUC" runat="server" CssClass="form-control form-control-sm" Width="95%"></asp:TextBox>
                                <small id="proveedorRUCMensaje" class="form-text text-danger" runat="server"></small>
                            </div>
                            <div class="mb-3" style="width: 100%">
                                <label for="razonSocial">Razón Social:</label>
                                <asp:TextBox ID="razonSocial" runat="server" CssClass="form-control form-control-sm" Width="100%"></asp:TextBox>
                                <small id="razonSocialMensaje" class="form-text text-danger" runat="server"></small>
                            </div>
                        </div>

                        <div class="mb-3" style="width: 100%">
                            <label for="lblnombreContacto">Nombre de Contacto:</label>
                            <asp:TextBox ID="nombreContacto" runat="server" CssClass="form-control form-control-sm" Width="100%"></asp:TextBox>
                            <small id="nombreContactoMensaje" class="form-text text-danger" runat="server"></small>
                        </div>
                        <div class="d-flex">
                            <div class="mb-3" style="width: 50%">
                                <label for="lbltelfono">Teléfono:</label>
                                <asp:TextBox ID="telfono" runat="server" CssClass="form-control form-control-sm" TextMode="Phone"
                                    Width="95%" Height="72%"></asp:TextBox>
                                <small id="telfonoMensaje" class="form-text text-danger" runat="server"></small>
                            </div>
                            <div class="mb-3" style="width: 100%">
                                <label for="lblcorreo">Correo Electrónico:</label>
                                <asp:TextBox ID="correo" runat="server" TextMode="Email" CssClass="form-control form-control-sm" Height="72%"></asp:TextBox>
                                <small id="correoMensaje" class="form-text text-danger" runat="server"></small>
                            </div>
                        </div>
                        <div class="d-flex" style="margin-top: 5vh">
                            <div class="d-flex flex-column" style="width: 40%">
                                <div class="mb-3">
                                    <label for="lbldireccion">Dirección:</label>
                                    <asp:TextBox ID="direccion" runat="server" CssClass="form-control form-control-sm"
                                        TextMode="MultiLine" Rows="3" Columns="20"></asp:TextBox>
                                    <small id="direccionMensaje" class="form-text text-danger" runat="server"></small>
                                </div>
                                <div class="mb-3">
                                    <label for="lbldescripcion">Descripción del Producto que Suministra:</label>
                                    <asp:TextBox ID="descripcion" runat="server" CssClass="form-control"
                                        TextMode="MultiLine" Rows="4" Columns="30"></asp:TextBox>
                                    <small id="descripcionMensaje" class="form-text text-danger" runat="server"></small>
                                </div>
                            </div>
                            <div class="col-12 col-md-4 d-flex flex-column align-items-center justify-content-center bg-light"
                                style="margin-left: 13%">
                                <asp:Label ID="lblimagen" runat="server" Text="Nuevo Proveedor:" CssClass="fw-bold d-block mb-3"></asp:Label>
                                <img src="/Imagenes/proveedor.png" alt="Icono de oferta" class="img-fluid img-thumbnail mb-3" style="width: 70%;">
                                <asp:FileUpload ID="imagen" CssClass="form-control mb-2" runat="server" Width="95%" />
                                <small id="imagenMensaje" class="form-text text-danger" runat="server"></small>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card-footer text-center">
                <asp:Button ID="botonRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary btn-lg w-100" OnClick="botonRegistrar_Click" />
                <asp:Label ID="lblRegistrar" runat="server" CssClass="text-success mt-2 d-block" Visible="false"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
