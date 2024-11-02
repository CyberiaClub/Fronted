<%@ Page Title="Asignar Rol" Language="C#" MasterPageFile="~/SoftCyberiaAdmi.Master" AutoEventWireup="true" CodeBehind="listado_stock.aspx.cs" Inherits="SoftCyberiaWA.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

        /* Body Styling */
        body {
            background-color: #667892; /* Background color for the page */
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        /* Container */
        .container {
            width: 60%;
            max-width: 800px;
            background-color: #f3f3f3;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
        }

        /* Header */
        .header {
            text-align: center;
            margin-bottom: 20px;
            font-size: 24px;
            font-weight: bold;
            color: #004EA8; /* Primary color */
        }

        /* Form styling */
        .form-group {
            display: flex;
            justify-content: space-between;
            margin-bottom: 20px;
        }

        label {
            font-size: 16px;
            color: #333;
        }

        input[type="text"] {
            width: 45%;
            padding: 10px;
            font-size: 16px;
            border: 1px solid #667892;
            border-radius: 4px;
        }

        /* Button styling */
        .btn {
            display: inline-block;
            padding: 10px 20px;
            font-size: 16px;
            background-color: #004EA8; /* Button color */
            color: #ffffff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        .btn:hover {
            background-color: #003b85;
        }
    </style>


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


