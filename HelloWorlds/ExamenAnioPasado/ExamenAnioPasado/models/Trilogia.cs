using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAnioPasado
{
    public class Trilogia
    {
        public int id { get; set; }
        private String _nombre; 

        public Trilogia( String nombre , int id)
        {
            this.id = id;
            this._nombre = nombre;
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
