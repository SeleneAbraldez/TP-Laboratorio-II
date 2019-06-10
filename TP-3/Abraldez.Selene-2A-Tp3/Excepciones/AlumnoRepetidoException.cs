using System;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Error alumnx repetido
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno esta repetido.")
        {
        }
    }
}
