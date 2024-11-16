<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/SoftCyberiaAdministrador.Master" AutoEventWireup="true" CodeBehind="registrar_produtco_compuesto.aspx.cs" Inherits="SoftCyberiaWA.Administrador.registrar_produtco_compuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Producto Compuesto
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteadmi.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center align-items-center vh-200">
        <div class="card" style="width: 100%; max-width: 800px; color: midnightblue">
            <div class="card-header text-center" style="width: 800px">
                <h2>Crear Producto Compuesto (Kit)</h2>
            </div>
            <div class="card-body pb-2">
                <div class="row">
                    <!-- Columna de información de la oferta -->
                    <div class="col-md-8">
                        <div class="pb-3">
                            <asp:Label ID="lblProductName" runat="server" Text="Nombre del Producto:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="productName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="pb-3">
                            <asp:Label ID="lblSKU" runat="server" Text="SKU:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="sku" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="pb-3">
                            <asp:Label ID="lblPrice" runat="server" Text="Precio de Venta:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="price" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="pb-3">
                            <asp:Label ID="lblUnidades" runat="server" Text="Unidades:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="unidades" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="pb-3">
                            <asp:Label ID="lblSede" runat="server" Text="Sede:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:DropDownList ID="sedeName" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="pb-3">
                            <asp:Label ID="lblDescription" runat="server" Text="Descripción del Producto:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="description" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <!-- Columna de botón de asignación -->
                    <div class="col-md-4 d-flex flex-column align-items-center justify-content-center bg-light" style="border-radius: 0 15px 15px 0;">
                        <h4 class="font-weight-bold mb-4 align-content-center" style="color: #004EA8;">Imagen Producto Compuesto</h4>

                        <asp:Label ID="lblImage" runat="server" Text="Imagen del Producto:" CssClass="col-form-label fw-bold"></asp:Label>
                        <img src="/Imagenes/oferta.png" alt="Icono de oferta" class="img-fluid img-thumbnail mb-3" style="width: 160px;">
                        <asp:FileUpload ID="fileUploadProductImage" CssClass="form-control mb-2" runat="server" />

                        <asp:Button ID="btnAsignarOferta" runat="server" Text="Asignar Imagen" CssClass="btn btn-primary mt-4" Style="background-color: #004EA8; border-color: #004EA8;"  />
                    </div>
                </div>

                <!-- Sección para agregar productos al kit -->
                <p> </p>
                <div class="col-md-13">
                    <h5 class="font-weight-bold text-center card-header font-bold" style="color: #004EA8;">Agregar Productos al Kit</h5>
                    <div class="row">
                        <div class="pb-7">
                            <asp:Label ID="lblSearchSKU" runat="server" Text="Buscar Producto por SKU:" CssClass="col-form-label fw-bold"></asp:Label>
                            <div class="d-flex">
                                <asp:TextBox ID="searchSKU" runat="server" CssClass="form-control mr-20"></asp:TextBox>
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary mr-20" Style="background-color: #004EA8; border-color: #004EA8;" />
                                <asp:Label ID="lblCantidadProducto" runat="server" Text="Cantidad:" CssClass="col-form-label fw-bold align-self-center mx-2"></asp:Label>
                                <asp:TextBox ID="cantidadProducto" runat="server" CssClass="form-control mr-2" TextMode="Number" Style="width: 80px;"></asp:TextBox>
                                <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar Producto" CssClass="btn btn-success" />
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Lista de productos en el kit -->
                <div class="row mt-4">
                    <div class="col-md-12">
                        <h5 class="font-weight-bold text-center" style="color: #004EA8;">Productos en el Kit (Máximo 5)</h5>
                        <asp:GridView ID="gridProductosKit" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                            <Columns>
                                <asp:BoundField DataField="SKU" HeaderText="SKU" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre del Producto" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="EliminarProducto" CssClass="btn btn-danger btn-sm" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

                <!-- Botón para finalizar la creación del kit -->
                <div class="row mt-4">
                    <div class="col-md-12 text-center">
                        <asp:Button ID="btnCrearKit" runat="server" Text="Crear Kit" CssClass="btn btn-primary" Style="background-color: #004EA8; border-color: #004EA8;" />
                    </div>
                </div>

            </div>
        </div>
    </div>


</asp:Content>
