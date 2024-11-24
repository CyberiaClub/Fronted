using SoftCyberiaBaseBO.CyberiaWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCyberiaPersonaBO
{
    public class TipoPersonaBO : PersonaBO
    {
        public BindingList<tipoPersona> tipopersona_listar_roles_trabajadores()
        {
            tipoPersona[] arreglo = this.WsTipoPersona.tipopersona_listar_roles_trabajadores(); ;
            return new BindingList<tipoPersona>(arreglo);
        }
        public tipoPersona tipopersona_listar_paginas(string rol)
        {
            tipoPersona t;
            t = this.WsTipoPersona.tipopersona_listar_paginas(rol);
            return t;
        }
    }
}
