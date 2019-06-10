using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesAbstractas
{
    abstract public class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Metodos

        #region Sobrecarga
        /// <summary>
        /// Si dos universitarixs son del mismo tipo
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>True si son del mismo tipo, false en le caso contrario</returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Universitario)
            {
                if (this == (Universitario)obj)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        #endregion

        /// <summary>
        /// Muestra los datos de Universitarix
        /// </summary>
        /// <returns>String de datos</returns>
        protected virtual string MostrarDatos()
        {
            return (base.ToString() + "\nLEGAJO NUMERO: " + this.legajo);
        }

        #region Operadores
        /// <summary>
        /// Sobrecarga de == para saber si dos universitarixs son iguales con dni y legajo
        /// </summary>
        /// <param name="pg1">universitarix 1</param>
        /// <param name="pg2">universitarix 2</param>
        /// <returns>True si son mismo, false en caso contrario</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;

            if (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga de != para saber si dos universitarixs son distintxs
        /// </summary>
        /// <param name="u1">universitarix 1</param>
        /// <param name="u2">universitarix 2</param>
        /// <returns>False si son mismo, True en caso contrario</returns>
        public static bool operator !=(Universitario u1, Universitario u2)
        {
            return !(u1 == u2);
        }
        #endregion

        /// <summary>
        /// clase abtsracta
        /// </summary>
        protected abstract string ParticiparEnClase();

        #region Constructores
        /// <summary>
        /// Inicializa Universitario/>.
        /// </summary>
        public Universitario()
        {
        }

        /// <summary>
        /// Inicializa Universitario/>. 
        /// </summary>
        /// <param name="legajo">Legajo del Universitario.</param>
        /// <param name="nombre">Nombre del Universitario</param>
        /// <param name="apellido">Apellido del Universitario</param>
        /// <param name="dni">DNI del Universitario</param>
        /// <param name="nacionalidad">Nacionalidad del Universitario</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion


        #endregion
    }
}
