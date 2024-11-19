<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente/SoftCyberiaCliente.Master" AutoEventWireup="true" CodeBehind="listado_sedes.aspx.cs" Inherits="SoftCyberiaWA.listado_sedes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Sedes -
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="/Content/site.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
     
    <!-- Encabezado de la Página -->
    <div class="header text-center">
        <h2 class="font-bold category-title bg-primary bg-opacity-50" style="font-size: 3em;">Retiro en Tiendas</h2>
        <p>Compra online y retira en tienda</p>
    </div>

    <!-- Mapa de Tiendas -->
    <div class="map-container text-center">
        <img src="/Imagenes/mapa-tiendas.png" alt="Mapa de Tiendas ubicadas en la Universidad" style="max-width: 100%; height: auto;">
    </div>

    <!-- Lista de Tiendas usando Repeater -->
    <div class="store-list d-flex justify-content-center flex-wrap mt-4">
        <asp:Repeater ID="repeaterSedes" runat="server">
            <ItemTemplate>
                <a href='<%# Eval("LinkUrl") %>' class="text-decoration-none text-dark">
                    <div class="store border rounded p-3 m-2" style="width: 300px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
                        <h5><%# Eval("Nombre") %></h5>
                        <p><%# Eval("Descripcion") %></p>
                        <p><strong>LUN - VIE</strong><br>
                            <%# Eval("HorarioApertura") %> - <%# Eval("HorarioCierre") %></p>
                        <div class="contact-info d-flex justify-content-between align-items-center">
                            <img src="/Imagenes/whatsapp.png" alt="WhatsApp" style="width: 20px; height: 20px;">
                            <span><%# Eval("Telefono") %></span>
                        </div>
                    </div>
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div class="store-list d-flex justify-content-center flex-wrap mt-4">
        <asp:PlaceHolder ID="storeList" runat="server"></asp:PlaceHolder>
    </div>

</asp:Content>
