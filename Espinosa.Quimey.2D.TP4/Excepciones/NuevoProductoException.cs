using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NuevoProductoException : Exception
    {
        /// <summary>
        /// Excepcion que se lanza si no pudo generarse una nueva venta
        /// </summary>
        public NuevoProductoException() : base("No se pudo agregar el producto")
        {
        }
        /// <summary>
        /// Excepcion que se lanza si no pudo generarse una nueva venta
        /// </summary>
        /// <param name="message">mensaje recibido por parámetro</param>
        public NuevoProductoException(string message) : base(message)
        {
        }
    }
}
