using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta
    {
        string nombreCliente;
        List<Producto> prodVendidos;
        float montoTotal;
        int numVenta;

        #region Constructores

        /// <summary>
        /// Constructor privado de clase
        /// </summary>
        private Venta()
        {
            this.nombreCliente = "Sin asignar";
            this.prodVendidos = new List<Producto>();
            this.montoTotal = 0;
            this.numVenta = -1;
        }

        /// <summary>
        /// Constructor parametrizado de clase
        /// </summary>
        /// <param name="nombreCliente"></param>
        /// <param name="prodVendidos"></param>
        /// <param name="montoTotal"></param>
        /// <param name="numVenta"></param>
        public Venta(string nombreCliente, List<Producto> prodVendidos, float montoTotal, int numVenta) : this()
        {
            this.nombreCliente = nombreCliente;
            this.prodVendidos = prodVendidos;
            this.montoTotal = montoTotal;
            this.numVenta = numVenta;
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Get y set del nombre del cliente
        /// </summary>
        public string NombreCliente
        {
            get { return this.nombreCliente; }
            set { this.nombreCliente = value; }
        }

        /// <summary>
        /// Get y set de la lista de productos vendidos
        /// </summary>
        public List<Producto> ProductosVendidos
        {
            get { return this.prodVendidos; }
            set { this.prodVendidos = value; }
        }

        /// <summary>
        /// Get y set del monto total de la venta
        /// </summary>
        public float PrecioTotal
        {
            get { return this.montoTotal; }
            set { this.montoTotal = value; }
        }

        /// <summary>
        /// Get y set del numero de venta
        /// </summary>
        public int NumVenta
        {
            get { return this.numVenta; }
            set { this.numVenta = value; }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Sobrecarga de ToString
        /// </summary>
        /// <returns>Datos de la venta</returns>
        public override string ToString()
        {
            StringBuilder datosVenta = new StringBuilder();

            datosVenta.AppendLine($"Cliente: {this.nombreCliente}");
            datosVenta.Append(this.GetDescripcionVenta());
            datosVenta.AppendLine($"Total: ${this.montoTotal}");
            datosVenta.AppendLine($"N° Venta: {this.numVenta}");
            datosVenta.AppendLine("------------------------------------------------------------------------------");

            return datosVenta.ToString();
        }

        /// <summary>
        /// Devuelve los datos de los productos de la venta
        /// </summary>
        /// <returns></returns>
        public string GetDescripcionVenta()
        {
            StringBuilder descVenta = new StringBuilder();

            foreach (Producto miProd in this.prodVendidos)
            {
                descVenta.AppendLine($"       {miProd}");
            }

            return descVenta.ToString();
        }

        #endregion
    }
}
