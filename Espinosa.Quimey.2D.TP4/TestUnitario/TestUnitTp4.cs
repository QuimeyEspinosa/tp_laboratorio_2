using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Excepciones;
using Archivos;

namespace TestUnitario
{
    [TestClass]
    public class TestUnitTp4
    {
        /// <summary>
        /// Valida que lance la excepción de NuevaVentaException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NuevaVentaException))]
        public void Test_NuevaVentaException()
        {
            Venta miVenta = null;
            Comercio.ConfirmarVenta(miVenta);
        }

        /// <summary>
        /// Valida que lance la excepcion ArchivoException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivoException))]
        public void Test_ArchivoException()
        {
            Texto txt = new Texto();

            txt.Guardar(string.Empty, string.Empty);
        }

        /// <summary>
        /// Valida que lance la excepción de NuevoProductoException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NuevoProductoException))]
        public void Test_NuevoProductoException()
        {
            Producto miProd = null;
            Comercio.AgregarProducto(miProd);
        }

        /// <summary>
        /// Valida que la lista de productos esté instanciada en el comercio.
        /// </summary>
        [TestMethod]
        public void Test_Coleccion()
        {
            Assert.IsNotNull(Comercio.MisProductos);
        }
    }
}
