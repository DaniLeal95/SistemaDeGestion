using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using ENT;

namespace Ejercicio2
{
   public class clsListadosCategoriasDAL
    {

        /// <summary>
        ///     Funcion para que nos devuelva el listado de categorias, de la bbdd
        ///         si hay algun error lo devolvera vacio
        /// </summary>
        /// <returns>un list Listado de categorias</returns>
        public List<Categoria> getListadoPersonaDAL()
        {
            List<Categoria> listadocategorias =new List<Categoria>();
            
             
            clsMyConnection myconexion = new clsMyConnection();


            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            Categoria categoria;
            SqlDataReader lector = null;

            try
            {
                conexion = myconexion.getConnection();

                comando.CommandText = "select * from categorias";
                comando.Connection = conexion;
                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        categoria = new Categoria();
                        categoria.idCategoria = (int)lector[ColumnasConstantes.colIdCategoria];
                        categoria.nombreCategoria=(String)lector[ColumnasConstantes.colNombreCategoria];

                        listadocategorias.Add(categoria);
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
            return listadocategorias;
        }
    }
}
