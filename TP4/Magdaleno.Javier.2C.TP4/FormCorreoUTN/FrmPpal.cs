using Entidades;
using Extensiones;
using InterfazMostrar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormCorreoUTN
{
    public partial class FrmPpal : Form
    {
        private Correo correo;
        public static string miPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public FrmPpal()
        {
            InitializeComponent();
            correo= new Correo();
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }
        private void ActualizarEstados()
        {
            listBoxEntregado.Items.Clear();
            listBoxEnViaje.Items.Clear();
            listBoxIngresado.Items.Clear();
            if (!(correo.Paquete is null))
            {
                foreach (Paquete item in correo.Paquete)
                {
                    switch (item.Estado)
                    {
                        case Paquete.EEstado.Ingresado:
                            //listBoxIngresado.Items.Add(item.MostrarDatos((Paquete)item));
                            listBoxIngresado.Items.Add(item);
                            break;
                        case Paquete.EEstado.EnViaje:
                            //listBoxEnViaje.Items.Add(item.MostrarDatos((Paquete)item));
                            listBoxEnViaje.Items.Add(item);
                            break;
                        case Paquete.EEstado.Entregado:
                            //listBoxEntregado.Items.Add(item.MostrarDatos((Paquete)item));
                            listBoxEntregado.Items.Add(item);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private void MostrarInforamcion<T>(IMostrar<T> elemento)
        {
            if (!(elemento is null))
            {
                this.richTextBoxMostrar.Text = elemento.MostrarDatos(elemento);
                string auxPath = string.Format("{0}{1}", miPath, @"\salida.txt");
                elemento.MostrarDatos(elemento).Guardar(auxPath);
            }
        }
        public void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d,new object[] { sender, e } );
            }
            else
            {
                ActualizarEstados();
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (!(textBoxDireccion.Text=="") && !(mkTextBoxTrackingID.Text==""))
            {
                Paquete nuevoPaquete = new Paquete(textBoxDireccion.Text,
                    mkTextBoxTrackingID.Text);
                nuevoPaquete.InformaEstado += this.paq_InformaEstado;
                try
                {
                    correo = correo + nuevoPaquete;
                }
                catch (Exception ex)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Error al intentar guardar el paquete en el correo");
                    sb.AppendLine(ex.Message);
                    sb.AppendLine(ex.StackTrace);
                    MessageBox.Show(sb.ToString(), "Error!");
                }
                ActualizarEstados();
            }
            else
            {
                MessageBox.Show("Faltan datos para agregar el paquete");
            }
            this.textBoxDireccion.Text = "";
            this.mkTextBoxTrackingID.Text = "";
            this.mkTextBoxTrackingID.Focus();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            this.MostrarInforamcion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void mostrarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.MostrarInforamcion<Paquete>((IMostrar<Paquete>)listBoxEntregado.SelectedItem);
        }
    }
}
