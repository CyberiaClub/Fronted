using SoftCyberiaBaseBO;
using SoftCyberiaBaseBO.CyberiaWS;

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
    }
}