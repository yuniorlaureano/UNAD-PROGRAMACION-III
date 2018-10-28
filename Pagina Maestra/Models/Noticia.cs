using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pagina_Maestra.Models
{
    public class Noticia
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public string Imagen { get; set; }
        public string Author { get; set; }
    }
}