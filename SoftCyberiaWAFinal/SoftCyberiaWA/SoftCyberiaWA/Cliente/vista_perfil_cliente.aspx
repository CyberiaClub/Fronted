﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente/SoftCyberiaCliente.Master" AutoEventWireup="true" CodeBehind="vista_perfil_cliente.aspx.cs" Inherits="SoftCyberiaWA.Vista_perfil_cliente_aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Perfil
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteCliente.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="container d-flex flex-column align-items-center mt-5">
        <asp:Literal ID="UserNameLiteral" runat="server"></asp:Literal>
        <hr class="w-100 mb-4">

        <div class="profile-picture mb-4">
            <img src="../Imagenes/admin-user.png" alt="Profile" class="img-fluid rounded-circle">
        </div>

        <div class="card p-4 text-center" style="width: 100%; max-width: 400px;">
            <!-- Campo del correo electrónico -->
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Correo electrónico</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control text-center" Text="" Enabled="false" runat="server"></asp:TextBox>
                <small id="errorEmail" class="form-text text-danger" runat="server"></small>
            </div>
            <!-- Campo del número de teléfono -->
            <div class="mb-3">
                <label for="txtPhone" class="form-label">Número de Teléfono</label>
                <asp:TextBox ID="txtPhone" CssClass="form-control text-center" Text="" Enabled="false" runat="server"></asp:TextBox>
                <small id="errorPhone" class="form-text text-danger" runat="server"></small>
            </div>
            <!-- Campo de la direccion -->
            <div class="mb-3">
                <label for="txtDireccion" class="form-label">Dirección</label>
                <asp:TextBox ID="txtDireccion" CssClass="form-control text-center" Text="" Enabled="false" runat="server"></asp:TextBox>
                <small id="errorDireccion" class="form-text text-danger" runat="server"></small>
            </div>
            <!-- Botones de edición y guardado -->
            <div id="editButtons" runat="server">
                <asp:Button ID="btnEditProfile" CssClass="btn btn-primary w-100 mb-3" Text="Editar Perfil" OnClick="BtnEditProfile_Click" runat="server" />
               
            </div>

            <div id="saveButtons" runat="server" style="display: none;">
                <asp:Button ID="btnSaveChanges" CssClass="btn btn-success w-100 mb-3" Text="Guardar Cambios" OnClick="SaveChanges" runat="server" />
                <asp:Button ID="btnCancel" CssClass="btn btn-secondary w-100" Text="Cancelar" OnClick="BtnCancel_Click" runat="server" />
            </div>
        </div>
    </div>

    <script type="text/javascript">
        // Función para habilitar la edición de perfil
        function enableEdit() {
            document.getElementById('<%= txtEmail.ClientID %>').readOnly = false;
            document.getElementById('<%= txtPhone.ClientID %>').readOnly = false;

            document.getElementById('<%= editButtons.ClientID %>').style.display = "none";
            document.getElementById('<%= saveButtons.ClientID %>').style.display = "block";
        }

        // Función para cancelar la edición y revertir a la vista original
        function cancelEdit() {
            document.getElementById('<%= txtEmail.ClientID %>').readOnly = true;
            document.getElementById('<%= txtPhone.ClientID %>').readOnly = true;

            document.getElementById('<%= editButtons.ClientID %>').style.display = "block";
            document.getElementById('<%= saveButtons.ClientID %>').style.display = "none";
        }

        // Función para cerrar sesión (opcional, implementación en C#)
        function logout() {
            window.location.href = 'logout.aspx';
        }
    </script>
</asp:Content>
