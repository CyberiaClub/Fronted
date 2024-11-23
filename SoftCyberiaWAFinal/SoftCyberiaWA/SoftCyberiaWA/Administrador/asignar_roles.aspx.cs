using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
using SoftCyberiaPersonaBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class asignar_roles : System.Web.UI.Page
    {
        private PersonaBO personaBO;
        private SedeBO sedeBO;
        private persona _persona = new persona();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarSedes();
        }

        protected void dni_Ingresado(object sender, EventArgs e)
        {
            _persona = personaBO.persona_buscar_por_documento(dni.Text.ToString());
            if (_persona != null)
            {
                nombre.Text = _persona.nombre;
                correo.Text = _persona.correo;
                telefono.Text = _persona.telefono;
                direccion.Text = _persona.direccion;
            }
        }

        private void CargarSedes()
        {
            sedeBO = new SedeBO();
            sede.DataSource = sedeBO.sede_listar();
            sede.DataTextField = "nombre";
            sede.DataValueField = "idSede";
            sede.DataBind();
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            bool valido = true;
            persona _persona = new persona();

            // Validar Tipo de Documento
            if (tipo_documento.SelectedIndex == 0)
            {
                lblTipoDocumento.Text = "Seleccione un tipo de documento.";
                valido = false;
            }
            else
            {
                lblTipoDocumento.Text = "";
            }

            // Validar Número de Documento
            if (dni.Text.Trim() == "")
            {
                lblDocumento.Text = "Ingrese su documento de identidad.";
                valido = false;
            }
            else
            {
                int documentoLength = dni.Text.Trim().Length;
                switch (tipo_documento.SelectedValue)
                {
                    case "1": // DNI
                        if (documentoLength != 8)
                        {
                            lblDocumento.Text = "El DNI debe tener 8 caracteres.";
                            valido = false;
                        }
                        else
                        {
                            lblDocumento.Text = "";
                        }
                        break;
                    case "2": // Pasaporte
                    case "3": // Carnet de Extranjería
                        if (documentoLength != 12)
                        {
                            lblDocumento.Text = "El documento debe tener 12 caracteres.";
                            valido = false;
                        }
                        else
                        {
                            lblDocumento.Text = "";
                        }
                        break;
                }
            }

            // Validar Nombre
            if (nombre.Text.Trim() == "")
            {
                lblNombre.Text = "Ingrese su nombre.";
                valido = false;
            }
            else
            {
                lblNombre.Text = "";
            }

            // Validar Correo
            if (correo.Text.Trim() == "")
            {
                lblCorreo.Text = "Ingrese su correo.";
                valido = false;
            }
            else
            {
                lblCorreo.Text = "";
            }

            // Validar Teléfono
            if (telefono.Text.Trim() == "")
            {
                lblTelefono.Text = "Ingrese su teléfono.";
                valido = false;
            }
            else
            {
                lblTelefono.Text = "";
            }

            // Validar Dirección
            if (direccion.Text.Trim() == "")
            {
                lblDireccion.Text = "Ingrese su dirección.";
                valido = false;
            }
            else
            {
                lblDireccion.Text = "";
            }

            // Validar Rol
            if (rol.SelectedIndex == 0)
            {
                lblRol.Text = "Seleccione un rol.";
                valido = false;
            }
            else
            {
                lblRol.Text = "";
            }

            // Validar Sueldo
            if (sueldo.Text.Trim() == "")
            {
                lblSueldo.Text = "Ingrese un sueldo.";
                valido = false;
            }
            else if (!decimal.TryParse(sueldo.Text.Trim(), out _))
            {
                lblSueldo.Text = "El sueldo debe ser un número válido.";
                valido = false;
            }
            else
            {
                lblSueldo.Text = "";
            }

            // Validar Sede
            if (sede.SelectedIndex == 0)
            {
                lblSede.Text = "Seleccione una sede.";
                valido = false;
            }
            else
            {
                lblSede.Text = "";
            }

            if (valido)
            {
                // Realizar lógica para asignar el rol
                successMessage.Visible = true;
                successMessage.Text = "Rol asignado exitosamente.";
            }



            string rolSeleccionado = rol.SelectedValue.ToString();

            if (rolSeleccionado == "Almacén")
            {
                _persona.idTipoPersona = 4;
            }
            else
            {
                _persona.idTipoPersona = 3;
            }

            _persona.sueldo = Convert.ToDouble(sueldo.Text);
            _persona.idSede = Convert.ToInt32(sede.SelectedValue);
            _persona.nombre = nombre.Text;
            _persona.correo = correo.Text;
            _persona.telefono = telefono.Text;
            _persona.direccion = direccion.Text;
            _persona.documento = dni.Text;
            _persona.tipoDeDocumento = (tipoDocumento)Enum.Parse(typeof(tipoDocumento), tipo_documento.SelectedValue);

            this.personaBO.persona_modificar(_persona);

        }
    }
}