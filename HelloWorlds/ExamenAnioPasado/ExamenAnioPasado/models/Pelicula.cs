using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAnioPasado
{
    public class Pelicula
    {

        private String _nombrePelicula;
        
        public int idtrilogia { get; set; }
        public int id { get; set; }

        

        public Pelicula(String peli, int id, int idtrilogia)
        {
            this._nombrePelicula = peli;
            this.id = id;
            this.idtrilogia = idtrilogia;
        }

        public String nombrePelicula
        {
            get
            {
                return this._nombrePelicula;
            }
            set
            {
                this._nombrePelicula = value;
            }
        }

    }
}
