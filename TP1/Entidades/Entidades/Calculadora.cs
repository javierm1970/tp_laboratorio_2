using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            return "+";
        }
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
                    if (num1 / num2 == 0)
                        return "Error no es posible dividir por 0";
                    return (num1 / num2).ToString();
                default:
                    /*si bien esta validado anteriormente coloco default porque sino 
                      el metodo "Operar dice que no todas las opciones del switch tienen retorno.*/
                    return (num1 + num2).ToString();
            }
        }
    }
}

