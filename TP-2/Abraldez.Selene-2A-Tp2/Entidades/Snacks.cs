using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        #region Propiedades
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get {
                return 104;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos del snack
        /// </summary>
        /// <returns>Retorna datos del snack como string</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #region Constructor
        /// <summary>
        /// Inicializa un nuevo snack
        /// </summary>
        /// <param name="marca">Marca del snack</param>
        /// <param name="patente">Codigo de barras del snack</param>
        /// <param name="color">Color de empaque del snack</param>
        public Snacks(EMarca marca, string patente, ConsoleColor color) : base(patente, marca, color)
        {
        }
        #endregion
        #endregion
    }
}
