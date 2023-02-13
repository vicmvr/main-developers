namespace Developers
{
    partial class FrmConfiguracion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfiguracion));
            this.tabConfiguracion = new System.Windows.Forms.TabControl();
            this.tpTipoCambio = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGuardarTipoCambio = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTipoDeCambio = new System.Windows.Forms.Label();
            this.txtTipoDeCambio = new System.Windows.Forms.TextBox();
            this.tpImpresora = new System.Windows.Forms.TabPage();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbImpresoraTickets = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tpConexion = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.gbConexion = new System.Windows.Forms.GroupBox();
            this.picConexion = new System.Windows.Forms.PictureBox();
            this.txtBaseDatos = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCargar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tpNegocio = new System.Windows.Forms.TabPage();
            this.tabConfiguracion.SuspendLayout();
            this.tpTipoCambio.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tpImpresora.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tpConexion.SuspendLayout();
            this.gbConexion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picConexion)).BeginInit();
            this.SuspendLayout();
            // 
            // tabConfiguracion
            // 
            this.tabConfiguracion.Controls.Add(this.tpTipoCambio);
            this.tabConfiguracion.Controls.Add(this.tpImpresora);
            this.tabConfiguracion.Controls.Add(this.tpConexion);
            this.tabConfiguracion.Controls.Add(this.tpNegocio);
            this.tabConfiguracion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabConfiguracion.Location = new System.Drawing.Point(0, 0);
            this.tabConfiguracion.Name = "tabConfiguracion";
            this.tabConfiguracion.SelectedIndex = 0;
            this.tabConfiguracion.Size = new System.Drawing.Size(415, 400);
            this.tabConfiguracion.TabIndex = 2;
            this.tabConfiguracion.SelectedIndexChanged += new System.EventHandler(this.tabConfiguracion_SelectedIndexChanged);
            // 
            // tpTipoCambio
            // 
            this.tpTipoCambio.Controls.Add(this.button1);
            this.tpTipoCambio.Controls.Add(this.btnGuardarTipoCambio);
            this.tpTipoCambio.Controls.Add(this.btnHistorial);
            this.tpTipoCambio.Controls.Add(this.groupBox2);
            this.tpTipoCambio.Location = new System.Drawing.Point(4, 22);
            this.tpTipoCambio.Name = "tpTipoCambio";
            this.tpTipoCambio.Padding = new System.Windows.Forms.Padding(3);
            this.tpTipoCambio.Size = new System.Drawing.Size(407, 374);
            this.tpTipoCambio.TabIndex = 0;
            this.tpTipoCambio.Text = "Tipo de cambio";
            this.tpTipoCambio.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(280, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 25);
            this.button1.TabIndex = 29;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnGuardarTipoCambio
            // 
            this.btnGuardarTipoCambio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarTipoCambio.Location = new System.Drawing.Point(171, 327);
            this.btnGuardarTipoCambio.Name = "btnGuardarTipoCambio";
            this.btnGuardarTipoCambio.Size = new System.Drawing.Size(103, 25);
            this.btnGuardarTipoCambio.TabIndex = 28;
            this.btnGuardarTipoCambio.Text = "Guardar";
            this.btnGuardarTipoCambio.UseVisualStyleBackColor = true;
            // 
            // btnHistorial
            // 
            this.btnHistorial.Image = ((System.Drawing.Image)(resources.GetObject("btnHistorial.Image")));
            this.btnHistorial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistorial.Location = new System.Drawing.Point(62, 327);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(103, 25);
            this.btnHistorial.TabIndex = 28;
            this.btnHistorial.Text = "Historial";
            this.btnHistorial.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtFecha);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lblTipoDeCambio);
            this.groupBox2.Controls.Add(this.txtTipoDeCambio);
            this.groupBox2.Location = new System.Drawing.Point(25, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(357, 270);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de cambio del dollar";
            // 
            // dtFecha
            // 
            this.dtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(103, 157);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(198, 21);
            this.dtFecha.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(56, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Capturar tipo de cambio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(56, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "Fecha:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(129, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 31);
            this.label10.TabIndex = 27;
            this.label10.Text = "=";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(28, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 31);
            this.label9.TabIndex = 27;
            this.label9.Text = "USD $1";
            // 
            // lblTipoDeCambio
            // 
            this.lblTipoDeCambio.AutoSize = true;
            this.lblTipoDeCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDeCambio.ForeColor = System.Drawing.Color.Green;
            this.lblTipoDeCambio.Location = new System.Drawing.Point(156, 43);
            this.lblTipoDeCambio.Name = "lblTipoDeCambio";
            this.lblTipoDeCambio.Size = new System.Drawing.Size(164, 31);
            this.lblTipoDeCambio.TabIndex = 27;
            this.lblTipoDeCambio.Text = "MXN $00.00";
            // 
            // txtTipoDeCambio
            // 
            this.txtTipoDeCambio.Location = new System.Drawing.Point(201, 122);
            this.txtTipoDeCambio.MaxLength = 5;
            this.txtTipoDeCambio.Name = "txtTipoDeCambio";
            this.txtTipoDeCambio.Size = new System.Drawing.Size(100, 20);
            this.txtTipoDeCambio.TabIndex = 23;
            // 
            // tpImpresora
            // 
            this.tpImpresora.Controls.Add(this.btnCancelar);
            this.tpImpresora.Controls.Add(this.btnGuardar);
            this.tpImpresora.Controls.Add(this.groupBox1);
            this.tpImpresora.Location = new System.Drawing.Point(4, 22);
            this.tpImpresora.Name = "tpImpresora";
            this.tpImpresora.Padding = new System.Windows.Forms.Padding(3);
            this.tpImpresora.Size = new System.Drawing.Size(407, 374);
            this.tpImpresora.TabIndex = 1;
            this.tpImpresora.Text = "Impresora";
            this.tpImpresora.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(280, 327);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 25);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(171, 327);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(103, 25);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbImpresoraTickets);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(25, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 270);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Impresoras disponibles";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Impresora disponibles:";
            // 
            // cbImpresoraTickets
            // 
            this.cbImpresoraTickets.FormattingEnabled = true;
            this.cbImpresoraTickets.Location = new System.Drawing.Point(20, 93);
            this.cbImpresoraTickets.Name = "cbImpresoraTickets";
            this.cbImpresoraTickets.Size = new System.Drawing.Size(315, 21);
            this.cbImpresoraTickets.TabIndex = 19;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 37);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Selecciona impresora para los tickets";
            // 
            // tpConexion
            // 
            this.tpConexion.Controls.Add(this.button2);
            this.tpConexion.Controls.Add(this.gbConexion);
            this.tpConexion.Controls.Add(this.btnCargar);
            this.tpConexion.Controls.Add(this.button3);
            this.tpConexion.Location = new System.Drawing.Point(4, 22);
            this.tpConexion.Name = "tpConexion";
            this.tpConexion.Size = new System.Drawing.Size(407, 374);
            this.tpConexion.TabIndex = 2;
            this.tpConexion.Text = "Conexion";
            this.tpConexion.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(280, 327);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 25);
            this.button2.TabIndex = 22;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // gbConexion
            // 
            this.gbConexion.Controls.Add(this.picConexion);
            this.gbConexion.Controls.Add(this.txtBaseDatos);
            this.gbConexion.Controls.Add(this.txtContrasena);
            this.gbConexion.Controls.Add(this.txtUsuario);
            this.gbConexion.Controls.Add(this.txtServidor);
            this.gbConexion.Controls.Add(this.label5);
            this.gbConexion.Controls.Add(this.label6);
            this.gbConexion.Controls.Add(this.label7);
            this.gbConexion.Controls.Add(this.label8);
            this.gbConexion.Location = new System.Drawing.Point(25, 37);
            this.gbConexion.Name = "gbConexion";
            this.gbConexion.Size = new System.Drawing.Size(357, 270);
            this.gbConexion.TabIndex = 21;
            this.gbConexion.TabStop = false;
            this.gbConexion.Text = "Cadena de conexion a la base de datos";
            // 
            // picConexion
            // 
            this.picConexion.BackColor = System.Drawing.SystemColors.ControlDark;
            this.picConexion.Image = ((System.Drawing.Image)(resources.GetObject("picConexion.Image")));
            this.picConexion.Location = new System.Drawing.Point(26, 45);
            this.picConexion.Name = "picConexion";
            this.picConexion.Size = new System.Drawing.Size(99, 190);
            this.picConexion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picConexion.TabIndex = 17;
            this.picConexion.TabStop = false;
            // 
            // txtBaseDatos
            // 
            this.txtBaseDatos.Location = new System.Drawing.Point(137, 165);
            this.txtBaseDatos.Name = "txtBaseDatos";
            this.txtBaseDatos.Size = new System.Drawing.Size(185, 20);
            this.txtBaseDatos.TabIndex = 2;
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(137, 206);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(185, 20);
            this.txtContrasena.TabIndex = 3;
            this.txtContrasena.UseSystemPasswordChar = true;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(137, 124);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(185, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(137, 82);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(185, 20);
            this.txtServidor.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(135, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Base de datos:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(135, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Contraseña:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(135, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Usuario:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(135, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Servidor:";
            // 
            // btnCargar
            // 
            this.btnCargar.Image = ((System.Drawing.Image)(resources.GetObject("btnCargar.Image")));
            this.btnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargar.Location = new System.Drawing.Point(55, 327);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(110, 25);
            this.btnCargar.TabIndex = 20;
            this.btnCargar.Text = "Conexion actual";
            this.btnCargar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCargar.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(171, 327);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 25);
            this.button3.TabIndex = 19;
            this.button3.Text = "Guardar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // tpNegocio
            // 
            this.tpNegocio.Location = new System.Drawing.Point(4, 22);
            this.tpNegocio.Name = "tpNegocio";
            this.tpNegocio.Padding = new System.Windows.Forms.Padding(3);
            this.tpNegocio.Size = new System.Drawing.Size(407, 374);
            this.tpNegocio.TabIndex = 3;
            this.tpNegocio.Text = "Negocio";
            this.tpNegocio.UseVisualStyleBackColor = true;
            // 
            // FrmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 400);
            this.Controls.Add(this.tabConfiguracion);
            this.Name = "FrmConfiguracion";
            this.Text = "Configuración";
            this.Load += new System.EventHandler(this.FrmConfiguracion_Load);
            this.tabConfiguracion.ResumeLayout(false);
            this.tpTipoCambio.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tpImpresora.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tpConexion.ResumeLayout(false);
            this.gbConexion.ResumeLayout(false);
            this.gbConexion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picConexion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabConfiguracion;
        private System.Windows.Forms.TabPage tpTipoCambio;
        private System.Windows.Forms.TabPage tpImpresora;
        private System.Windows.Forms.TabPage tpConexion;
        private System.Windows.Forms.Button btnGuardarTipoCambio;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Label lblTipoDeCambio;
        private System.Windows.Forms.TextBox txtTipoDeCambio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbImpresoraTickets;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox gbConexion;
        private System.Windows.Forms.PictureBox picConexion;
        private System.Windows.Forms.TextBox txtBaseDatos;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tpNegocio;


    }
}