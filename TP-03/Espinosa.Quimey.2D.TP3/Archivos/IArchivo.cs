using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo <T>
    {
        /// <summary>
        /// Guarda en un archivo cualquier tipo de objeto
        /// </summary>
        /// <param name="archivo"> Path del archivo</param>
        /// <param name="datos"> Clase a guardar</param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Lee un archivo y retorna lo que se encuentra en él
        /// </summary>
        /// <param name="archivo"> Path del archivo</param>
        /// <param name="datos"> Clase a leer</param>
        /// <returns></returns>
        bool Leer(string archivo, out T datos);
    }
}
