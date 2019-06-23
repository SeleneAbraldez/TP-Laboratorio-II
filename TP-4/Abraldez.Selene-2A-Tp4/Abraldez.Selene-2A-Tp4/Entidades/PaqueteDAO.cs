using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos
        private static SqlCommand _comando;
        private static SqlConnection _conexion;
        #endregion

        #region Metodos
        #region Constructor
        /// <summary>
        /// Constructor de PaqueteDAO
        /// </summary>
        static PaqueteDAO()
        {
            PaqueteDAO._conexion = new SqlConnection(Properties.Settings.Default.conexion);
            PaqueteDAO._comando = new SqlCommand();
        }
        #endregion

        /// <summary>
        /// Guarda paquete en la base de datos
        /// </summary>
        /// <param name="p">Objeto a insertar</param>
        /// <returns>True si se pudo insertar, en caso contrario false</returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            PaqueteDAO._comando.CommandType = System.Data.CommandType.Text;
            PaqueteDAO._comando.CommandText = String.Format("INSERT INTO Paquetes values('{0}','{1}','{2}')", p.DireccionEntrega, p.TrackingID, "Selene Abraldez");
            PaqueteDAO._comando.Connection = PaqueteDAO._conexion;
            try
            {
                PaqueteDAO._conexion.Open();
                PaqueteDAO._comando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                PaqueteDAO._conexion.Close();
            }
            return retorno;
        }
        #endregion
    }
}
