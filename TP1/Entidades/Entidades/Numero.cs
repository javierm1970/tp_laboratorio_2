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
        private double numero;

        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            SetNumero = numero.ToString();
        }

        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        public Numero(string strNumero) 
        {
            SetNumero = strNumero;
        }

        #region Conversión

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
        public static string DecimalBinario(string numero)
        {
            if (!double.TryParse(numero, out double num1))
                return "0";
            else
                return DecimalBinario(num1);
        }

        #endregion


        #region Operaciones

        public static double operator +(Numero n1, Numero n2)
        {
            return (n1.numero + n2.numero);
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return (n1.numero - n2.numero);
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return (n1.numero * n2.numero);
        }
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            return (n1.numero / n2.numero);
        }

        #endregion

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
