using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public interface IMostrar<T>
    {
        /// <summary>
        /// Muestra los datos de las clases que implementaron esta interfaz -Correo y Paquete-
        /// </summary>
        /// <param name="elemento">El elemento a mostrar</param>
        /// <returns>Sring con los datos</returns>
        string MostrarDatos(IMostrar<T> elemento);
    }
}
