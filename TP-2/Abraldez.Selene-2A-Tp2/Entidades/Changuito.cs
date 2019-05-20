using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        #region Atributos
        int espacioDisponible;
        List<Producto> productos;
        #endregion

        #region Metodos
        #region Constructores
        /// <summary>
        /// Constructor privado que inicializa la lista de productos del changuito
        /// </summary>
        private Changuito()
        {
            this.productos = new List<Producto>();
        }
        /// <summary>
        /// Inicializa changuito con especificacion de espacio disponible
        /// </summary>
        /// <param name="espacioDisponible">Espacio disponible en el changuito</param>
        public Changuito(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion
        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Changuito c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.productos.Count, c.espacioDisponible);
            sb.AppendLine("");
            foreach (Producto pro in c.productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if(pro is Snacks)
                        {
                            sb.AppendLine(pro.Mostrar());
                        }
                        break;
                    case ETipo.Dulce:
                        if(pro is Dulce)
                        {
                            sb.AppendLine(pro.Mostrar());
                        }
                        break;
                    case ETipo.Leche:
                        if(pro is Leche)
                        {
                            sb.AppendLine(pro.Mostrar());
                        }
                        break;
                    default:
                        sb.AppendLine(pro.Mostrar());
                        break;
                }
            }
            return sb.ToString();
        }
        #region Operadores
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            foreach (Producto pro in c.productos)
            {
                if (pro == p)
                {
                    c.productos.Remove(pro);
                    break;
                }
                //
            }
            return c;
        }
        /// <summary>
        /// Agregará un elemento a la lista, si hay espacio en la lista y si el objeto no se encuentra ya agregado
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns>Retorna lista de productos</returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            if(c.productos.Count < c.espacioDisponible)
            {
                foreach (Producto pro in c.productos)
                {
                    if (pro == p)
                    {
                        //
                        return c;
                    }                  
                }
                c.productos.Add(p);
            }
            return c;
        }
        #endregion
        #region Sobrecargas
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Changuito.Mostrar(this, ETipo.Todos);
        }
        #endregion  

        #endregion

















        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

        

              
    }
}
