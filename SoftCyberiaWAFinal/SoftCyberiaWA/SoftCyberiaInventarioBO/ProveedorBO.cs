using SoftCyberiaBaseBO;
using SoftCyberiaBaseBO.CyberiaWS;
using System.ComponentModel;

namespace SoftCyberiaInventarioBO
{
    public class ProveedorBO : BaseBO
    {
        public int Proveedor_insertar(proveedor _proveedor)
        {
            return wsBase.proveedor_insertar(_proveedor);
        }

        public int Proveedor_modificar(proveedor _proveedor)
        {
            return wsBase.proveedor_modificar(_proveedor);
        }

        public BindingList<proveedor> Proveedor_listar()
        {
            proveedor[] arreglo = wsBase.proveedor_listar();
            return new BindingList<proveedor>(arreglo);
        }
        public int Proveedor_eliminar(proveedor _proveedor)
        {
            return wsBase.proveedor_eliminar(_proveedor); 
        }
    }
}