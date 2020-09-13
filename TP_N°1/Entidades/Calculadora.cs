using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza el calculo de dos objetos en base al operador recibido
        /// </summary>
        /// <param name="num1">Primer objeto a realizar calculo</param>
        /// <param name="num2">Segundo objeto a realizar calculo</param>
        /// <param name="operador">Operador del calculo a realizar</param>
        /// <returns>El resultado del calculo realizado</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            char operacion;

            operacion = Convert.ToChar(operador);          //Convierto el operador a un dato de tipo char
                                                           
            switch (ValidarOperador(operacion))            //
            {                                              //
                case "+":                                  //
                    resultado = num1 + num2;               //
                    break;                                 //
                case "-":                                  //
                    resultado = num1 - num2;               // valido que sea un operador y realizo el calculo en base a su valor
                    break;                                 //
                case "*":                                  //
                    resultado = num1 * num2;               //
                    break;                                 //
                case "/":                                  //
                    resultado = num1 / num2;               //
                    break;                                 //
            }                                              //

            return resultado;                              //retorno el resultado

        }

        /// <summary>
        /// Valida el operador recibido por parámetro
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>Retorna el operador validado, si no es válido retorna "+"</returns>
        private static string ValidarOperador(char operador)
        {
            string retorno = "+";

            if (operador == '-' || operador == '/' || operador == '*')  //
            {                                                           //
                retorno = operador.ToString();                          //si el operador recibido cumple las condiciones, lo asigno al retorno
            }                                                           //

            return retorno;
        }
    }
}
