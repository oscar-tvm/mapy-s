using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapysApi.Model
{
    public class MensajeCliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Ciudad { get; set; }
        public string Telefono { get; set; }
        public string Mensaje { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
