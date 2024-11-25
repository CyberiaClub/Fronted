using SoftCyberiaBaseBO;
using SoftCyberiaBaseBO.CyberiaWS;
using System.ComponentModel;

namespace SoftCyberiaInventarioBO
{
    public class MarcaBO : BaseBO
    {
        public int Marca_insertar(marca _marca)
        {
            return wsBase.marca_insertar(_marca);
        }
        public BindingList<marca> Marca_listar()
        {
            marca[] arreglo = wsBase.marca_listar();
            return new BindingList<marca>(arreglo);
        }
        public int Marca_eliminar(marca _marca)
        {
            return wsBase.marca_eliminar(_marca);
        }

    }
}
