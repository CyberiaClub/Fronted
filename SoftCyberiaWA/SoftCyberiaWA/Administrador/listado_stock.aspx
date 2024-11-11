<%@ Page Title="Asignar Rol" Language="C#" MasterPageFile="~/SoftCyberiaAdmi.Master" AutoEventWireup="true" CodeBehind="listado_stock.aspx.cs" Inherits="SoftCyberiaWA.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphStyle" runat="server">
        <link href="../Content/siteadmi.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitulo" runat="server">
    Stock de Producto Por Sede
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
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
                            <label for="categoriaName">Buscar por Nombre:</label>
                            <input type="text" id="nombre" name="nombre" placeholder="Ingresa Nombre">
                        </div>

                    </div>

                    <div>
                        <p> </p>
                        <asp:Button ID="Button2" runat="server" Text="buscar" CssClass="btn btn-primary w-75 align-content-sm-center" />

                    </div>

                    <div>   
                        aaaaaaa
                    </div>

                </div>
            </div>
        </div>
    </div>




</asp:Content>


