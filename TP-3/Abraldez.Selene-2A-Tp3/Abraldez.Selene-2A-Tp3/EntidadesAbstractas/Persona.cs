using System;
using System.Collections.Generic;
using System.Text;
using Excepciones;

namespace EntidadesAbstractas
{
    abstract public class Persona
    {
        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades
        /// <summary>
        /// Lectura y escritura de Apellido validado
        /// </summary>
        public string Apellido
        {
            get {
                return this.apellido;
            }

            set {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Lectura y escritura de Dni validado
        /// </summary>
        public int DNI
        {
            get {
                return this.dni;
            }
            set {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Lectura y escritura de Nacionalidado
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get {
                return this.nacionalidad;
            }

            set {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Lectura y escritura de Nombre validado
        /// </summary>
        public string Nombre
        {
            get {
                return this.nombre;
            }

            set {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Escritura de int dni a string
        /// </summary>
        public string StringToDni
        {
            set {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa una Persona/>.
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Inicializa una Persona/>.
        /// </summary>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido de la Persona</param>
        /// <param name="nacionalidad">Nacionalidad de la Persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Inicializa una Persona/>.
        /// </summary>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido de la Persona</param>
        /// <param name="dni">DNI de la Persona INT</param>
        /// <param name="nacionalidad">Nacionalidad de la Persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la Clase persona.
        /// </summary>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido de la Persona</param>
        /// <param name="dni">DNI de la Persona STRING</param>
        /// <param name="nacionalidad">Nacionalidad de la Persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo sobreescirtura de toString
        /// </summary>
        /// <returns>Devuelve los datos de Persona</returns>
        public override string ToString()
        {
            return ("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre + "\nNACIONALIDAD: " + this.Nacionalidad);
        }


        /// <summary>
        /// Validacion de dni INT
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de Persona</param>
        /// <param name="dni">DNI a Validar de Persona</param>
        /// <returns>-1 si es invalido, si no el dni</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = -1;
            if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato >= 1 && dato <= 89999999)
                {
                    retorno = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }
            else if (nacionalidad == ENacionalidad.Extranjero)
            {
                if (dato >= 90000000 && dato <= 99999999)
                {
                    retorno = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }
            return retorno;
        }

        /// <summary>
        /// Validacion de dni STRING
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de Persona</param>
        /// <param name="dni">DNI a Validar de Persona</param>
        /// <returns>-1 si es invalido, si no el dni</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dniV;
            int retorno = -1;
            if (dato.Length >= 1 && dato.Length <= 8 && (int.TryParse(dato, out dniV)))
            {
                retorno = dniV;
            }
            else
            {
                throw new DniInvalidoException();
            }
            return retorno;
        }

        /// <summary>
        /// Validacion de nombre y apellido
        /// </summary>
        /// <param name="dato">Nombre/Apellido de Persona</param>
        /// <returns>Cadena vacia si es invalido, si no el nombre/apellido</returns>
        private string ValidarNombreApellido(string dato)
        {
            bool flag = true;
            string retorno = " ";
            foreach (char item in dato)
            {
                if (!(Char.IsLetter(item)))
                {
                    flag = false;
                    break;
                }
            }
            if (flag == true)
            {
                retorno = dato;
            }
            return retorno;
        }
        #endregion

        #region Enumerado anidado
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion
    }
}
