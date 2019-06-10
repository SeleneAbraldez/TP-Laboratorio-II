using System;
using System.Collections.Generic;
using System.Text;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Guarda los datos
        /// </summary>
        /// <param name="archivo">Ruta</param>
        /// <param name="datos">Datos a guardar </param>
        /// <returns>True si el archivo puydo guardarse, false en el caso contrario</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Lee el archivo cohn los datos
        /// </summary>
        /// <param name="archivo">Ruta</param>
        /// <param name="datos">Datos leidos</param>
        /// <returns>True si el archivo pudo leerse, false en el caso contrario</returns>
        bool Leer(string archivo, out T datos);
    }
}
