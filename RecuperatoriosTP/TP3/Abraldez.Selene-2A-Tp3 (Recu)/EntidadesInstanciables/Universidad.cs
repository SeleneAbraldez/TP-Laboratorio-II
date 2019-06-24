using System;
using System.Collections.Generic;
using System.Text;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Propiedades
        // <summary>
        /// Lecura y escirtura lista de alumnxs de la universidad/>.
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

        // <summary>
        /// Lecura y escirtura lista de profesores de la universidad/>.
        /// </summary>
        public List<Profesor> Instructores
        {
            get {
                return this.profesores;
            }
            set {
                this.profesores = value;
            }
        }

        // <summary>
        /// Lecura y escirtura lista de jornadas de la universidad/>.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get {
                return this.jornada;
            }
            set {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Lectura y escritura para definir en jornadas validando
        /// </summary>
        /// <param name="i">Indice</param>
        public Jornada this[int i]
        {
            get {
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    return this.Jornadas[i];
                }
                else
                {
                    return null;
                }
            }
            set {
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    this.Jornadas[i] = value;
                }
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Serializa Universidad a archivo Xml
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>True si se pudo realizar con exito, false en caso contrario</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar((AppDomain.CurrentDomain.BaseDirectory + @"/Universidad.xml"), uni);
        }


        /// <summary>
        /// Muestra los datos de la universidad
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>String de datos de la Universidad.</returns>
        private static string MostrarDatos(Universidad uni)
        {
            string retorno = "JORNADA: ";
            foreach (Jornada j in uni.Jornadas)
            {
                retorno += j.ToString() + "<-------------------------------------------------->\n";
            }
            return retorno;
        }

        #region Operadores
        /// <summary>
        /// Comprueba si alumnx pasadx no esta inscriptio la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumnx</param>
        /// <returns>Retorna true si alumnx no esta, false en caso contrario</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Comprueba si profesorx pasadx no esta inscriptio la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">profesorx</param>
        /// <returns>Retorna true si profesorx no esta, false en caso contrario</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor retorno = null;
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor != clase)
                {
                    retorno = profesor;
                    break;
                }
            }
            return retorno;
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada;
            Profesor profesor = (g == clase);
            jornada = new Jornada(clase, profesor);
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == clase)
                {
                    jornada += alumno;
                }
            }
            g.Jornadas.Add(jornada);
            return g;
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno alumno in g.Alumnos)
            {
                if (a == alumno)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == i)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor retorno = null;
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor == clase)
                {
                    retorno = profesor;
                    break;
                }
            }

            if (retorno is null)
            {
                throw new SinProfesorException();
            }
            return retorno;
        }
        #endregion

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        #region Contructor
        /// <summary>
        /// Constructor de universidad, incializa las listas
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }
        #endregion

        #endregion

        #region Enumerados anidados
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion
    }
}
