using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Excepcion de alumno repetido
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno repetido")
        {
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="mensaje"></param>
        public AlumnoRepetidoException(string message) : base(message)
        {
        }
    }
}
