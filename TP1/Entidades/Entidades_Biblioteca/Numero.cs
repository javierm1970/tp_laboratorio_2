using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_Biblioteca
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
            this.numero = numero;
        }
        public Numero(string strNumero)
        {
            double num1;
            if (!double.TryParse(strNumero, out num1)) 
                this.numero = 0;
            this.numero = num1;
        }
        public string BinarioDecimal(string binario)
        {
            return "";
        }
        public string DecimalBinario(double numero)
        {
            double resto = numero;
            string auxString = "";

            if (numero >= 2)
            {
                while (resto / 2 >= 1)
                {
                    if (resto % 2 == 0)
                    {
                        auxString = "0" + auxString;
                    }
                    else
                    {
                        auxString = "1" + auxString;
                    }
                    resto = resto / 2;
                }
                auxString = "1" + auxString;
                return auxString;
            }
            else 
            {
                if (numero > 0)
                {
                    auxString = numero.ToString();
                    return auxString;
                }
                else
                    return "0";
            }
        }
        public string DecimalBinario(string numero)
        {
            if (ValidarNumero(numero) >= 0)
            {
                double resultado=0;

                for (int i = 0; i < numero.Length; i++)
                {
                    if (numero.Substring(i, 1) == "1")
                    {
                        resultado = resultado + Math.Pow(2, i);
                    }
                }
                return resultado.ToString();
            }
            return "0";
        }

        public static double operator + (Numero n1,Numero n2)
        {
            return (n1.numero + n2.numero);
        }
        public static double operator - (Numero n1, Numero n2)
        {
            return (n1.numero - n2.numero);
        }
        public static double operator * (Numero n1, Numero n2)
        {
            return (n1.numero * n2.numero);
        }
        public static double operator / (Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return 0;
            }
            return (n1.numero / n2.numero);
        }
        public static double ValidarNumero(string strNumero)
        {
            double numero;

            if (!double.TryParse(strNumero,out numero))
            {
                numero = 0;
            }
            return numero;
        }
    }
}
