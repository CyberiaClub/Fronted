using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class registrar_nuevos_proveedores : System.Web.UI.Page
    {
        private ProveedorBO proveedorBO;

        public registrar_nuevos_proveedores()
        {
            this.proveedorBO = new ProveedorBO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void botonRegistrar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                proveedor _proveedor = new proveedor();
                _proveedor.ruc = proveedorRUC.Text.Trim();
                _proveedor.nombreContacto = nombreContacto.Text.Trim();
                _proveedor.razonSocial = razonSocial.Text.Trim();
                _proveedor.telefono = telfono.Text.Trim();
                _proveedor.correo = correo.Text.Trim();
                _proveedor.direccion = direccion.Text.Trim();
                _proveedor.descripcion = descripcion.Text.Trim();

                this.proveedorBO.proveedor_insertar(_proveedor);
            }

        }

        protected Boolean Validar()
        {
            Boolean validarRUC = ValidarCampo(proveedorRUC, proveedorRUCMensaje, "Por favor ingrese un RUC.");
            Boolean validarRazonSocial = ValidarCampo(razonSocial, razonSocialMensaje, "Por favor ingrese la razón social.");
            Boolean validarNombre = ValidarCampo(nombreContacto, nombreContactoMensaje, "Por favor ingrese un nombre de contacto.");
            Boolean validarTelefono = ValidarCampo(telfono, telfonoMensaje, "Por favor seleccione un número de telefono.");
            Boolean validarCorreo = ValidarCampo(correo, correoMensaje, "Por favor seleccione un correo.");
            Boolean validarDireccion = ValidarCampo(direccion, direccionMensaje, "Por favor ingrese una direccion.");

            if (validarRazonSocial && (razonSocial.Text.Length > 20 || razonSocial.Text.Length < 11))
            {
                validarRazonSocial = false;
                razonSocialMensaje.InnerText = "Por favor ingrese un RUC válido.";
                razonSocialMensaje.Visible = true;
            }

            Boolean validarImagen = true;
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

        private Boolean ValidarCampo(TextBox campo, HtmlGenericControl mensaje, string textoError, bool esCombo = false, DropDownList combo = null)
        {
            Boolean valido;
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