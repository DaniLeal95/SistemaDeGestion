using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class ProductVM:Producto
    {

        public List<Categoria> categorias { get; set; }
    }
}