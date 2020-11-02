using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
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
                StreamWriter file = new StreamWriter(archivo);
                file.Write(datos);
                file.Close();
                pudoGuardar = true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
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

            try
            {
                StreamReader file = new StreamReader(archivo);
                datos = file.ReadToEnd();
                file.Close();
                pudoLeer = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return pudoLeer;
        }
    }
}
