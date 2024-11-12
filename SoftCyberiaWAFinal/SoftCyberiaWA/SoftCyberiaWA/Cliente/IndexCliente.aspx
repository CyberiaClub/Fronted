<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente/SoftCyberiaCliente.Master" AutoEventWireup="true" CodeBehind="IndexCliente.aspx.cs" Inherits="SoftCyberiaWA.Cliente.IndexCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="Content/siteCliente.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">

    <!-- Banner Section -->
    <div>

        <!--OFERTAS-->
        <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
            </div>
            <div class="carousel-inner">
                <!-- Slide 1 -->
                <div class="carousel-item active">
                    <img src="/Imagenes/halloween.png" class="d-block w-100 carousel-img" alt="Banner 1">
                    <div class="carousel-caption d-none d-md-block">
                    </div>
                </div>

                <!-- Slide 2 -->
                <div class="carousel-item">
                    <img src="/Imagenes/pucp.png" class="d-block w-100 carousel-img" alt="Banner 2">
                    <div class="carousel-caption d-none d-md-block">
                    </div>
                </div>

                <!-- Slide 3 -->
                <div class="carousel-item">
                    <img src="/Imagenes/navidad.png" class="d-block w-100 carousel-img" alt="Banner 3">
                    <div class="carousel-caption d-none d-md-block">
                    </div>
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Anterior</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Siguiente</span>
            </button>
        </div>


               <!-- Categories Section -->
       <section class="categories text-center my-5 ">
           <div class="container">
               <h3 class="font-bold category-title bg-primary bg-opacity-50" style="font-size: 3em;">Categorías destacadas</h3>
               <div class="row mt-4">
                   <asp:Panel ID="categoriaPanelEstatico" runat="server" CssClass="row">
                       <!-- Categoría: Arte -->
                           <div class="col-md-6 mb-4">
                               <div class="card border-0">
                                   <a href="../Cliente/listado_productos.aspx?categoria=Arte" class="text-decoration-none"> 
                                       <img src="../Imagenes/arte.png" class="card-img-top rounded-img mx-auto" alt="Arte">
                                       <div class="card-body">
                                           <h5 class="card-title category-title font-regular">Arte</h5>
                                       </div>

                                   </a>
                               </div>
                           </div>
                    
                       <!-- Categoría: Arquitectura -->
                       <div class="col-md-6 mb-4">
                           <div class="card border-0">
                               <a href="/Cliente/listado_productos.aspx?categoria=Arquitectura" class="text-decoration-none">
                                   <img src="../Imagenes/arquitectura.png" class="card-img-top rounded-img mx-auto" alt="Arquitectura">
                                   <div class="card-body">
                                       <h5 class="card-title  category-title font-regular">Arquitectura</h5>
                                   </div>
                               </a>
                           </div>
                       </div>

                       <!-- Categoría: Educación -->
                       <div class="col-md-6 mb-4">
                           <div class="card border-0">
                               <a href="../Cliente/listado_productos.aspx?categoria=Educación" class="text-decoration-none">
                                   <img src="../Imagenes/educacion.jpg" class="card-img-top rounded-img mx-auto" alt="Educación">
                                   <div class="card-body">
                                       <h5 class="card-title  category-title font-regular">Educación</h5>
                                   </div>
                               </a>
                           </div>
                       </div>

                       <!-- Categoría: Oficina -->
                       <div class="col-md-6 mb-4">
                           <div class="card border-0">
                               <a href="../Cliente/listado_productos.aspx?categoria=Oficina" class="text-decoration-none">
                                   <img src="../Imagenes/oficina.jpg" class="card-img-top rounded-img mx-auto" alt="Oficina">
                                   <div class="card-body">
                                       <h5 class="card-title  category-title font-regular">Oficina</h5>
                                   </div>
                               </a>
                           </div>
                       </div>
                   </asp:Panel> 
               </div>
           </div>
       </section>

        <!-- Categories Section 4-->
        
        <section class="categories text-center my-5">
    <div class="container">
        <h3 class="font-bold category-title bg-primary bg-opacity-50" style="font-size: 3em;">Categorías destacadas</h3>
        <div id="carouselCategorias" class="carousel slide" data-bs-ride="carousel">
            <asp:Panel ID="categoriaPanel" runat="server" CssClass="carousel-inner"></asp:Panel>
            
            <!-- Botón para deslizar hacia la izquierda -->
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselCategorias" data-bs-slide="prev" style="background-color: rgba(0,0,0,0.3); width: 5%;">
                <span class="carousel-control-prev-icon" aria-hidden="true" style="width: 30px; height: 30px;"></span>
                <span class="visually-hidden">Anterior</span>
            </button>

            <!-- Botón para deslizar hacia la derecha -->
            <button class="carousel-control-next" type="button" data-bs-target="#carouselCategorias" data-bs-slide="next" style="background-color: rgba(0,0,0,0.3); width: 5%;">
                <span class="carousel-control-next-icon" aria-hidden="true" style="width: 30px; height: 30px;"></span>
                <span class="visually-hidden">Siguiente</span>
            </button>
        </div>
    </div>
</section>

        <!-- Brands Section -->
        <section class="brands text-center my-4">
            <h3 class="font-bold bg-primary bg-opacity-50" style="font-size: 3em;">Marcas</h3>
            <div class="container">
                <div class="row justify-content-center mt-4">
                    <asp:Panel ID="marcaContainer" runat="server" CssClass="row">
                        <div class="col-6 col-md-3 mb-3">
                            <img src="/Imagenes/faber.png" alt="Faber" class="brand-img precisa-img">
                        </div>
                        <div class="col-6 col-md-3 mb-3">
                            <img src="/Imagenes/sharpie.png" alt="Sharpie" class="brand-img precisa-img">
                        </div>
                        <div class="col-6 col-md-3 mb-3">
                            <img src="/Imagenes/stae.png" alt="Staedtler" class="brand-img precisa-img">
                        </div>
                        <div class="col-6 col-md-3 mb-3">
                            <img src="/Imagenes/seles.png" alt="Seles" class="brand-img precisa-img">
                        </div>
                    </asp:Panel>
                    <!-- Puedes añadir más imágenes siguiendo la misma estructura -->
                </div>
            </div>
        </section>

    </div>
    <script> 
        let currentOffset = 0;

        function moveLeft() {
            const carousel = document.getElementById("carouselCategories");
            const itemWidth = carousel.querySelector(".category-item").offsetWidth;
            const maxOffset = -(carousel.scrollWidth - carousel.offsetWidth);

            currentOffset += itemWidth * 2; // Mueve 2 elementos a la izquierda
            if (currentOffset > 0) {
                currentOffset = maxOffset; // Si llega al final, vuelve al inicio
            }
            carousel.style.transform = `translateX(${currentOffset}px)`;
        }

        function moveRight() {
            const carousel = document.getElementById("carouselCategories");
            const itemWidth = carousel.querySelector(".category-item").offsetWidth;
            const maxOffset = -(carousel.scrollWidth - carousel.offsetWidth);

            currentOffset -= itemWidth * 2; // Mueve 2 elementos a la derecha
            if (currentOffset < maxOffset) {
                currentOffset = 0; // Si llega al final, vuelve al inicio
            }
            carousel.style.transform = `translateX(${currentOffset}px)`;
        }
    </script>
</asp:Content>
