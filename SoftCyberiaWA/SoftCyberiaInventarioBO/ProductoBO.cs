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
    internal class ProductoBO
    {
        private productoWS _productoWS;
        
        public void test()
        {
            _productoWS = WsCliente.getProductoWS();
        }
    }
}
