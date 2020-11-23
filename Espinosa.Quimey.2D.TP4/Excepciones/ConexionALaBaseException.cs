using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ConexionALaBaseException : Exception
    {
        /// <summary>
        /// Excepcion que se lanza si no pudo conectarse a la base de datos
        /// </summary>
        public ConexionALaBaseException() : base("No se pudo conectar a la base de datos")
        {
        }
        /// <summary>
        /// Excepcion que se lanza si no pudo conectarse a la base de datos
        /// </summary>
        /// <param name="message">mensaje recibido por parámetro</param>
        public ConexionALaBaseException(string message) : base(message)
        {
        }
    }
}
