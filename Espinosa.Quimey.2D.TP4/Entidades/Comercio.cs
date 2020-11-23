using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entidades
{
    //Delegados de la clase Comercio
    public delegate void MiComercio();
    public delegate bool MiTransaccion(Venta miVenta);

    public static class Comercio
    {
        static public event MiComercio CargarComercio;
        static public event MiTransaccion RealizarVenta;

        static Queue<Venta> ventasEntregadas;
        static List<Producto> misProductos;
        static Queue<Venta> ventasPendientes;

        #region Constructores

        /// <summary>
        /// Constructor estático de Comercio
        /// Asigna los manejadores de los eventos e instancia las listas/queues
        /// </summary>
        static Comercio()
        {
            misProductos = new List<Producto>();
            ventasPendientes = new Queue<Venta>();
            ventasEntregadas = new Queue<Venta>();

            CargarComercio += DAO.GetProductos;
            CargarComercio += CargarVentasPendientesXml;

            RealizarVenta += DAO.InsertarVenta;
            RealizarVenta += GenerarTicketVenta;
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Get de los productos del comercio
        /// </summary>
        public static List<Producto> MisProductos
        {
            get { return misProductos; }
            set { misProductos = value; }
        }

        /// <summary>
        /// Get de las ventas pendientes del comercio
        /// </summary>
        public static Queue<Venta> VentasPendientes
        {
            get { return ventasPendientes; }
        }

        /// <summary>
        /// Get de las ventas entregadas del comercio
        /// </summary>
        public static Queue<Venta> VentasEntregadas
        {
            get { return ventasEntregadas; }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Invoca al evento CargarComercio
        /// </summary>
        public static void Iniciar()
        {
            CargarComercio.Invoke();
        }

        /// <summary>
        /// Método que ejecutan los threads.
        /// Simula entregar una venta cada 4 segundos
        /// </summary>
        public static void EntregarVentas()
        {
            do
            {
                if (ventasPendientes.Count > 0)
                {
                    Thread.Sleep(4000);
                    ventasEntregadas.Enqueue(ventasPendientes.Dequeue());
                }
                else
                {
                    Thread.Sleep(4000);
                }

            } while (true);
        }

        #region Productos

        /// <summary>
        /// Agrega un producto a la base y a la lista de productos
        /// </summary>
        /// <param name="nuevoProd">Producto a agregar</param>
        /// <returns>True si pudo agregar, false si no</returns>
        public static bool AgregarProducto(Producto nuevoProd)
        {
            bool pudoAgregar = false;
            DAO.GetProductos();

            if (!(nuevoProd is null))
            {
                if(MisProductos + nuevoProd)
                {
                    if (DAO.InsertarProducto(nuevoProd))
                    {
                        pudoAgregar = true;
                        DAO.GetProductos();
                    }
                    else
                    {
                        throw new NuevoProductoException("No se pudo agregar el nuevo producto");
                    }
                }                
            }
            else
            {
                throw new NuevoProductoException("El producto es nulo");
            }

            return pudoAgregar;
        }

        /// <summary>
        /// Genera un numero aleatorio de stock y lo suma a todos los productos de la base
        /// </summary>
        public static void AgregarStock()
        {
            Random nRand = new Random(DateTime.Now.Millisecond);
            DAO.AumentarStockProductos(nRand.Next(3, 16));
            DAO.GetProductos();
        }

        /// <summary>
        /// Genera una nueva lista de productos aleatoria
        /// </summary>
        /// <returns>Lista de productos aleatoria</returns>
        private static List<Producto> NuevosProductosRandom()
        {
            List<Producto> auxProductos = new List<Producto>();
            Random nRand = new Random(DateTime.Now.Millisecond);
            Producto nuevoProducto;
            int index;
            int cantProductos = nRand.Next(1, 6);

            DAO.GetProductos();

            for (int i = 0; i < cantProductos; i++)
            {
                index = nRand.Next(0, misProductos.Count);

                nuevoProducto = new Producto(misProductos[index].NumArticulo,
                    misProductos[index].Tipo,
                    misProductos[index].Descripcion,
                    misProductos[index].PrecioUnitario,
                    misProductos[index].Unidades);

                if (nuevoProducto.Unidades != 0)
                {
                    nuevoProducto.Unidades = nRand.Next(1, 6);

                    if (misProductos - nuevoProducto)
                    {
                        if (nuevoProducto == auxProductos)
                        {
                            foreach (Producto item in auxProductos)
                            {
                                item.Unidades += nuevoProducto.Unidades;
                                break;
                            }
                        }
                        else
                        {
                            auxProductos.Add(nuevoProducto);
                        }
                    }
                }
            }

            return auxProductos;
        }

        #endregion

        #region Ventas

        /// <summary>
        /// Genera una nueva venta aleatoria con una lista de productos aleatoria
        /// </summary>
        /// <returns>Nueva venta aleatoria</returns>
        public static Venta NuevaVentaRandom()
        {
            Venta auxVenta;
            List<Producto> auxProductos = NuevosProductosRandom();
            int ultimaVenta = DAO.GetIdUltimaVenta();
            float auxMontoTotal = 0;

            if (auxProductos.Count > 0)
            {
                for (int i = 0; i < auxProductos.Count; i++)
                {
                    DAO.DescontarStockProducto(auxProductos[i]);
                    auxMontoTotal += auxProductos[i].Unidades * auxProductos[i].PrecioUnitario;
                }
                auxVenta = new Venta(RandomElement.Nombre(), auxProductos, auxMontoTotal, ultimaVenta + 1);
            }
            else
            {
                throw new NuevaVentaException("No pudo concretarse la venta porque se acabó el stock del/los producto/s solicitado/s");
            }

            return auxVenta;
        }

        /// <summary>
        /// Realiza la venta pasada por parámetro mediante el evento RealizarVenta
        /// </summary>
        /// <param name="nuevaVenta">Venta a realizar</param>
        /// <returns>True si se realizo la venta, false si no</returns>
        public static bool ConfirmarVenta(Venta nuevaVenta)
        {
            bool confirma = false;
            try
            {
                if (!(nuevaVenta is null))
                {
                    RealizarVenta.Invoke(nuevaVenta);
                    VentasPendientes.Enqueue(nuevaVenta);
                    confirma = true;
                }
                else
                {
                    throw new NuevaVentaException("No se pudo confirmar la compra");
                }
            }
            catch (Exception ex)
            {
                throw new NuevaVentaException("No se pudo confirmar la compra" + ex.Message);
            }

            return confirma;
        }

        /// <summary>
        /// Genera un ticket de la venta pasada por parámetro
        /// </summary>
        /// <param name="miVenta">Venta a generar ticket</param>
        /// <returns>True si pudo generar, false si no</returns>
        public static bool GenerarTicketVenta(Venta miVenta)
        {
            bool retorno = false;
            Texto txt = new Texto();
            string path = AppDomain.CurrentDomain.BaseDirectory;

            try
            {
                if (txt.Guardar(path + "\\VentasTxt\\" + $"Venta N{miVenta.NumVenta}.txt", miVenta.ToString()))
                {
                    retorno = true;
                }
            }
            catch (ArchivoException ex)
            {
                ex.Guardar();
            }

            return retorno;
        }

        /// <summary>
        /// Guarda las ventas pendientes en un archivo serializado xml
        /// </summary>
        public static void GuardarVentasPendientesXml()
        {
            List<Venta> auxVentas = new List<Venta>();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            Xml<List<Venta>> auxArchivo = new Xml<List<Venta>>();

            while (VentasPendientes.Count != 0)
            {
                auxVentas.Add(VentasPendientes.Dequeue());
            }

            auxArchivo.Guardar(path + @"VentasPendientes.xml", auxVentas);
        }

        /// <summary>
        /// Carga las ventas pendientes de un archivo xml a la Queue
        /// </summary>
        public static void CargarVentasPendientesXml()
        {
            Xml<List<Venta>> auxArchivo = new Xml<List<Venta>>();
            string path = AppDomain.CurrentDomain.BaseDirectory;

            if (auxArchivo.Leer(path + @"VentasPendientes.xml", out List<Venta> auxLista))
            {
                for (int i = 0; i < auxLista.Count; i++)
                {
                    VentasPendientes.Enqueue(auxLista[i]);
                }
            }
        }

        #endregion

        #endregion
    }
}
