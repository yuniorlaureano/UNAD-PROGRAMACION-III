using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pagina_Maestra.Models
{
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Sexo { get; set; }
        public string Cedula { get; set; }
        public string ExperienciaLaboral { get; set; }
        public string Carrera { get; set; }
    }
}