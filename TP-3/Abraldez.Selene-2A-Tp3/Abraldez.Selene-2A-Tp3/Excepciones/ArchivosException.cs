using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Error archivos 
        /// </summary>
        /// <param name="innerException">Excepcion </param>
        public ArchivosException(Exception innerException) : base("Error en archivo", innerException)
        {
        }
    }
}
