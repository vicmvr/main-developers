using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Developers.DataAccessLayer;
using Developers.LayerEntities;

namespace Developers.BusinessLogicLayer
{

    public class ProductoBol
    {
        //Instanciamos nuestra clase ProductoDal para poder utilizar sus miembros
        private ProductoDal _ProductoDal = new ProductoDal();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Registrar(EProducto producto)
        {
            if (Validarproducto(producto))
            {
                if (_ProductoDal.GetByid(producto.idproducto) == null)
                {
                    _ProductoDal.Insert(producto);
                }
                else
                    _ProductoDal.Update(producto);

            }
        }

        public List<EProducto> Todos()
        {
            return _ProductoDal.GetAll();
        }

        public EProducto TraerPorId(int idProducto)
        {
            stringBuilder.Clear();

            if (idProducto == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _ProductoDal.GetByid(idProducto);
            }
            return null;
        }

        public void Eliminar(int idProducto)
        {
            stringBuilder.Clear();

            if (idProducto == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _ProductoDal.Delete(idProducto);
            }
        }

        private bool Validarproducto(EProducto producto)
        {
            stringBuilder.Clear();

            //if (string.IsNullOrEmpty(producto.apellidop)) stringBuilder.Append("El campo apellido es obligatorio");
            //if (string.IsNullOrEmpty(producto.nombre)) stringBuilder.Append(Environment.NewLine + "El campo nombre es obligatorio");
            
            
            //if (producto.direccion <= 0) stringBuilder.Append(Environment.NewLine + "El campo Precio es obligatorio");

            return stringBuilder.Length == 0;
        }
    }
}
