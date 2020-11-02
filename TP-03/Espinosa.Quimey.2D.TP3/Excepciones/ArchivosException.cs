using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ArchivosException() : base("Archivo Exception")
        {
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="mensaje"></param>
        public ArchivosException(string mensaje) : base(mensaje)
        {
        }

        /// <summary>
        /// Excepcion que controla si el archivo es null
        /// </summary>
        /// <param name="e"> Excepcion </param>
        public ArchivosException(Exception innerException) : base("Archivo Exception", innerException)
        {
        }

    }
}
