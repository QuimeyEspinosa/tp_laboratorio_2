using System;
using Clases_Instanciables;
using Entidades;
using EntidadesAbstractas;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnitario
    {
        /// <summary>
        /// Valida que lance la excepcion DniInvalidoException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void Test_DniInvalidoException()
        {
            Alumno alumno = new Alumno(103, "Quimey", "Espinosa", "asd", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
        }

        /// <summary>
        /// Valida que lance la excepcion NacionalidadInvalidaException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void Test_NacionalidadInvalidaException()
        {
            Alumno alumno = new Alumno(103, "Quimey", "Espinosa", "100000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.Becado);
        }

        /// <summary>
        /// Valida que lance la excepción de AlumnoRepetidoException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void Test_AlumnoRepetidoException()
        {
            Alumno alumno = new Alumno(1001, "Quimey", "Espinosa", "40000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            Alumno alumno2 = new Alumno(1001, "Lionel", "Messi", "40000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);

            Universidad utn = new Universidad();

            utn += alumno;
            utn += alumno2;
        }

        /// <summary>
        /// Valida que la lista de profesores esté instanciada.
        /// </summary>
        [TestMethod]
        public void Test_Coleccion()
        {
            Universidad universidad = new Universidad();
            Assert.IsNotNull(universidad.Instructores);
        }
    }
}
