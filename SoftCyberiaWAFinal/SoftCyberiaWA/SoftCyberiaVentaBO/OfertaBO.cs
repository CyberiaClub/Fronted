using SoftCyberiaBaseBO;
using SoftCyberiaBaseBO.CyberiaWS;
using System.ComponentModel;

namespace SoftCyberiaVentaBO
{
    public class OfertaBO : BaseBO
    {
        public int Oferta_insertar(oferta _oferta, producto[] productosOferta)
        {
            return wsBase.oferta_insertar(_oferta, productosOferta);
        }

        public int Oferta_modificar(oferta _oferta)
        {
            return wsBase.oferta_modificar(_oferta);
        }
        public BindingList<oferta> Oferta_listar()
        {
            oferta[] arreglo = wsBase.oferta_listar();
            return new BindingList<oferta>(arreglo);
        }
    }
}