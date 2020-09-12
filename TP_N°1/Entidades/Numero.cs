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

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        public string SetNumero
        {
            set { numero = ValidarNumero(value); }
        }

        private double ValidarNumero(string strNumero)
        {
            double retorno = 0;

            double.TryParse(strNumero, out retorno);

            return retorno;
        }

        private bool EsBinario(string binario)
        {
            bool retorno = false;

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] == '0' || binario[i] == '1')
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor inválido";
            double numDecimal = 0;
            int incrementoPotencia = 0;

            if (EsBinario(binario))
            {
                for (int i = binario.Length - 1; i >= 0; i--) //Recorro el array de derecha a izquierda
                {
                    if (binario[i] == '1')
                    {
                        numDecimal += Math.Pow(2, incrementoPotencia);
                    }
                    incrementoPotencia++;
                }

                retorno = numDecimal.ToString();
            }

            return retorno;
        }


        public string DecimalBinario(string numero)
        {
            string retorno = "Valor inválido";
            double numDecimal;

            if (double.TryParse(numero, out numDecimal)) //convierto el string en double
            {
                retorno = DecimalBinario(numDecimal);
            }

            return retorno;
        }

        public string DecimalBinario(double numero)
        {
            string retorno = String.Empty;
            string auxBinario = String.Empty;
            int numDecimal = (int)numero;

            if (numDecimal > 0)
            {
                while (numDecimal > 0)
                {
                    if (numDecimal % 2 == 0)
                    {
                        auxBinario = String.Concat(auxBinario, "0");
                    }
                    else
                    {
                        auxBinario = String.Concat(auxBinario, "1");
                    }

                    numDecimal = numDecimal / 2;
                }

                foreach (char invertirBinario in auxBinario)    //
                {                                               //doy vuelta la cadena
                    retorno = invertirBinario + retorno;        //
                }                                               //

            }
            else if (numDecimal == 0)
            {
                retorno = "0";
            }
            else
            {
                retorno = "Valor inválido";
            }

            return retorno;
        }


        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

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
