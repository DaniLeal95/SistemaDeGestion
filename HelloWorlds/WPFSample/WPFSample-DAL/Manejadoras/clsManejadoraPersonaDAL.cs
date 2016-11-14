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
            

            SqlConnection conexion;
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
                                            "=@Telefono where IDPersona=@Id";

                resultado = comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }

                return resultado;
        }
    }
}