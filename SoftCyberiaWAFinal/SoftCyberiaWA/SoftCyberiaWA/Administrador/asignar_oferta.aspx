<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/SoftCyberiaAdministrador.Master" AutoEventWireup="true" CodeBehind="asignar_oferta.aspx.cs" Inherits="SoftCyberiaWA.Administrador.asignar_oferta" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Asignar Oferta
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteadmi.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center align-items-center vh-200">
        <div class="d-flex card h-auto" style="width: 100%; max-width: 900px; color: midnightblue; background-color: white; border: 0.5px solid #c1bcb1; border-radius: 1px;">
            <div class="card-header text-center" style="width: 900px">
                <h2>Ingresar una Oferta</h2>
            </div>
            <div class="card-body pb-2 col-13">
                <!-- Columna de información de la oferta -->
                <div class="d-flex col-13">
                    <div class="d-flex flex-column col-4">
                        <h5>Ingrese la Información de la Oferta</h5>
                        <p><br></p>
                        <div class="pb-3">
                            <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha de Inicio de la Oferta:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="fechaInicio" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            <small id="fechaInicioMensaje" class="form-text text-bg-danger" runat="server"></small>
                        </div>
                        <div class="pb-3">
                            <asp:Label ID="lblFechaFin" runat="server" Text="Fecha de Fin de la Oferta:" CssClass="col-form-label fw-bold"></asp:Label>
                            <asp:TextBox ID="fechaFin" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            <small id="fechaFinMensaje" class="form-text text-bg-danger" runat="server"></small>
                        </div>
                    </div>

                    <!-- Columna de botón de asignación -->
                    <div class="col-7 d-flex flex-column align-items-center bg-light" style="border-radius: 0 15px 15px 0; margin-left: 20%; margin-right: auto; width: auto">

                        <h4 class="font-weight-bold" style="color: #004EA8;">Asignar Imagen</h4>

                        <asp:Label ID="lblImage" runat="server" Text="Imagen del Producto:" CssClass="col-form-label fw-bold"></asp:Label>
                        <img src="/Imagenes/oferta.png" alt="Icono de oferta" class="img-fluid img-thumbnail mb-3" style="width: 160px;">
                        <asp:FileUpload ID="fileUploadProductImage" CssClass="form-control mb-2" runat="server" />
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
                <h2>Agregar Productos a la Oferta</h2>
            </div>
            <div class="card-body pb-2">
                <!-- Sección para agregar productos al kit -->
                <div class="d-flex col-13">
                    <!-- Caja de texto para el sku -->
                    <div class="d-flex flex-column mr-4 col-5" style="margin-left: 20px;">
                        <asp:Label ID="lblproductoSku" runat="server" Text="Buscar Producto por SKU:" CssClass="col-form-label fw-bold"></asp:Label>
                        <asp:TextBox ID="productoSKU" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="sku_TextChange" Width="300px"></asp:TextBox>
                        <small id="productoSKUMensaje" class="form-text text-bg-danger" runat="server"></small>
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
                    <h4 style="margin-left: 20px;">Listado de Productos en la Oferta</h4>
                    <div class="d-flex col-13" style="margin-left: 20px; margin-right: 20px;">
                        <asp:GridView ID="gridProductosOferta" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
                            OnRowEditing="gridProductosOferta_RowEditing" OnRowUpdating="gridProductosOferta_RowUpdating"
                            OnRowCancelingEdit="gridProductosOferta_RowCancelingEdit" OnRowCommand="gridViewProductos_RowCommand"
                            Width="95.3%" Style="table-layout: fixed;">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="Nro." ReadOnly="true"
                                    HeaderStyle-Width="7%" ItemStyle-Width="7%" FooterStyle-Width="7%" />
                                <asp:BoundField DataField="SKU" HeaderText="Sku." ReadOnly="true" ItemStyle-Width="50px"
                                    HeaderStyle-Width="15%" FooterStyle-Width="15%" />
                                <asp:BoundField DataField="NOMBRE" HeaderText="Nombre del Producto" ReadOnly="true" ItemStyle-Width="150px"
                                    HeaderStyle-Width="40%" FooterStyle-Width="40%" />
                                <asp:TemplateField HeaderText="Oferta(%)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescuento" runat="server" Text='<%# Bind("DESCUENTO") %>' CssClass="form-control align-items-center" Width="60%" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDescuento" runat="server" Text='<%# Bind("DESCUENTO") %>' CssClass="form-control align-items-center" />
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
                    <asp:Button ID="btnAsignarOferta" runat="server" Text="Asignar Oferta" CssClass="btn btn-primary mt-4"
                        Style="background-color: #004EA8; border-color: #004EA8;" OnClick="btnAsignarOferta_Click" Width="20%" />
                    <asp:Label ID="successMessage" runat="server" CssClass="text-success" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
