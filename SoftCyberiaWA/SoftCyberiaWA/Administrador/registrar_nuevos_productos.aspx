<%@ Page Title="" Language="C#" MasterPageFile="~/SoftCyberiaAdmi.Master" AutoEventWireup="true" CodeBehind="registrar_nuevos_productos.aspx.cs" Inherits="SoftCyberiaWA.registrarNuevosProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphStyle" runat="server">
     <link href="../Content/siteadmi.css" rel="stylesheet" />
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
            <img src="/Imagenes/producto.png" alt="Icono de seguridad" style="width: 160px;">
            <asp:Button ID="registerButton" runat="server" Text="Registrar" CssClass="register-button" OnClick="lbGuardar_Click"/>
        </div>
    </div>
</asp:Content>
