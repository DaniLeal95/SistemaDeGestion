using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAnioPasado
{
    public class Personaje
    {

        private String _nombre;
        public int id { get; set; }
        public int idpelicula { get; set; }
        public string musica { get; set; }

        public Personaje(String name, int id, int idpelicula,string musica)
        {
            this._nombre = name;
            this.id = id;
            this.idpelicula = idpelicula;
            this.musica = musica;
        }

        public String nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = value;
            }
        }
    }
}
