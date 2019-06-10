using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;

        /// <summary>
        /// Error dni invalido.
        /// </summary>
        public DniInvalidoException() : this("Formato de DNI invalido.")
        {
        }

        /// <summary>
        /// Error dni invalido.
        /// </summary>
        /// <param name="e">Excepcion</param>
        public DniInvalidoException(Exception e) : base("Formato de DNI invalido.", e)
        {
        }

        /// <summary>
        /// Error dni invalido
        /// </summary>
        /// <param name="message">Mensaje de error</param>
        public DniInvalidoException(string message) : base(message)
        {
            this.mensajeBase = message;
        }

        /// <summary>
        /// Error dni invalido
        /// </summary>
        /// <param name="message">Mensaje error</param>
        /// <param name="e">Excepcion</param>
        public DniInvalidoException(string message, Exception e) : base(message, e)
        {
            this.mensajeBase = message;
        }
    }
}
