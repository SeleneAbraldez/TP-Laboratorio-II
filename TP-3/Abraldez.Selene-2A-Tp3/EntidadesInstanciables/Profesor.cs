using System;
using System.Collections.Generic;
using System.Text;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Metodos
        /// <summary>
        /// Elige dos clases al azar para profesorx
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue(((Universidad.EClases)Profesor.random.Next(0, 4)));
            this.clasesDelDia.Enqueue(((Universidad.EClases)Profesor.random.Next(0, 4)));
        }

        /// <summary>
        /// Muestra los datos de profesorx
        /// </summary>
        /// <returns>String de datos</returns>
        protected override string MostrarDatos()
        {
            return (base.MostrarDatos() + this.ParticiparEnClase());
        }

        #region Operadores
        /// <summary>
        /// Verifica Profesor dicta una clase.
        /// </summary>
        /// <param name="p">Profesor dicta la clase.</param>
        /// <param name="clase">Clase</param>
        /// <returns>True si el Profesor dicta la clase, caso contrario False</returns>
        public static bool operator ==(Profesor p, Universidad.EClases clase)
        {
            bool retorno = false;
            foreach (Universidad.EClases cla in p.clasesDelDia)
            {
                if (cla == clase)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        //// <summary>
        /// Verifica Profesor no dicta una clase.
        /// </summary>
        /// <param name="p">Profesor dicta la clase.</param>
        /// <param name="clase">Clase</param>
        /// <returns>False si el Profesor dicta la clase, caso contrario Treu</returns>
        public static bool operator !=(Profesor p, Universidad.EClases clase)
        {
            return !(p == clase);
        }
        #endregion

        /// <summary>
        ///  Clase que da profesorx
        /// </summary>
        /// <returns>String clase</returns>
        protected override string ParticiparEnClase()
        {
            string retorno = "\nCLASES DEL DÍA: ";
            foreach (Universidad.EClases clases in this.clasesDelDia)
            {
                retorno += "\n" + clases.ToString();
            }
            return retorno;
        }

        #region Constructores
        /// <summary>
        /// Inicializa los atributos estaticos Profesor/>.
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Inicializa Profesor/>.
        /// </summary>
        public Profesor()
        {
        }

        /// <summary>
        /// Inicializa Profesor, asigna clases y random/>.
        /// </summary>
        /// <param name="id">Legajo del Profesor.</param>
        /// <param name="nombre">Nombre del Profesor.</param>
        /// <param name="apellido">Apellido del Profesor.</param>
        /// <param name="dni">DNI del Profesor</param>
        /// <param name="nacionalidad">Nacionalidad del Profesor.</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        /// <summary>
        /// Sobrescritura de toString  
        /// </summary>
        /// <returns>Muestra los datos de profesorx string</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

    }
}
