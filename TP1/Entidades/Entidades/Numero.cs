using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        /// <summary>
        /// atributo double numero
        /// </summary>
        private double numero;
        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// sobrecarga del constructor por defecto
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            SetNumero = numero.ToString();
        }
        /// <summary>
        /// Propiedad de solo escritura que valida el valor para el atributo numero del objeto
        /// instanciado
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        /// <summary>
        /// metodo publico que pasa el valor del parametro ingresado a la propiedad
        /// que validara el string ingresado
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero) 
        {
            SetNumero = strNumero;
        }

        #region Conversión
        /// <summary>
        /// metodo statico que convierte un string binario en un string que puede
        /// ser parseado a double
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public static string BinarioDecimal(string binario)
        {
            double resultado = 0;
            string strBinario = (Math.Abs(double.Parse(binario))).ToString();

            for (int i = 0; i < strBinario.Length; i++)
            {
                if (strBinario.Substring((strBinario.Length - 1) - i, 1) == "1")
                {
                    resultado = resultado + Math.Pow(2, i);
                }

                else if (strBinario.Substring((strBinario.Length - 1) - i, 1) != "0")
                {
                    return binario;
                }

            }
            return resultado.ToString();
        }
        /// <summary>
        /// metodo statico que convierte un parametro ingresado de tipo double
        /// a un string que puede ser parseado como numero binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(double numero)
        {
            int resto = Math.Abs((int)numero);
            string numString = Math.Abs(resto).ToString();
            
            string auxString = "";

            if (Math.Abs(numero) >= 2)
            {
                while (resto / 2 >= 1)
                {
                    if (resto % 2 == 0)
                        auxString = "0" + auxString;
                    else
                        auxString = "1" + auxString;

                    resto = resto / 2;
                }
                auxString = "1" + auxString;
                return auxString;
            }
            else
            {
                if (numero > 0)
                    return numero.ToString();
                else
                    return "0";
            }
        }
        /// <summary>
        /// Sobrecarga de el metodo DecimalBinario en lugar de recibir un double como 
        /// parametro recibe un string y devuelve un string que contiene un numero binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(string numero)
        {
            if (!double.TryParse(numero, out double num1))
                return "0";
            else
                return DecimalBinario(num1);
        }

        #endregion


        #region Operaciones
        /// <summary>
        /// Sobrecarga del operador + suma dos parametros del tipo Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return (n1.numero + n2.numero);
        }
        /// <summary>
        /// sobrecarga del operador - resta dos parametros del tipo Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return (n1.numero - n2.numero);
        }
        /// <summary>
        /// sobrecarga del operador * multiplica dos parametros del tipo Numero 
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return (n1.numero * n2.numero);
        }
        /// <summary>
        /// sobrecarga del operador / divide dos parametros del tipo Numero 
        /// y valida la division por 0 devolviendo en ese caso double.MinValue;
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return -1.7976931348623157E+307;
            }
            return (n1.numero / n2.numero);
        }

        #endregion

        /// <summary>
        /// Metodo estatico que recibe un string como parametro y comprueba que 
        /// que el contenido puede ser un double valido, valida que no se hayan 
        /// ingresado dos puntos decimales y retorna un double.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        public static double ValidarNumero(string strNumero)
        {
            double numero;
            string nuevoString="";
            int contador = 0;

            foreach(char i in strNumero)
            {
                if (i == '.')
                {
                    contador++;
                    if (contador <= 1)
                        nuevoString += ",";
                }
                else
                    nuevoString += i;
            }

            if (!double.TryParse(nuevoString, out numero))
                numero = 0;

            return numero;
        }
    }
}
