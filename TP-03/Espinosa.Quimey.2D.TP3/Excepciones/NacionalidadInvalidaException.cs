using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Excepcion que se lanza si la nacionalidad no es correspondiente con el DNI
        /// </summary>
        public NacionalidadInvalidaException() : base("La nacionalidad no se condice con el número de DNI")
        {
        }
        /// <summary>
        /// Excepcion que se lanza si la nacionalidad no es correspondiente con el DNI con mensaje recibido
        /// </summary>
        /// <param name="message">mensaje recibido por parámetro</param>
        public NacionalidadInvalidaException(string message) : base(message)
        {
        }
    }
}
