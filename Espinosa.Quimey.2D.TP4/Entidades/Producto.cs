using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Producto
    {
        public enum ETipo
        {
            Cuerdas, Percusion, Teclas, Otros
        }
        int numArticulo;
        ETipo tipoProducto;
        string descripcion;
        float precio;
        int stock;

        #region Constructores

        /// <summary>
        /// Constructor privado de la clase Producto
        /// </summary>
        private Producto()
        {
            this.numArticulo = -1;
            this.descripcion = "Sin asignar";
            this.precio = -1;
            this.stock = -1;
        }

        /// <summary>
        /// Constructor público de la clase Producto
        /// </summary>
        /// <param name="descripcion">Descripción del producto</param>
        /// <param name="precio">Precio del producto</param>
        /// <param name="stock">Stock del producto</param>
        /// <param name="tipoProd">Tipo de producto</param>
        public Producto(ETipo tipoProd, string descripcion, float precio, int stock) : this()
        {
            this.tipoProducto = tipoProd;
            this.descripcion = descripcion;
            this.precio = precio;
            this.stock = stock;
        }

        /// <summary>
        /// Constructor público de la clase Producto
        /// </summary>
        /// <param name="numArticulo">Numero de articulo del producto</param>
        /// <param name="descripcion">Descripción del producto</param>
        /// <param name="precio">Precio del producto</param>
        /// <param name="stock">Stock del producto</param>
        /// <param name="tipoProd">Tipo de producto</param>
        public Producto(int numArticulo, ETipo tipoProd, string descripcion, float precio, int stock) : this()
        {
            this.numArticulo = numArticulo;
            this.tipoProducto = tipoProd;
            this.descripcion = descripcion;
            this.precio = precio;
            this.stock = stock;
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Get de numero de artículo
        /// </summary>
        public int NumArticulo
        {
            get
            {
                return this.numArticulo;
            }
            set
            {
                this.numArticulo = value;
            }
        }

        /// <summary>
        /// Get de tipo de producto
        /// </summary>
        public ETipo Tipo
        {
            get
            {
                return this.tipoProducto;
            }
            set
            {
                this.tipoProducto = value;
            }
        }

        /// <summary>
        /// Get de descripción
        /// </summary>
        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }

        /// <summary>
        /// Get y Set del precio unitario
        /// </summary>
        public float PrecioUnitario
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value;
            }
        }

        /// <summary>
        /// Get y Set de las unidades del producto
        /// </summary>
        public int Unidades
        {
            get
            {
                return this.stock;
            }
            set
            {
                this.stock = value;
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Muestra los datos del Producto
        /// </summary>
        /// <returns>los datos del producto</returns>
        public override string ToString()
        {
            StringBuilder miProd = new StringBuilder();

            miProd.Append($"N° Art: {this.numArticulo} | {this.tipoProducto.ToString()} | {this.descripcion} | ${this.precio} | {this.stock}");

            return miProd.ToString();
        }

        /// <summary>
        /// Devuelve el tipo de producto en base al string recibido
        /// </summary>
        /// <param name="tipo">string recibido</param>
        /// <returns>El tipo de producto, si es inválido devuelve el tipo SinDatos</returns>
        public static Producto.ETipo MapearEnum(string tipo)
        {
            Producto.ETipo miTipo;
            switch (tipo)
            {
                case "Cuerdas":
                    miTipo = Producto.ETipo.Cuerdas;
                    break;
                case "Percusion":
                    miTipo = Producto.ETipo.Percusion;
                    break;
                case "Teclas":
                    miTipo = Producto.ETipo.Teclas;
                    break;
                default:
                    miTipo = Producto.ETipo.Otros;
                    break;
            }
            return miTipo;
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga de operador '==' que verifica si un Producto es igual a otro en base al N°Articulo
        /// </summary>
        /// <param name="unProducto">Producto a buscar</param>
        /// <param name="misProductos">lista de Productos</param>
        /// <returns>True si es igual, false si es distinto</returns>
        public static bool operator ==(Producto unProducto, Producto otroProducto)
        {
            bool retorno = false;

            if (unProducto.numArticulo == otroProducto.numArticulo)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga de operador '!=' que verifica si un Producto es igual a otro en base al N°Articulo
        /// </summary>
        /// <param name="unProducto">Producto a buscar</param>
        /// <param name="misProductos">lista de Productos</param>
        /// <returns>True si es distinto, false si es igual</returns>
        public static bool operator !=(Producto unProducto, Producto otroProducto)
        {
            return !(unProducto == otroProducto);
        }

        /// <summary>
        /// Sobrecarga de operador '==' que verifica si un Producto ya existe en base al Id
        /// </summary>
        /// <param name="unProducto">Producto a buscar</param>
        /// <param name="misProductos">lista de Productos</param>
        /// <returns>True si es igual, false si es distinto</returns>
        public static bool operator ==(Producto unProducto, List<Producto> misProductos)
        {
            bool retorno = false;

            foreach (Producto item in misProductos)
            {
                if (item == unProducto)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga de operador '!=' que verifica si un Producto es distinto a otro en base al Id
        /// </summary>
        /// <param name="unProducto"></param>
        /// <param name="misProductos"></param>
        /// <returns>True si es distinto, false si no</returns>
        public static bool operator !=(Producto unProducto, List<Producto> misProductos)
        {
            return !(unProducto == misProductos);
        }

        /// <summary>
        /// Sobrecarga de operador '+' que agrega un producto a la lista de productos
        /// </summary>
        /// <param name="misProductos">Lista de productos</param>
        /// <param name="unProducto">Producto a agregar</param>
        /// <returns>True si pudo agregar, false si no</returns>
        public static bool operator +(List<Producto> misProductos, Producto unProducto)
        {
            bool retorno = false;

            if (unProducto != misProductos)
            {
                misProductos.Add(unProducto);
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga de operador '-' que resta stock a un producto de la lista de productos
        /// </summary>
        /// <param name="misProductos">Lista de productos</param>
        /// <param name="unProducto">Producto a restar stock</param>
        /// <returns>True si pudo restar, false si no</returns>
        public static bool operator -(List<Producto> misProductos, Producto unProducto)
        {
            bool retorno = false;

            foreach (Producto item in misProductos)
            {
                if (item == unProducto)
                {
                    if(item.Unidades >= unProducto.Unidades)
                    {
                        item.Unidades -= unProducto.Unidades;
                        retorno = true;
                        break;
                    }                    
                }
            }

            return retorno;
        }

        #endregion
    }
}
