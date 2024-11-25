<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/SoftCyberiaAdministrador.Master" AutoEventWireup="true" CodeBehind="listado_stock.aspx.cs" Inherits="SoftCyberiaWA.Administrador.listado_stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Stock de Producto Por Sede
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteadmi.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex justify-content-center align-items-center vh-200" style="color: slategrey">
        <div class="card" style="width: 95%;  color: midnightblue">
            <div class="card-header text-center">
                <h2>
                    <!--El nombre puede cambiar, pero por mientras dejemoslo asi-->
                    <asp:Label ID="lblTitulo" runat="server" Text="Stock de un Producto"></asp:Label>
                </h2>
            </div>

            <div class="card-body align-content-xxl-center align-content-center" style="font: medium">

                <div class="d-flex w-100">
                    <div class="w-50">
                        <asp:Label ID="lblproductoSku" runat="server" Text="Buscar Producto por SKU:" CssClass="col-form-label fw-bold"></asp:Label>
                        <asp:TextBox ID="productoSku" runat="server" CssClass="form-control mr-10" Width="80%"></asp:TextBox>
                        <small id="productoSkuMensaje" class="form-text text-danger" runat="server"></small>
                    </div>

                    <div class="w-50" >
                        <asp:Label ID="lblsedeNombre" runat="server" Text="Sede:" CssClass="col-form-label fw-bold "></asp:Label>
                        <asp:DropDownList ID="sedeNombre" runat="server" CssClass="form-control h-75"></asp:DropDownList>
                        <small id="sedeNombreMensaje" class="form-text text-danger" runat="server"></small>
                    </div>

                </div>
                <br>
                <div class="pb-3">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary mr-20 w-25" Style="background-color: #004EA8; border-color: #004EA8;" OnClick="btnBuscar_Click" />
                    <asp:Label ID="buscarMensaje" runat="server" CssClass="text-success" Visible="false"></asp:Label>
                </div>
                <asp:Panel ID="panelDetallesProducto" runat="server">
                    <h3>Detalle del Producto</h3>
                    

                    <!-- GridView para mostrar el inventario por sede -->
                    <asp:GridView ID="gridStockProducto" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"  Width="95%" Style="table-layout: fixed;">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="Nro."  ReadOnly="true" HeaderStyle-Width="5%" ItemStyle-Width="5%" FooterStyle-Width="5%" />
                            <asp:BoundField DataField="SKU" HeaderText="Sku" ReadOnly="true" ItemStyle-Width="5%" HeaderStyle-Width="5%" FooterStyle-Width="5%"/>
                            <asp:BoundField DataField="NOMBRE" HeaderText="Nombre del producto" ReadOnly="true" ItemStyle-Width="40%" HeaderStyle-Width="40%" FooterStyle-Width="40%"/>
                            <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripcion" ReadOnly="true" ItemStyle-Width="40%" HeaderStyle-Width="40%" FooterStyle-Width="40%"/>
                            <asp:BoundField DataField="STOCK" HeaderText="Stock"  HeaderStyle-Width="5%" ItemStyle-Width="5%" FooterStyle-Width="5%"/>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>


                <!-- Lista de productos en la oferta -->
                <%--<asp:PlaceHolder runat="server">
                    <h4 class="ms-2 mb-3" style="width: 56.8vw">Listado de Productos en la Oferta</h4>
                    <div class="table-responsive">

                        <asp:GridView ID="gridProductosOferta" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
                            OnRowEditing="gridProductosOferta_RowEditing" OnRowUpdating="gridProductosOferta_RowUpdating"
                            OnRowCancelingEdit="gridProductosOferta_RowCancelingEdit" OnRowCommand="gridViewProductos_RowCommand"
                            Width="100%" Style="table-layout: fixed;">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="Nro." ReadOnly="true" HeaderStyle-Width="7%" ItemStyle-Width="7%" FooterStyle-Width="7%" />
                                <asp:BoundField DataField="SKU" HeaderText="Sku." ReadOnly="true" ItemStyle-Width="50px" HeaderStyle-Width="15%" FooterStyle-Width="15%" />
                                <asp:BoundField DataField="NOMBRE" HeaderText="Nombre del Producto" ReadOnly="true" ItemStyle-Width="150px" HeaderStyle-Width="40%" FooterStyle-Width="40%" />
                                <asp:TemplateField HeaderText="Oferta(%)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescuento" runat="server" Text='<%# Bind("DESCUENTO") %>' CssClass="form-control align-items-center" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDescuento" runat="server" Text='<%# Bind("DESCUENTO") %>' CssClass="form-control align-items-center"
                                            TextMode="Number" min="0" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="true" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEliminar" runat="server" Text="Eliminar" CommandName="EliminarProducto"
                                            CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Style="font-size: 20px; padding: 6px 7px;">
                             <i class="fas fa-trash-alt"></i>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:PlaceHolder>--%>



            </div>
        </div>
    </div>
</asp:Content>
