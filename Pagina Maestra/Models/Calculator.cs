using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pagina_Maestra.Models
{
    public class Calculator
    {
        private Numbers numbers { get; set; }

        public Calculator(Numbers numbers)
        {
            this.numbers = numbers;
        }

        public int Compute()
        {
            int result = 0;
            switch (numbers.Operator)
            {
                case '+':
                    result = numbers.Number1 + numbers.Number2;
                    break;
                case '-':
                    result = numbers.Number1 - numbers.Number2;
                    break;
                case '*':
                    result = numbers.Number1 * numbers.Number2;
                    break;
                case '/':
                    result = numbers.Number1 / numbers.Number2;
                    break;
                default: throw new ArgumentException("Operador desconocido");
            }

            return result;
        }

    }
}