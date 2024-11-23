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
    public class SedeBO : BaseBO
    {
        public int sede_insertar(sede _sede)
        {
            return this.WsSede.sede_insertar(_sede);
        }
        public int sede_modificar(sede _sede)
        {
            return this.WsSede.sede_modificar(_sede);
        }
        public BindingList<sede> sede_listar()
        {
            sede[] arreglo = this.WsSede.sede_listar();
            return new BindingList<sede>(arreglo);
        }
    }
}