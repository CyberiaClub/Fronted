<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/SoftCyberiaAdministrador.Master" AutoEventWireup="true" CodeBehind="detalle_reporte.aspx.cs" Inherits="SoftCyberiaWA.Administrador.Detalle_reporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Reporte
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteadmi.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="d-flex justify-content-center align-items-center vh-200" style="color: slategrey">
        <div class="card" style="width: 100%; max-width: 900px; color: midnightblue">
            <div class="card-header text-center" style="width: 900px">
                <h2>
                    <asp:Label ID="lblTitulo" runat="server" Text="Reporte"></asp:Label>
                </h2>
            </div>



            <div class="card-body align-content-xxl-center align-content-center" style="font: medium">

                <div class="d-flex card-body" style="width: 150%">
                    <div class="mb-0" style="width: 100%">
                        <asp:Label ID="lblsedeNombre" runat="server" Text="Seleccione la Sede a generar el reporte:" CssClass="col-form-label fw-bold "></asp:Label>
                        <asp:DropDownList ID="sedeNombre" runat="server" CssClass="form-control h-30" Width="500px"></asp:DropDownList>
                        <small id="sedeNombreMensaje" class="form-text text-danger" runat="server"></small>
                    </div>
                </div>

                <div class="d-flex card-body" style="width: 150%">
                    <div style="width: 200%">
                        <h5>Reporte de Stock de Productos</h5>
                    </div>
                    <div class="d-flex" style="width: 250%">
                        <asp:Button ID="btnBuscar" target="_blank" runat="server" Text="Generar Reporte" CssClass="btn btn-primary mr-20 w-25" Style="background-color: #004EA8; border-color: #004EA8;" OnClick="BtnBuscar_Click" />
                        <asp:Label ID="reporteStock" runat="server" CssClass="text-success" Visible="false"></asp:Label>
                    </div>
                </div>

                <div class="d-flex card-body" style="width: 150%">
                    <div style="width: 200%">
                        <h5>Reporte de Top Clientes</h5>
                    </div>
                    <div class="d-flex" style="width: 250%">
                        <asp:Button ID="btnTop" target="_blank" runat="server" Text="Generar Reporte" CssClass="btn btn-primary mr-20 w-25" Style="background-color: #004EA8; border-color: #004EA8;" OnClick="BtnTop_Click" />
                        <asp:Label ID="Label1" runat="server" CssClass="text-success" Visible="false"></asp:Label>
                    </div>
                </div>





            </div>
        </div>
    </div>
</asp:Content>
