
using ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    public class clsManejadoraProductoDAL
    {
        clsMyConnection miConexion;

        public clsManejadoraProductoDAL()
          {
            miConexion = new clsMyConnection();
          }

        /// <summary>
        /// El metodo obtiene un producto por parametros, e intenta introducirlo en la bbdd,
        ///     si todo va correcto retornará un entero (0 o 1) con el numero de filas afectadas en la bbdd,
        ///     si algo falla en la conexion saltará una excepcion sql.
        ///     Retornara 1 en el caso de que hubiera insertado una fila en la bbdd
        ///     "       " 0 en el caso de que no insertara nada.
        /// </summary>
        /// <param name="producto">Objeto producto que hace refencia al producto a insertar</param>
        /// <returns>Retornara un entero con el numero de filas afectadas en la bbdd :
        ///         1 en el caso de que hubiera insertado una fila en la bbdd
        ///         0 en el caso de que no insertara nada.
        /// </returns>
        public int insertPersona(Producto producto)
        {
            int resultado = 0;

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando;


            try
            {
                conexion = miConexion.getConnection();
                comando = new SqlCommand();

                //Añadimos los parametros
                comando.Parameters.Add("@idCategoria", System.Data.SqlDbType.Int).Value = producto.idCategoria;
                comando.Parameters.Add("@nombreProducto", System.Data.SqlDbType.VarChar).Value = producto.nombreProducto;
              

                //Comando Sql
                comando.CommandText = "Insert Into productos (" + ColumnasConstantes.colIdCategoria + ", " + ColumnasConstantes.colNombreProducto +")" +
                        "Values (@idCategoria,@nombreProducto)";
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

