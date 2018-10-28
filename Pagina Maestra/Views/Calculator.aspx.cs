using Pagina_Maestra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pagina_Maestra.Views
{
    public partial class Calculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {

            
            Numbers numbers = new Numbers
            {
                Number1 = Convert.ToInt32(number1.Text),
                Number2 = Convert.ToInt32(number2.Text),
                Operator = Operator()
            };

            Models.Calculator calculator = new Models.Calculator(numbers);

            lblReuslt.Text = $"El resultado es {calculator.Compute()}";
        }

        private char Operator()
        {
            char _operator = 'x';

            if (radioSuma.Checked)
            {
                _operator = '+';
            }
            else if (radioResta.Checked)
            {
                _operator = '-';
            }
            else if (radioMultiplicacion.Checked)
            {
                _operator = '*';
            }
            else if (radioDivicion.Checked)
            {
                _operator = '/';
            }

            return _operator;
        }
    }
}