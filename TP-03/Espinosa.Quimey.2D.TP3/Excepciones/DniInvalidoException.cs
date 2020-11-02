using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Excepcion de dni inválido
        /// </summary>
        public DniInvalidoException() : base("DNI Inválido")
        {
        }

        /// <summary>
        /// Excepcion de dni inválido sin mensaje
        /// </summary>
        /// <param name="e">Excepcion</param>
        public DniInvalidoException(Exception e) : base(e.ToString())
        {
        }

        /// <summary>
        /// Excepcion de dni inválido con mensaje recibido por parametro
        /// </summary>
        /// <param name="message">Mensaje recibido</param>
        public DniInvalidoException(string message) : base(message)
        {
        }

        /// <summary>
        /// Excepcion de dni inválido con mensaje por parámetro mas mensaje base
        /// </summary>
        /// <param name="message">Mensaje recibido</param>
        /// <param name="e">Excepcion</param>
        public DniInvalidoException(string message, Exception e) : this(message + e.ToString())
        {
        }
    }
}
