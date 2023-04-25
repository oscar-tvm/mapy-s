using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapysApi.Model
{
    public class Producto
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Precio { get; set; }
        public int CATEGORIAS_CODIGO { get; set; }
        public string Imagen { get; set; }
        public DateTime Fecha { get; set; }
        public int Descuento { get; set; }
    }
}
