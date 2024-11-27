using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaVentaBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace SoftCyberiaWA
{
    public partial class Detalle_carro_de_compras : Page
    {
        private readonly ComprobantePagoBO comprobantePagoBO;

        public Detalle_carro_de_compras()
        {
            comprobantePagoBO = new ComprobantePagoBO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/InicioSesion/indexInicioSesion.aspx");
            }
            if (!IsPostBack)
            {
                CargarCarrito();
            }
        }

        private void CargarCarrito()
        {
            List<producto> carrito = (List<producto>)Session["Carrito"];
            if (carrito != null && carrito.Count > 0)
            {
                rptCarrito.DataSource = carrito;
                rptCarrito.DataBind();
            }
            else
            {
                lblMensajeCarrito.Text = "Tu carrito está vacío.";
            }
        }
        protected void BtnFinalizarCompra_Click(object sender, EventArgs e)
        {
            // Obtiene el carrito desde la sesión
            List<producto> carrito = (List<producto>)Session["Carrito"];
            if (carrito == null || carrito.Count == 0)
            {
                lblMensajeCarrito.Text = "El carrito está vacío.";
                return;
            }

            // Crear un nuevo comprobante de pago
            comprobantePago comprobante = new comprobantePago
            {
                fecha = DateTime.Now,
                total = carrito.Sum(p => p.precio * p.cantidad),
                subtotal = carrito.Sum(p => p.precio * p.cantidad) / 1.18, // Calcular subtotal
                igv = carrito.Sum(p => p.precio * p.cantidad) - (carrito.Sum(p => p.precio * p.cantidad) / 1.18),
                activo = true,
                estadoPedido = estadoPedido.EN_PREPARACION // Asignar un estado inicial válido
            };

            try
            {
                // Llama al método del servicio web para insertar el comprobante
                int idComprobante = comprobantePagoBO.Comprobante_pago_insertar(comprobante);

                // Limpiar el carrito después de la compra
                Session["Carrito"] = null;
                lblMensajeCarrito.Text = "Compra realizada con éxito. ¡Gracias por tu compra!";
            }
            catch (Exception ex)
            {
                // Manejar errores del servicio web
                lblMensajeCarrito.Text = "Ocurrió un error al procesar tu compra: " + ex.Message;
            }
        }

    }
}