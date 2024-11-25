<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/SoftCyberiaAdministrador.Master" AutoEventWireup="true" CodeBehind="registrar_nuevos_productos.aspx.cs" Inherits="SoftCyberiaWA.Administrador.Registrar_nuevos_productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Registrar Producto
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteadmi.css" rel="stylesheet" />

</asp:Content>




<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex flex-wrap justify-content-center align-items-center vh-100" style="color: slategrey">
        <div class="card" style="color: midnightblue; height:110vh; width:50vw">
            <div class="card-header text-center">
                <h2>Registro Nuevo Producto</h2>
            </div>
            <div class="card-body pb-2">
                <div class="row g-3">
                    <!-- Columna de información del producto -->
                    <div class="col-12 col-md-8" style="height: 92vh; width: 100%">
                        <div class="pb-3" style="height: 15vh; width: 100%">
                            <asp:Label ID="lblproductoNombre" runat="server" Text="Nombre del Producto:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="productoNombre" runat="server" CssClass="form-control" Width="93.5%"></asp:TextBox>
                            <small id="productonombreMensaje" runat="server" class="form-text text-danger"></small>
                        </div>
                        <div class="pb-3" style="height: 15vh; width: 100%"">
                            <asp:Label ID="lblproductoSku" runat="server" Text="SKU:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="productoSku" runat="server" CssClass="form-control" Width="50%"></asp:TextBox>
                            <small id="productoSkuMensaje" runat="server" class="form-text text-danger"></small>
                        </div>
                        <div class="d-flex" style="height: 15vh; width: 100%"">
                            <div class="pb-3 col-md-6">
                                <asp:Label ID="lblproductoMarca" runat="server" Text="Marca del Producto:" CssClass="col-form-label fw-bold"></asp:Label>
                                <asp:DropDownList ID="productoMarca" runat="server" AutoPostBack="true"
                                    CssClass="form-select" Width="100%">
                                </asp:DropDownList>
                                <small id="productoMarcaMensaje" runat="server" class="form-text text-danger"></small>
                            </div>
                            <br>
                            <div style="margin-left:5%">
                                <asp:Label ID="lblproductoPrecioVenta" runat="server" Text="Precio de Venta:" CssClass="col-form-label fw-bold"></asp:Label>
                                <asp:TextBox ID="productoPrecioVenta" runat="server" CssClass="form-control"
                                    TextMode="Number" min="0" Width="100%"></asp:TextBox>
                                <small id="productoPrecioVentaMensaje" runat="server" class="form-text text-danger"></small>
                            </div>
                        </div>
                        <div class="d-flex" style="height: 15vh; width: 100%"">
                            <div class="pb-3  col-md-6">
                                <asp:Label ID="lblproductoCategoria" runat="server" Text="Categoría del Producto:" CssClass="col-form-label fw-bold"></asp:Label>
                                <asp:DropDownList ID="productoCategoria" runat="server" AutoPostBack="true"
                                    CssClass="form-select" Width="100%">
                                </asp:DropDownList>
                                <small id="productoCategoriaMensaje" runat="server" class="form-text text-danger"></small>
                            </div>
                            <br>
                            <div class="pb-3" style="margin-left:5%">
                                <asp:Label ID="lblproductoPrecioCompra" runat="server" Text="Precio de Compra:" CssClass="col-form-label fw-bold"></asp:Label>
                                <asp:TextBox ID="productoPrecioCompra" runat="server" CssClass="form-control"
                                    TextMode="Number" min="0" Width="100%"></asp:TextBox>
                                <small id="productoPrecioCompraMensaje" runat="server" class="form-text text-danger"></small>
                            </div>
                        </div>
                        <div class="d-flex"style="height:29vh; width:50vw;">
                            <div class="pb-3">
                                <asp:Label ID="lblproductoDescripcion" runat="server" Text="Descripción del Producto:" CssClass="col-form-label fw-bold"></asp:Label>
                                <asp:TextBox ID="productoDescripcion" runat="server" TextMode="MultiLine" Rows="3" Columns="31"
                                    CssClass="form-control" Height="80%" Width="100%"></asp:TextBox>
                                <small id="productoDescripcionMensaje" runat="server" class="form-text text-danger"></small>
                            </div>
                            <div class="col-md-6 text-center d-flex flex-column align-items-center justify-content-center align-content-center">
                                <asp:Label ID="lblImage" runat="server" Text="Imagen del Producto:" CssClass="col-form-label fw-bold"></asp:Label>
                                <img src="/Imagenes/producto.png" alt="Producto" class="img-fluid img-thumbnail mb-3" style="width:40%;">
                                <asp:FileUpload ID="imagenProducto" CssClass="form-control mb-2" runat="server" Width="70%"/>
                                <small id="productoImagenMensaje" runat="server" class="form-text text-danger"></small>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card-footer text-center">
                <asp:Button ID="Button1" runat="server" Text="Registrar" CssClass="btn btn-primary btn-lg w-100" OnClick="registerButton_Click" />
                <asp:Label ID="Label1" runat="server" CssClass="text-success mt-2 d-block" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
