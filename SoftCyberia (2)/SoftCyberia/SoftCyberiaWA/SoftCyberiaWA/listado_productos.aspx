<%@ Page Title="Productos" Language="C#" MasterPageFile="~/SoftCyberia.Master" AutoEventWireup="true" CodeBehind="listado_productos.aspx.cs" Inherits="SoftCyberiaWA.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Productos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <!-- Filtros -->
        <div class="row">
            <div class="col-md-3">
                <h5>Filtros</h5>
                <!-- Rango de precios -->
                <label for="priceRange">Precio: S/<span id="priceValue">0</span></label>
                <input type="range" id="priceRange" min="0" max="300" class="form-range" oninput="updatePriceValue()">

                <script>
                    function updatePriceValue() {
                        // Obtiene el valor actual del rango
                        const priceRange = document.getElementById("priceRange");
                        const priceValue = document.getElementById("priceValue");

                        // Actualiza el valor del precio seleccionado en el span
                        priceValue.textContent = priceRange.value;
                    }
                </script>
                <!-- Categorías -->
                <h6 class="mt-3">Categoría</h6>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="Arquitectura" id="catArquitectura">
                    <label class="form-check-label" for="catArquitectura">Arquitectura</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="Artes" id="catArtes">
                    <label class="form-check-label" for="catArtes">Artes</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="Diseño" id="catDiseño">
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
                <div class="row">
                    <!-- Producto 1 -->
                    <div class="col-md-4 mb-4">
                        <div class="card">
                            <img src="/Images/lapiz.jpg" class="card-img-top" alt="Lápiz para dibujo Staedtler">
                            <div class="card-body">
                                <h6 class="card-title">Lápiz para dibujo profesional Staedtler x 24</h6>
                                <p class="card-text">S/2.9</p>
                            </div>
                        </div>
                    </div>

                    <!-- Producto 2 -->
                    <div class="col-md-4 mb-4">
                        <div class="card">
                            <img src="/Images/papeles.jpg" class="card-img-top" alt="Hojas A4">
                            <div class="card-body">
                                <h6 class="card-title">Hojas para impresión tamaño A47</h6>
                                <p class="card-text">S/17.50</p>
                            </div>
                        </div>
                    </div>

                    <!-- Producto 3 -->
                    <div class="col-md-4 mb-4">
                        <div class="card">
                            <img src="/Images/canva.jpg" class="card-img-top" alt="Canva Staedtler">
                            <div class="card-body">
                                <h6 class="card-title">Lienzo 50X60 Cm Conda</h6>
                                <p class="card-text">S/50.70</p>
                            </div>
                        </div>
                    </div>
                                        
                    <!-- Producto 4-->
                    <div class="col-md-4 mb-4">
                        <div class="card">
                            <img src="/Images/pinturas.jpg" class="card-img-top" alt="Studio Acrylics">
                            <div class="card-body">
                                <h6 class="card-title">Set de acrilicos  10X20 ml tubos</h6>
                                <p class="card-text">S/36.70</p>
                            </div>
                        </div>
                    </div>

                    <!-- Añade más productos aquí de forma similar -->
                </div>
            </div>
        </div>
    </div>



</asp:Content>
