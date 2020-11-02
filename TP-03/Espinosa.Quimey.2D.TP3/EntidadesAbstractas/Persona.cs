using Entidades;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad { Argentino, Extranjero }
        string apellido;
        int dni;
        ENacionalidad nacionalidad;
        string nombre;

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {
            this.apellido = "Sin asignar";
            this.nombre = "Sin asignar";
        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad">Argentino, Extranjero</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni">dni de tipo int</param>
        /// <param name="nacionalidad">Argentino, Extranjero</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.dni = dni;
        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni">dni de tipo string</param>
        /// <param name="nacionalidad">Argentino, Extranjero</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado apellido, valida el dato ingresado
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }

            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado DNI, valida el dato ingresado
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }

            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado nombre, valida el dato ingresado
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }

            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado DNI, valida el dato ingresado
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        #endregion       

        #region Métodos

        /// <summary>
        /// Retorna apellido, nombre y nacionalidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder datosPersona = new StringBuilder();

            datosPersona.AppendLine($"NOMBRE COMPLETO: {this.apellido}, {this.nombre}");
            datosPersona.AppendLine($"NACIONALIDAD: {this.nacionalidad}");

            return datosPersona.ToString();
        }

        #endregion

        #region Validaciones

        /// <summary>
        /// Valida el rango del dni dependiendo de la nacionalidad de la persona
        /// </summary>
        /// <param name="nacionalidad">Argentino, Extranjero</param>
        /// <param name="dato">Dni de tipo int</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int auxDato;

            if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato > 0 && dato < 90000000)
                {
                    auxDato = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }
            else if (nacionalidad == ENacionalidad.Extranjero)
            {
                if (dato > 89999999 && dato < 100000000)
                {
                    auxDato = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }

            return dato;
        }

        /// <summary>
        /// Valida que el dni ingresado sea válido y que se encuentre dentro del rango especificado dependiendo la nacionalidad de la persona
        /// </summary>
        /// <param name="nacionalidad">Argentino, Extranjero</param>
        /// <param name="dato">Dni de tipo string</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (int.TryParse(dato, out int auxDato))
            {
                auxDato = ValidarDni(nacionalidad, auxDato);
            }
            else
            {
                throw new DniInvalidoException();
            }

            return auxDato;
        }

        /// <summary>
        /// Valida que el dato ingresado sea correspondiente a un nombre o un apellido
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string auxString = string.Empty;

            dato.Trim();
            if (dato.Length > 2 && !int.TryParse(dato, out _))
            {
                auxString = dato;
            }

            return auxString;
        }

        #endregion

    }
}
