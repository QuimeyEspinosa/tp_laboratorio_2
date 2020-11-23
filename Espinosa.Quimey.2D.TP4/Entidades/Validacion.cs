using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Validacion
    {
        #region ValidarNumero

        /// <summary>
        /// valida que el numero ingresado sea positivo
        /// </summary>
        /// <param name="numero1">numero de tipo int</param>
        /// <returns>true si es positivo, false si no</returns>
        public static bool EsPositivo(int numero1)
        {
            bool retorno = false;

            if (numero1 >= 0)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// valida que el numero ingresado sea positivo
        /// </summary>
        /// <param name="numero1">numero de tipo double</param>
        /// <returns>true si es positivo, false si no</returns>
        public static bool EsPositivo(double numero1)
        {
            bool retorno = false;

            if (numero1 >= 0)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// valida que el numero ingresado sea positivo
        /// </summary>
        /// <param name="numero1">numero de tipo string</param>
        /// <returns>true si es positivo, false si no</returns>
        public static bool EsPositivo(string numero1)
        {
            bool retorno = false;

            int numValidado = 0;

            int.TryParse(numero1, out numValidado);

            if (numValidado >= 0)
            {
                retorno = true;
            }

            return retorno;
        }

        #endregion

        #region LeavesForm

        /// <summary>
        /// "Normaliza" la cadena recibida por parámetro
        /// </summary>
        /// <param name="cadenaRecibida"></param>
        /// <returns>la cadena normalizada</returns>
        public static string AsignarLeaveString(string cadenaRecibida)
        {
            int posicion = 1;

            cadenaRecibida.Trim();
            cadenaRecibida.ToLower();

            //Si el texto tiene al menos 2 caracteres
            if (cadenaRecibida.Length > 1)
            {
                //Convierto en mayúscula el primer caracter del string
                cadenaRecibida = Char.ToUpper(cadenaRecibida[0]) + cadenaRecibida.Substring(1);

                while (cadenaRecibida.IndexOf(' ', posicion) > 0)
                {
                    //String ejemplo: "homero simpson"

                    //Le asigno a posicion el lugar donde se encuentra el espacio ' '
                    posicion = cadenaRecibida.IndexOf(' ', posicion);

                    //Asigno la siguiente concatenacion
                    cadenaRecibida = String.Concat(
                        //Homero
                        cadenaRecibida.Substring(0, posicion + 1),
                        //S
                        Char.ToUpper(cadenaRecibida[posicion + 1]),
                        //impson
                        cadenaRecibida.Substring(posicion + 2));

                    posicion++;
                }

                //resultado: Homero Simpson
            }

            return cadenaRecibida;
        }

        /// <summary>
        /// "Normaliza" el numero pasado por parámetro y que no sea posible ingresar más de un número
        /// ejemplo (int id = 12  34) borra el 34
        /// </summary>
        /// <param name="numeroRecibido"></param>
        /// <returns>el número normalizado</returns>
        public static string AsignarLeaveStringNumero(string numeroRecibido)
        {
            numeroRecibido.Trim();

            for (int i = 0; i < numeroRecibido.Length; i++)
            {
                if (numeroRecibido[i].ToString() == " ")
                {
                    numeroRecibido = numeroRecibido.Remove(i);
                }
            }

            if (!EsPositivo(numeroRecibido))
            {
                numeroRecibido = "0";
            }

            return numeroRecibido;
        }

        #endregion
    }
}

