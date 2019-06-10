using System;
using System.Collections.Generic;
using System.Text;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    sealed public class Alumno : Universitario
    {
        #region Atributos
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Costructores
        /// <summary>
        /// Constructor Alumnx
        /// </summary>
        public Alumno()
        {
        }

        /// <summary>
        /// Constructor alumnx con base y clase que toma
        /// </summary>
        /// <param name="id">Id de alumnx</param>
        /// <param name="nombre">Nombre de alumnx</param>
        /// <param name="apellido">Apellido de alumnx</param>
        /// <param name="dni">STRING DNI de alumnx</param>
        /// <param name="nacionalidad">Nacionalidad de alumnx</param>
        /// <param name="claseQueToma">Clase que toma alumnx</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor alumnx con base, clase que toma y estado de cuenta
        /// </summary>
        /// <param name="id">Id de alumnx</param>
        /// <param name="nombre">Nombre de alumnx</param>
        /// <param name="apellido">Apellido de alumnx</param>
        /// <param name="dni">STRING DNI de alumnx</param>
        /// <param name="nacionalidad">Nacionalidad de alumnx</param>
        /// <param name="claseQueToma">Clase que toma alumnx</param>
        /// <param name="estadoCuenta">Estado de cuenta de alumnx</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muetra los datos de Alumnx
        /// </summary>
        /// <returns>String de datos</returns>
        protected override string MostrarDatos()
        {
            string estado = estadoCuenta.ToString();
            if(this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                estado = "Cuota al dia";
            }
            return (base.MostrarDatos() + "\nESTADO DE CUENTA: " + estado + this.ParticiparEnClase());
        }

        #region Operadores 
        /// <summary>
        /// Alumnx será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a">alumnx </param>
        /// <param name="clase">clase a ver si toma alumnx</param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor);
        }

        /// <summary>
        /// Alumnx será distinto a un EClase sólo si no toma esa clase
        /// </summary>
        /// <param name="a">alumnx</param>
        /// <param name="clase">clase a ver si toma alumnx</param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma != clase);
        }
        #endregion

        /// <summary>
        /// Muestra la clase que toma Alumnx
        /// </summary>
        /// <returns>String clase que toma</returns>
        protected override string ParticiparEnClase()
        {
            return ("\nTOMA CLASE DE: " + this.claseQueToma);
        }

        /// <summary>
        /// Hace publicos los datos de Alumnx
        /// </summary>
        /// <returns>String de datos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Enumerado anidado
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion
    }
}
