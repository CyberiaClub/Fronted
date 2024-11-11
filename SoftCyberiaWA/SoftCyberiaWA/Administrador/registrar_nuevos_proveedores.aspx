<%@ Page Title="" Language="C#" MasterPageFile="~/SoftCyberiaAdmi.Master" AutoEventWireup="true" CodeBehind="registrar_nuevos_proveedores.aspx.cs" Inherits="SoftCyberiaWA.WebForm3" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphStyle" runat="server">
       <link href="../Content/siteadmi.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="d-flex justify-content-center align-items-center vh-200" style="color:slategrey">
        <div class="card" style="width: 100%; max-width: 1100px; color: midnightblue">
            <div class="card-header text-center" style="width:1100px">
                <h2>
                    <asp:Label ID="lblTitulo" runat="server" Text="Registrar nuevos Proveedores"></asp:Label>
                </h2>
            </div>

            <!-- Sección de formulario e imagen dentro de la tarjeta -->
            <div class="card-body align-content-xxl-center" style="font: medium">
                <div class="row">
                    <!-- Columna de información del proveedor -->
                    <div class="col-md-6">
                        <div class="mb-3">
                            <label for="providerRUC">RUC del Proveedor:</label>
                            <asp:TextBox ID="providerRUC" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="providerName">Nombre del Proveedor:</label>
                            <asp:TextBox ID="nombreProveedor" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="razonSocial">Razón Social:</label>
                            <asp:TextBox ID="razonSocial" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="phone">Teléfono:</label>
                            <asp:TextBox ID="phone" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="email">Correo Electrónico:</label>
                            <asp:TextBox ID="email" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="address">Dirección:</label>
                            <asp:TextBox ID="address" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="products">Descripción del Producto que Suministra:</label>
                            <asp:TextBox ID="products" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <!-- Columna de imagen y botón -->
                    <div class="col-md-6 text-center d-flex flex-column align-items-center justify-content-center">
                        <asp:Label ID="lbnuevoProveedor" runat="server" Text="Nuevo Proveedor:" CssClass="fw-bold d-block mb-3"></asp:Label>
                        <asp:Image ID="imgNuevoProveedor" runat="server" CssClass="img-fluid img-thumbnail mb-3" ImageUrl="/Imagenes/proveedor.png" Height="250px" Width="250px" />
                        <asp:FileUpload ID="fileUploadNuevoProveedor" CssClass="form-control mb-3 w-75" runat="server" />
                        <asp:Button ID="registerButton" runat="server" Text="Registrar" CssClass="btn btn-primary w-75" OnClick="lbGuardar_Click" />
                    </div>


                </div>
            </div>
        </div>
    </div>
</asp:Content>




<asp:Content ID="Content3" ContentPlaceHolderID="cphTitulo" runat="server">
      Registrar Proveedor
</asp:Content>

