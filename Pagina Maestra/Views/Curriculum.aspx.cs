using Pagina_Maestra.Models;
using Pagina_Maestra.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pagina_Maestra.Views
{
    public partial class CurriculumFormaspx : System.Web.UI.Page
    {
        private CurriculumnContext context = new CurriculumnContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var students = context.Cvs.ToList();
                tblStudents.DataSource = students;
                tblStudents.DataBind();
            }

            var id = Request.QueryString["id"];
            if (!string.IsNullOrWhiteSpace(id))
            {
                var cv = context.Cvs.FirstOrDefault(c => c.Id == new Guid(id));
                if (cv != null)
                {
                    context.Cvs.Remove(cv);
                    context.SaveChanges();
                }
                Response.Redirect("Curriculum");
            }
        }
        
        protected void btnGuardarClick(object sender, EventArgs e)
        {
            var id = hiddenId.Value;

            if (string.IsNullOrWhiteSpace(id))
            {
                if (!checkTerminos.Checked)
                {
                    return;
                }
            }

            if (ValidateError())
            {
                return;
            }

            

            if (string.IsNullOrWhiteSpace(id))
            {
                context.Cvs.Add(new Cv
                {
                    Name = textNombre.Value,
                    Apellido = textApellido.Value,
                    Direccion = textDireccion.Value,
                    Carrera = textCarrera.Value,
                    Cedula = textCedula.Value,
                    ExperienciaLaboral = textExperienciaLaboral.Value,
                    Sexo = textSexo.Value
                });
            }
            else
            {
                var cv = context.Cvs.FirstOrDefault(c => c.Id == new Guid(id));
                if (cv != null)
                {
                    cv.Name = textNombre.Value;
                    cv.Apellido = textApellido.Value;
                    cv.Direccion = textDireccion.Value;
                    cv.Carrera = textCarrera.Value;
                    cv.Cedula = textCedula.Value;
                    cv.ExperienciaLaboral = textExperienciaLaboral.Value;
                    cv.Sexo = textSexo.Value;
                }
            }


            context.SaveChanges();
            tblStudents.DataSource = context.Cvs.ToList();
            tblStudents.DataBind();
            clearField();
        }

        private void clearField()
        {
            hiddenId.Value = "";
            textNombre.Value = "";
            textApellido.Value = "";
            textDireccion.Value = "";
            textSexo.Value = "";
            textCedula.Value = "";
            textCarrera.Value = "";
            textExperienciaLaboral.Value = "";
        }


        protected void btnBuscarClick(object sender, EventArgs e)
        {   
            var _cv = context.Cvs.Where(cv => cv.Name == textSearch.Value).FirstOrDefault();

            if (_cv == null)
            {
                clearField();
            }
            else
            {
                textNombre.Value = _cv.Name;
                textApellido.Value = _cv.Apellido;
                textDireccion.Value = _cv.Direccion;
                tblStudents.DataSource = new List<Cv> { _cv };
                tblStudents.DataBind();
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