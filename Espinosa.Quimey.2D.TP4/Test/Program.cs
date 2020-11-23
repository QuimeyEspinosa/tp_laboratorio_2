using Entidades;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    public delegate void MiApp();

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Espinosa Quimey 2D TP N°4";

            Thread thVendedor = new Thread(Comercio.EntregarVentas);
            //Thread thActualizador = new Thread(this.Actualizar2);
            Producto miProd1 = new Producto(1, Producto.ETipo.Cuerdas, "Electracústica", 180, 35);
            Producto miProd2 = new Producto(2, Producto.ETipo.Percusion, "Triángulo", 25, 35);
            Producto miProd3 = new Producto(3, Producto.ETipo.Teclas, "Teclado Yamaha", 450, 35);

            try
            {
                DAO.AumentarStockProductos(100);
                DAO.GetProductos(); //Cargo productos de la base

                Console.WriteLine("Se intentará traer los productos de la base de datos y agregar 3 nuevos productos con ID's que ya contienen otros productos\n");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();

                if (Comercio.AgregarProducto(miProd1))
                {
                    Console.WriteLine($"Se agregó satisfactoriamente el producto: \n{miProd1.ToString()}\n");
                }
                else
                {
                    Console.WriteLine($"Ya existe un producto con el ID de producto: {miProd1.NumArticulo}\n");
                }

                if (Comercio.AgregarProducto(miProd2))
                {
                    Console.WriteLine($"Se agregó satisfactoriamente el producto: \n{miProd2.ToString()}\n");
                }
                else
                {
                    Console.WriteLine($"Ya existe un producto con el ID de producto: {miProd2.NumArticulo}\n");
                }

                if (Comercio.AgregarProducto(miProd3))
                {
                    Console.WriteLine($"Se agregó satisfactoriamente el producto: \n{miProd3.ToString()}");
                }
                else
                {
                    Console.WriteLine($"Ya existe un producto con el ID de producto: {miProd3.NumArticulo}\n");
                }
            }
            catch(ConexionALaBaseException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(NuevoProductoException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(ArchivoException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine($"La cantidad de productos traidos de la base es {Comercio.MisProductos.Count} y son los siguientes: \n");

            foreach (Producto item in Comercio.MisProductos)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Se intentará generar 5 nuevas ventas aleatorias");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    Comercio.VentasPendientes.Enqueue(Comercio.NuevaVentaRandom());
                }
            }
            catch(NuevaVentaException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Las nuevas ventas pendientes de entrega son:");

            foreach (Venta item in Comercio.VentasPendientes)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Se intentará guardar en un archivo XML las 5 nuevas ventas generadas anteriormente y luego se leeran y cargaran nuevamente a la queue de VentasPendientes");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

            try
            {
                Comercio.GuardarVentasPendientesXml();
                Comercio.CargarVentasPendientesXml();
            }
            catch (ArchivoException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Se guardó y luego cargó del xml {Comercio.VentasPendientes.Count} ventas:");
            foreach (Venta item in Comercio.VentasPendientes)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Se intentará pasar hasta agotarse las ventas pendientes a la queue de ventas entregadas cada 4 segundos mediante un hilo");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

            try
            {
                thVendedor.Start();

                while (Comercio.VentasPendientes.Count > 0)
                {
                    Thread.Sleep(1000);
                    Console.Clear();
                    foreach (Venta item in Comercio.VentasPendientes)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    Thread.Sleep(3000);
                }

                thVendedor.Abort();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Se mostrara la queue con las ventas que acaba de ser cargada (VentasEntregadas)");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

            foreach (Venta item in Comercio.VentasEntregadas)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("\n\nFinalizó el test exitosamente");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }        
    }
}
