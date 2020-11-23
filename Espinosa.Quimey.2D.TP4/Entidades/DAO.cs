using Excepciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entidades
{
    public static class DAO
    {
        static SqlConnection conexionDB;

        #region Constructores

        /// <summary>
        /// Constructor estático de DataAccessObject (DAO)
        /// </summary>
        static DAO()
        {
            conexionDB = new SqlConnection(@"Data Source=DESKTOP-V9PJ831\SQLEXPRESS;" +
                " Initial Catalog=TP4;" +
                " Integrated security=true;");
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Devuelve los productos de la base y los carga en la lista de productos del comercio
        /// </summary>
        public static void GetProductos()
        {
            List<Producto> auxProductos = new List<Producto>();
            SqlCommand comando = new SqlCommand();

            try
            {
                comando.Connection = conexionDB;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM PRODUCTOS";

                if (conexionDB.State != ConnectionState.Open)
                {
                    conexionDB.Open();
                }

                SqlDataReader datosDevueltos = comando.ExecuteReader();

                while (datosDevueltos.Read())
                {
                    auxProductos.Add(new Producto(
                        int.Parse(datosDevueltos["Id"].ToString()),
                        Producto.MapearEnum(datosDevueltos["Tipo"].ToString()),
                        datosDevueltos["Descripcion"].ToString(),
                        float.Parse(datosDevueltos["PrecioUnitario"].ToString()),
                        int.Parse(datosDevueltos["Stock"].ToString())
                        ));
                }
            }
            catch (Exception ex)
            {
                throw new ConexionALaBaseException("No se pudo conectar a la base de datos" + ex.Message.ToString());
            }
            finally
            {
                conexionDB.Close();
            }

            Comercio.MisProductos = auxProductos;
        }

        /// <summary>
        /// Inserta un producto en la base
        /// </summary>
        /// <param name="miProducto">Producto a insertar</param>
        /// <returns>True si pudo insertar, false si no</returns>
        public static bool InsertarProducto(Producto miProducto)
        {
            SqlCommand comando = new SqlCommand();
            bool pudoInsertar = false;
        
            try
            {
                comando.Connection = conexionDB;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "INSERT INTO Productos (Tipo, Descripcion, PrecioUnitario, Stock) VALUES(@Tipo, @Descripcion, @PrecioUnitario, @Stock)";
                comando.Parameters.Clear();
                comando.Parameters.Add(new SqlParameter("@Tipo", miProducto.Tipo.ToString()));
                comando.Parameters.Add(new SqlParameter("@Descripcion", miProducto.Descripcion));
                comando.Parameters.Add(new SqlParameter("@PrecioUnitario", miProducto.PrecioUnitario));
                comando.Parameters.Add(new SqlParameter("@Stock", miProducto.Unidades));

                if (conexionDB.State != ConnectionState.Open)
                {
                    conexionDB.Open();
                }

                comando.ExecuteNonQuery();
                pudoInsertar = true;

            }
            catch (Exception ex)
            {
                throw new ArchivoException("No se pudo conectar a la base de datos" + ex.Message.ToString());
            }
            finally
            {
                conexionDB.Close();
            }

            return pudoInsertar;
        }

        /// <summary>
        /// Aumenta el stock de todos los productos en la base
        /// </summary>
        /// <param name="stock">cantidad a aumentar</param>
        /// <returns>True si pudo aumentar, false si no</returns>
        public static bool AumentarStockProductos(int stock)
        {
            SqlCommand comando = new SqlCommand();
            bool pudoInsertar = false;

            try
            {
                comando.Connection = conexionDB;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "UPDATE Productos SET Stock = Stock + @Stock";
                comando.Parameters.Clear();
                comando.Parameters.Add(new SqlParameter("@Stock", stock));

                if (conexionDB.State != ConnectionState.Open)
                {
                    conexionDB.Open();
                }

                comando.ExecuteNonQuery();
                pudoInsertar = true;
            }
            catch (Exception ex)
            {
                throw new ArchivoException("No se pudo conectar a la base de datos" + ex.Message.ToString());
            }
            finally
            {
                conexionDB.Close();
            }

            return pudoInsertar;
        }

        /// <summary>
        /// Descuenta stock a un producto en base al Id
        /// </summary>
        /// <param name="prodADescontar">Producto a descontar stock</param>
        public static void DescontarStockProducto(Producto prodADescontar)
        {
            SqlCommand comando = new SqlCommand();

            try
            {
                comando.Connection = conexionDB;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "UPDATE Productos SET Stock = Stock - @Stock WHERE Id=@IdProducto";
                comando.Parameters.Clear();
                comando.Parameters.Add(new SqlParameter("@Stock", prodADescontar.Unidades));
                comando.Parameters.Add(new SqlParameter("@IdProducto", prodADescontar.NumArticulo));

                if (conexionDB.State != ConnectionState.Open)
                {
                    conexionDB.Open();
                }

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ArchivoException("No se pudo conectar a la base de datos" + ex.Message.ToString());
            }
            finally
            {
                conexionDB.Close();
            }

        }

        /// <summary>
        /// Obtiene el Id de la última venta
        /// </summary>
        /// <returns></returns>
        public static int GetIdUltimaVenta()
        {
            SqlCommand comando = new SqlCommand();
            int idUltimaVenta = -1;

            try
            {
                comando.Connection = conexionDB;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "select * from Ventas where Id in(select MAX(Id) as maximo from Ventas)";

                if (conexionDB.State != ConnectionState.Open)
                {
                    conexionDB.Open();
                }

                SqlDataReader datosDevueltos = comando.ExecuteReader();

                while (datosDevueltos.Read())
                {
                    idUltimaVenta = int.Parse(datosDevueltos["Id"].ToString());
                }
            }
            catch (ConexionALaBaseException miEx)
            {
                MessageBox.Show(miEx.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                miEx.Guardar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                ex.Guardar();
            }
            finally
            {
                conexionDB.Close();
            }

            return idUltimaVenta;
        }

        /// <summary>
        /// Inserta una venta en la base
        /// </summary>
        /// <param name="miVenta">Venta a insertar</param>
        /// <returns>True si pudo insertar, false si no</returns>
        public static bool InsertarVenta(Venta miVenta)
        {
            SqlCommand comando = new SqlCommand();
            bool pudoInsertar = false;

            try
            {
                comando.Connection = conexionDB;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "INSERT INTO Ventas (NombreCliente, Descripcion, MontoTotal) VALUES(@NombreCliente, @Descripcion, @MontoTotal)";
                comando.Parameters.Clear();
                comando.Parameters.Add(new SqlParameter("@NombreCliente", miVenta.NombreCliente));
                comando.Parameters.Add(new SqlParameter("@Descripcion", miVenta.GetDescripcionVenta()));
                comando.Parameters.Add(new SqlParameter("@MontoTotal", miVenta.PrecioTotal));

                if (conexionDB.State != ConnectionState.Open)
                {
                    conexionDB.Open();
                }

                comando.ExecuteNonQuery();
                pudoInsertar = true;

            }
            catch (Exception ex)
            {
                throw new ArchivoException("No se pudo conectar a la base de datos" + ex.Message.ToString());
            }
            finally
            {
                conexionDB.Close();
            }

            return pudoInsertar;
        }

        #endregion
    }
}
