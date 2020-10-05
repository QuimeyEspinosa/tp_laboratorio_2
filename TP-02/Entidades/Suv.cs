using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Suv : Vehiculo
    {
        #region Constructores

        /// <summary>
        /// Constructor de clase
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Suv(EMarca marca, string chasis, ConsoleColor color) : base(marca, chasis, color)
        {            
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Las SUV son de tamaño 'Grande'
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Muestra los datos del vehículo a través de un StringBuilder
        /// </summary>
        /// <returns>String con los datos</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("\n---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
