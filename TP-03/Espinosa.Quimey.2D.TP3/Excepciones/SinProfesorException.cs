using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Excepcion que muestra un mensaje si no hay un profesor disponible para dar la clase
        /// </summary>
        public SinProfesorException() : base("No hay profesor para la clase.")
        {
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="mensaje"></param>
        public SinProfesorException(string mensaje) : base(mensaje)
        {
        }
    }
}
