<%@ Page Title="" Language="C#" MasterPageFile="~/SoftCyberia.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SoftCyberiaWA.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    Cyberia - Home 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


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
                   <img src="Images/halloween.png" class="d-block w-100 carousel-img" alt="Banner 1">
                   <div class="carousel-caption d-none d-md-block">
                   </div>
               </div>

               <!-- Slide 3 -->
               <div class="carousel-item">
                   <img src="Images/pucp.png" class="d-block w-100 carousel-img" alt="Banner 3">
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


       <!-- Estilos adicionales para la sección del banner -->
       <style>
           .carousel-caption {
               background: rgba(0, 0, 0, 0.5); /* Fondo semitransparente */
               padding: 20px;
               border-radius: 10px;
           }
       </style>


        <!-- Categories Section -->
       <section class="categories text-center my-5">
    <div class="container">
        <h3 class="font-bold">Categorías destacadas</h3>
        <div class="row mt-4">
            <!-- Categoría: Arte -->
            <div class="col-md-6 mb-4">
                <div class="card border-0">
                    <img src="Images/arte.png" class="card-img-top rounded-img" alt="Arte">
                    <div class="card-body">
                        <h5 class="card-title font-regular">Arte</h5>
                    </div>
                </div>
            </div>

           <!-- Categoría: Arquitectura -->
           <div class="col-md-6 mb-4">
               <div class="card border-0">
                   <img src="Images/arquitectura.png" class="card-img-top rounded-img" alt="Arquitectura">
                   <div class="card-body">
                       <h5 class="card-title font-regular">Arquitectura</h5>
                   </div>
               </div>
           </div>

           <!-- Categoría: Educación -->
           <div class="col-md-6 mb-4">
               <div class="card border-0">
                   <img src="Images/educacion.jpg" class="card-img-top rounded-img" alt="Educación">
                   <div class="card-body">
                       <h5 class="card-title font-regular">Educación</h5>
                   </div>
               </div>
           </div>

           <!-- Categoría: Oficina -->
           <div class="col-md-6 mb-4">
               <div class="card border-0">
                   <img src="Images/oficina.jpg" class="card-img-top rounded-img" alt="Oficina">
                   <div class="card-body">
                       <h5 class="card-title font-regular">Oficina</h5>
                   </div>
               </div>
           </div>
       </div>
       </div>
       </section>
        <!-- Brands Section -->
        <section class="brands text-center my-4">
            <h3 class="font-bold">Marcas</h3>
            <div class="container">
                <div class="row justify-content-center mt-4">
                    <div class="col-6 col-md-3 mb-3">
                        <img src="Images/faber.png" alt="Faber" class="brand-img">
                    </div>
                    <div class="col-6 col-md-3 mb-3">
                        <img src="Images/sharpie.png" alt="Sharpie" class="brand-img">
                    </div>
                    <div class="col-6 col-md-3 mb-3">
                        <img src="Images/stae.png" alt="Staedtler" class="brand-img">
                    </div>
                    <div class="col-6 col-md-3 mb-3">
                        <img src="Images/seles.png" alt="Seles" class="brand-img">
                    </div>
                    <!-- Puedes añadir más imágenes siguiendo la misma estructura -->
                </div>
            </div>
        </section>
    </div>
</asp:Content>
