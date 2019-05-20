using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        #region Atributos
        ETipo tipo;
        #endregion

        #region Propiedades
        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get {
                return 20;
            }
        }
        #endregion

        #region Metodos
        #region Constructores
        /// <summary>
        /// Nueva instancia de leche, por defecto TIPO será ENTERA
        /// </summary>
        /// <param name="marca">Marca de la leche</param>
        /// <param name="patente">Codigo de barras de la leche</param>
        /// <param name="color">Color de empaque de la leche</param>
        public Leche(EMarca marca, string patente, ConsoleColor color) : this(marca, patente, color, ETipo.Entera)
        {
        }
        /// <summary>
        /// Nueva instancia de leche con especificacion de tipo
        /// </summary>
        /// <param name="marca">Marca de la leche</param>
        /// <param name="patente">Codigo de barras de la leche</param>
        /// <param name="color">Color de empaque de la leche</param>
        public Leche(EMarca marca, string patente, ConsoleColor color, ETipo tipo) : base (patente, marca, color)
        {
            this.tipo = tipo;
        }
        #endregion
        /// <summary>
        /// Muestra los datos de la leche
        /// </summary>
        /// <returns>Retorna los datos de la leche en formato string</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion


        #region Enumerados
        /// <summary>
        /// Enumerado de los distintos tipos de leche
        /// </summary>
        public enum ETipo
        {
            Entera,
            Descremada
        }
        #endregion
    }
}
