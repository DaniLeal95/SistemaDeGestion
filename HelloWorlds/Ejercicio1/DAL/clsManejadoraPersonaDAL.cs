using System;
using System.Data.SqlClient;


namespace Ejercicio1
{
    public class clsManejadoraPersonaDAL
    {
        clsMyConnection miConexion;

        public clsManejadoraPersonaDAL()
        {
            miConexion = new clsMyConnection();
        }

       
      
        /// <summary>
        ///     Obtiene una id por parametros, buscará una persona en la bbdd con ese id, si lo encuentra devolvera esa persona
        ///         si no devolvera una persona vacía, saltará excepcion de sql en caso de algun fallo con la conexion.
        /// </summary>
        /// <param name="id">entero que hace referencia a la id de la persona </param>
        /// <returns>retornara una persona, si todo es correcto una persona de la bbdd segun su id,
        ///         si no hay ninguna persona con esa id retornará una persona vacia.</returns>
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
        ///     Obtiene una id por parametros, buscará una persona en la bbdd con ese id, si lo encuentra devolvera true
        ///         si no devolvera false, saltará excepcion de sql en caso de algun fallo con la conexion.
        /// </summary>
        /// <param name="id">entero que hace referencia a la id de la persona </param>
        /// <returns>retornara un booleando si existe esa persona o no</returns>
        public Boolean existePersona(int id)
        {

            Boolean haypersona = false;

            clsMyConnection myconexion = new clsMyConnection();


            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            SqlDataReader lector = null;
            comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            try
            {
                conexion = myconexion.getConnection();

                comando.CommandText = "select * from personas where IDPersona = @id";
                comando.Connection = conexion;
                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    haypersona = true;
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
            return haypersona;
        }

    }

}