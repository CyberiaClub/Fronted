﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCyberiaBaseBO
{
    public class BaseBO
    {
        private CyberiaWS.MarcaWSClient wsMarca;
        private CyberiaWS.ProductoWSClient wsProducto;
        private CyberiaWS.ProveedorWSClient wsProveedor;
        private CyberiaWS.SedeWSClient wsSede;
        private CyberiaWS.TipoProductoWSClient wsTipoProducto;
        private CyberiaWS.AdministradorWSClient wsAdministrador;
        private CyberiaWS.AlmaceneroWSClient wsAlmacenero;
        private CyberiaWS.VendedorWSClient wsVendedor;
        private CyberiaWS.ClienteWSClient wsCliente;
        private CyberiaWS.RolWSClient wsRol;
        private CyberiaWS.BoletaWSClient wsBoleta;
        private CyberiaWS.FacturaWSClient wsFactura;
        private CyberiaWS.OfertaWSClient wsOferta;
        private CyberiaWS.PedidoWSClient wsPedido;

        public BaseBO()
        {
            this.wsMarca = new CyberiaWS.MarcaWSClient();
            this.wsProducto = new CyberiaWS.ProductoWSClient();
            this.wsProveedor = new CyberiaWS.ProveedorWSClient();
            this.wsSede = new CyberiaWS.SedeWSClient();
            this.wsTipoProducto = new CyberiaWS.TipoProductoWSClient();
            this.wsAdministrador = new CyberiaWS.AdministradorWSClient();
            this.wsAlmacenero = new CyberiaWS.AlmaceneroWSClient();
            this.wsVendedor = new CyberiaWS.VendedorWSClient();
            this.wsCliente = new CyberiaWS.ClienteWSClient();
            this.wsRol = new CyberiaWS.RolWSClient();
            this.wsBoleta = new CyberiaWS.BoletaWSClient();
            this.wsFactura = new CyberiaWS.FacturaWSClient();
            this.wsOferta = new CyberiaWS.OfertaWSClient();
            this.wsPedido = new CyberiaWS.ClienteWSClient();
        }
                
    }
}

