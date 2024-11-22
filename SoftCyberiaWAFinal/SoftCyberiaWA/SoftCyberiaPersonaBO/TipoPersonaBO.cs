using SoftCyberiaBaseBO.CyberiaWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCyberiaPersonaBO
{
    internal class TipoPersonaBO : PersonaBO
    {
        public BindingList<tipoPersona> tipopersona_listar()
        {
            tipoPersona[] arreglo = this.WsTipoProducto.tipopersona_listar(); ;
            return new BindingList<tipoPersona>(arreglo);
        }
    }
}
