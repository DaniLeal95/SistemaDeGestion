using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSample;
using WPFSample.Conexion;
using WPFSample_Ent;

namespace WPFSample_DAL.Manejadoras
{
    public class clsManejadoraPersonaDAL
    {
        clsMyConnection miConexion;

        public clsManejadoraPersonaDAL()
        {
            miConexion = new clsMyConnection();
        }

        /// <summary>
        ///  añade una persona a la base de datos
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public int insertPersona(clsPersona persona)
        {
            int resultado = 0;

            SqlConnection conexion;
            SqlCommand comando;
           

            try
            {
                conexion = miConexion.getConnection();
                comando = new SqlCommand();

                //Añadimos los parametros
                comando.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = persona.nombre;
                comando.Parameters.Add("@Apellidos", System.Data.SqlDbType.VarChar).Value = persona.apellido;
                comando.Parameters.Add("@FechaNac", System.Data.SqlDbType.VarChar).Value = persona.fechaNac;
                comando.Parameters.Add("@Direccion", System.Data.SqlDbType.VarChar).Value = persona.direccion;
                comando.Parameters.Add("@Telefono", System.Data.SqlDbType.VarChar).Value = persona.telefono;

                //Comando Sql
                comando.CommandText = "Insert Into personas (" + ColumnasConstantes.@colNombre + ", " + ColumnasConstantes.@colApellidos + "," +
                    ColumnasConstantes.@colFechaNac + "," + ColumnasConstantes.@colDireccion + "," + ColumnasConstantes.@colTelefono + ")"+
                        "Values (@Nombre, @Apellidos,@FechaNac,@Direccion,@Telefono)";
                comando.Connection = conexion;
                resultado = comando.ExecuteNonQuery();


            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                //conexion.Close();
            }

            

            return resultado;
        }


        /// <summary>
        ///     Este metodo actualizara una persona de la base de datos segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int updatePersona(clsPersona persona)
        {
            int resultado=-1;
            

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando;


            try
            {
                conexion = miConexion.getConnection();
                comando = new SqlCommand();

                //Añadimos los parametros
                comando.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = persona.id;
                comando.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = persona.nombre;
                comando.Parameters.Add("@Apellidos", System.Data.SqlDbType.VarChar).Value = persona.apellido;
                comando.Parameters.Add("@FechaNac", System.Data.SqlDbType.VarChar).Value = persona.fechaNac;
                comando.Parameters.Add("@Direccion", System.Data.SqlDbType.VarChar).Value = persona.direccion;
                comando.Parameters.Add("@Telefono", System.Data.SqlDbType.VarChar).Value = persona.telefono;

                //Comando Sql
                comando.CommandText = "Update Personas set " + ColumnasConstantes.colNombre +
                                            "=@Nombre, " + ColumnasConstantes.colApellidos +
                                            "=@Apellidos, " + ColumnasConstantes.colFechaNac +
                                            "=@FechaNac, " + ColumnasConstantes.colDireccion +
                                            "=@Direccion, " + ColumnasConstantes.colTelefono +
                                            "=@Telefono where IDPersona="+persona.id;
                comando.Connection = conexion;
                resultado = comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }

                return resultado;
        }
        /// <summary>
        /// Devuelve una persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsPersona getPersona(int id)
        {
            clsPersona persona = new clsPersona();


            clsMyConnection myconexion = new clsMyConnection();


            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            
            SqlDataReader lector = null;
            comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value=id;
            try
            {
                conexion = myconexion.getConnection();

                comando.CommandText = "select * from personas where IDPersona = @id";
                comando.Connection = conexion;
                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        
                        persona.id = (int)lector[ColumnasConstantes.colId];
                        persona.nombre = (String)lector[ColumnasConstantes.colNombre];
                        persona.apellido = (String)lector[ColumnasConstantes.colApellidos];
                        persona.fechaNac = (DateTime)lector[ColumnasConstantes.colFechaNac];
                        persona.direccion = (String)lector[ColumnasConstantes.colDireccion];
                        persona.telefono = (String)lector[ColumnasConstantes.colTelefono];
                        
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (lector != null)
                {
                    lector.Close();
                }
                myconexion.closeConnection(ref conexion);
            }
            return persona;
        }


        /// <summary>
        /// Borra a una persona segun la id que nos envien
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int deletePerson(int id)
        {
            int resultado = 0;

            clsMyConnection myconexion = new clsMyConnection();


            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            try
            {
                conexion = miConexion.getConnection();
                comando = new SqlCommand();


                //Comando Sql
                comando.CommandText = "Delete from personas Where IDPersona = "+id;
                comando.Connection = conexion;

                resultado = comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;


            
        }

         
    }

}