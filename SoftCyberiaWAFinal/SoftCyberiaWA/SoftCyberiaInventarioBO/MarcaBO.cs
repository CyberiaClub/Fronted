using SoftCyberiaBaseBO;
using SoftCyberiaBaseBO.CyberiaWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace SoftCyberiaInventarioBO
{
    public class MarcaBO : BaseBO
    {
        public int marca_insertar(marca _marca)
        {
            return this.WsMarca.marca_insertar(_marca);
        }
        public BindingList<marca> marca_listar()
        {
            marca[] arreglo = this.WsMarca.marca_listar();
            return new BindingList<marca>(arreglo);
        }
        public void marca_eliminar(marca _marca)
        {
            this.WsMarca.marca_eliminar(_marca);
        }

    }
}
