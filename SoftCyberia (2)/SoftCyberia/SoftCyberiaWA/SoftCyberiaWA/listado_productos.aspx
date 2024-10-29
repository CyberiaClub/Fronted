<%@ Page Title="Productos" Language="C#" MasterPageFile="~/SoftCyberia.Master" AutoEventWireup="true" CodeBehind="listado_productos.aspx.cs" Inherits="SoftCyberiaWA.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Productos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="container mt-5">
        <!-- Filtros -->
        <div class="row">
            <div class="col-md-3">
                <h5>Filtros</h5>
                <!-- Rango de precios -->
                <label for="priceRange">Precio: S/<span id="priceValue">0</span></label>
                <input type="range" id="priceRange" min="0" max="300" class="form-range" oninput="applyFilters()">
                
                <!-- Categorías -->
                <h6 class="mt-3">Categoría</h6>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="Arquitectura" id="catArquitectura" onchange="applyFilters()">
                    <label class="form-check-label" for="catArquitectura">Arquitectura</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="Artes" id="catArtes" onchange="applyFilters()">
                    <label class="form-check-label" for="catArtes">Artes</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="Diseño" id="catDiseño" onchange="applyFilters()">
                    <label class="form-check-label" for="catDiseño">Diseño</label>
                </div>

                <!-- Marcas -->
                <h6 class="mt-3">Marca</h6>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="Faber-Castell" id="marcaFaber">
                    <label class="form-check-label" for="marcaFaber">Faber-Castell</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="Winsor & Newton" id="marcaWinsor">
                    <label class="form-check-label" for="marcaWinsor">Winsor & Newton</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="Staedtler" id="marcaStaedtler">
                    <label class="form-check-label" for="marcaStaedtler">Staedtler</label>
                </div>

            </div>

            <!-- Listado de Productos -->
            <div class="col-md-9">
                <div class="row" id="product-list">
                    <!-- Producto 1 -->
                    <div class="col-md-4 mb-4" data-category="Arquitectura" data-price="146.40">
                        <a href="detalle_producto3.aspx" class="text-decoration-none">
                            <div class="card">
                                <img src="/Images/lapiz-grafito.jpg" class="card-img-top" alt="Lápiz grafito Staedtler">
                                <div class="card-body">
                                    <h6 class="card-title">Lápiz grafito Staedtler x 24</h6>
                                    <p class="card-text">S/146.40</p>
                                </div>
                            </div>
                        </a>
                    </div>

                    <!-- Producto 2 -->
                    <div class="col-md-4 mb-4" data-category="Artes" data-price="81.50">
                        <a href="detalle_producto3.aspx" class="text-decoration-none">
                            <div class="card">
                                <img src="/Images/papeles.jpg" class="card-img-top" alt="Hojas A4">
                                <div class="card-body">
                                    <h6 class="card-title">Papel Adhesivo Blanco Brillante 180 G A4 100 Hojas</h6>
                                    <p class="card-text">S/81.50</p>
                                </div>
                            </div>
                        </a>
                    </div>

                    <!-- Producto 3 -->
                    <div class="col-md-4 mb-4" data-category="Arquitectura" data-price="50.70">
                        <a href="detalle_producto2.aspx" class="text-decoration-none">
                            <div class="card">
                                <img src="/Images/canva.jpg" class="card-img-top" alt="Canva Staedtler">
                                <div class="card-body">
                                    <h6 class="card-title">Lienzo 50X60 Cm Conda</h6>
                                    <p class="card-text">S/50.70</p>
                                </div>
                            </div>
                        </a>
                    </div>

                    <!-- Producto 4 -->
                    <div class="col-md-4 mb-4" data-category="Diseño" data-price="36.70">
                        <a href="detalle_producto.aspx" class="text-decoration-none">
                            <div class="card">
                                <img src="/Images/pinturas.jpg" class="card-img-top" alt="Studio Acrylics">
                                <div class="card-body">
                                    <h6 class="card-title">Set de acrilicos 10X20 ml tubos</h6>
                                    <p class="card-text">S/36.70</p>
                                </div>
                            </div>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="Scripts/filtrar_listado_productos.js"></script>

</asp:Content>
