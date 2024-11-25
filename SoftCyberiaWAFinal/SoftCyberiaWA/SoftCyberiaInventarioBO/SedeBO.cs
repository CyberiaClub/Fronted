using SoftCyberiaBaseBO;
using SoftCyberiaBaseBO.CyberiaWS;
using System.ComponentModel;

namespace SoftCyberiaInventarioBO
{
    public class SedeBO : BaseBO
    {
        public int Sede_insertar(sede _sede)
        {
            return wsBase.sede_insertar(_sede);
        }
        public int Sede_modificar(sede _sede)
        {
            return wsBase.sede_modificar(_sede);
        }
        public BindingList<sede> Sede_listar()
        {
            sede[] arreglo = wsBase.sede_listar();
            return new BindingList<sede>(arreglo);
        }
    }
}