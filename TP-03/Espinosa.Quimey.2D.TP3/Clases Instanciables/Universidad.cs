using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }
        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;

        #region Constructores

        /// <summary>
        /// Constructor por defecto que inicializa las listas
        /// </summary>
        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado instructores
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado jornada
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de una jornada
        /// </summary>
        /// <param name="i">Indice donde leer o escribir</param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get { return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Guarda la informacion de la clase Universidad en un archivo .xml
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            bool pudoGuardar = false;

            string path = AppDomain.CurrentDomain.BaseDirectory;

            Xml<Universidad> auxArchivo = new Xml<Universidad>();
            pudoGuardar = auxArchivo.Guardar(path + @"Universidad.xml", uni);

            return pudoGuardar;
        }

        /// <summary>
        /// Lee un archivo serializado .xml y retorna sus datos
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Xml<Universidad> auxArchivo = new Xml<Universidad>();
            string path = AppDomain.CurrentDomain.BaseDirectory;

            if (!auxArchivo.Leer(path + @"Universidad.xml", out Universidad pudoLeer))
            {
                pudoLeer = null;
            }

            return pudoLeer.ToString();
        }

        /// <summary>
        /// Muestra los datos de la universidad
        /// </summary>
        /// <param name="uni">Universidad a mostrar datos</param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder datosUniversidad = new StringBuilder();

            foreach (Jornada j in uni.Jornadas)
            {
                datosUniversidad.AppendLine(j.ToString());
            }

            return datosUniversidad.ToString();
        }

        /// <summary>
        /// Hace públicos los datos de la universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo NO está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool existeAlumno = false;

            foreach (Alumno auxAlum in g.alumnos)
            {
                if (auxAlum == a)
                {
                    existeAlumno = true;
                }
            }
            return existeAlumno;
        }

        /// <summary>
        /// Agrega un alumno a la universidad, si ya existe lanza la excepcion AlumnoRepetidoException
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g == a)
            {
                throw new AlumnoRepetidoException();
            }
            else
            {
                g.Alumnos.Add(a);

            }

            return g;
        }


        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo NO está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool existeProfesor = false;

            foreach (Profesor p in g.profesores)
            {
                if (p == i)
                {
                    existeProfesor = true;
                }
            }
            return existeProfesor;
        }

        /// <summary>
        /// Agrega un profesor a la universidad validando que no esté previamente cargado
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.profesores.Add(i);
            }

            return g;
        }


        /// <summary>
        /// Retorna el profesor que NO puede dictar la clase recibida como parametro
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            Profesor aux = null;

            foreach (Profesor p in g.profesores)
            {
                if (p != clase)
                {
                    aux = p;
                    break;
                }
            }
            return aux;
        }

        /// <summary>
        /// Retorna el profesor que puede dictar la clase recibida como parametro
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor item in g.profesores)
            {
                if (item == clase)
                {
                    return item;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Agrega una clase a una universidad, generando una jornada con el correspondiente profesor los alunmos que toman la clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor auxProfe = g == clase;
            Jornada auxJornada;

            if (auxProfe != null)
            {
                auxJornada = new Jornada(clase, auxProfe);

                for (int i = 0; i < g.alumnos.Count; i++)
                {
                    if (g.alumnos[i] == clase)
                    {
                        auxJornada.Alumnos.Add(g.alumnos[i]);
                    }
                }

                g.jornada.Add(auxJornada);
            }

            return g;
        }

        #endregion
    }
}
