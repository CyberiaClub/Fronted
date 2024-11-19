<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/SoftCyberiaAdministrador.Master" AutoEventWireup="true" CodeBehind="asignar_oferta.aspx.cs" Inherits="SoftCyberiaWA.Administrador.asignar_oferta" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Asignar Oferta
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteadmi.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex justify-content-center align-items-center vh-200">
        <div class="card" style="width: 100%; max-width: 800px; color: midnightblue">
            <div class="card-header text-center" style="width: 800px">
                <h2>Asignar Oferta de Producto</h2>
            </div>
            <div class="card-body pb-2">
                <div class="row">
                    <!-- Columna de información de la oferta -->
                    <div class="col-md-8">
                        <div class="pb-3">
                            <asp:Label ID="lblSku" runat="server" Text="SKU del Producto:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="sku" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="pb-3">
                            <asp:Label ID="lblPorcentajeOferta" runat="server" Text="Porcentaje de Oferta:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="porcentajeOferta" runat="server" MinimumValue="0" Min="0" Max="100" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                        <div class="pb-3">
                            <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha de Inicio de la Oferta:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="fechaInicio" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="pb-3">
                            <asp:Label ID="lblFechaFin" runat="server" Text="Fecha de Fin de la Oferta:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="fechaFin" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>

                    <!-- Columna de botón de asignación -->
                    <div class="col-md-4 d-flex flex-column align-items-center justify-content-center bg-light" style="border-radius: 0 15px 15px 0;">
                        <h4 class="font-weight-bold mb-4" style="color: #004EA8;">Asignar Oferta</h4>

                        <asp:Label ID="lblImage" runat="server" Text="Imagen del Producto:" CssClass="col-form-label fw-bold"></asp:Label>
                        <img src="/Imagenes/oferta.png" alt="Icono de oferta" class="img-fluid img-thumbnail mb-3" style="width: 160px;">
                        <asp:FileUpload ID="fileUploadProductImage" CssClass="form-control mb-2" runat="server" />

                        <asp:Button ID="btnAsignarOferta" runat="server" Text="Asignar Oferta" CssClass="btn btn-primary mt-4" Style="background-color: #004EA8; border-color: #004EA8;" OnClick="btnAsignarOferta_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
