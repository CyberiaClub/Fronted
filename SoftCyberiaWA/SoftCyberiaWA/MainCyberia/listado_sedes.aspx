<%@ Page Title="Sedes" Language="C#" MasterPageFile="~/SoftCyberia.Master" AutoEventWireup="true" CodeBehind="listado_sedes.aspx.cs" Inherits="SoftCyberiaWA.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Sedes
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
          <link href="/Content/site.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
     <!-- Encabezado de la Página -->
    <div class="header text-center" >
        <h2  class="font-bold category-title bg-primary bg-opacity-50 " style="font-size: 3em;">Retiro en Tiendas</h2>
        <p>Compra online y retira en tienda</p>
    </div>

    <!-- Mapa de Tiendas -->
    <div class="map-container text-center">
        <img src="/Imagenes/mapa-tiendas.png" alt="Mapa de Tiendas ubicadas en la Universidad" style="max-width: 100%; height: auto;">
    </div>

    <!-- Lista de Tiendas -->
    <div class="store-list d-flex justify-content-center flex-wrap mt-4">
        <a href="../Productos/listado_productos.aspx?sede=BibliotecaCentral" class="text-decoration-none  text-dark">
            <div class="store border rounded p-3 m-2" style="width: 300px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
                <h5 class="font-regular">Tienda Biblioteca Central</h5>
                <p>Ubicado cerca al pabellón Z</p>
                <p><strong>LUN - VIE</strong><br>
                    8 am - 8 pm</p>
                <div class="contact-info d-flex justify-content-between align-items-center">
                    <img src="/Imagenes/whatsapp.png" alt="WhatsApp" style="width: 20px; height: 20px;">
                    <span>934843731</span>
                </div>
            </div>
        </a>

        <a href="../Productos/listado_productos.aspx?sede=Sociales" class="text-decoration-none  text-dark">
            <div class="store border rounded p-3 m-2" style="width: 300px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
                <h5>Tienda Sociales</h5>
                <p>Ubicado en el pabellón J</p>
                <p><strong>LUN - VIE</strong><br>
                    8 am - 8 pm</p>
                <div class="contact-info d-flex justify-content-between align-items-center">
                    <img src="/Imagenes/whatsapp.png" alt="WhatsApp" style="width: 20px; height: 20px;">
                    <span>934843731</span>
                </div>
            </div>
        </a>

        <a href="../Productos/listado_productos.aspx?sede=Arquitectura" class="text-decoration-none  text-dark">
            <div class="store border rounded p-3 m-2" style="width: 300px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
                <h5>Tienda Arquitectura</h5>
                <p>Ubicado en el pabellón T</p>
                <p><strong>LUN - VIE</strong><br>
                    8 am - 8 pm</p>
                <div class="contact-info d-flex justify-content-between align-items-center">
                    <img src="/Imagenes/whatsapp.png" alt="WhatsApp" style="width: 20px; height: 20px;">
                    <span>934843731</span>
                </div>
            </div>
        </a>

        <a href="../Productos/listado_productos.aspx?sede=McGregor" class="text-decoration-none  text-dark">
            <div class="store border rounded p-3 m-2" style="width: 300px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
                <h5>Tienda Mc Gregor</h5>
                <p>Ubicado en el pabellón N</p>
                <p><strong>LUN - VIE</strong><br>
                    8 am - 8 pm</p>
                <div class="contact-info d-flex justify-content-between align-items-center">
                    <img src="/Imagenes/whatsapp.png" alt="WhatsApp" style="width: 20px; height: 20px;">
                    <span>934843731</span>
                </div>
            </div>
        </a>

        <a href="../Productos/listado_productos.aspx?sede=GeneralesCiencias" class="text-decoration-none  text-dark">
            <div class="store border rounded p-3 m-2" style="width: 300px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
                <h5>Tiendas Generales Ciencias</h5>
                <p>Ubicado en el pabellón E</p>
                <p><strong>LUN - VIE</strong><br>
                    8 am - 8 pm</p>
                <div class="contact-info d-flex justify-content-between align-items-center">
                    <img src="/Imagenes/whatsapp.png" alt="WhatsApp" style="width: 20px; height: 20px;">
                    <span>934843731</span>
                </div>
            </div>
        </a>
    </div>

</asp:Content>
