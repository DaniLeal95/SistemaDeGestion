using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSample_Ent;
using System.Data.SqlClient;

namespace WPFSample
{
   public class clsListadosPersonasDAL
    {

        /// <summary>
        /// Funcion para que nos devuelva el listado de las personas
        /// </summary>
        /// <returns>Listado de personas</returns>
        public List<clsPersona> getListadoPersonaDAL()
        {
            List<clsPersona> listadoPersonas =new List<clsPersona>();
            
             
            clsMyConnection myconexion = new clsMyConnection();


            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            clsPersona persona;
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
                        persona = new clsPersona();
                        persona.id = (int)lector[Conexion.ColumnasConstantes.colId];
                        persona.nombre = (String)lector[Conexion.ColumnasConstantes.colNombre];
                        persona.apellido = (String)lector[Conexion.ColumnasConstantes.colApellidos];
                        persona.fechaNac = (DateTime)lector[Conexion.ColumnasConstantes.colFechaNac];
                        persona.direccion = (String)lector[Conexion.ColumnasConstantes.colDireccion];
                        persona.telefono = (String)lector[Conexion.ColumnasConstantes.colTelefono];
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
