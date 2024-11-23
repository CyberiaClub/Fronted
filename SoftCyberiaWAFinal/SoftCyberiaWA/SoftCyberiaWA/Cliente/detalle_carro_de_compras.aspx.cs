using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaVentaBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA
{
    //public partial class detalle_carro_de_compras : System.Web.UI.Page
    //{
    //    protected void Page_Load(object sender, EventArgs e)
    //    {

    //    }

    //    protected void btnHistorialCompras_Click(object sender, EventArgs e)
    //    {
    //        // Redirigir a la página del historial de compras
    //        Response.Redirect("detalle_historial_de_compras.aspx");
    //    }

    //    protected void btnSeguirComprando_Click(object sender, EventArgs e)
    //    {
    //        Response.Redirect("metodo_pago.aspx");
    //    }
    //}

    public partial class detalle_carro_de_compras : Page
    {
        private ComprobantePagoBO comprobantePagoBO;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCarrito();
            }
        }

        private void CargarCarrito()
        {
            var carrito = (List<producto>)Session["Carrito"];
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

        //protected void btnFinalizarCompra_Click(object sender, EventArgs e)
        //{
        //    // Obtiene el carrito desde la sesión
        //    var carrito = (List<producto>)Session["Carrito"];
        //    if (carrito == null || carrito.Count == 0)
        //    {
        //        lblMensajeCarrito.Text = "El carrito está vacío.";
        //        return;
        //    }

        //    // Crear un nuevo comprobante de pago usando el nombre completo del tipo
        //    comprobantePago comprobante = new comprobantePago
        //    {
        //        fecha = DateTime.Now,
        //        total = carrito.Sum(p => p.precio * p.cantidad),
        //        subtotal = carrito.Sum(p => p.precio * p.cantidad) / 1.18, // Calcular subtotal
        //        igv = carrito.Sum(p => p.precio * p.cantidad) - (carrito.Sum(p => p.precio * p.cantidad) / 1.18),
        //        activo = true,
        //        estadoPedido = estadoPedido.EN_PREPARACION // Usa el valor del enum aquí  // Asigna un valor predeterminado a EstadoPedido    duda del estado
        //    };

        //    // Aquí puedes configurar el estado específico que necesitas, por ejemplo:


        //    // Llama al método del servicio web para insertar el comprobante
        //    int idComprobante = comprobantePagoBO.comprobante_pago_insertar(comprobante);

        //    // Limpiar el carrito después de la compra
        //    Session["Carrito"] = null;
        //    lblMensajeCarrito.Text = "Compra realizada con éxito. ¡Gracias por tu compra!";
        //}
        protected void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            // Obtiene el carrito desde la sesión
            var carrito = (List<producto>)Session["Carrito"];
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
                int idComprobante = comprobantePagoBO.comprobante_pago_insertar(comprobante);

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