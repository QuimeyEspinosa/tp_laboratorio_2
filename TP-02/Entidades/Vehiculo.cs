using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS0660
#pragma warning disable CS0661

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {     
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        protected EMarca marca;
        protected string chasis;
        protected ConsoleColor color;

        #region Constructores

        /// <summary>
        /// Constructor protegido de Vehiculo (Solo puede ser utilizado por ésta clase y sus clases derivadas)
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        protected Vehiculo(EMarca marca, string chasis, ConsoleColor color)
        {
            this.marca = marca;
            this.chasis = chasis;
            this.color = color;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        public abstract ETamanio Tamanio { get; }

        #endregion

        #region Métodos
        /// <summary>
        /// Muestra todos los datos de un vehículo
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {        
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CHASIS: {this.chasis}");
            sb.AppendLine($"MARCA : {this.marca}");
            sb.AppendLine($"COLOR : {this.color}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del operador string
        /// </summary>
        /// <returns></returns>
        public static explicit operator string (Vehiculo p)
        {
            return p.Mostrar();
        }
        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1.chasis == v2.chasis);
        }
        #endregion
    }
}
