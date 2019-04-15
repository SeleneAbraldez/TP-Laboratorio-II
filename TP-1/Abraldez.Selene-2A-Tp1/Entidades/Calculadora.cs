using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades { 
    /// <summary>
    /// Clase encargada de realzar la operacion seleccionada
    /// </summary>
    public class Calculadora {
        #region Metodos
        /// <summary>
        /// Opera dos valores en funcion de la operacion solicitada.
        /// </summary>
        /// <param name="num1">Primer dato Numero</param>
        /// <param name="num2">Segundo dato Numero</param>
        /// <param name="operador">Operacion a realizar</param>
        /// <returns>Retornara el resultado de la operacion, o en caso de una division por 0, retornará double.MinValue.</returns>
        public static double Operar(Numero num1, Numero num2, string operador) {
            double retorno = 0;
            switch (ValidarOperador(operador)) {
                case "+":
                    retorno = (num1 + num2);
                    break;
                case "-":
                    retorno = (num1 - num2);
                    break;
                case "/":
                   retorno = (num1 / num2);
                    if (double.IsInfinity(retorno))
                    {
                        retorno = double.MinValue;
                    }
                    break;
                case "*":
                    retorno = (num1 * num2);
                    break;
                default:
                    break;
            }
            return retorno;
        }

        /// <summary>
        /// Metodo para validar el operador ingresado.
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns> Retorna el operador ingresado originalmente si la validacion es correcta. Cas contrario, retornara "+". </returns>
        private static string ValidarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                return operador;
            } else
            {
                return "+";
            }
        }

        #endregion
    }
}
