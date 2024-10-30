<%@ Page Title="" Language="C#" MasterPageFile="~/SoftCyberiaAdmi.Master" AutoEventWireup="true" CodeBehind="registrar_nuevos_proveedores.aspx.cs" Inherits="SoftCyberiaWA.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphStyle" runat="server">
    <!-- Agregar aquí estilos específicos para esta página si es necesario -->
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
        .form-section input[type="email"],
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
            <label for="providerRUC">RUC del Proveedor:</label>
            <asp:TextBox ID="providerRUC" runat="server" CssClass="form-control"></asp:TextBox>

            <label for="providerName">Nombre del Proveedor:</label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>


            <label for="phone">Teléfono:</label>
            <asp:TextBox ID="phone" runat="server" CssClass="form-control"></asp:TextBox>

            <label for="email">Correo Electrónico:</label>
            <asp:TextBox ID="email" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>

            <label for="address">Dirección:</label>
            <asp:TextBox ID="address" runat="server" CssClass="form-control"></asp:TextBox>


            <label for="paymentMethod">Método de Pago:</label>
            <asp:DropDownList ID="paymentMethod" runat="server" CssClass="form-control">
                <asp:ListItem Text="Transferencia Bancaria" Value="transferencia"></asp:ListItem>
                <asp:ListItem Text="Tarjeta de Debito" Value="tarjeta"></asp:ListItem>
                <asp:ListItem Text="Efectivo" Value="efectivo"></asp:ListItem>
            </asp:DropDownList>

            <label for="products">Producto que Suministra:</label>
            <asp:TextBox ID="products" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
            
            <label for="precioProducto">Precio de Producto:</label>
            <asp:TextBox ID="precioProducto" runat="server" CssClass="form-control"></asp:TextBox>

        </div>

        <!-- Sección de información -->
        <div class="info-section">
            <h2>Nuevo Proveedor</h2>
            <img src="Images/proveedor.png" alt="Icono de seguridad" style="width: 160px;">
            <p> </p>
            <p> </p>

            <asp:Button ID="registerButton" runat="server" Text="Registrar" CssClass="register-button" />
        </div>
    </div>
</asp:Content>

