using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Developers
{
    class Producto
    {
        public string ID_Producto { get; set; }
        public string Descripcion { get; set; }
        public double PrecioContado { get; set; }
        public double PrecioCredito { get; set; }
        public string Departamento { get; set; }
        public int ExistenciaMinima { get; set; }
        public int ExistenciaMaxima { get; set; }
        public double Impuesto { get; set; }
        public double Descuento { get; set; }
        public int ExistenciasAlmacen { get; set; }
        public int idDepartamento { get; set; }
        public int cantidad { get; set; }
        public int ID_Existencias { get; set; }

    }
}
