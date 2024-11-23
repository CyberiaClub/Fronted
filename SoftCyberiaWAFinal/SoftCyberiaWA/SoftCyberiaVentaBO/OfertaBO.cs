using SoftCyberiaBaseBO;
using SoftCyberiaBaseBO.CyberiaWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCyberiaVentaBO
{
    public class OfertaBO : BaseBO
    {
        public int oferta_insertar(oferta _oferta)
        {
            return this.WsOferta.oferta_insertar(_oferta);
        }

        public int oferta_modificar(oferta _oferta)
        {
            return this.WsOferta.oferta_modificar(_oferta);
        }
        public BindingList<oferta> oferta_listar()
        {
            oferta[] arreglo = this.WsOferta.oferta_listar();
            return new BindingList<oferta>(arreglo);
        }
    }
}