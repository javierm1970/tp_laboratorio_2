using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida el operador pasado como parametro, si el operador no es una de las
        /// opciones retorna el operador +
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static string ValidarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            return "+";
        }
        /// <summary>
        /// Esta metodo llama a las sobrecargas +-*/ segun el valor del operador
        /// mediante un switch - operando1 operador operando2
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static string Operar(Numero num1, Numero num2, string operador)
        {
            Numero numRes = new Numero();
            operador = ValidarOperador(operador);

            switch (operador)
            {
                case "+":
                    return (num1 + num2).ToString();
                case "-":
                    return (num1 - num2).ToString();
                case "*":
                    return (num1 * num2).ToString();
                case "/":
                    return (num1 / num2).ToString();
                default:
                    /*si bien esta validado anteriormente coloco default porque sino 
                      el metodo "Operar dice que no todas las opciones del switch tienen retorno.*/
                    return (num1 + num2).ToString();
            }
        }
    }
}

