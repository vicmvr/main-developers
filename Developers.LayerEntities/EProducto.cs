using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developers.LayerEntities
{

    public class EProducto
    {
        public int idproducto { get; set; }
        public string codigodebarras { get; set; }
        public string descripcion { get; set; }
        public string precio { get; set; }
        public int existencia { get; set; }
        public int iddepartamento { get; set; }
        
    }
}
