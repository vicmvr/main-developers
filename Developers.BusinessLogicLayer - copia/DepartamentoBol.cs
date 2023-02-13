using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Developers.DataAccessLayer;
using Developers.LayerEntities;

namespace Developers.BusinessLogicLayer
{

    public class DepartamentoBol
    {
        //Instanciamos nuestra clase DepartamentoDal para poder utilizar sus miembros
        private DepartamentoDal _DepartamentoDal = new DepartamentoDal();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Departamento, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Registrar(EDepartamento departamento, DbConnection cn)
        {
            if (Validardepartamento(departamento))
            {
                if (_DepartamentoDal.GetByid(departamento.iddepartamento, cn) == null)
                {
                    _DepartamentoDal.Insert(departamento);
                }
                else
                    _DepartamentoDal.Update(departamento);

            }
        }

        public List<EDepartamento> Todos(DbConnection cn)
        {
            return _DepartamentoDal.GetAll(cn);
        }

        public EDepartamento TraerPorId(int idDepartamento, DbConnection cn)
        {
            stringBuilder.Clear();

            if (idDepartamento == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _DepartamentoDal.GetByid(idDepartamento, cn);
            }
            return null;
        }

        public void Eliminar(int idDepartamento)
        {
            stringBuilder.Clear();

            if (idDepartamento == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _DepartamentoDal.Delete(idDepartamento);
            }
        }

        private bool Validardepartamento(EDepartamento departamento)
        {
            stringBuilder.Clear();

            //if (string.IsNullOrEmpty(departamento.apellidop)) stringBuilder.Append("El campo apellido es obligatorio");
            //if (string.IsNullOrEmpty(departamento.nombre)) stringBuilder.Append(Environment.NewLine + "El campo nombre es obligatorio");
            
            
            //if (departamento.direccion <= 0) stringBuilder.Append(Environment.NewLine + "El campo Precio es obligatorio");

            return stringBuilder.Length == 0;
        }
    }
}
