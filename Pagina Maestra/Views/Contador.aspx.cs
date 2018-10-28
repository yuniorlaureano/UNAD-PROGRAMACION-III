using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pagina_Maestra.Views
{
    public partial class Contador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("d");
        }

        protected void btnIncrementCounter_Click(object sender, EventArgs e)
        {
            lblContatador.Text = IncrementCounter(lblContatador.Text);
        }

        private string IncrementCounter(string counter)
        {
            int intCounter = Convert.ToInt32(counter);
            return (++intCounter).ToString();
        }
    }
}