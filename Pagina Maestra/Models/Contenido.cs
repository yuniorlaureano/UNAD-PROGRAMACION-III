using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pagina_Maestra.Models
{
    public class Contenido
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Asunto { get; set; }
        public string Content { get; set; }
    }
}