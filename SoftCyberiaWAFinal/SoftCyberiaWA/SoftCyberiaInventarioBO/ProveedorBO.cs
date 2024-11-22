using SoftCyberiaBaseBO;
using SoftCyberiaBaseBO.CyberiaWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCyberiaInventarioBO
{
    internal class ProveedorBO : BaseBO
    {
        public int proveedor_insertar(proveedor _proveedor)
        {
            return this.WsProveedor.proveedor_insertar(_proveedor);
        }

        public int proveedor_modificar(proveedor _proveedor)
        {
            return this.WsProveedor.proveedor_modificar(_proveedor);
        }
        
        public BindingList<proveedor> proveedor_listar()
        {
            proveedor[] arreglo = this.WsProveedor.proveedor_listar();
            return new BindingList<proveedor>(arreglo);
        }
        public void proveedor_eliminar(proveedor _proveedor)
        {
            this.WsProveedor.proveedor_eliminar(_proveedor); 
        }
    }
}