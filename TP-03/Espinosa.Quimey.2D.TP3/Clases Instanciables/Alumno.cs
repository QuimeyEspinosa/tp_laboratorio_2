using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static Clases_Instanciables.Universidad;


namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta { AlDia, Deudor, Becado }

        private EClases claseQueToma;
        EEstadoCuenta estadoCuenta;

        #region Constructores

        /// <summary>
        /// Constructor de instancia de Alumno
        /// </summary>
        public Alumno() : base()
        {
        }

        /// <summary>
        /// Constructor de instancia de Alumno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad">Argentino, Extranjero</param>
        /// <param name="claseQueToma">Programacion, Laboratorio, Legislacion, SPD</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor de instancia de Alumno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad">Argentino, Extranjero</param>
        /// <param name="claseQueToma">Programacion, Laboratorio, Legislacion, SPD</param>
        /// <param name="estadoCuenta">AlDia, Deudor, Becado</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Sobreescritura del método base que muestra todos los datos del Alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder datosAlumno = new StringBuilder();

            datosAlumno.AppendLine($"{base.MostrarDatos()}");
            datosAlumno.AppendLine();
            datosAlumno.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta}");
            datosAlumno.Append(this.ParticiparEnClase());

            return datosAlumno.ToString();
        }

        /// <summary>
        /// Sobreescritura del método base que muestra la clase que toma el Alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder pEnClase = new StringBuilder();

            pEnClase.AppendLine($"TOMA CLASES DE {this.claseQueToma}");

            return pEnClase.ToString();
        }

        /// <summary>
        /// Hace públicos los datos del Alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Un Alumno será distinto a una clase sólo si no la toma
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            bool esDistinto = false;

            if (a.claseQueToma != clase)
            {
                esDistinto = true;
            }

            return esDistinto;
        }

        /// <summary>
        /// Un Alumno será igual a una clase si toma esa clase y su estado de cuenta no es deudor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            bool esIgual = false;

            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                esIgual = true;
            }

            return esIgual;
        }

        #endregion
    }
}
