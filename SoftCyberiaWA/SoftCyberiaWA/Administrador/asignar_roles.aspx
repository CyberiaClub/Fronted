<%@ Page Title="Asignar Rol" Language="C#" MasterPageFile="~/SoftCyberiaAdmi.Master" AutoEventWireup="true" CodeBehind="asignar_roles.aspx.cs" Inherits="SoftCyberiaWA.WebForm5" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container-fluid d-flex justify-content-center align-items-center" style="height: 100vh; background-color: #E6E9EE;">
            <!-- Formulario de asignación de roles -->
            <div class="col-md-8 p-5">
                <h3 class="text-white text-center mb-4">Asignar Rol</h3>

                <div class="form-group mt-3">
                    <label for="tipo_documento" class="text-white">Tipo de documento de Identificación:</label>
                    <asp:DropDownList ID="tipo_documento" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">Seleccione un tipo</asp:ListItem>
                        <asp:ListItem Value="1">DNI</asp:ListItem>
                        <asp:ListItem Value="2">Passaporte</asp:ListItem>
                        <asp:ListItem Value="3">Carnet de Extranjeria</asp:ListItem>
                    </asp:DropDownList>
                </div>
                
                <div class="form-group">
                    <label for="documento" class="text-white">Número de documento de identidad:</label>
                    <div class="d-flex">
                        <asp:TextBox ID="dni" runat="server" CssClass="form-control mr-2" placeholder="Ingrese DNI"></asp:TextBox>
                        <asp:Button ID="btnProcesar" runat="server" Text="Procesar" CssClass="btn btn-secondary" />
                    </div>
                </div>

                <div class="form-group mt-3">
                    <label for="nombre" class="text-white">Nombre:</label>
                    <asp:TextBox ID="nombre" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="form-group mt-3">
                    <label for="correo" class="text-white">Correo Electrónico:</label>
                    <asp:TextBox ID="correo" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="form-group mt-3">
                    <label for="telefono" class="text-white">Teléfono:</label>
                    <asp:TextBox ID="telefono" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="form-group mt-3">
                    <label for="direccion" class="text-white">Dirección:</label>
                    <asp:TextBox ID="direccion" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="form-group mt-3">
                    <label for="rol" class="text-white">Asignar Rol:</label>
                    <asp:DropDownList ID="rol" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">Seleccione un rol</asp:ListItem>
                        <asp:ListItem Value="1">Vendedor</asp:ListItem>
                        <asp:ListItem Value="2">Almacén</asp:ListItem>
                        <asp:ListItem Value="3">Cliente</asp:ListItem>
                    </asp:DropDownList>
                </div>

            </div>

            <!-- Panel derecho -->
            <div class="col-md-4 d-flex flex-column justify-content-center align-items-center bg-light" style="border-radius: 0 15px 15px 0;">
                <h4 class="font-weight-bold mb-4" style="color: #004EA8;">Asignar Rol</h4>
                <img src="Images/rol.png" alt="Icono de seguridad" style="width: 160px; height: 160px;">
                
                <asp:Button ID="btnAsignar" runat="server" Text="Asignar" CssClass="btn btn-primary mt-4" style="background-color: #004EA8; border-color: #004EA8;" />
            </div>
        </div>
    </div>
 
</asp:Content>
