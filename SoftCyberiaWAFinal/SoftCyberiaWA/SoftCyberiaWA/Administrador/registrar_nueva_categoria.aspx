<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/SoftCyberiaAdministrador.Master" AutoEventWireup="true" CodeBehind="registrar_nueva_categoria.aspx.cs" Inherits="SoftCyberiaWA.Administrador.registrar_nueva_categoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Registrar Categoría
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteadmi.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center align-items-center vh-200" style="color: slategrey">
        <div class="card" style="width: 80%;  color: midnightblue">
            <div class="card-header text-center">
                <h2>
                    <asp:Label ID="lblTitulo" runat="server" Text="Registrar Nueva Categoría"></asp:Label>
                </h2>
            </div>

            <!-- Sección de formulario e imagen dentro de la tarjeta -->
            <div class="card-body align-content-xxl-center align-content-center h-100" style="font: medium">


                <div class="d-flex">
                    <!-- Columna de información del proveedor -->
                    <div class="col-md-20 align-content-center">
                        <div class="mb-3">
                            <label for="categoriaName">Nombre de la Categoría:</label>
                            <asp:TextBox ID="categoriaName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <!-- Columna de imagen y botón -->
                    <div class="col-md-6 text-center d-flex flex-column align-items-center justify-content-center align-content-center">
                        <asp:Label ID="lbnuevaCategoria" runat="server" Text="Nueva Categoría:" CssClass="fw-bold d-block mb-3"></asp:Label>
                        <asp:Image ID="imgNuevCategoria" runat="server" CssClass="img-fluid img-thumbnail mb-3" ImageUrl="/Imagenes/categoria.png" Height="250px" Width="250px" />
                        <asp:FileUpload ID="fileUploadNuevaCategoria" CssClass="form-control mb-3 w-75" runat="server" />
                        <asp:Button ID="registerButton" runat="server" Text="Registrar" CssClass="btn btn-primary w-75" OnClick="registerButton_Click" />
                        <asp:Label ID="successMessage" runat="server" CssClass="text-success" Visible="false"></asp:Label>
                    </div>

                </div>


            </div>
        </div>
    </div>
</asp:Content>
