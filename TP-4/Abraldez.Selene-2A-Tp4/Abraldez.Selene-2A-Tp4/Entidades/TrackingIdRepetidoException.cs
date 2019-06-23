using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        /// <summary>
        /// Inicializa instancia
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepcion </param>
        public TrackingIdRepetidoException(string mensaje) : base(mensaje)
        {
        }

        /// <summary>
        /// Inicializa instancia
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepcion </param>
        /// <param name="inner">Excepcion</param>
        public TrackingIdRepetidoException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }
    }
}
