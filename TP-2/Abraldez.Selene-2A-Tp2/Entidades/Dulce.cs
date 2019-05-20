using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        #region Propiedades
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get {
                return 80;
            }
        }
        #endregion

        #region Metodos
        #region Contructor 
        /// <summary>
        /// Inicializa un nuevo dulce
        /// </summary>
        /// <param name="marca">Marca del dulce</param>
        /// <param name="patente">Codigo de barras del dulce</param>
        /// <param name="color">Color de empaque del dulce</param>
        public Dulce(EMarca marca, string patente, ConsoleColor color) :base(patente, marca, color)
        {
        }
        #endregion
        /// <summary>
        /// Muestra los datos del dulce
        /// </summary>
        /// <returns>Retorna datos del dulce como string</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
