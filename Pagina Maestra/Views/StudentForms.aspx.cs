using Pagina_Maestra.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pagina_Maestra.Views
{
    public partial class StudentFormaspx : System.Web.UI.Page
    {
        private StudentTextService studentTextService = new StudentTextService();
        protected void Page_Load(object sender, EventArgs e)
        {
            hideButton();
            var students = GetStudent();
            tblStudents.DataSource = students;
            tblStudents.DataBind();
        }

        public List<Models.Student> GetStudent()
        {
            studentTextService.FileName = "Students.csv";
            studentTextService.FilePath = Server.MapPath("~/App_Data/");
            return studentTextService.GetStudents();
        }

        protected void btnGuardarClick(object sender, EventArgs e)
        {
            if (!checkTerminos.Checked)
            {
                return;
            }

            if (ValidateError())
            {
                return;
            }

            if (studentTextService.GetStudents(textNombre.Value) != null)
            {
                return;
            }

            studentTextService.FileName = "Students.csv";
            studentTextService.FilePath = Server.MapPath("~/App_Data/");

            studentTextService.WriteStudents(new Models.Student
            {
                Name = textNombre.Value,
                Apellido = textApellido.Value,
                Direccion = textDireccion.Value,
                Carrera = textCarrera.Value,
                Cedula = textCedula.Value,
                ExperienciaLaboral = textExperienciaLaboral.Value,
                 Sexo = textSexo.Value
            });

            tblStudents.DataSource = studentTextService.GetStudents();
            tblStudents.DataBind();
            hideButton();
            clearField();
        }

        private void clearField()
        {
            textNombre.Value = "";
            textApellido.Value = "";
            textDireccion.Value = "";
            textSexo.Value = "";
            textCedula.Value = "";
            textCarrera.Value = "";
            textExperienciaLaboral.Value = "";
        }

        protected void btnBorrarClick(object sender, EventArgs e)
        {
            studentTextService.Truncate();
            tblStudents.DataSource = studentTextService.GetStudents();
            tblStudents.DataBind();
            hideButton();
        }

        protected void btnBuscarClick(object sender, EventArgs e)
        {          

            if (string.IsNullOrWhiteSpace(textSearch.Value))
            {
                tblStudents.DataSource = studentTextService.GetStudents();
                tblStudents.DataBind();
                hideButton();
                return;
            }

            var student = studentTextService.GetStudents(textSearch.Value);

            if (student == null)
            {
                clearField();

            }
            else
            {
                textNombre.Value = student.Name;
                textApellido.Value = student.Apellido;
                textDireccion.Value = student.Direccion;
                tblStudents.DataSource = new List<Models.Student> { student };
                tblStudents.DataBind();
            }
            
        }

        protected void btnDouwnloadClick(object sender, EventArgs e)
        {
            if (!studentTextService.FileExists())
            {
                return;
            }
            else
            {
                Response.ContentType = "Application/csv";
                Response.AppendHeader("Content-Disposition", "attachment; filename=student.csv");
                
                Response.TransmitFile("~/App_Data/"+studentTextService.FileName);
                Response.End();
            }            
        }

        private void hideButton()
        {
            // btnDescargar.Visible = false;
            if (!studentTextService.FileExists())
            {
                btnDescargar.Visible = false;
            }
            else
            {
                btnDescargar.Visible = true;
            }
        }

        private bool ValidateError()
        {
            bool errors = false;

            if (string.IsNullOrWhiteSpace(textNombre.Value))
            {
                errors = true;
                lblNombreValidation.Visible = true;
            }
            else
            {
                lblNombreValidation.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(textApellido.Value))
            {
                errors = true;
                lblApellidoValidation.Visible = true;
            }
            else
            {
                lblApellidoValidation.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(textDireccion.Value))
            {
                errors = true;
                lblDireccionValidation.Visible = true;
            }
            else
            {
                lblDireccionValidation.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(textSexo.Value))
            {
                errors = true;
                lblSexo.Visible = true;
            }
            else
            {
                lblSexo.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(textCedula.Value))
            {
                errors = true;
                lblCedula.Visible = true;
            }
            else
            {
                lblCedula.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(textCarrera.Value))
            {
                errors = true;
                lblCarrera.Visible = true;
            }
            else
            {
                lblCarrera.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(textExperienciaLaboral.Value))
            {
                errors = true;
                lblExperienciaLaboral.Visible = true;
            }
            else
            {
                lblExperienciaLaboral.Visible = false;
            }
            
            return errors;
        }
    }
}