<%@ Page Title="Sedes" Language="C#" MasterPageFile="~/SoftCyberia.Master" AutoEventWireup="true" CodeBehind="listado_sedes.aspx.cs" Inherits="SoftCyberiaWA.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Sedes
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
     <!-- Encabezado de la Página -->
    <div class="header text-center">
        <h2>Retiro en Tiendas</h2>
        <p>Compra online y retira en tienda</p>
    </div>

    <!-- Mapa de Tiendas -->
    <div class="map-container text-center">
        <img src="Images/mapa-tiendas.png" alt="Mapa de Tiendas ubicadas en la Universidad" style="max-width: 100%; height: auto;">
    </div>

    <!-- Lista de Tiendas -->
    <div class="store-list d-flex justify-content-center flex-wrap mt-4">
        <div class="store border rounded p-3 m-2" style="width: 300px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
            <h5>Tienda Biblioteca Central</h5>
            <p>Dirigido a: Estudiantes, Administrativos, Docentes, Padres de Familia, Egresados, Empresas y organizaciones externas</p>
            <p><strong>LUN - DOM</strong><br>8 am - 10 pm</p>
            <div class="contact-info d-flex justify-content-between align-items-center">
                <img src="Images/whatsapp.png" alt="WhatsApp" style="width: 20px; height: 20px;"> <span>934843731</span>
            </div>
        </div>

        <div class="store border rounded p-3 m-2" style="width: 300px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
            <h5>Tienda Sociales</h5>
            <p>Dirigido a: Estudiantes, Administrativos, Docentes, Padres de Familia, Egresados, Empresas y organizaciones externas</p>
            <p><strong>LUN - DOM</strong><br>8 am - 10 pm</p>
            <div class="contact-info d-flex justify-content-between align-items-center">
                <img src="Images/whatsapp.png" alt="WhatsApp" style="width: 20px; height: 20px;"> <span>934843731</span>
            </div>
        </div>

        <div class="store border rounded p-3 m-2" style="width: 300px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
            <h5>Tienda Arquitectura</h5>
            <p>Dirigido a: Estudiantes, Administrativos, Docentes, Padres de Familia, Egresados, Empresas y organizaciones externas</p>
            <p><strong>LUN - DOM</strong><br>8 am - 10 pm</p>
            <div class="contact-info d-flex justify-content-between align-items-center">
                <img src="Images/whatsapp.png" alt="WhatsApp" style="width: 20px; height: 20px;"> <span>934843731</span>
            </div>
        </div>

        <div class="store border rounded p-3 m-2" style="width: 300px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
            <h5>Tienda Tinkuy</h5>
            <p>Dirigido a: Estudiantes, Administrativos, Docentes, Padres de Familia, Egresados, Empresas y organizaciones externas</p>
            <p><strong>LUN - DOM</strong><br>8 am - 10 pm</p>
            <div class="contact-info d-flex justify-content-between align-items-center">
                <img src="Images/whatsapp.png" alt="WhatsApp" style="width: 20px; height: 20px;"> <span>934843731</span>
            </div>
        </div>

        <div class="store border rounded p-3 m-2" style="width: 300px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
            <h5>Tiendas Generales Ciencias</h5>
            <p>Dirigido a: Estudiantes, Administrativos, Docentes, Padres de Familia, Egresados, Empresas y organizaciones externas</p>
            <p><strong>LUN - DOM</strong><br>8 am - 10 pm</p>
            <div class="contact-info d-flex justify-content-between align-items-center">
               <img src="Images/whatsapp.png" alt="WhatsApp" style="width: 20px; height: 20px;"> <span>934843731</span>
            </div>
        </div>
    </div>
</asp:Content>
