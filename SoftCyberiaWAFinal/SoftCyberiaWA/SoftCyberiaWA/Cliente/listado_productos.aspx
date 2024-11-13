<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente/SoftCyberiaCliente.Master" AutoEventWireup="true" CodeBehind="listado_productos.aspx.cs" Inherits="SoftCyberiaWA.listado_productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <asp:Panel ID="filtrosSedes" runat="server">
                <%--<div class="form-check">
                    <input class="form-check-input" type="checkbox" name="sede" value="BibliotecaCentral" id="sedeBibliotecaCentral" onclick="selectOnlyOne(this)" data-sede="BibliotecaCentral">
                    <label class="form-check-label" for="sedeBibliotecaCentral">Tienda Biblioteca Central</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" name="sede" value="Sociales" id="sedeSociales" onclick="selectOnlyOne(this)" data-sede="Sociales">
                    <label class="form-check-label" for="sedeSociales">Tienda Sociales</label>
                </div>

                <div class="form-check">
                    <input class="form-check-input" type="checkbox" name="sede" value="Arquitectura" id="sedeArquitectura" onclick="selectOnlyOne(this)" data-sede="Arquitectura">
                    <label class="form-check-label" for="sedeArquitectura">Tienda Arquitectura</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" name="sede" value="McGregor" id="sedeMcGregor" onclick="selectOnlyOne(this)" data-sede="McGregor">
                    <label class="form-check-label" for="sedeMcGregor">Tienda Mc Gregor</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" name="sede" value="GeneralesCiencias" id="sedeGeneralesCiencias" onclick="selectOnlyOne(this)" data-sede="GeneralesCiencias">
                    <label class="form-check-label" for="sedeGeneralesCiencias">Tiendas Generales Ciencias</label>
                </div>--%>
                </asp:Panel>


                <!-- Rango de precios -->
                <label for="priceRange">Precio: S/<span id="priceValue">500</span></label>
                <input type="range" id="priceRange" min="0" max="500" value="500" class="form-range" oninput="applyFilters()">

                <!-- Categorías -->
                <h6 class="mt-3">Categoría</h6>
                <asp:Panel ID="filtrosTipoProducto" runat="server" CssClass="overflow-auto p-2" style="max-height: 200px;">
                    <div class="form-check">
                        <input class="form-check-input" type="checkbox" name="categoria" value="Arquitectura" id="catArquitectura" onchange="applyFilters()" data-categoria="Arquitectura">
                        <label class="form-check-label" for="catArquitectura">Arquitectura</label>
                    </div>
                    <div class="form-check">
                        <input class="form-check-input" type="checkbox" name="categoria" value="Arte" id="catArtes" onchange="applyFilters()" data-categoria="Arte">
                        <label class="form-check-label" for="catArtes">Artes</label>
                    </div>


                    <div class="form-check">
                        <input class="form-check-input" type="checkbox" name="categoria" value="Educación" id="catEducación" onchange="applyFilters()" data-categoria="Educación">
                        <label class="form-check-label" for="catEducación">Educación</label>
                    </div>
                    <div class="form-check">
                        <input class="form-check-input" type="checkbox" name="categoria" value="Oficina" id="catOficina" onchange="applyFilters()" data-categoria="Oficina">
                        <label class="form-check-label" for="catOficina">Oficina</label>
                    </div>
                </asp:Panel>
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

                    <div class="col-md-9">

                        <asp:Panel ID="productContainer" runat="server" CssClass="row">
                            <p id="loading-message">Cargando productos...</p>
                            <div class="col-md-4 mb-4" data-sede="Sociales" data-category="Arquitectura" data-price="146.40">
                                <a href="detalle_producto2.aspx" class="text-decoration-none">
                                    <div class="card">
                                        <div class="card-img-container">
                                            <img src="/Imagenes/lapiz-grafito.jpg" class="card-img-top" alt="Lápiz grafito Staedtler">
                                        </div>
                                        <div class="card-body">
                                            <h6 class="card-title">Lápiz grafito Staedtler x 24</h6>
                                            <p class="card-text">S/146.40</p>
                                        </div>
                                    </div>
                                </a>
                            </div>

                            <!-- Producto 2 sede=Tienda_Sociales&idSede=2-->
                            <div class="col-md-4 mb-4" data-sede="Sociales" data-category="Oficina" data-price="81.50">
                                <a href="detalle_producto2.aspx" class="text-decoration-none">
                                    <div class="card">
                                        <div class="card-img-container">
                                            <img src="/Imagenes/papeles.jpg" class="card-img-top" alt="Hojas A4">
                                        </div>
                                        <div class="card-body">
                                            <h6 class="card-title">Papel Adhesivo Blanco Brillante 180 G A4 100 Hojas</h6>
                                            <p class="card-text">S/81.50</p>
                                        </div>
                                    </div>
                                </a>
                            </div>

                            <!-- Producto 3 -->
                            <div class="col-md-4 mb-4" data-sede="Arquitectura" data-category="Arquitectura" data-price="50.70">
                                <a href="detalle_producto2.aspx" class="text-decoration-none">
                                    <div class="card">
                                        <div class="card-img-container">
                                            <img src="/Imagenes/canva.jpg" class="card-img-top" alt="Canva Staedtler">
                                        </div>
                                        <div class="card-body">
                                            <h6 class="card-title">Lienzo 50X60 Cm Conda</h6>
                                            <p class="card-text">S/50.70</p>
                                        </div>
                                    </div>
                                </a>
                            </div>

                            <!-- Producto 4 -->
                            <div class="col-md-4 mb-4" data-sede="BibliotecaCentral" data-category="Arte" data-price="36.70">
                                <a href="detalle_producto2.aspx" class="text-decoration-none">
                                    <div class="card">
                                        <div class="card-img-container">
                                            <img src="/Imagenes/pinturas.jpg" class="card-img-top" alt="Studio Acrylics">
                                        </div>
                                        <div class="card-body">
                                            <h6 class="card-title">Set de acrilicos 10X20 ml tubos</h6>
                                            <p class="card-text">S/36.70</p>
                                        </div>
                                    </div>
                                </a>
                            </div>



                            <!-- Producto 9 -->
                            <div class="col-md-4 mb-4" data-sede="BibliotecaCentral"  data-category="Oficina" data-price="18.50">
                                <a href="detalle_producto2.aspx" class="text-decoration-none">
                                    <div class="card">
                                        <div class="card-img-container">
                                            <img src="/Imagenes/libreta.jpg" class="card-img-top" alt="Libreta de Notas">
                                        </div>
                                       
                                        <div class="card-body">
                                            <h6 class="card-title">Libreta de Notas A5 con Tapa Dura</h6>
                                            <p class="card-text">S/18.50</p>
                                        </div>
                                    </div>
                                </a>
                            </div>

                            <!-- Producto 10 -->
                            <div class="col-md-4 mb-4" data-sede="BibliotecaCentral"  data-category="Oficina" data-price="45.00">
                                <a href="detalle_producto2.aspx" class="text-decoration-none">
                                    <div class="card">
                                        <div class="card-img-container">
                                            <img src="/Imagenes/lapices_dibujo.jpg" class="card-img-top" alt="Set de Lápices de Dibujo">
                                        </div>
                                        <div class="card-body">
                                            <h6 class="card-title">Set de Lápices de Dibujo 12 Piezas</h6>
                                            <p class="card-text">S/45.00</p>
                                        </div>
                                    </div>
                                </a>
                            </div>
                            <!-- Producto 12 -->
                            <div class="col-md-4 mb-4" data-sede="BibliotecaCentral"  data-category="Oficina" data-price="32.40">
                                <a href="detalle_producto2.aspx" class="text-decoration-none">
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
                            <div class="col-md-4 mb-4" data-sede="BibliotecaCentral"  data-category="Educación" data-price="15.00">
                                <a href="detalle_producto2.aspx" class="text-decoration-none">
                                    <div class="card">
                                        <img src="/Imagenes/cartulinas.jpg" class="card-img-top" alt="Pack de Cartulinas de Colores">
                                        <div class="card-body">
                                            <h6 class="card-title">Pack de Cartulinas de Colores (10 unidades)</h6>
                                            <p class="card-text">S/15.00</p>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </asp:Panel>
                    </div>




                    <!-- Producto 9 -->
                    <div class="col-md-4 mb-4" data-sede="BibliotecaCentral"  data-category="Oficina" data-price="18.50">
                        <a href="detalle_producto2.aspx" class="text-decoration-none">
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
                    <div class="col-md-4 mb-4" data-sede="BibliotecaCentral"  data-category="Oficina" data-price="45.00">
                        <a href="detalle_producto2.aspx" class="text-decoration-none">
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
                    <div class="col-md-4 mb-4" data-sede="BibliotecaCentral"  data-category="Oficina" data-price="32.40">
                        <a href="detalle_producto2.aspx" class="text-decoration-none">
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
                    <div class="col-md-4 mb-4" data-sede="BibliotecaCentral"  data-category="Educación" data-price="15.00">
                        <a href="detalle_producto2.aspx" class="text-decoration-none">
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


