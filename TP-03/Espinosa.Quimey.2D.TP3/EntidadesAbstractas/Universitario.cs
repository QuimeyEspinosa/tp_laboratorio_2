using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        int legajo;

        #region Constructores

        /// <summary>
        /// Constructor por defecto hereda de la clase base Persona
        /// </summary>
        public Universitario() : base()
        {
        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad">Argentino, Extranjero</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Sobreescritura del método Equals para comprobar si un objeto es del mismo tipo (universitario)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Universitario;
        }

        /// <summary>
        /// Método protegido virtual que muestra los datos de la clase Universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder datosUniversitario = new StringBuilder();

            datosUniversitario.AppendLine($"{base.ToString()}");
            datosUniversitario.Append($"LEGAJO NúMERO: {this.legajo}");

            return datosUniversitario.ToString();
        }

        /// <summary>
        /// Método protegido abstracto que deben implementar las clases derivadas de Universitario
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        #endregion

        #region Sobrecargas

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Dos Universitario serán iguales si son del mismo Tipo y su Legajo o DNI son iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;

            if (pg1.Equals(pg2))
            {
                if ((pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI))
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        #endregion
    }
}
