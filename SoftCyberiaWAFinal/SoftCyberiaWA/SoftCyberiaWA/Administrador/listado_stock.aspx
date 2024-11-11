<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/SoftCyberiaAdministrador.Master" AutoEventWireup="true" CodeBehind="listado_stock.aspx.cs" Inherits="SoftCyberiaWA.Administrador.listado_stock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     Stock de Producto Por Sede
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteadmi.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center align-items-center vh-200" style="color: slategrey">
        <div class="card" style="width: 100%; max-width: 900px; color: midnightblue">
            <div class="card-header text-center" style="width: 900px">
                <h2>
                    <asp:Label ID="lblTitulo" runat="server" Text="Stock de Productos por Sede"></asp:Label>
                </h2>
            </div>



            <div class="card-body align-content-xxl-center align-content-center" style="font: medium">
                <div class="row">

                    <div class="col-md-6 ">
                        <div class="col-md-10">
                            <label for="categoriaName">Buscar por SKU:</label>
                            <input type="text" id="sku" name="sku" placeholder="Ingresa SKU">
                        </div>
                    </div>

                    <div class="col-md-6 ">
                        <div class="col-md-10">
                            <asp:Button ID="Button1" runat="server" Text="buscar" CssClass="btn btn-primary w-75 align-content-sm-center" OnClick="Button2_Click" />
                        </div>

                    </div>


                    <div>
                        aaaaaaa
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
