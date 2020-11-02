using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        #region METODOS
        /// <summary>
        /// Guarda el archivo en formato serializado .xml.
        /// </summary>
        /// <param name="archivo"> Path del archivo</param>
        /// <param name="datos"> datos a guardar</param>
        /// <returns>Retorna true si pudo guardar, false si no</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool rtn = false;
            try
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                StreamWriter f = new StreamWriter(archivo);
                s.Serialize(f, datos);
                f.Close();
                rtn = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return rtn;
        }

        /// <summary>
        /// Lee el archivo .xml.
        /// </summary>
        /// <param name="archivo"> Path del archivo </param>
        /// <param name="datos"> datos leídos </param>
        /// <returns>Retorna true si pudo leer, false si no</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool rtn = false;

            try
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                StreamReader f = new StreamReader(archivo);
                datos = (T)s.Deserialize(f);
                f.Close();
                rtn = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return rtn;
        }
        #endregion
    }
}
