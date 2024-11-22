<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/SoftCyberiaAdministrador.Master" AutoEventWireup="true" CodeBehind="registrar_produtco_compuesto.aspx.cs" Inherits="SoftCyberiaWA.Administrador.registrar_produtco_compuesto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Producto Compuesto
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteadmi.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center align-items-center vh-200">
        <div class="card h-auto" style="width: 100%; max-width: 900px; color: midnightblue; border: 0.5px solid #c1bcb1; border-radius: 1px;">
            <div class="card-header text-center" style="width: 900px">
                <h2>Crear Producto Compuesto (Kit)</h2>
            </div>
            <div class="card-body pb-2 col-13 d-flex">
                <div class="d-flex col-13">
                    <!-- Columna de información del producto    -->
                    <div class="d-flex flex-column col-6">
                        <div class="d-flex flex-column">
                            <asp:Label ID="lblproductoNombre" runat="server" Text="Nombre del Producto:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="productoNombre" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                            <small id="productoNombreMensaje" class="form-text text-danger" runat="server"></small>
                        </div>
                        <div class="d-flex flex-column">
                            <asp:Label ID="lblproductoSku" runat="server" Text="SKU:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="productoSku" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                            <small id="productoSkuMensaje" class="form-text text-danger" runat="server"></small>                            
                        </div>
                        <div class="d-flex flex-column">
                            <asp:Label ID="lblproductoPrecio" runat="server" Text="Precio de Venta:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="productoPrecio" runat="server" CssClass="form-control" Width="45%" TextMode="Number"></asp:TextBox>
                            <small id="ProductoPrecioMensaje" class="form-text text-danger" runat="server"></small>                            
                        </div>
                        <div class="d-flex flex-column">
                            <asp:Label ID="lblproductoMarca" runat="server" Text="Marca del Producto:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:DropDownList ID="productoMarca" runat="server" AutoPostBack="true" CssClass="form-select"></asp:DropDownList>
                            <small id="productoMarcaMensaje" class="form-text text-danger" runat="server"></small>                            
                        </div>
                        <div class="d-flex flex-column">
                            <asp:Label ID="lblproductoTipoProducto" runat="server" Text="Categoría del Producto:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:DropDownList ID="productoTipoProducto" runat="server" AutoPostBack="true" CssClass="form-select"></asp:DropDownList>
                            <small id="ProductoTipoProductoMensaje" class="form-text text-danger" runat="server"></small>                            
                        </div>
                        <div class="d-flex flex-column">
                            <asp:Label ID="lblproductoDescripcion" runat="server" Text="Descripción del Producto:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="productoDescripcion" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                            <small id="productoDescripcionMensaje" class="form-text text-danger" runat="server"></small>                            
                        </div>
                    </div>
                    <!-- Columna de botón de asignación -->
                    <div class="col-md-7 d-flex flex-column align-items-center bg-light h-auto" style="border-radius: 0 15px 15px 0; margin-left: 6.5%; margin-right: auto; width: auto; max-height:50vh">
                        <h4 class="font-weight-bold mb-4 align-content-center" style="color: #004EA8;">Imagen Producto Compuesto</h4>
                        <asp:Label ID="lblImage" runat="server" Text="Imagen del Producto:" CssClass="col-form-label fw-bold"></asp:Label>
                        <img src="/Imagenes/oferta.png" alt="Icono de oferta" class="img-fluid img-thumbnail mb-3" style="width: 160px;">
                        <asp:FileUpload ID="imagenProducto" CssClass="form-control mb-2" runat="server" Width="95%" />
                        <small id="productoImagenMensaje" class="form-text text-danger" runat="server"></small>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <p>
        <br>
    </p>
    <div class="d-flex justify-content-center align-items-center vh-200">
        <div class="d-flex card h-auto" style="width: 100%; max-width: 900px; color: midnightblue; background-color: white; border: 0.5px solid #c1bcb1; border-radius: 1px;">
            <div class="card-header text-center" style="width: 900px">
                <h2>Agregar Productos al Kit</h2>
            </div>
            <div class="card-body pb-2">
                <!-- Sección para agregar productos al kit -->
                <div class="d-flex col-13">
                    <!-- Caja de texto para el sku -->
                    <div class="d-flex flex-column mr-4 col-5" style="margin-left: 20px;">
                        <asp:Label ID="lblproductoKitSKU" runat="server" Text="Buscar Producto por SKU:" CssClass="col-form-label fw-bold"></asp:Label>
                        <asp:TextBox ID="productoKitSKU" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="sku_TextChange" Width="300px"></asp:TextBox>
                        <small id="productoKitSKUMensaje" class="form-text text-danger" runat="server"></small>
                    </div>
                    <div class="d-flex align-items-center col-6" style="height: 120px">
                        <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar Producto" CssClass="btn btn-success" OnClick="AgregarProducto_Click" />
                    </div>
                </div>
                <asp:PlaceHolder ID="prodBuscadoPlaceHolder" runat="server">
                    <div class="d-flex col-13" style="margin-left: 20px; margin-right: 20px;">
                        <asp:GridView ID="gridViewProdBuscado" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" ReadOnly="true"
                            Width="100%" Style="table-layout: fixed;">
                            <Columns>
                                <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                                <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripcion" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:PlaceHolder>
                <!-- Lista de productos en la oferta -->
                <asp:PlaceHolder runat="server">
                    <h4 style="margin-left: 20px;">Listado de Productos el Kit</h4>
                    <div class="d-flex col-13" style="margin-left: 20px; margin-right: 20px;">
                        <asp:GridView ID="gridProductosKit" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
                            OnRowEditing="gridProductosKit_RowEditing" OnRowUpdating="gridProductosKit_RowUpdating"
                            OnRowCancelingEdit="gridProductosKit_RowCancelingEdit" OnRowCommand="gridViewProductosKit_RowCommand"
                            Width="95.3%" Style="table-layout: fixed;">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="Nro." ReadOnly="true"
                                    HeaderStyle-Width="7%" ItemStyle-Width="7%" FooterStyle-Width="7%" />
                                <asp:BoundField DataField="SKU" HeaderText="Sku." ReadOnly="true" ItemStyle-Width="50px"
                                    HeaderStyle-Width="15%" FooterStyle-Width="15%" />
                                <asp:BoundField DataField="NOMBRE" HeaderText="Nombre del Producto" ReadOnly="true" ItemStyle-Width="150px"
                                    HeaderStyle-Width="40%" FooterStyle-Width="40%" />
                                <asp:TemplateField HeaderText="Cantidad">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCantidad" runat="server" Text='<%# Bind("CANTIDAD") %>' CssClass="form-control align-items-center" Width="60%" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtCantidad" runat="server" Text='<%# Bind("CANTIDAD") %>' CssClass="form-control align-items-center" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="true"
                                    HeaderStyle-Width="12%" FooterStyle-Width="12%" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEliminar" runat="server" Text="Eliminar" CommandName="EliminarProducto"
                                            CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm"
                                            Style="font-size: 20px; padding: 6px 7px;">
                                        <i class="fas fa-trash-alt"></i>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:PlaceHolder>
                <div class="col-13 text-center">
                    <asp:Button ID="btnRegistrarKit" runat="server" Text="Registrar Kit" CssClass="btn btn-primary mt-4"
                        Style="background-color: #004EA8; border-color: #004EA8;" OnClick="RegistrarKit_Click" Width="20%" />
                    <asp:Label ID="successMessage" runat="server" CssClass="text-success" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
