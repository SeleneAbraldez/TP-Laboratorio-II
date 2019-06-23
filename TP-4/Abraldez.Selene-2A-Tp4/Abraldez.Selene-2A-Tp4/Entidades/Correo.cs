using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Propiedad
        /// <summary>
        /// Propiedad lectura y escritura de Paquete
        /// </summary>
        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }
        #endregion

        #region Metodos

        #region Constructor
        /// <summary>
        /// Constructor de Correo que inciializa las listas
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        #endregion

        /// <summary>
        /// Cierra todos los hilos activos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread hilos in this.mockPaquetes)
            {
                hilos.Abort();
            }
        }

        /// <summary>
        /// Muestra todos los paquetes de un correo
        /// </summary>
        /// <param name="elemento"> Elemento</param>
        /// <returns> String con datos de los paquetes </returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete paquete in ((Correo)elemento).paquetes)
            {
                sb.AppendLine(string.Format("{0} para {1} ({2}) \n", paquete.TrackingID, paquete.DireccionEntrega, paquete.Estado.ToString()));
            }
            return sb.ToString();
        }

        #region Sobrecarga de operadores
        /// <summary>
        /// En el operador +:
        ///a.Controlar si el paquete ya está en la lista.En el caso de que esté, se lanzará la excepción TrackingIdRepetidoException.
        ///b.De no estar repetido, agregar el paquete a la lista de paquetes.
        ///c.Crear un hilo para el método MockCicloDeVida del paquete, y agregar dicho hilo a mockPaquetes.
        ///d.Ejecutar el hilo.
        /// </summary>
        /// <param name="c">Correo</param>
        /// <param name="p">Paquete</param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paq in c.Paquetes)
            {
                if (paq == p) //a
                {
                    throw new TrackingIdRepetidoException(String.Format("\nEl Tracking ID {0} ya figura en la lista de envios.", p.TrackingID));
                }
            }
            c.Paquetes.Add(p); //b
            Thread hilo = new Thread(p.MockCicloDeVida); //c
            c.mockPaquetes.Add(hilo);
            hilo.Start(); //d
            return c;
        }
        #endregion
        #endregion
    }
}
