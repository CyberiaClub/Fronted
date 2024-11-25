using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftCyberiaBaseBO.CyberiaWS;

namespace SoftCyberiaBaseBO
{
    public class BaseBO
    {
    // Servicios web de inventario
    private CyberiaWS.MarcaWSClient wsMarca;
    private CyberiaWS.ProductoWSClient wsProducto;
    private CyberiaWS.ProveedorWSClient wsProveedor;
    private CyberiaWS.SedeWSClient wsSede;
    private CyberiaWS.TipoProductoWSClient wsTipoProducto;
    // Servicios web de persona
    private CyberiaWS.PersonaWSClient wsPersona;
    private CyberiaWS.TipoPersonaWSClient wsTipoPersona;
    // Servicios web de venta
    private CyberiaWS.ComprobantePagoWSClient wsComprobantePago;
    private CyberiaWS.OfertaWSClient wsOferta;
    private CyberiaWS.TipoComprobanteWSClient wsTipoComprobante;

        public BaseBO()
        {
            this.WsMarca = new CyberiaWS.MarcaWSClient();
            this.WsProducto = new CyberiaWS.ProductoWSClient();
            this.WsProveedor = new CyberiaWS.ProveedorWSClient();
            this.WsSede = new CyberiaWS.SedeWSClient();
            this.WsTipoProducto = new CyberiaWS.TipoProductoWSClient() ;
            this.WsPersona = new CyberiaWS.PersonaWSClient();
            this.WsTipoPersona = new CyberiaWS.TipoPersonaWSClient() ;
            this.WsComprobantePago = new CyberiaWS.ComprobantePagoWSClient();
            this.WsOferta = new CyberiaWS.OfertaWSClient();
            this.WsTipoComprobante = new CyberiaWS.TipoComprobanteWSClient();
        }

        public MarcaWSClient WsMarca { get => wsMarca; set => wsMarca = value; }
        public ProductoWSClient WsProducto { get => wsProducto; set => wsProducto = value; }
        public ProveedorWSClient WsProveedor { get => wsProveedor; set => wsProveedor = value; }
        public SedeWSClient WsSede { get => wsSede; set => wsSede = value; }
        public TipoProductoWSClient WsTipoProducto { get => wsTipoProducto; set => wsTipoProducto = value; }
        public PersonaWSClient WsPersona { get => wsPersona; set => wsPersona = value; }
        public TipoPersonaWSClient WsTipoPersona { get => wsTipoPersona; set => wsTipoPersona = value; }
        public ComprobantePagoWSClient WsComprobantePago { get => wsComprobantePago; set => wsComprobantePago = value; }
        public OfertaWSClient WsOferta { get => wsOferta; set => wsOferta = value; }
        public TipoComprobanteWSClient WsTipoComprobante { get => wsTipoComprobante; set => wsTipoComprobante = value; }
    }
}
