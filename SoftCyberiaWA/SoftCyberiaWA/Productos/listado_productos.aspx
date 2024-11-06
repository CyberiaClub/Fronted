﻿<%@ Page Title="Productos" Language="C#" MasterPageFile="~/SoftCyberia.Master" AutoEventWireup="true" CodeBehind="listado_productos.aspx.cs" Inherits="SoftCyberiaWA.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Productos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="Content/siteProductos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="container mt-5">

        <!-- Pop-up de información de sedes -->
        <div class="popup-overlay" id="popup" style="display: none;">
            <div class="popup-content">
                <h2 style="color: var(--primary-color);">Información de Sedes</h2>
                <button class="popup-close" onclick="closePopup()">×</button>

                <div class="sede-info">
                    <h3 style="color: var(--secondary-color1);">Tienda Biblioteca Central</h3>
                    <p>Ubicado cerca al pabellón Z</p>
                    <p><strong>LUN - VIE:</strong> 8 am - 8 pm</p>
                    <p>WhatsApp: 934843731</p>

                    <h3 style="color: var(--secondary-color1);">Tienda Sociales</h3>
                    <p>Ubicado en el pabellón J</p>
                    <p><strong>LUN - VIE:</strong> 8 am - 8 pm</p>
                    <p>WhatsApp: 934843731</p>

                    <h3 style="color: var(--secondary-color1);">Tienda Arquitectura</h3>
                    <p>Ubicado en el pabellón T</p>
                    <p><strong>LUN - VIE:</strong> 8 am - 8 pm</p>
                    <p>WhatsApp: 934843731</p>

                    <h3 style="color: var(--secondary-color1);">Tienda Mc Gregor</h3>
                    <p>Ubicado en el pabellón N</p>
                    <p><strong>LUN - VIE:</strong> 8 am - 8 pm</p>
                    <p>WhatsApp: 934843731</p>

                    <h3 style="color: var(--secondary-color1);">Tiendas Generales Ciencias</h3>
                    <p>Ubicado en el pabellón E</p>
                    <p><strong>LUN - VIE:</strong> 8 am - 8 pm</p>
                    <p>WhatsApp: 934843731</p>
                </div>
            </div>
        </div>




        <!-- Filtros -->
        <div class="row">
            <div class="col-md-3">
                <h5>Filtros</h5>

                <!-- Sedes -->
                <h6 class="mt-3">Sedes</h6>
                <div class="form-check">
                    <input class="form-check-input" type="radio" name="sede" value="BibliotecaCentral" id="sedeBibliotecaCentral" required onchange="applyFilters()">
                    <label class="form-check-label" for="sedeBibliotecaCentral">Tienda Biblioteca Central</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="radio" name="sede" value="Sociales" id="sedeSociales" onchange="applyFilters()">
                    <label class="form-check-label" for="sedeSociales">Tienda Sociales</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="radio" name="sede" value="Arquitectura" id="sedeArquitectura" onchange="applyFilters()">
                    <label class="form-check-label" for="sedeArquitectura">Tienda Arquitectura</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="radio" name="sede" value="McGregor" id="sedeMcGregor" onchange="applyFilters()">
                    <label class="form-check-label" for="sedeMcGregor">Tienda Mc Gregor</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="radio" name="sede" value="GeneralesCiencias" id="sedeGeneralesCiencias" onchange="applyFilters()">
                    <label class="form-check-label" for="sedeGeneralesCiencias">Tiendas Generales Ciencias</label>
                </div>






                <!-- Rango de precios -->
                <label for="priceRange">Precio: S/<span id="priceValue">500</span></label>
                <input type="range" id="priceRange" min="0" max="500" value="500" class="form-range" oninput="applyFilters()">

                <!-- Categorías -->
                <h6 class="mt-3">Categoría</h6>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="Arquitectura" id="catArquitectura" onchange="applyFilters()">
                    <label class="form-check-label" for="catArquitectura">Arquitectura</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="Arte" id="catArtes" onchange="applyFilters()">
                    <label class="form-check-label" for="catArtes">Artes</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="Educación" id="catEducación" onchange="applyFilters()">
                    <label class="form-check-label" for="catEducación">Educación</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="Oficina" id="catOficina" onchange="applyFilters()">
                    <label class="form-check-label" for="catOficina">Oficina</label>
                </div>
                <!-- Marcas -->
                <h6 class="mt-5 ">Marca</h6>
                <p>Cargando Marcas...</p>


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
                    <p id="loading-message">Cargando productos...</p>
                    
                    <asp:Panel ID="productContainer" runat="server" CssClass="row">
                <p id="loading-message">Cargando productos...</p>
            </asp:Panel>

                    <!-- Producto 1 -->
                    <div class="col-md-4 mb-4" data-category="Arquitectura" data-price="146.40">
                        <a href="detalle_producto3.aspx" class="text-decoration-none">
                            <div class="card">
                                <img src="/Imagenes/lapiz-grafito.jpg" class="card-img-top" alt="Lápiz grafito Staedtler">
                                <div class="card-body">
                                    <h6 class="card-title">Lápiz grafito Staedtler x 24</h6>
                                    <p class="card-text">S/146.40</p>
                                </div>
                            </div>
                        </a>
                    </div>

                    <!-- Producto 2 -->
                    <div class="col-md-4 mb-4" data-category="Oficina" data-price="81.50">
                        <a href="detalle_producto3.aspx" class="text-decoration-none">
                            <div class="card">
                                <img src="/Imagenes/papeles.jpg" class="card-img-top" alt="Hojas A4">
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
                                <img src="/Imagenes/canva.jpg" class="card-img-top" alt="Canva Staedtler">
                                <div class="card-body">
                                    <h6 class="card-title">Lienzo 50X60 Cm Conda</h6>
                                    <p class="card-text">S/50.70</p>
                                </div>
                            </div>
                        </a>
                    </div>

                    <!-- Producto 4 -->
                    <div class="col-md-4 mb-4" data-category="Arte" data-price="36.70">
                        <a href="detalle_producto.aspx" class="text-decoration-none">
                            <div class="card">
                                <img src="/Imagenes/pinturas.jpg" class="card-img-top" alt="Studio Acrylics">
                                <div class="card-body">
                                    <h6 class="card-title">Set de acrilicos 10X20 ml tubos</h6>
                                    <p class="card-text">S/36.70</p>
                                </div>
                            </div>
                        </a>
                    </div>



                    <!-- Producto 9 -->
                    <div class="col-md-4 mb-4" data-category="Oficina" data-price="18.50">
                        <a href="detalle_producto5.aspx" class="text-decoration-none">
                            <div class="card">
                                <img src="/Imagenes/libreta.jpg" class="card-img-top" alt="Libreta de Notas">
                                <div class="card-body">
                                    <h6 class="card-title">Libreta de Notas A5 con Tapa Dura</h6>
                                    <p class="card-text">S/18.50</p>
                                </div>
                            </div>
                        </a>
                    </div>

                    <!-- Producto 10 -->
                    <div class="col-md-4 mb-4" data-category="Dibujo" data-price="45.00">
                        <a href="detalle_producto6.aspx" class="text-decoration-none">
                            <div class="card">
                                <img src="/Imagenes/lapices_dibujo.jpg" class="card-img-top" alt="Set de Lápices de Dibujo">
                                <div class="card-body">
                                    <h6 class="card-title">Set de Lápices de Dibujo 12 Piezas</h6>
                                    <p class="card-text">S/45.00</p>
                                </div>
                            </div>
                        </a>
                    </div>
                    <!-- Producto 12 -->
                    <div class="col-md-4 mb-4" data-category="Oficina" data-price="32.40">
                        <a href="detalle_producto7.aspx" class="text-decoration-none">
                            <div class="card">
                                <img src="/Imagenes/kit_escritorio.jpg" class="card-img-top" alt="Kit de Oficina">
                                <div class="card-body">
                                    <h6 class="card-title">Kit de Oficina Completo</h6>
                                    <p class="card-text">S/32.40</p>
                                </div>
                            </div>
                        </a>
                    </div>
                    <!-- Producto 14 -->
                    <div class="col-md-4 mb-4" data-category="Material de Arte" data-price="15.00">
                        <a href="detalle_producto8.aspx" class="text-decoration-none">
                            <div class="card">
                                <img src="/Imagenes/cartulinas.jpg" class="card-img-top" alt="Pack de Cartulinas de Colores">
                                <div class="card-body">
                                    <h6 class="card-title">Pack de Cartulinas de Colores (10 unidades)</h6>
                                    <p class="card-text">S/15.00</p>
                                </div>
                            </div>
                        </a>
                    </div>




                </div>
            </div>
        </div>
    </div>

    
    <script src="/Scripts/filtrar_listado_productos.js"></script>

</asp:Content>