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
        public BindingList<tipoPersona> tipopersona_listar()
        {
            tipoPersona[] arreglo = this.WsTipoPersona.tipopersona_listar(); ;
            return new BindingList<tipoPersona>(arreglo);
        }
    }
}
