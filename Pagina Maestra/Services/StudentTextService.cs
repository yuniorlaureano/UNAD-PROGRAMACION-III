using Pagina_Maestra.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Pagina_Maestra.Services
{
    public class StudentTextService
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FullFile
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.FilePath) || string.IsNullOrWhiteSpace(this.FilePath))
                {
                    return null;
                }

                return this.FilePath + this.FileName;
            }
        }

        public List<Student> GetStudents()
        {
            List<Student> autos = new List<Student>();
            string file = this.FilePath + this.FileName;

            if (!File.Exists(file))
            {
                return new List<Student>();
            }

            TextReader reader = new StreamReader(file);

            string content = reader.ReadLine();

            while (content != null && content != "")
            {
                autos.Add(TransformStudent(content));
                content = reader.ReadLine();
            }

            reader.Close();
            reader.Dispose();

            return autos;
        }

        public Student GetStudents(string name)
        {
            return this.GetStudents().Where(e => e.Name.ToLower().Contains(name.ToLower())).FirstOrDefault();
        }

        public List<string> GetBrands()
        {
            List<string> brands = new List<string>();
            string file = this.FilePath + this.FileName;
            using (TextReader reader = new StreamReader(file))
            {
                string content = reader.ReadLine();

                while (content != null)
                {
                    brands.Add(content);
                    content = reader.ReadLine();
                }
            }

            return brands;
        }

        private Student TransformStudent(string commaseparatedStudent)
        {
            string[] student = commaseparatedStudent.Split(',');
            return new Student()
            {
                Id = Convert.ToInt64(student[0]),
                Name = student[1],
                Apellido = student[2],
                Sexo = student[3],
                Cedula = student[4],
                Direccion = student[5],
                ExperienciaLaboral = student[6],
                Carrera = student[7]
            };
        }

        public void WriteStudents(Student student)
        {
            List<Student> autos = new List<Student>();
            string file = this.FilePath + this.FileName;
            using (TextWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", student.Id, 
                                                                  student.Name, 
                                                                  student.Apellido, 
                                                                  student.Sexo,
                                                                  student.Cedula, 
                                                                  student.Direccion,
                                                                  student.ExperienciaLaboral,
                                                                  student.Carrera));
            }
        }

        public void Truncate()
        {
            if (File.Exists(this.FilePath + this.FileName))
            {
                File.Delete(this.FilePath + this.FileName);
            }
        }

        public bool FileExists()
        {
            return File.Exists(this.FullFile);
        }
    }
}