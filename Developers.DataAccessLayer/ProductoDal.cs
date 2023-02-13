using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Developers.LayerEntities;
using System.Configuration;

namespace Developers.DataAccessLayer
{

    public class ProductoDal
    {
        //Primero y siguiendo el orden de las acciones CRUD
        //Crearemos un Método que se encarga de insertar un nuevo Pacient es nuestra tabla Pacient
        /// <summary>
        /// Inserta un nuevo Producto en la tabla Producto
        /// </summary>
        /// <param name="producto">Entidad contenedora de los valores a insertar</param>
        /// <autor>Víctor Manuel Villagómez Ramos</autor>
        public void Insert(EProducto producto)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Developers.ApplicationProgrammingInterface.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery =
                    "INSERT INTO Producto (apellidop,apellidom,nombre, sexo) VALUES (@apellidop,@apellidom, @nombre, @sexo)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    //El primero de los cambios significativos con respecto al ejemplo descargado es que aqui...
                    //ya no leeremos controles sino usaremos las propiedades del Objeto EProducto de nuestra capa
                    ////de entidades...
                    //cmd.Parameters.AddWithValue("@apellidop", producto.apellidop);
                    //cmd.Parameters.AddWithValue("@apellidom", producto.apellidom);
                    //cmd.Parameters.AddWithValue("@nombre", producto.nombre);
                    //cmd.Parameters.AddWithValue("@sexo", producto.sexo);
                    //cmd.Parameters.AddWithValue("@id", producto.id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Devuelve una lista de Productos ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de productos</returns>
        /// <autor>José Luis García Bautista</autor>
        public List<EProducto> GetAll()
        {
            //Declaramos una lista del objeto EProducto la cual será la encargada de
            //regresar una colección de los elementos que se obtengan de la BD
            //
            //La lista substituye a DataTable utilizado en el proyecto de ejemplo
            List<EProducto> productos = new List<EProducto>();
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM producto ORDER BY Id ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        EProducto producto = new EProducto
                        {
                            idproducto = Convert.ToInt32(dataReader["id"]),
                            codigodebarras = Convert.ToString(dataReader["apellidop"]),
                            descripcion = Convert.ToString(dataReader["apellidom"]),
                            precio = Convert.ToString(dataReader["nombre"]),
                            existencia = Convert.ToInt32(dataReader["sexo"]),
                            //foto
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        productos.Add(producto);
                    }
                }
            }
            return productos;
        }
        /// <summary>
        /// Devuelve un Objeto Producto
        /// </summary>
        /// <param name="idProducto">Id del producto a buscar</param>
        /// <returns>Un registro con los valores del Producto</returns>
        /// <autor>José Luis García Bautista</autor>
        public EProducto GetByid(int idProducto)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            //using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ToString()))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM producto WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    //
                    //Utilizamos el valor del parámetro idProducto para enviarlo al parámetro declarado en la consulta
                    //de selección SQL
                    cmd.Parameters.AddWithValue("@id", idProducto);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        EProducto producto = new EProducto
                        {
                            idproducto = Convert.ToInt32(dataReader["id"]),
                            
                         
                        };

                        return producto;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Actualiza el Producto correspondiente al Id proporcionado
        /// </summary>
        /// <param name="producto">Valores utilizados para hacer el Update al registro</param>
        /// <autor>José Luis García Bautista</autor>
        public void Update(EProducto producto)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE producto SET apellidop = @apellidop,apellidom = @apellidom, nombre = @nombre, idcreson=@idcreson, programa=@programa, grupo= @grupo,matricula=@matricula, curp=@curp, referencia= @referencia, sangre= @sangre, fechanac= @fechanac, sexo= @sexo,nss= @nss, celular= @celular, telefono= @telefono, edonac= @edonac, generacion= @generacion, correo= @correo, bachillerato= @bachillerato, prombachillerato= @prombachillerato, comentario= @comentario, direccion= @direccion, alergia= @alergias, contacto= @contacto WHERE Id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", producto.idproducto);
                    //cmd.Parameters.AddWithValue("@idcreson", producto.idcreson);
                    //cmd.Parameters.AddWithValue("@apellidop", producto.apellidop);
                    //cmd.Parameters.AddWithValue("@apellidom", producto.apellidom);
                    //cmd.Parameters.AddWithValue("@nombre", producto.nombre);
                    //cmd.Parameters.AddWithValue("@matricula", producto.matricula);
                    //cmd.Parameters.AddWithValue("@curp", producto.curp);
                    //cmd.Parameters.AddWithValue("@referencia", producto.referencia);
                    //cmd.Parameters.AddWithValue("@programa", producto.programa);
                    //cmd.Parameters.AddWithValue("@grupo", producto.grupo);
                    //cmd.Parameters.AddWithValue("@generacion", producto.generacion);
                    //cmd.Parameters.AddWithValue("@fechanac", producto.fechaNacimiento);
                    //cmd.Parameters.AddWithValue("@edonac", producto.edonac);
                    //cmd.Parameters.AddWithValue("@sexo", producto.sexo);
                    //cmd.Parameters.AddWithValue("@nss", producto.nss);
                    //cmd.Parameters.AddWithValue("@sangre", producto.sangre);
                    //cmd.Parameters.AddWithValue("@celular", producto.telefonoCelular);
                    //cmd.Parameters.AddWithValue("@telefono", producto.telefonoCasa);
                    //cmd.Parameters.AddWithValue("@correo", producto.correo);
                    //cmd.Parameters.AddWithValue("@bachillerato", producto.bachillerato);
                    //cmd.Parameters.AddWithValue("@prombachillerato", producto.prombachillerato);
                    //cmd.Parameters.AddWithValue("@direccion", producto.direccion);
                    //cmd.Parameters.AddWithValue("@comentario", producto.comentario);
                    //cmd.Parameters.AddWithValue("@alergias", producto.alergias);
                    //cmd.Parameters.AddWithValue("@contacto", producto.contacto);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Elimina un registro coincidente con el Id Proporcionado
        /// </summary>
        /// <param name="idproducto">Id del registro a Eliminar</param>
        /// <autor>José Luis García Bautista</autor>
        public void Delete(int idproducto)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM producto WHERE Id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", idproducto);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
