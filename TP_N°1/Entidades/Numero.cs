using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Constructor de clase
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor de clase inicializado por parámetro de tipo double
        /// </summary>
        /// <param name="numero">numero a asignar</param>
        public Numero(double numero) : this()
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor de clase inicializado por parámetro de tipo string
        /// </summary>
        /// <param name="strNumero">numero a asignar</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Propiedad que valida y asigna un valor de tipo double
        /// </summary>
        public string SetNumero
        {
            set { numero = ValidarNumero(value); }
        }

        /// <summary>
        /// Recibe un string y valida que sea un numero
        /// </summary>
        /// <param name="strNumero">numero a validar</param>
        /// <returns>Devuelve el numero de tipo double validado</returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno = 0;

            double.TryParse(strNumero, out retorno);          

            return retorno;
        }

        /// <summary>
        /// Valida que el parámetro string recibido sea un numero binario
        /// </summary>
        /// <param name="binario">numero a convertir</param>
        /// <returns>Devuelve true si es binario, caso contrario devuelve false</returns>
        private bool EsBinario(string binario)
        {
            bool retorno = false;

            for (int i = 0; i < binario.Length; i++)          //Recorro el string
            {                                                 //
                if (binario[i] == '0' || binario[i] == '1')   //verificando que contenga uno o cero
                {                                             //
                    retorno = true;                           //si la condicion se cumple devuelvo true
                }
            }

            return retorno;
        }

        /// <summary>
        /// Convierte un numero binario a numero decimal
        /// </summary>
        /// <param name="binario">numero a convertir</param>
        /// <returns>Si pudo convertir devuelve un string con el numero decimal cargado, caso contrario devuelve un string cargado con "Valor inválido"</returns>
        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor inválido";                          
            double numDecimal = 0;                                      //acumulador del resultado
            int incrementoPotencia = 0;                                 
                                                                        
            if (EsBinario(binario))                                     //Verifico que el parametro recibido sea binario
            {                                                           //
                for (int i = binario.Length - 1; i >= 0; i--)           //recorro el string de derecha a izquierda
                {                                                       //
                    if (binario[i] == '1')                              //si el caracter en el indice i es igual a 1
                    {                                                   //
                        numDecimal += Math.Pow(2, incrementoPotencia);  //elevo la base por la potencia especificada y lo acumulo en numDecimal
                    }                                                   //
                    incrementoPotencia++;                               //incremento la potencia para la proxima iteración
                }                                                       //
                                                                        //
                retorno = numDecimal.ToString();                        //luego de iterar asigno el valor acumulado a retorno
            }

            return retorno;
        }

        /// <summary>
        /// Convierte un numero decimal a numero binario
        /// </summary>
        /// <param name="numero">numero a convertir</param>
        /// <returns>Si pudo convertir devuelve un string con el numero binario cargado, caso contrario devuelve un string cargado con "Valor inválido"</returns>
        public string DecimalBinario(string numero)
        {
            string retorno = "Valor inválido";
            double numDecimal;

            if (double.TryParse(numero, out numDecimal)) //Convierto el string en double
            {                                            //
                retorno = DecimalBinario(numDecimal);    //realizo la conversión de decimal a binario y lo asigno a retorno
            }

            return retorno;
        }

        /// <summary>
        /// Convierte un numero decimal a numero binario
        /// </summary>
        /// <param name="numero">numero a convertir</param>
        /// <returns>Si pudo convertir devuelve un string con el numero binario cargado, caso contrario devuelve un string cargado con "Valor inválido"</returns>
        public string DecimalBinario(double numero)
        {
            string retorno = String.Empty;
            string auxBinario = String.Empty;
            int numDecimal = (int)numero;                               //Convierto el numero de tipo double a tipo entero obteniendo el valor absoluto
                                                                        //
            if (numDecimal > 0)                                         //
            {                                                           //
                while (numDecimal > 0)                                  //itero mientras el numero recibido sea mayor a 0
                {                                                       //
                    if (numDecimal % 2 == 0)                            //si el resto de numDecimal es 0, concateno "0" al string auxBinario
                    {                                                   //
                        auxBinario = String.Concat(auxBinario, "0");    //
                    }                                                   //
                    else                                                //si el resto de numDecimal no es 0, concateno "1" al string auxBinario
                    {                                                   //
                        auxBinario = String.Concat(auxBinario, "1");    //
                    }                                                   //
                                                                        //
                    numDecimal = numDecimal / 2;                        //luego de calcular el resto divido numDecimal para el calculo de la próxima iteración
                }                                                       //

                foreach (char invertirBinario in auxBinario)            //
                {                                                       //doy vuelta la cadena para que se muestre en el orden correcto y la asigno a retorno
                    retorno = invertirBinario + retorno;                //
                }                                                       //

            }
            else if (numDecimal == 0)                                   //si el valor de numDecimal es 0, lo asigno a retorno
            {                                                           //
                retorno = "0";                                          //
            }                                                           //
            else                                                        //si no se cumplen las condiciones anteriores retorno "Valor inválido"
            {                                                           //
                retorno = "Valor inválido";                             //
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador +
        /// </summary>
        /// <param name="n1">primer objeto a sumar</param>
        /// <param name="n2">segundo objeto a sumar</param>
        /// <returns>La suma de los 2 objetos recibidos</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador -
        /// </summary>
        /// <param name="n1">primer objeto a restar</param>
        /// <param name="n2">segundo objeto a restar</param>
        /// <returns>La resta de los 2 objetos recibidos</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador *
        /// </summary>
        /// <param name="n1">primer objeto a multiplicar</param>
        /// <param name="n2">segundo objeto a multiplicar</param>
        /// <returns>La multiplicación de los 2 objetos recibidos</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador /
        /// </summary>
        /// <param name="n1">primer objeto a dividir</param>
        /// <param name="n2">segundo objeto a dividir</param>
        /// <returns>La división de los 2 objetos recibidos</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double resultado;

            if (n2.numero == 0)
            {
                resultado = double.MinValue;
            }
            else
            {
                resultado = n1.numero / n2.numero;
            }

            return resultado;
        }

    }
}
