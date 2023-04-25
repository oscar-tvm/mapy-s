using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapysApi.Model
{
    public class ProductoCategoria
    {
        public int Codigo { get; set; }
        public string NombreCategoria { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int Descuento { get; set; }
    }
}
