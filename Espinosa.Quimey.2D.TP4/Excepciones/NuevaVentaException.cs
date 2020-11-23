using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NuevaVentaException : Exception
    {
        /// <summary>
        /// Excepcion que se lanza si no pudo generarse una nueva venta
        /// </summary>
        public NuevaVentaException() : base("No se pudo concretar la venta")
        {
        }
        /// <summary>
        /// Excepcion que se lanza si no pudo generarse una nueva venta
        /// </summary>
        /// <param name="message">mensaje recibido por parámetro</param>
        public NuevaVentaException(string message) : base(message)
        {
        }
    }
}
