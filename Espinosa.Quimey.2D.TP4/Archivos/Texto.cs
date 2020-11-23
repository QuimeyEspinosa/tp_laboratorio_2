using Excepciones;
using System;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region METODOS

        /// <summary>
        /// Guarda información en un archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            bool pudoGuardar = false;

            try
            {
                if (!String.IsNullOrEmpty(archivo) && !String.IsNullOrEmpty(datos))
                {
                    using (StreamWriter sw = new StreamWriter(archivo, false))
                    {
                        sw.WriteLine(datos);
                    }

                    pudoGuardar = true;
                }
                else
                {
                    throw new ArchivoException("No se pudo guardar el archivo");
                }
            }
            catch (Exception ex)
            {
                throw new ArchivoException("No se pudo guardar el archivo" + ex.Message);
            }

            return pudoGuardar;
        }

        /// <summary>
        /// Lee información de un archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            bool pudoLeer = false;
            datos = string.Empty;

            try
            {
                if (File.Exists(archivo))
                {
                    using (StreamReader sr = new StreamReader(archivo))
                    {
                        datos = sr.ReadToEnd();
                        pudoLeer = true;
                    }
                }
                else
                {
                    throw new ArchivoException("No se pudo leer el archivo");
                }
            }
            catch (Exception ex)
            {
                throw new ArchivoException("No se pudo leer el archivo" + ex.Message);
            }

            return pudoLeer;
        }

        #endregion
    }
}
