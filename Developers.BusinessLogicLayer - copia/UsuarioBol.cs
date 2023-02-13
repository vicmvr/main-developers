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

    public class UsuarioBol
    {
        //Instanciamos nuestra clase UsuarioDal para poder utilizar sus miembros
        private UsuarioDal _UsuarioDal = new UsuarioDal();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Usuario, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Registrar(EUsuario usuario, DbConnection cn)
        {
            if (Validarusuario(usuario))
            {
                if (_UsuarioDal.GetByid(usuario.idusuario, cn) == null)
                {
                    _UsuarioDal.Insert(usuario);
                }
                else
                    _UsuarioDal.Update(usuario);

            }
        }

        public List<EUsuario> Todos(DbConnection cn)
        {
            return _UsuarioDal.GetAll(cn);
        }

        public EUsuario TraerPorId(int idUsuario, DbConnection cn)
        {
            stringBuilder.Clear();

            if (idUsuario == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _UsuarioDal.GetByid(idUsuario, cn);
            }
            return null;
        }

        public void Eliminar(int idUsuario)
        {
            stringBuilder.Clear();

            if (idUsuario == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _UsuarioDal.Delete(idUsuario);
            }
        }

        private bool Validarusuario(EUsuario usuario)
        {
            stringBuilder.Clear();

            //if (string.IsNullOrEmpty(usuario.apellidop)) stringBuilder.Append("El campo apellido es obligatorio");
            //if (string.IsNullOrEmpty(usuario.nombre)) stringBuilder.Append(Environment.NewLine + "El campo nombre es obligatorio");
            
            
            //if (usuario.direccion <= 0) stringBuilder.Append(Environment.NewLine + "El campo Precio es obligatorio");

            return stringBuilder.Length == 0;
        }
    }
}
