<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/SoftCyberiaAdministrador.Master" AutoEventWireup="true" CodeBehind="listado_pedidos.aspx.cs" Inherits="SoftCyberiaWA.Administrador.listado_pedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Pedidos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
        <link href="../Content/siteadmi.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="panelPedidos" runat="server">
        <asp:GridView ID="gvPedidos" runat="server" AllowPaging="true" CssClass="table table-hover table-responsive table-striped" AutoGenerateColumns="false" OnRowDataBound="GvPedidos_RowDataBound" OnSelectedIndexChanged="GvPedidos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="NumeroPedido" HeaderText="Número de Pedido" />
                <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de Creación" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="Estado" HeaderText="EstadoHidden" />
                <asp:BoundField DataField="idPedido" HeaderText="idPedidoHidden" />
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="DdlEstado_SelectedIndexChanged">
                            <asp:ListItem Value="EN_PREPARACION" Text="En preparación" />
                            <asp:ListItem Value="LISTO_PARA_RECOGER" Text="Listo para Recoger" />
                            <asp:ListItem Value="ENTREGADO" Text="Entregado" />
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowSelectButton="true" SelectText="Ver Detalles" />
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="panelDetallePedido" runat="server" Visible="false">
        <h3>Descripción</h3>
        <asp:GridView ID="gvDetalleProductos" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="NombreProducto" HeaderText="Producto" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
