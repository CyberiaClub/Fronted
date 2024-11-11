<%@ Page Title="" Language="C#" MasterPageFile="~/SoftCyberiaAdmi.Master" AutoEventWireup="true" CodeBehind="registrar_nueva_marca.aspx.cs" Inherits="SoftCyberiaWA.registrarNuevaMarca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteadmi.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphTitulo" runat="server">
    Registrar Marca
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

 <div class="d-flex justify-content-center align-items-center vh-200" style="color:slategrey">
     <div class="card" style="width: 100%; max-width: 800px; color: midnightblue">
         <div class="card-header text-center" style="width:800px">
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

                 <!-- Columna de imagen y botón -->
                 <div class="col-md-6 text-center d-flex flex-column align-items-center justify-content-center align-content-center">
                     <asp:Label ID="lbnuevaMarca" runat="server" Text="Nueva Marca:" CssClass="fw-bold d-block mb-3"></asp:Label>
                     <asp:Image ID="imgNuevaMarca" runat="server" CssClass="img-fluid img-thumbnail mb-3" ImageUrl="/Imagenes/marca.png" Height="250px" Width="250px" />
                     <asp:FileUpload ID="fileUploadNuevaMarca" CssClass="form-control mb-3 w-75" runat="server" />
                     <asp:Button ID="registerButton" runat="server" Text="Registrar" CssClass="btn btn-primary w-75" OnClick="registerButton_Click" />
                 </div>


             </div>
         </div>
     </div>
 </div>

</asp:Content>
