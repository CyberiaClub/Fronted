<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/SoftCyberiaAdministrador.Master" AutoEventWireup="true" CodeBehind="registrar_nueva_marca.aspx.cs" Inherits="SoftCyberiaWA.Administrador.registrar_nueva_marca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Registrar Marca
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteadmi.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center align-items-center vh-200" style="color: slategrey">
        <div class="card" style="width: 100%; max-width: 800px; color: midnightblue">
            <div class="card-header text-center" style="width: 800px">
                <h2>
                    <asp:Label ID="lblTitulo" runat="server" Text="Registrar Nueva Marca"></asp:Label>
                </h2>
            </div>

            <!-- Sección de formulario e imagen dentro de la tarjeta -->
            <div class="card-body align-content-xxl-center align-content-center" style="font: medium">
                <div class="row">
                    <!-- Columna de información del proveedor -->
                    <div class="col-md-20 align-content-center">
                        <div class="mb-3">
                            <label for="marcaName">Nombre de la Marca:</label>
                            <asp:TextBox ID="marcaName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <div class="pb-3">
                            <asp:Label ID="lblProvider" runat="server" Text="Proveedor:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:DropDownList ID="providerName" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <!-- Columna de imagen y botón -->
                    <div class="col-md-6 text-center d-flex flex-column align-items-center justify-content-center align-content-center">
                        <asp:Label ID="lbnuevaMarca" runat="server" Text="Nueva Marca:" CssClass="fw-bold d-block mb-3"></asp:Label>
                        <asp:Image ID="imgNuevaMarca" runat="server" CssClass="img-fluid img-thumbnail mb-3" ImageUrl="/Imagenes/marca.png" Height="250px" Width="250px" />
                        <asp:FileUpload ID="fileUploadNuevaMarca" CssClass="form-control mb-3 w-75" runat="server" />
                    </div>


                    <div class="mb-3">
                       
                        <asp:Button ID="registerButton" runat="server" Text="Registrar" CssClass="btn btn-primary w-50 align-content-xl-center" OnClick="RegisterButton_Click" />
                         <asp:Label ID="successMessage" runat="server" CssClass="text-success" Visible="false"></asp:Label>
                    </div>


                </div>
            </div>
        </div>
    </div>

</asp:Content>
