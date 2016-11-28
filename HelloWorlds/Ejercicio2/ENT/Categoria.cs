using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class Categoria
    {

        public int idCategoria { get; set; }
        public String nombreCategoria { get; set; }

        public Categoria()
        {
            this.idCategoria = 0;
            this.nombreCategoria = null;

        }
        public Categoria(int idCategoria,String nombreCategoria)
        {
            this.idCategoria = idCategoria;
            this.nombreCategoria = nombreCategoria;
        }
    }
}
