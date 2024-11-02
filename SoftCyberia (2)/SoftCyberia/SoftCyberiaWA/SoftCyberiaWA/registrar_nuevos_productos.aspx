<%@ Page Title="" Language="C#" MasterPageFile="~/SoftCyberiaAdmi.Master" AutoEventWireup="true" CodeBehind="registrar_nuevos_productos.aspx.cs" Inherits="SoftCyberiaWA.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphStyle" runat="server">
    <!-- Estilos específicos para registrar nuevos productos -->
    <style>
        .form-container {
            display: flex;
            width: 800px;
            border-radius: 15px;
            overflow: hidden;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            background-color: #ffffff;
            margin: 20px auto;
        }

        .form-section {
            padding: 20px;
            width: 60%;
            display: flex;
            flex-wrap: wrap;
            gap: 10px;
            background-color: #d3d8dc;
            color: #333333;
        }

        .form-section label {
            width: 45%;
            font-weight: bold;
            margin-top: 10px;
            color: #667892;
        }

        .form-section input[type="text"],
        .form-section input[type="number"],
        .form-section select,
        .form-section textarea {
            width: 45%;
            padding: 8px;
            border-radius: 5px;
            border: 1px solid #ccc;
            font-size: 0.9em;
        }

        .info-section {
            width: 40%;
            background-color: #e8ebed;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            text-align: center;
            padding: 20px;
            color: #667892;
        }

        .register-button {
            width: 100%;
            padding: 10px;
            background-color: #004EA8;
            color: white;
            border: none;
            border-radius: 5px;
            font-size: 1em;
            cursor: pointer;
        }

        .register-button:hover {
            background-color: #003a7a;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="form-container">
        <!-- Sección de formulario -->
        <div class="form-section">
            <label for="productName">Nombre del Producto:</label>
            <asp:TextBox ID="productName" runat="server" CssClass="form-control"></asp:TextBox>

            <label for="sku">SKU:</label>
            <asp:TextBox ID="sku" runat="server" CssClass="form-control"></asp:TextBox>

            <label for="marcaTxt">Marca del Producto:</label>
            <asp:TextBox ID="marcaTxt" runat="server" CssClass="form-control"></asp:TextBox>

            <!--tipo de producto-->
            <label for="category">Categoría:</label>
            <asp:DropDownList ID="category" runat="server" CssClass="form-control">
                <asp:ListItem Text="Arte" Value="electronica"></asp:ListItem>
                <asp:ListItem Text="Arquitectura" Value="ropa"></asp:ListItem>
                <asp:ListItem Text="Oficina" Value="alimentos"></asp:ListItem>
                <asp:ListItem Text="Educación" Value="educacion"></asp:ListItem>

            </asp:DropDownList>

            <label for="price">Precio de Venta:</label>
            <asp:TextBox ID="price" runat="server" CssClass="form-control"></asp:TextBox>

            <label for="providerPrice">Precio de Venta del Proveedor:</label>
            <asp:TextBox ID="providerPrice" runat="server" CssClass="form-control"></asp:TextBox>    

            <label for="providerTxt">Proveedor:</label>
            <asp:TextBox ID="providerTxt" runat="server" CssClass="form-control"></asp:TextBox>

            <label for="unidades">Unidades:</label>
            <asp:TextBox ID="unidades" runat="server" CssClass="form-control"></asp:TextBox>
            
            <label for="sedeTxt">Sede:</label>
            <asp:TextBox ID="sedeTxt" runat="server" CssClass="form-control"></asp:TextBox>

            <label for="description">Descripción del Producto:</label>
            <asp:TextBox ID="description" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>



        </div>

        <!-- Sección de información -->
        <div class="info-section">
            <h2>Registro Nuevo Producto</h2>
            <img src="Images/producto.png" alt="Icono de seguridad" style="width: 160px;">
            <asp:Button ID="registerButton" runat="server" Text="Registrar" CssClass="register-button" OnClick="lbGuardar_Click"/>
        </div>
    </div>
</asp:Content>
