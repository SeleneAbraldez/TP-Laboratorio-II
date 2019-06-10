using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Error nacionalidad invalida
        /// </summary>
        public NacionalidadInvalidaException() : this("La nacionalidad no condice con el número de DNI")
        {
        }

        /// <summary>
        /// Error nacionalidad invalida
        /// </summary>
        /// <param name="message">Mensaje de error</param>
        public NacionalidadInvalidaException(string message) : base(message)
        {
        }
    }
}
