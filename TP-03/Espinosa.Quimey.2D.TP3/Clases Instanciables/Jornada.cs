using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Clases_Instanciables.Universidad;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        List<Alumno> alumnos;
        EClases clase;
        Profesor instructor;

        #region Constructores

        /// <summary>
        /// Constructor de Jornada privado
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad de lectura y escritura de la lista privada de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado clase
        /// </summary>
        public EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado instructor
        /// </summary>
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Muestra los datos de la Jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder datosJornada = new StringBuilder();

            if (this.Alumnos.Count > 0)
            {
                datosJornada.Append("JORNADA:\n");
                datosJornada.AppendFormat("CLASE DE {0} POR {1}\nALUMNOS:\n", this.Clase.ToString(), this.Instructor.ToString());

                for (int i = 0; i < this.Alumnos.Count; i++)
                {
                    datosJornada.AppendLine($"{this.Alumnos[i]}");
                }

                datosJornada.AppendLine("<------------------------------------------------->");
            }

            return datosJornada.ToString();
        }

        /// <summary>
        /// Guarda el objeto de tipo Jornada en formato texto
        /// </summary>
        /// <param name="jornada">objeto a guardar</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            bool pudoGuardar = false;
            Texto txt = new Texto();
            string path = AppDomain.CurrentDomain.BaseDirectory;

            pudoGuardar = txt.Guardar(path + "Jornada.txt", jornada.ToString());

            return pudoGuardar;
        }

        /// <summary>
        /// Lee el archivo llamado "Jornada.txt"
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Texto txt = new Texto();
            string pudoLeer = null;
            string path = AppDomain.CurrentDomain.BaseDirectory;

            if (txt.Leer(path + @"Jornada.txt", out string auxLectura))
            {
                pudoLeer = auxLectura;
            }

            return pudoLeer;
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Una Jornada será distinta a un Alumno si el mismo no participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega alumnos a la clase validando que no estén previamente cargados
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            for (int i = 0; i < j.alumnos.Count; i++)
            {
                if (j.alumnos[i] != a)
                {
                    j.alumnos.Add(a);
                }
            }

            return j;
        }

        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return a == j.clase;
        }

        #endregion
    }
}
