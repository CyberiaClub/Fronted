using SoftCyberiaBaseBO.CyberiaWS;
using System.ComponentModel;

namespace SoftCyberiaPersonaBO
{
    public class TipoPersonaBO : PersonaBO
    {
        public BindingList<tipoPersona> Tipopersona_listar_roles_trabajadores()
        {
            tipoPersona[] arreglo = wsBase.tipopersona_listar_roles_trabajadores(); ;
            return new BindingList<tipoPersona>(arreglo);
        }
        public tipoPersona Tipopersona_listar_paginas(string rol)
        {
            tipoPersona t;
            t = wsBase.tipopersona_listar_paginas(rol);
            return t;
        }
    }
}
