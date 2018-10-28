using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pagina_Maestra.Views
{
    public partial class Repeater : System.Web.UI.Page
    {
        List<Student> students;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["students"] = new List<Student>();
            }
        }

        protected void btnScoreSubmit(object sender, EventArgs e)
        {
            UpdateStudent();
            rptResult.DataSource = students;
            rptResult.DataBind();
        }

        private void UpdateStudent()
        {
            if (Session["students"] != null)
            {
                students = (List<Student>)Session["students"];
            }
            else
            {
                students = new List<Student>();
            }

            students.Add(new Student
            {
                Name = txtNombre.Text,
                Score = Convert.ToInt32(txtNota.Text)
            });

            txtNombre.Text = "";
            txtNota.Text = "";
            Session["students"] = students;
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
}