using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoBar;
using System.Data.SqlClient;
using ProyectoBarDAL.Conexion;
using ProyectoBar.Conexion;

namespace ProyectoBarDAL.ListadosDAL
{
   public class clsListadosClientesDAL
    {

        /// <summary>
        /// Funcion para que nos devuelva el listado de las personas
        /// </summary>
        /// <returns>Listado de personas</returns>
        public List<clsCliente> getListadoPersonaDAL()
        {
            List<clsCliente> listadoPersonas =new List<clsCliente>();
            
             
            clsMyConnection myconexion = new clsMyConnection();


            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            clsCliente persona;
            SqlDataReader lector = null;

            try
            {
                conexion = myconexion.getConnection();

                comando.CommandText = "select * from personas";
                comando.Connection = conexion;
                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        persona = new clsCliente();
                        
                        persona.id = (int)lector[ColumnasConstantes.colId];
                        persona.nombre = (String)lector[ColumnasConstantes.colNombre];
                        persona.apellido = (String)lector[ColumnasConstantes.colApellidos];
                        persona.fechaNac = (DateTime)lector[ColumnasConstantes.colFechaNac];
                        persona.direccion = (String)lector[ColumnasConstantes.colDireccion];
                        persona.telefono = (String)lector[ColumnasConstantes.colTelefono];
                        listadoPersonas.Add(persona);
                        
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
            return listadoPersonas;
        }
    }
}
