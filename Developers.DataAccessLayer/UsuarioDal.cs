using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Developers.LayerEntities;
using System.Configuration;
using System.Data.Common;
using System.Data;

namespace Developers.DataAccessLayer
{

    public class UsuarioDal
    {
        //Primero y siguiendo el orden de las acciones CRUD
        //Crearemos un Método que se encarga de insertar un nuevo Pacient es nuestra tabla Pacient
        /// <summary>
        /// Inserta un nuevo Usuario en la tabla Usuario
        /// </summary>
        /// <param name="usuario">Entidad contenedora de los valores a insertar</param>
        /// <autor>Víctor Manuel Villagómez Ramos</autor>
        public void Insert(EUsuario usuario)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Developers.ApplicationProgrammingInterface.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery =
                    "INSERT INTO Usuario (apellidop,apellidom,nombre, sexo) VALUES (@apellidop,@apellidom, @nombre, @sexo)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    //El primero de los cambios significativos con respecto al ejemplo descargado es que aqui...
                    //ya no leeremos controles sino usaremos las propiedades del Objeto EUsuario de nuestra capa
                    ////de entidades...
                    //cmd.Parameters.AddWithValue("@apellidop", usuario.apellidop);
                    //cmd.Parameters.AddWithValue("@apellidom", usuario.apellidom);
                    //cmd.Parameters.AddWithValue("@nombre", usuario.nombre);
                    //cmd.Parameters.AddWithValue("@sexo", usuario.sexo);
                    //cmd.Parameters.AddWithValue("@id", usuario.id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        // Takes a DbConnection, creates and executes a DbCommand. 
        // Assumes SQL INSERT syntax is supported by provider.
        static void ExecuteDbCommand(DbConnection connection)
        {
            // Check for valid DbConnection object.
            if (connection != null)
            {
                using (connection)
                {
                    try
                    {
                        // Open the connection.
                        connection.Open();

                        // Create and execute the DbCommand.
                        DbCommand command = connection.CreateCommand();
                        command.CommandText =
                            "INSERT INTO Categories (CategoryName) VALUES ('Low Carb')";
                        int rows = command.ExecuteNonQuery();

                        // Display number of rows inserted.
                        Console.WriteLine("Inserted {0} rows.", rows);
                    }
                    // Handle data errors.
                    catch (DbException exDb)
                    {
                        Console.WriteLine("DbException.GetType: {0}", exDb.GetType());
                        Console.WriteLine("DbException.Source: {0}", exDb.Source);
                        Console.WriteLine("DbException.ErrorCode: {0}", exDb.ErrorCode);
                        Console.WriteLine("DbException.Message: {0}", exDb.Message);
                    }
                    // Handle all other exceptions.
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception.Message: {0}", ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("Failed: DbConnection is null.");
            }
        }
        // Takes a DbConnection and creates a DbCommand to retrieve data
        // from the Categories table by executing a DbDataReader. 
        static void DbCommandSelect(DbConnection connection)
        {
            string queryString =
                "SELECT * FROM usuarios";

            // Check for valid DbConnection.
            if (connection != null)
            {
                using (connection)
                {
                    try
                    {
                        // Create the command.
                        DbCommand command = connection.CreateCommand();
                        command.CommandText = queryString;
                        command.CommandType = CommandType.Text;

                        // Open the connection.
                        connection.Open();

                        // Retrieve the data.
                        DbDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}. {1}", reader[0], reader[1]);
                        }
                    }

                    catch (Exception ex)
                    {
                       Console.WriteLine("Exception.Message: {0}", ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("Failed: DbConnection is null.");
            }
        }
        /// <summary>
        /// Devuelve una lista de Usuarios ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        /// <autor>José Luis García Bautista</autor>
        public List<EUsuario> GetAll(DbConnection connection)
        {//
            string queryString =
                "SELECT * FROM usuarios ORDER BY idusuario ASC";

            // Check for valid DbConnection.
            if (connection != null)
            {
                using (connection)
                {
                    try
                    {
                        List<EUsuario> usuarios = new List<EUsuario>();
                        // Create the command.
                        DbCommand command = connection.CreateCommand();
                        command.CommandText = queryString;
                        command.CommandType = CommandType.Text;

                        // Open the connection.
                        connection.Open();

                        // Retrieve the data.
                        DbDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            //
                            //Instanciamos al objeto Eusuario para llenar sus propiedades
                            EUsuario usuario = new EUsuario
                            {
                                idusuario = Convert.ToInt32(reader["idusuario"]),
                                usuario = ((reader["usuario"]).ToString()),
                                //foto
                            };
                            //
                            //Insertamos el objeto Usuario dentro de la lista Usuarios
                            usuarios.Add(usuario);
                        }
                        return usuarios;
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception.Message: {0}", ex.Message);
                        return null;
                    }
                }
            }
            else
            {
                Console.WriteLine("Failed: DbConnection is null.");
                return null;
            }
            //
            //Declaramos una lista del objeto EUsuario la cual será la encargada de
            //regresar una colección de los elementos que se obtengan de la BD
            //
            //La lista substituye a DataTable utilizado en el proyecto de ejemplo
            //using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            //const string sqlQuery = "SELECT * FROM usuarios ORDER BY Id ASC";                  
        }



        /// <summary>
        /// Devuelve un Objeto Usuario
        /// </summary>
        /// <param name="idUsuario">Id del usuario a buscar</param>
        /// <returns>Un registro con los valores del Usuario</returns>
        /// <autor>José Luis García Bautista</autor>
        public EUsuario GetByid(int idUsuario, DbConnection connection)
        {
           // string queryString = "SELECT * FROM usuarios WHERE idusuario = @id";
            string queryString = "SELECT * FROM usuarios WHERE idusuario = "+idUsuario+"";

            // Check for valid DbConnection.
            if (connection != null)
            {
                using (connection)
                {
                    try
                    {
                        //List<EUsuario> usuarios = new List<EUsuario>();
                        // Create the command.
                        DbCommand command = connection.CreateCommand();
                        command.CommandText = queryString;
                        command.CommandType = CommandType.Text;

                        // Open the connection.
                        connection.Open();


                        // Retrieve the data.
                        DbDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            //
                            //Instanciamos al objeto Eusuario para llenar sus propiedades
                            EUsuario usuario = new EUsuario
                            {
                                idusuario = Convert.ToInt32(reader["idusuario"]),
                                clave = reader["clave"].ToString(),
                                //foto
                            };
                            //
                            //Insertamos el objeto Usuario dentro de la lista Usuarios
                            //usuarios.Add(usuario);
                        return usuario;
                        }
                        return null;
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception.Message: {0}", ex.Message);
                        return null;
                    }
                }
            }
            else
            {
                Console.WriteLine("Failed: DbConnection is null.");
                return null;
            }
        }

        public EUsuario GetByid2(int idUsuario)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            //using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ToString()))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM usuario WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    //
                    //Utilizamos el valor del parámetro idUsuario para enviarlo al parámetro declarado en la consulta
                    //de selección SQL
                    cmd.Parameters.AddWithValue("@id", idUsuario);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        EUsuario usuario = new EUsuario
                        {
                            idusuario = Convert.ToInt32(dataReader["id"]),


                        };

                        return usuario;
                    }
                }
            }

            return null;
        }
        /// <summary>
        /// Actualiza el Usuario correspondiente al Id proporcionado
        /// </summary>
        /// <param name="usuario">Valores utilizados para hacer el Update al registro</param>
        /// <autor>José Luis García Bautista</autor>
        public void Update(EUsuario usuario)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE usuario SET apellidop = @apellidop,apellidom = @apellidom, nombre = @nombre, idcreson=@idcreson, programa=@programa, grupo= @grupo,matricula=@matricula, curp=@curp, referencia= @referencia, sangre= @sangre, fechanac= @fechanac, sexo= @sexo,nss= @nss, celular= @celular, telefono= @telefono, edonac= @edonac, generacion= @generacion, correo= @correo, bachillerato= @bachillerato, prombachillerato= @prombachillerato, comentario= @comentario, direccion= @direccion, alergia= @alergias, contacto= @contacto WHERE Id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", usuario.idusuario);
                    //cmd.Parameters.AddWithValue("@idcreson", usuario.idcreson);
                    //cmd.Parameters.AddWithValue("@apellidop", usuario.apellidop);
                    //cmd.Parameters.AddWithValue("@apellidom", usuario.apellidom);
                    //cmd.Parameters.AddWithValue("@nombre", usuario.nombre);
                    //cmd.Parameters.AddWithValue("@matricula", usuario.matricula);
                    //cmd.Parameters.AddWithValue("@curp", usuario.curp);
                    //cmd.Parameters.AddWithValue("@referencia", usuario.referencia);
                    //cmd.Parameters.AddWithValue("@programa", usuario.programa);
                    //cmd.Parameters.AddWithValue("@grupo", usuario.grupo);
                    //cmd.Parameters.AddWithValue("@generacion", usuario.generacion);
                    //cmd.Parameters.AddWithValue("@fechanac", usuario.fechaNacimiento);
                    //cmd.Parameters.AddWithValue("@edonac", usuario.edonac);
                    //cmd.Parameters.AddWithValue("@sexo", usuario.sexo);
                    //cmd.Parameters.AddWithValue("@nss", usuario.nss);
                    //cmd.Parameters.AddWithValue("@sangre", usuario.sangre);
                    //cmd.Parameters.AddWithValue("@celular", usuario.telefonoCelular);
                    //cmd.Parameters.AddWithValue("@telefono", usuario.telefonoCasa);
                    //cmd.Parameters.AddWithValue("@correo", usuario.correo);
                    //cmd.Parameters.AddWithValue("@bachillerato", usuario.bachillerato);
                    //cmd.Parameters.AddWithValue("@prombachillerato", usuario.prombachillerato);
                    //cmd.Parameters.AddWithValue("@direccion", usuario.direccion);
                    //cmd.Parameters.AddWithValue("@comentario", usuario.comentario);
                    //cmd.Parameters.AddWithValue("@alergias", usuario.alergias);
                    //cmd.Parameters.AddWithValue("@contacto", usuario.contacto);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Elimina un registro coincidente con el Id Proporcionado
        /// </summary>
        /// <param name="idusuario">Id del registro a Eliminar</param>
        /// <autor>José Luis García Bautista</autor>
        public void Delete(int idusuario)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM usuario WHERE Id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", idusuario);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
