using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Atributos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #region Delegado
        public event DelegadoEstado InformaEstado;
        #endregion
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad lecutura y escritura de direccionEntrega
        /// </summary>
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        /// <summary>
        /// Propiedad lecutura y escritura de estado
        /// </summary>
        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        /// <summary>
        /// Propiedad lecutura y escritura de trackingID
        /// </summary>
        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// MockCicloDeVida hará que el paquete cambie de estado de la siguiente forma:
        //a.Colocar una demora de 4 segundos.
        //b.Pasar al siguiente estado.
        //c.Informar el estado a través de InformarEstado. EventArgs no tendrá ningún dato extra.
        //d.Repetir las acciones desde el punto A hasta que el estado sea Entregado.
        //e.Finalmente guardar los datos del paquete en la base de datos
        /// </summary
        public void MockCicloDeVida()
        {
            do
            {
                Thread.Sleep(4000); //a

                if (this.estado == EEstado.Ingresado) //b
                {
                    this.estado = EEstado.EnViaje;
                }
                else if (this.estado == EEstado.EnViaje)
                {
                    this.estado = EEstado.Entregado;
                }

                this.InformaEstado(this.estado, new EventArgs()); //c
            } while (this.estado != EEstado.Entregado); //d
            try
            {
                PaqueteDAO.Insertar(this); //e
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// MostrarDatos utilizará string.Format con el siguiente formato "{0} para {1}", p.trackingID, p.direccionEntrega para compilar la información del paquete
        /// </summary>
        /// <param name="elemento"> Paquete pasado</param>
        /// <returns> String con los datos</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).direccionEntrega, ((Paquete)elemento).trackingID);
        }

        #region Sobrecarga de operadores
        /// <summary>
        /// Dos paquetes son iguales si tienen el mismo trackingID
        /// </summary>
        /// <param name="p1">Paquete 1</param>
        /// <param name="p2">Paquete 2</param>
        /// <returns>True si son iguales, false si son distintos</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.trackingID == p2.trackingID);
        }

        /// <summary>
        /// Dos paquetes son distintos si no tienen el mismo trackingID
        /// </summary>
        /// <param name="p1">Paquete 1</param>
        /// <param name="p2">Paquete 2</param>
        /// <returns>True si son distintos, false si son iguales</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de paquete con direccion de entrega y trackingid
        /// </summary>
        /// <param name="direccionEntrega">Dato direccion de entrega</param>
        /// <param name="trackingID">Dato tracking id</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }
        #endregion

        #region Sobrecarga de metodo
        /// <summary>
        /// Sobrecarga del método ToString 
        /// </summary>
        /// <returns> Retornará string con la información del paquete. </returns>

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #endregion

        #region Delegado Anidado
        public delegate void DelegadoEstado(object sender, EventArgs e);
        #endregion

        #region Enumerado Anidado
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado,
        }
        #endregion
    }
}
