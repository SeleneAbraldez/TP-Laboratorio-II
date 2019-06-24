using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Error sin profesorx
        /// </summary>
        public SinProfesorException() : base("No hay profesor para la clase.")
        {
        }
    }
}
