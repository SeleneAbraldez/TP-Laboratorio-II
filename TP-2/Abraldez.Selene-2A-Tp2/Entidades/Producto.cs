using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        #region Atributos
        string codigoDeBarras;
        ConsoleColor colorPrimarioEmpaque;
        EMarca marca;
        #endregion

        #region Propiedades
        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>
        protected abstract short CantidadCalorias { get; }
        #endregion


        #region Metodos
        #region Sobrecarga
        /// <summary>
        /// Explicitamente conierte datos de Producto a String
        /// </summary>
        /// <param name="p">Datos pasados</param>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p.codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

        /// <summary>
        /// Muestra los datos del Producto
        /// </summary>
        /// <returns>Los datos del producto como string</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        #region Operadores
        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1">Producto 1</param>
        /// <param name="v2">Producto 2</param>
        /// <returns>Retorna true si son iguales, false si el codigo de barras es distinto</returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1.codigoDeBarras == v2.codigoDeBarras);
        }

        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1">Producto 1</param>
        /// <param name="v2">Producto 2</param>
        /// <returns>Retorna false si son iguales, true si el codigo de barras es distinto</returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return (v1.codigoDeBarras == v2.codigoDeBarras);
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa un nuevo Producto
        /// </summary>
        /// <param name="patente">Codigo de barras del producto</param>
        /// <param name="marca">Marca del producto</param>
        /// <param name="color">Color del empaque</param>
        public Producto(string patente, EMarca marca, ConsoleColor color)
        {
            this.codigoDeBarras = patente;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }
        #endregion
        #endregion


        #region Enumerados
        /// <summary>
        /// Enumerado con las distintas marcas del producto
        /// </summary>
        public enum EMarca
        {
            Serenisima,
            Campagnola,
            Arcor,
            Ilolay,
            Sancor,
            Pepsico,
        }
        #endregion
    }
}
