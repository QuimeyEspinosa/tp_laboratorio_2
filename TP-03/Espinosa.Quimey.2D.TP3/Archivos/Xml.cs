using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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
            bool pudoGuardar = false;

            try
            {
                if (archivo != null)
                {
                    using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(T));

                        ser.Serialize(writer, datos);

                        pudoGuardar = true;
                    }
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al intentar guardar archivo xml");
            }

            return pudoGuardar;
        }

        /// <summary>
        /// Lee el archivo .xml.
        /// </summary>
        /// <param name="archivo"> Path del archivo </param>
        /// <param name="datos"> datos leídos </param>
        /// <returns>Retorna true si pudo leer, false si no</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool pudoLeer = false;

            datos = default(T);

            try
            {
                if (File.Exists(archivo))
                {
                    using (XmlTextReader reader = new XmlTextReader(archivo))
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(T));

                        datos = (T)ser.Deserialize(reader);

                        pudoLeer = true;
                    }
                }
            }
            catch (Exception e)
            {

                throw new ArchivosException("Error al intentar leer archivo xml");
            }

            return pudoLeer;
        }
        #endregion
    }
}
