using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Clases_Instanciables.Universidad;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<EClases> clasesDelDia;
        private static Random random;

        #region Constructores

        /// <summary>
        /// Constructor estático de clase
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor de clase privado
        /// </summary>
        private Profesor() : base()
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }

        /// <summary>
        /// Constructor de instancia público
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad">Argentino, Extranjero</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Profesor().clasesDelDia;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método que asigna dos clases a un profesor
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                clasesDelDia.Enqueue((EClases)random.Next(0, 3));
            }
        }

        /// <summary>
        /// Sobreescritura del método base que muestra todos los datos del Profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder datosProfesor = new StringBuilder();

            datosProfesor.AppendLine(base.MostrarDatos());
            datosProfesor.AppendLine(this.ParticiparEnClase());

            return datosProfesor.ToString();
        }

        /// <summary>
        /// Retorna la cadena "CLASES DEL DÍA" junto al nombre de las clases que da
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder pEnClase = new StringBuilder();

            pEnClase.AppendLine("CLASES DEL DIA: ");
            foreach (EClases c in this.clasesDelDia)
            {
                pEnClase.AppendLine(c.ToString());
            }

            return pEnClase.ToString();
        }

        /// <summary>
        /// Hace públicos los datos del Profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Profesor será distinto a una clase si no la dicta
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Profesor será igual a una clase si la dicta
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            bool esIgual = false;

            foreach (EClases c in i.clasesDelDia)
            {
                if (c == clase)
                {
                    esIgual = true;
                }
            }

            return esIgual;
        }

        #endregion
    }
}
