namespace FormCorreoUTN
{
    partial class FrmPpal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBoxEstado = new System.Windows.Forms.GroupBox();
            this.lblEntregado = new System.Windows.Forms.Label();
            this.lblEnViaje = new System.Windows.Forms.Label();
            this.lblIngresado = new System.Windows.Forms.Label();
            this.listBoxEnViaje = new System.Windows.Forms.ListBox();
            this.listBoxIngresado = new System.Windows.Forms.ListBox();
            this.listBoxEntregado = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mostrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxPaquete = new System.Windows.Forms.GroupBox();
            this.mkTextBoxTrackingID = new System.Windows.Forms.MaskedTextBox();
            this.textBoxDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTrackingID = new System.Windows.Forms.Label();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.richTextBoxMostrar = new System.Windows.Forms.RichTextBox();
            this.groupBoxEstado.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBoxPaquete.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxEstado
            // 
            this.groupBoxEstado.Controls.Add(this.lblEntregado);
            this.groupBoxEstado.Controls.Add(this.lblEnViaje);
            this.groupBoxEstado.Controls.Add(this.lblIngresado);
            this.groupBoxEstado.Controls.Add(this.listBoxEnViaje);
            this.groupBoxEstado.Controls.Add(this.listBoxIngresado);
            this.groupBoxEstado.Controls.Add(this.listBoxEntregado);
            this.groupBoxEstado.Location = new System.Drawing.Point(12, 12);
            this.groupBoxEstado.Name = "groupBoxEstado";
            this.groupBoxEstado.Size = new System.Drawing.Size(776, 334);
            this.groupBoxEstado.TabIndex = 1;
            this.groupBoxEstado.TabStop = false;
            this.groupBoxEstado.Text = "Estados Paquete";
            // 
            // lblEntregado
            // 
            this.lblEntregado.AutoSize = true;
            this.lblEntregado.Location = new System.Drawing.Point(536, 23);
            this.lblEntregado.Name = "lblEntregado";
            this.lblEntregado.Size = new System.Drawing.Size(56, 13);
            this.lblEntregado.TabIndex = 11;
            this.lblEntregado.Text = "Entregado";
            // 
            // lblEnViaje
            // 
            this.lblEnViaje.AutoSize = true;
            this.lblEnViaje.Location = new System.Drawing.Point(283, 23);
            this.lblEnViaje.Name = "lblEnViaje";
            this.lblEnViaje.Size = new System.Drawing.Size(46, 13);
            this.lblEnViaje.TabIndex = 10;
            this.lblEnViaje.Text = "En Viaje";
            // 
            // lblIngresado
            // 
            this.lblIngresado.AutoSize = true;
            this.lblIngresado.Location = new System.Drawing.Point(25, 23);
            this.lblIngresado.Name = "lblIngresado";
            this.lblIngresado.Size = new System.Drawing.Size(54, 13);
            this.lblIngresado.TabIndex = 9;
            this.lblIngresado.Text = "Ingresado";
            // 
            // listBoxEnViaje
            // 
            this.listBoxEnViaje.FormattingEnabled = true;
            this.listBoxEnViaje.Location = new System.Drawing.Point(250, 44);
            this.listBoxEnViaje.Name = "listBoxEnViaje";
            this.listBoxEnViaje.Size = new System.Drawing.Size(241, 277);
            this.listBoxEnViaje.TabIndex = 7;
            // 
            // listBoxIngresado
            // 
            this.listBoxIngresado.FormattingEnabled = true;
            this.listBoxIngresado.Location = new System.Drawing.Point(6, 44);
            this.listBoxIngresado.Name = "listBoxIngresado";
            this.listBoxIngresado.Size = new System.Drawing.Size(236, 277);
            this.listBoxIngresado.TabIndex = 6;
            // 
            // listBoxEntregado
            // 
            this.listBoxEntregado.ContextMenuStrip = this.contextMenuStrip1;
            this.listBoxEntregado.FormattingEnabled = true;
            this.listBoxEntregado.Location = new System.Drawing.Point(502, 44);
            this.listBoxEntregado.Name = "listBoxEntregado";
            this.listBoxEntregado.Size = new System.Drawing.Size(255, 277);
            this.listBoxEntregado.TabIndex = 8;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(116, 26);
            // 
            // mostrarToolStripMenuItem
            // 
            this.mostrarToolStripMenuItem.Name = "mostrarToolStripMenuItem";
            this.mostrarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mostrarToolStripMenuItem.Text = "&Mostrar";
            this.mostrarToolStripMenuItem.Click += new System.EventHandler(this.mostrarToolStripMenuItem_Click_1);
            // 
            // groupBoxPaquete
            // 
            this.groupBoxPaquete.Controls.Add(this.mkTextBoxTrackingID);
            this.groupBoxPaquete.Controls.Add(this.textBoxDireccion);
            this.groupBoxPaquete.Controls.Add(this.lblDireccion);
            this.groupBoxPaquete.Controls.Add(this.lblTrackingID);
            this.groupBoxPaquete.Controls.Add(this.btnMostrar);
            this.groupBoxPaquete.Controls.Add(this.btnAgregar);
            this.groupBoxPaquete.Location = new System.Drawing.Point(443, 354);
            this.groupBoxPaquete.Name = "groupBoxPaquete";
            this.groupBoxPaquete.Size = new System.Drawing.Size(345, 155);
            this.groupBoxPaquete.TabIndex = 0;
            this.groupBoxPaquete.TabStop = false;
            this.groupBoxPaquete.Text = "Paquete";
            // 
            // mkTextBoxTrackingID
            // 
            this.mkTextBoxTrackingID.Location = new System.Drawing.Point(15, 51);
            this.mkTextBoxTrackingID.Name = "mkTextBoxTrackingID";
            this.mkTextBoxTrackingID.Size = new System.Drawing.Size(181, 20);
            this.mkTextBoxTrackingID.TabIndex = 0;
            // 
            // textBoxDireccion
            // 
            this.textBoxDireccion.Location = new System.Drawing.Point(15, 97);
            this.textBoxDireccion.Name = "textBoxDireccion";
            this.textBoxDireccion.Size = new System.Drawing.Size(181, 20);
            this.textBoxDireccion.TabIndex = 1;
            // 
            // lblDireccion
            // 
            this.lblDireccion.Location = new System.Drawing.Point(28, 79);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(79, 15);
            this.lblDireccion.TabIndex = 3;
            this.lblDireccion.Text = "Dirección";
            // 
            // lblTrackingID
            // 
            this.lblTrackingID.Location = new System.Drawing.Point(28, 30);
            this.lblTrackingID.Name = "lblTrackingID";
            this.lblTrackingID.Size = new System.Drawing.Size(79, 19);
            this.lblTrackingID.TabIndex = 2;
            this.lblTrackingID.Text = "Tracking ID";
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(206, 87);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(120, 39);
            this.btnMostrar.TabIndex = 3;
            this.btnMostrar.Text = "&MostrarTodos";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(206, 32);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(120, 39);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // richTextBoxMostrar
            // 
            this.richTextBoxMostrar.Location = new System.Drawing.Point(12, 354);
            this.richTextBoxMostrar.Name = "richTextBoxMostrar";
            this.richTextBoxMostrar.Size = new System.Drawing.Size(419, 161);
            this.richTextBoxMostrar.TabIndex = 5;
            this.richTextBoxMostrar.Text = "";
            // 
            // FrmPpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 529);
            this.Controls.Add(this.richTextBoxMostrar);
            this.Controls.Add(this.groupBoxPaquete);
            this.Controls.Add(this.groupBoxEstado);
            this.Name = "FrmPpal";
            this.Text = "Correo UTN por Javier.Magdaleno.2C";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPpal_FormClosing);
            this.groupBoxEstado.ResumeLayout(false);
            this.groupBoxEstado.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBoxPaquete.ResumeLayout(false);
            this.groupBoxPaquete.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxEstado;
        private System.Windows.Forms.GroupBox groupBoxPaquete;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTrackingID;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ListBox listBoxEntregado;
        private System.Windows.Forms.ListBox listBoxEnViaje;
        private System.Windows.Forms.ListBox listBoxIngresado;
        private System.Windows.Forms.RichTextBox richTextBoxMostrar;
        private System.Windows.Forms.TextBox textBoxDireccion;
        private System.Windows.Forms.Label lblEntregado;
        private System.Windows.Forms.Label lblEnViaje;
        private System.Windows.Forms.Label lblIngresado;
        private System.Windows.Forms.MaskedTextBox mkTextBoxTrackingID;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mostrarToolStripMenuItem;
    }
}

