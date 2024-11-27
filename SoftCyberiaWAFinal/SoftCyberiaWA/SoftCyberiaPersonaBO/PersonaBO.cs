using SoftCyberiaBaseBO;
using SoftCyberiaBaseBO.CyberiaWS;
using System;
using System.ServiceModel;

namespace SoftCyberiaPersonaBO
{
    public class PersonaBO : BaseBO
    {
        public int Persona_insertar(persona _persona)
        {
            return wsBase.persona_insertar(_persona);
        }

        public int Persona_modificar(persona _persona)
        {
            return wsBase.persona_modificar(_persona);
        }

        public persona Persona_buscar_por_documento(string _documento)
        {
            return wsBase.persona_buscar_por_documento(_documento);
        }
        public bool Persona_enviar_correo_verificacion(string correo, string token)
        {
            return wsBase.persona_enviar_correo_verificacion(correo, token);
        }
        public int Persona_verificar_correo(string token)
        {
            return wsBase.persona_verificar_correo(token);
        }
        public persona Persona_loguearse(string correo, string contrasena)
        {
            try
            {
                persona _persona = wsBase.persona_loguearse(correo, contrasena);
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

        public int Persona_modficar_usuario(persona _persona)
        {
            try
            {
                int modificacion = wsBase.persona_modificar_usuario(_persona);
                return modificacion;
            }
            catch (FaultException ex)
            {
                return 0;
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