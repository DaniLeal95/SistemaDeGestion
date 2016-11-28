using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class Producto
    {

        public int idCategoria { get; set; }
        public string nombreProducto { get; set; }
        
        public Producto()
        {
            this.idCategoria = 0;
            
            this.nombreProducto = null;
        }
        public Producto(int idCategoria,string nombreProducto)
        {
            
            this.idCategoria = idCategoria;
            this.nombreProducto = nombreProducto;
        }
    }
}
