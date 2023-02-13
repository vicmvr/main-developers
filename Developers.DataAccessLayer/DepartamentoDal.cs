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

    public class DepartamentoDal
    {
        //Primero y siguiendo el orden de las acciones CRUD
        //Crearemos un Método que se encarga de insertar un nuevo Pacient es nuestra tabla Pacient
        /// <summary>
        /// Inserta un nuevo Departamento en la tabla Departamento
        /// </summary>
        /// <param name="departamento">Entidad contenedora de los valores a insertar</param>
        /// <autor>Víctor Manuel Villagómez Ramos</autor>
        public void Insert(EDepartamento departamento)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Developers.ApplicationProgrammingInterface.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery =
                    "INSERT INTO Departamento (apellidop,apellidom,nombre, sexo) VALUES (@apellidop,@apellidom, @nombre, @sexo)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    //El primero de los cambios significativos con respecto al ejemplo descargado es que aqui...
                    //ya no leeremos controles sino usaremos las propiedades del Objeto EDepartamento de nuestra capa
                    ////de entidades...
                    //cmd.Parameters.AddWithValue("@apellidop", departamento.apellidop);
                    //cmd.Parameters.AddWithValue("@apellidom", departamento.apellidom);
                    //cmd.Parameters.AddWithValue("@nombre", departamento.nombre);
                    //cmd.Parameters.AddWithValue("@sexo", departamento.sexo);
                    //cmd.Parameters.AddWithValue("@id", departamento.id);

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
                "SELECT * FROM departamentos";

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
        /// Devuelve una lista de Departamentos ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de departamentos</returns>
        /// <autor>José Luis García Bautista</autor>
        public List<EDepartamento> GetAll(DbConnection connection)
        {//
            string queryString =
                "SELECT * FROM departamentos ORDER BY iddepartamento ASC";

            // Check for valid DbConnection.
            if (connection != null)
            {
                using (connection)
                {
                    try
                    {
                        List<EDepartamento> departamentos = new List<EDepartamento>();
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
                            //Instanciamos al objeto Edepartamento para llenar sus propiedades
                            EDepartamento departamento = new EDepartamento
                            {
                                iddepartamento = Convert.ToInt32(reader["iddepartamento"]),
                                nombre = ((reader["nombre"]).ToString()),
                                //foto
                            };
                            //
                            //Insertamos el objeto Departamento dentro de la lista Departamentos
                            departamentos.Add(departamento);
                        }
                        return departamentos;
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
            //Declaramos una lista del objeto EDepartamento la cual será la encargada de
            //regresar una colección de los elementos que se obtengan de la BD
            //
            //La lista substituye a DataTable utilizado en el proyecto de ejemplo
            //using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            //const string sqlQuery = "SELECT * FROM departamentos ORDER BY Id ASC";                  
        }



        /// <summary>
        /// Devuelve un Objeto Departamento
        /// </summary>
        /// <param name="idDepartamento">Id del departamento a buscar</param>
        /// <returns>Un registro con los valores del Departamento</returns>
        /// <autor>José Luis García Bautista</autor>
        public EDepartamento GetByid(int idDepartamento, DbConnection connection)
        {
           // string queryString = "SELECT * FROM departamentos WHERE iddepartamento = @id";
            string queryString = "SELECT * FROM departamentos WHERE iddepartamento = "+idDepartamento+"";

            // Check for valid DbConnection.
            if (connection != null)
            {
                using (connection)
                {
                    try
                    {
                        //List<EDepartamento> departamentos = new List<EDepartamento>();
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
                            //Instanciamos al objeto Edepartamento para llenar sus propiedades
                            EDepartamento departamento = new EDepartamento
                            {
                                iddepartamento = Convert.ToInt32(reader["iddepartamento"]),
                                nombre = reader["nombre"].ToString(),
                                //foto
                            };
                            //
                            //Insertamos el objeto Departamento dentro de la lista Departamentos
                            //departamentos.Add(departamento);
                        return departamento;
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

        public EDepartamento GetByid2(int idDepartamento)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            //using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ToString()))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM departamento WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    //
                    //Utilizamos el valor del parámetro idDepartamento para enviarlo al parámetro declarado en la consulta
                    //de selección SQL
                    cmd.Parameters.AddWithValue("@id", idDepartamento);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        EDepartamento departamento = new EDepartamento
                        {
                            iddepartamento = Convert.ToInt32(dataReader["id"]),


                        };

                        return departamento;
                    }
                }
            }

            return null;
        }
        /// <summary>
        /// Actualiza el Departamento correspondiente al Id proporcionado
        /// </summary>
        /// <param name="departamento">Valores utilizados para hacer el Update al registro</param>
        /// <autor>José Luis García Bautista</autor>
        public void Update(EDepartamento departamento)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE departamento SET apellidop = @apellidop,apellidom = @apellidom, nombre = @nombre, idcreson=@idcreson, programa=@programa, grupo= @grupo,matricula=@matricula, curp=@curp, referencia= @referencia, sangre= @sangre, fechanac= @fechanac, sexo= @sexo,nss= @nss, celular= @celular, telefono= @telefono, edonac= @edonac, generacion= @generacion, correo= @correo, bachillerato= @bachillerato, prombachillerato= @prombachillerato, comentario= @comentario, direccion= @direccion, alergia= @alergias, contacto= @contacto WHERE Id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", departamento.iddepartamento);
                    //cmd.Parameters.AddWithValue("@idcreson", departamento.idcreson);
                    //cmd.Parameters.AddWithValue("@apellidop", departamento.apellidop);
                    //cmd.Parameters.AddWithValue("@apellidom", departamento.apellidom);
                    //cmd.Parameters.AddWithValue("@nombre", departamento.nombre);
                    //cmd.Parameters.AddWithValue("@matricula", departamento.matricula);
                    //cmd.Parameters.AddWithValue("@curp", departamento.curp);
                    //cmd.Parameters.AddWithValue("@referencia", departamento.referencia);
                    //cmd.Parameters.AddWithValue("@programa", departamento.programa);
                    //cmd.Parameters.AddWithValue("@grupo", departamento.grupo);
                    //cmd.Parameters.AddWithValue("@generacion", departamento.generacion);
                    //cmd.Parameters.AddWithValue("@fechanac", departamento.fechaNacimiento);
                    //cmd.Parameters.AddWithValue("@edonac", departamento.edonac);
                    //cmd.Parameters.AddWithValue("@sexo", departamento.sexo);
                    //cmd.Parameters.AddWithValue("@nss", departamento.nss);
                    //cmd.Parameters.AddWithValue("@sangre", departamento.sangre);
                    //cmd.Parameters.AddWithValue("@celular", departamento.telefonoCelular);
                    //cmd.Parameters.AddWithValue("@telefono", departamento.telefonoCasa);
                    //cmd.Parameters.AddWithValue("@correo", departamento.correo);
                    //cmd.Parameters.AddWithValue("@bachillerato", departamento.bachillerato);
                    //cmd.Parameters.AddWithValue("@prombachillerato", departamento.prombachillerato);
                    //cmd.Parameters.AddWithValue("@direccion", departamento.direccion);
                    //cmd.Parameters.AddWithValue("@comentario", departamento.comentario);
                    //cmd.Parameters.AddWithValue("@alergias", departamento.alergias);
                    //cmd.Parameters.AddWithValue("@contacto", departamento.contacto);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Elimina un registro coincidente con el Id Proporcionado
        /// </summary>
        /// <param name="iddepartamento">Id del registro a Eliminar</param>
        /// <autor>José Luis García Bautista</autor>
        public void Delete(int iddepartamento)
        {
            using (MySqlConnection cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM departamento WHERE Id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", iddepartamento);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
