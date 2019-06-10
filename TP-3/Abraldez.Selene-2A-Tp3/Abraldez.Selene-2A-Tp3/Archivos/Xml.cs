using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serializa objeto cualquiera en un archivo xml
        /// </summary>
        /// <param name="archivo">Ruta</param>
        /// <param name="datos">Datos</param>
        /// <returns>True si el archivo se serializo exitosamente. ArchivosException en caso contrario</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            try
            {
                using (TextWriter writer = new StreamWriter(archivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(writer, datos);
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }

        /// <summary>
        /// Deserializa un archivo xml y retorna el contenido como un objeto 
        /// </summary>
        /// <param name="archivo">Ruta</param>
        /// <param name="datos">retornara el objeto deserializado</param>
        /// <returns>True si se deserializo exitosamente.ArchivosException en caso contrario</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            try
            {
                using (TextReader reader = new StreamReader(archivo))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(T));
                    datos = (T)xml.Deserialize(reader);
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }
    }
}
