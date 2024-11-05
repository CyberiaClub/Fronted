<%@ Page Title="Asignar Rol" Language="C#" MasterPageFile="~/SoftCyberiaAdmi.Master" AutoEventWireup="true" CodeBehind="listado_stock.aspx.cs" Inherits="SoftCyberiaWA.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphStyle" runat="server">
        <link href="../Content/siteadmi.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

 <div class="container-fluid d-flex justify-content-center align-items-center" style="height: 100vh; background-color: #E6E9EE;">
     <div class="row" style="width: 100%; max-width: 1200px; border-radius: 15px; box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1); background-color: #667892;">

         <!-- Formulario de asignación de roles -->
         <div class="col-md-8 p-5">
             <h3 class="text-white text-center mb-4">Stock disponible por Sede</h3>

             <div>
                 <label for="sku" class="text-white">Buscar por SKU:</label>
                 <input type="text" id="sku" name="sku" placeholder="Ingresa SKU">
             </div>
             <div>
                 <label for="nombre" class="text-white">Buscar por Nombre:</label>
                 <input type="text" id="nombre" name="nombre" placeholder="Ingresa Nombre">
             </div>

              


         </div>

         <!-- Panel derecho -->
         <div class="col-md-2 d-flex flex-column justify-content-center align-items-center bg-light" style="border-radius: 0 15px 15px 0;">
            <asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="btn btn-primary" />
         </div>
     </div>
 </div>
</asp:Content>




