<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/SoftCyberiaAdministrador.Master" AutoEventWireup="true" CodeBehind="listado_pedidos_vendedor.aspx.cs" Inherits="SoftCyberiaWA.Administrador.listado_pedidos_vendedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Pedidos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/siteadmi.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="panelPedidos" runat="server">
        <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvPedidos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="NumeroPedido" HeaderText="Número de Pedido" />
                <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de Creación" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged">
                            <asp:ListItem Value="Listo para Recoger" Text="Listo para Recoger" />
                            <asp:ListItem Value="Entregado" Text="Entregado" />
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
