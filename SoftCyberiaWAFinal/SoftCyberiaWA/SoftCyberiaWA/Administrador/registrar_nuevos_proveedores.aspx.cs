using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class Registrar_nuevos_proveedores : Page
    {
        private readonly ProveedorBO proveedorBO;

        public Registrar_nuevos_proveedores()
        {
            proveedorBO = new ProveedorBO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null || Session["paginas"] == null)
            {
                Response.Redirect("~/InicioSesion/indexInicioSesion.aspx");
            }
            // Obtener la ruta completa
            string currentPage = Request.Url.AbsolutePath;

            // Extraer solo el archivo
            string fileName = Path.GetFileName(currentPage);
            if (!(Session["paginas"] is BindingList<pagina> allowedPages))
            {
                Response.Redirect("~/InicioSesion/indexInicioSesion.aspx");
            }
            else
            {
                if (!allowedPages.Any(page => page.referencia.Equals(fileName, StringComparison.OrdinalIgnoreCase)))
                {
                    // Redirigir a la página 403 si no tiene acceso
                    Response.Redirect("~/InicioSesion/403.aspx");
                }
            }
        }

        protected void BotonRegistrar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                proveedor _proveedor = new proveedor
                {
                    ruc = proveedorRUC.Text.Trim(),
                    nombreContacto = nombreContacto.Text.Trim(),
                    razonSocial = razonSocial.Text.Trim(),
                    telefono = telfono.Text.Trim(),
                    correo = correo.Text.Trim(),
                    direccion = direccion.Text.Trim(),
                    descripcion = descripcion.Text.Trim()
                };

                _ = proveedorBO.Proveedor_insertar(_proveedor);
            }

        }

        protected bool Validar()
        {
            bool validarRUC = ValidarCampo(proveedorRUC, proveedorRUCMensaje, "Por favor ingrese un RUC.");
            bool validarRazonSocial = ValidarCampo(razonSocial, razonSocialMensaje, "Por favor ingrese la razón social.");
            bool validarNombre = ValidarCampo(nombreContacto, nombreContactoMensaje, "Por favor ingrese un nombre de contacto.");
            bool validarTelefono = ValidarCampo(telfono, telfonoMensaje, "Por favor seleccione un número de telefono.");
            bool validarCorreo = ValidarCampo(correo, correoMensaje, "Por favor seleccione un correo.");
            bool validarDireccion = ValidarCampo(direccion, direccionMensaje, "Por favor ingrese una direccion.");

            if (validarRazonSocial && (razonSocial.Text.Length > 20 || razonSocial.Text.Length < 11))
            {
                validarRazonSocial = false;
                razonSocialMensaje.InnerText = "Por favor ingrese un RUC válido.";
                razonSocialMensaje.Visible = true;
            }

            bool validarImagen = true;
            if (!imagen.HasFile)
            {
                validarImagen = false;
                imagenMensaje.InnerText = "Por favor ingrese una imagen.";
                imagenMensaje.Visible = true;
            }
            else
            {
                imagenMensaje.Visible = false;
            }


            return validarRUC && validarRazonSocial && validarNombre && validarTelefono && validarCorreo && validarDireccion && validarImagen;
        }

        private bool ValidarCampo(TextBox campo, HtmlGenericControl mensaje, string textoError, bool esCombo = false, DropDownList combo = null)
        {
            bool valido;
            if (esCombo)
            {
                if (combo.SelectedIndex == 0)
                {
                    valido = false;
                    mensaje.InnerText = textoError;
                    mensaje.Visible = true;
                }
                else
                {
                    valido = true;
                    mensaje.Visible = false;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(campo.Text))
                {
                    valido = false;
                    mensaje.InnerText = textoError;
                    mensaje.Visible = true;
                }
                else
                {
                    valido = true;
                    mensaje.Visible = false;
                }
            }
            return valido;
        }

    }
}