using System;
using System.Collections.Generic;
using System.Text;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        /// <summary>
        /// Lectura y escritura lista de alumnxs
        /// </summary>
        public List<Alumno> Alumnos
        {
            get {
                return this.alumnos;
            }
            set {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Lectura y escritura clases
        /// </summary>
        public Universidad.EClases Clase
        {
            get {
                return this.clase;
            }

            set {
                this.clase = value;
            }
        }

        /// <summary>
        /// Lectura y escritura profesores
        /// </summary>
        public Profesor Instructor
        {
            get {
                return this.instructor;
            }

            set {
                this.instructor = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda los datos de la jornada en jornadas.txt
        /// </summary>
        /// <param name="jornada">Informacion de jornada</param>
        /// <returns>True si se puedo, false en caso contrario</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto t = new Texto();
            return t.Guardar((AppDomain.CurrentDomain.BaseDirectory + @"/Jornadas.txt"), jornada.ToString());
        }

        #region Constructor
        /// <summary>
        /// Inicializa Jornada/>.
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Inicializa Jornada/>.
        /// </summary>
        /// <param name="clase">Clase dictada en la Jornada.</param>
        /// <param name="instructor">Profesor que dicta Clase de la Jornada.</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.instructor = instructor;
        }
        #endregion

        /// <summary>
        /// Lee los datos guardados de jornada
        /// </summary>
        /// <returns>String con los datos</returns>
        public static string Leer()
        {
            string retorno = "";
            Texto t = new Texto();
            t.Leer((AppDomain.CurrentDomain.BaseDirectory) + @"\Jornada.txt", out retorno);
            return retorno;
        }

        #region Operadores
        /// <summary>
        /// Alumnx no forma parte de la Jornada/>.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumnx</param>
        /// <returns>True si el Alumno no forma parte de la Jornada, false si fue parte.
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega alumnx a la jornada validando que no repetido
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumnx</param>
        /// <returns>jornada con alumnx agregadx</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return j;
        }

        /// <summary>
        /// Alumnx forma parte de la Jornada/>.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumnx</param>
        /// <returns>True si el Alumno forma parte de la Jornada, false si no fue parte.
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno alumno in j.Alumnos)
            {
                if (alumno == a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        #endregion

        /// <summary>
        /// Sobrecarga de toString
        /// </summary>
        /// <returns>String datos de la jornada</returns>
        public override string ToString()
        {
            string retorno = "";
            StringBuilder sb = new StringBuilder();
            retorno = "\nClase de " + this.Clase + " por " + this.Instructor + ". \n\nALUMNOS:\n";
            foreach (Alumno a in this.alumnos)
            {
                retorno += a.ToString() + "\n\n";
            }
            return retorno;
        }

        #endregion

    }
}
