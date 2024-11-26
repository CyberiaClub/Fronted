using SoftCyberiaBaseBO;
using SoftCyberiaBaseBO.CyberiaWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SoftCyberiaPersonaBO
{
    public class PersonaBO : BaseBO
    {
        public int persona_insertar(persona _persona)
        {
            return this.WsPersona.persona_insertar(_persona);
        }

        public int persona_modificar(persona _persona)
        {
            return this.WsPersona.persona_modificar(_persona);
        }

        public persona persona_buscar_por_documento(string _documento)
        {
            return this.WsPersona.persona_buscar_por_documento(_documento);
        }
        public Boolean persona_enviar_correo_verificacion(string correo, string token)
        {
            return this.WsPersona.persona_enviar_correo_verificacion(correo, token);
        }
        public int persona_verificar_correo(string token)
        {
            return this.WsPersona.persona_verificar_correo(token);
        }
        public persona persona_loguearse(string correo, string contrasena)
        {
            try
            {
                persona _persona = this.WsPersona.persona_loguearse(correo, contrasena);
                return _persona ?? null;
            }
            catch (FaultException ex)
            {
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //public byte[] reporteTopClientes()
        //{
        //    return this.WsProducto.reporteTopClientes();
        //}
    }
}