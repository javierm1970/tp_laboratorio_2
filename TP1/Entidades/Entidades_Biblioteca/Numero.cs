﻿using System;
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

        public string BinarioDecimal(string binario)
        {
            double resultado = 0;
            binario = (Math.Abs(int.Parse(binario))).ToString();

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario.Substring(i, 1) == "1")
                {
                    resultado = resultado + Math.Pow(2, i);
                }
            }
            return resultado.ToString();
        }
        public string DecimalBinario(double numero)
        {
            int resto = Math.Abs((int)numero);
            string auxString = "";

            if (numero >= 2)
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
        public string DecimalBinario(string numero)
        {
            if(!double.TryParse(numero,out double num1))
                return "0";
            else
                return DecimalBinario(num1);
        }

        #endregion


        #region Operaciones

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
                return double.MinValue;
            }
            return (n1.numero / n2.numero);
        }

        #endregion

        public static double ValidarNumero(string strNumero)
        {
            double numero;

            if (!double.TryParse(strNumero,out numero))
                numero = 0;
            return numero;
        }
    }
}
