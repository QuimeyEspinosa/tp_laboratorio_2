using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    static class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            char operacion;

            operacion = Convert.ToChar(operador);

            switch (ValidarOperador(operacion))
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }
            return resultado;

        }

        private static string ValidarOperador(char operador)
        {
            string retorno = "+";

            if (operador == '-' || operador == '/' || operador == '*')
            {
                retorno = operador.ToString();
            }

            return retorno;
        }
    }
}
