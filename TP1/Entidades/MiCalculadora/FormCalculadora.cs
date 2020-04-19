using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using MiCalculadora;

namespace Entidades
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// metodo que valida si los texBox no son nulos y llama al metodo operar 
        /// que realizara el calculo matematico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            if (txtNumero1 is null)
                txtNumero1.Text = "0";
            if (txtNumero2 is null)
                txtNumero2.Text = "0";
            if (cmbOperador.SelectedItem is null)
                cmbOperador.SelectedIndex=0;

            
            resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.SelectedItem.ToString());

            lblResultado.Text = resultado.ToString();
        }
        /// <summary>
        /// Boton que cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// boton que llama al metodo limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        /// <summary>
        /// metodo que inicializa los texbox, etiqueta y comboBox y hace foco 
        /// en una etiqueta especificada
        /// </summary>
        private void limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
            cmbOperador.ResetText();
            txtNumero1.Focus();
        }
        /// <summary>
        /// Metodo del formulario Operar que llama al metodo de la calculadora 
        /// operar pasandole los parametros correspondientes
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1,string numero2, string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);

            return double.Parse(Calculadora.Operar(n1, n2, operador));
        }
        /// <summary>
        /// metodo del formulario que llama al metodo del la clase Numero
        /// DecimalBinario(parametro)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "")
            {
                lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
            }
        }
        /// <summary>
        /// Metodo del formulario que llama al metodo de la Clase Numero
        /// BinarioDecimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "")
            {
                lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
            }
        }
    }
}
