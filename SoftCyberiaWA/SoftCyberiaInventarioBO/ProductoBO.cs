using SoftCyberiaBaseBO;
using SoftCyberiaBaseBO.CyberiaWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SoftCyberiaInventarioBO
{
    internal class ProductoBO : BaseBO
    {
        public int insertar(producto _producto)
        {
            return this.WsProducto.producto_insertar(prod)
        }
    }
}
