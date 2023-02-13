namespace Developers
{
    partial class FrmEdicionClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEdicionClientes));
            this.Barra = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnIngresaBoleta = new System.Windows.Forms.ToolStripButton();
            this.btnHuella = new System.Windows.Forms.ToolStripButton();
            this.lblNombre = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbColonia = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.txtNumInt = new System.Windows.Forms.TextBox();
            this.txtNumExt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.nudSaldo = new System.Windows.Forms.NumericUpDown();
            this.cbLimite = new System.Windows.Forms.ComboBox();
            this.cbCobro = new System.Windows.Forms.ComboBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.txtCURP = new System.Windows.Forms.MaskedTextBox();
            this.txtTelefono = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRFC = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtApeMat = new System.Windows.Forms.TextBox();
            this.txtApePat = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblPagoIni = new System.Windows.Forms.Label();
            this.Barra.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Barra
            // 
            this.Barra.BackColor = System.Drawing.SystemColors.Control;
            this.Barra.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Barra.ImageScalingSize = new System.Drawing.Size(15, 15);
            this.Barra.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.btnNuevo,
            this.btnIngresaBoleta,
            this.btnHuella});
            this.Barra.Location = new System.Drawing.Point(0, 0);
            this.Barra.Name = "Barra";
            this.Barra.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Barra.Size = new System.Drawing.Size(631, 25);
            this.Barra.TabIndex = 0;
            this.Barra.Text = "toolStrip1";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(68, 22);
            this.btnNuevo.Text = "Guardar";
            this.btnNuevo.ToolTipText = "Ventas ";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnIngresaBoleta
            // 
            this.btnIngresaBoleta.Enabled = false;
            this.btnIngresaBoleta.Image = ((System.Drawing.Image)(resources.GetObject("btnIngresaBoleta.Image")));
            this.btnIngresaBoleta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIngresaBoleta.Name = "btnIngresaBoleta";
            this.btnIngresaBoleta.Size = new System.Drawing.Size(152, 22);
            this.btnIngresaBoleta.Text = "Ingresar datos de Boleta";
            // 
            // btnHuella
            // 
            this.btnHuella.Image = ((System.Drawing.Image)(resources.GetObject("btnHuella.Image")));
            this.btnHuella.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHuella.Name = "btnHuella";
            this.btnHuella.Size = new System.Drawing.Size(96, 22);
            this.btnHuella.Text = "Huella digital";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblNombre.Location = new System.Drawing.Point(49, 40);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(0, 28);
            this.lblNombre.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.nudSaldo);
            this.groupBox1.Controls.Add(this.cbLimite);
            this.groupBox1.Controls.Add(this.cbCobro);
            this.groupBox1.Controls.Add(this.txtCorreo);
            this.groupBox1.Controls.Add(this.txtInfo);
            this.groupBox1.Controls.Add(this.txtCURP);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtRFC);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtApeMat);
            this.groupBox1.Controls.Add(this.txtApePat);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Location = new System.Drawing.Point(8, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 404);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtComplemento);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cbColonia);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtCiudad);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtCalle);
            this.groupBox2.Controls.Add(this.txtNumInt);
            this.groupBox2.Controls.Add(this.txtNumExt);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(1, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 157);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Direccion";
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.MistyRose;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 43);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 23);
            this.label17.TabIndex = 10;
            this.label17.Text = "COMPLEMENTO:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtComplemento
            // 
            this.txtComplemento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtComplemento.Location = new System.Drawing.Point(112, 43);
            this.txtComplemento.MaxLength = 40;
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(488, 23);
            this.txtComplemento.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.MistyRose;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Location = new System.Drawing.Point(6, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 23);
            this.label11.TabIndex = 7;
            this.label11.Text = "NUMERO EXT:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbColonia
            // 
            this.cbColonia.FormattingEnabled = true;
            this.cbColonia.Location = new System.Drawing.Point(112, 98);
            this.cbColonia.Name = "cbColonia";
            this.cbColonia.Size = new System.Drawing.Size(203, 23);
            this.cbColonia.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.MistyRose;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 7;
            this.label7.Text = "CALLE:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.MistyRose;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(6, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "COLONIA:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCiudad
            // 
            this.txtCiudad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCiudad.Location = new System.Drawing.Point(112, 124);
            this.txtCiudad.MaxLength = 40;
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(486, 23);
            this.txtCiudad.TabIndex = 5;
            this.txtCiudad.Text = "SAN LUIS RIO COLORADO";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Azure;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(280, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 23);
            this.label12.TabIndex = 7;
            this.label12.Text = "NUMERO INT";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCalle
            // 
            this.txtCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCalle.Location = new System.Drawing.Point(112, 16);
            this.txtCalle.MaxLength = 40;
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(488, 23);
            this.txtCalle.TabIndex = 0;
            // 
            // txtNumInt
            // 
            this.txtNumInt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumInt.Location = new System.Drawing.Point(405, 69);
            this.txtNumInt.MaxLength = 5;
            this.txtNumInt.Name = "txtNumInt";
            this.txtNumInt.Size = new System.Drawing.Size(195, 23);
            this.txtNumInt.TabIndex = 3;
            // 
            // txtNumExt
            // 
            this.txtNumExt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumExt.Location = new System.Drawing.Point(112, 69);
            this.txtNumExt.MaxLength = 5;
            this.txtNumExt.Name = "txtNumExt";
            this.txtNumExt.Size = new System.Drawing.Size(162, 23);
            this.txtNumExt.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Azure;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Location = new System.Drawing.Point(6, 124);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 23);
            this.label13.TabIndex = 7;
            this.label13.Text = "CIUDAD:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudSaldo
            // 
            this.nudSaldo.DecimalPlaces = 2;
            this.nudSaldo.Enabled = false;
            this.nudSaldo.Location = new System.Drawing.Point(507, 78);
            this.nudSaldo.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudSaldo.Name = "nudSaldo";
            this.nudSaldo.Size = new System.Drawing.Size(94, 23);
            this.nudSaldo.TabIndex = 5;
            // 
            // cbLimite
            // 
            this.cbLimite.DisplayMember = "CantidadLimite";
            this.cbLimite.Enabled = false;
            this.cbLimite.FormattingEnabled = true;
            this.cbLimite.Location = new System.Drawing.Point(322, 78);
            this.cbLimite.Name = "cbLimite";
            this.cbLimite.Size = new System.Drawing.Size(115, 23);
            this.cbLimite.TabIndex = 4;
            this.cbLimite.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbLimite_KeyPress);
            // 
            // cbCobro
            // 
            this.cbCobro.DisplayMember = "CantidadLimite";
            this.cbCobro.FormattingEnabled = true;
            this.cbCobro.Items.AddRange(new object[] {
            "NO COBRAR",
            "LUNES",
            "MARTES",
            "MIERCOLES",
            "JUEVES",
            "VIERNES",
            "SABADO",
            "DOMINGO"});
            this.cbCobro.Location = new System.Drawing.Point(115, 78);
            this.cbCobro.Name = "cbCobro";
            this.cbCobro.Size = new System.Drawing.Size(98, 23);
            this.cbCobro.TabIndex = 3;
            this.cbCobro.Text = "NO COBRAR";
            this.cbCobro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbCobro_KeyPress);
            // 
            // txtCorreo
            // 
            this.txtCorreo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCorreo.Location = new System.Drawing.Point(408, 298);
            this.txtCorreo.MaxLength = 5;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(193, 23);
            this.txtCorreo.TabIndex = 9;
            // 
            // txtInfo
            // 
            this.txtInfo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInfo.Location = new System.Drawing.Point(115, 327);
            this.txtInfo.MaxLength = 250;
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(486, 71);
            this.txtInfo.TabIndex = 10;
            // 
            // txtCURP
            // 
            this.txtCURP.Location = new System.Drawing.Point(115, 299);
            this.txtCURP.Mask = "LLLL-######-LLLLLL-##";
            this.txtCURP.Name = "txtCURP";
            this.txtCURP.Size = new System.Drawing.Size(161, 23);
            this.txtCURP.TabIndex = 8;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(115, 270);
            this.txtTelefono.Mask = "(999)000-0000";
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(161, 23);
            this.txtTelefono.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Azure;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Location = new System.Drawing.Point(234, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 23);
            this.label14.TabIndex = 7;
            this.label14.Text = "LIM CRED:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRFC
            // 
            this.txtRFC.Location = new System.Drawing.Point(408, 270);
            this.txtRFC.Mask = "LLLL-######-##";
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Size = new System.Drawing.Size(193, 23);
            this.txtRFC.TabIndex = 7;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.MistyRose;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Location = new System.Drawing.Point(9, 78);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 23);
            this.label15.TabIndex = 7;
            this.label15.Text = "DIA DE COBRO:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Azure;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(282, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "CORREO:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Azure;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(9, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "TEL:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Azure;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(282, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "RFC:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Azure;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Location = new System.Drawing.Point(9, 327);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 23);
            this.label16.TabIndex = 8;
            this.label16.Text = "INF. EXTRA:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Azure;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(9, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "CURP:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Azure;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(443, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 23);
            this.label8.TabIndex = 6;
            this.label8.Text = "SALDO:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.MistyRose;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(308, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 6;
            this.label10.Text = "AP. MATERNO:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.MistyRose;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(9, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 6;
            this.label9.Text = "AP. PATERNO:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.MistyRose;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "NOMBRE:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtApeMat
            // 
            this.txtApeMat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApeMat.Location = new System.Drawing.Point(414, 48);
            this.txtApeMat.MaxLength = 20;
            this.txtApeMat.Name = "txtApeMat";
            this.txtApeMat.Size = new System.Drawing.Size(187, 23);
            this.txtApeMat.TabIndex = 2;
            this.txtApeMat.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtApeMat_KeyUp);
            // 
            // txtApePat
            // 
            this.txtApePat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApePat.Location = new System.Drawing.Point(115, 48);
            this.txtApePat.MaxLength = 20;
            this.txtApePat.Name = "txtApePat";
            this.txtApePat.Size = new System.Drawing.Size(187, 23);
            this.txtApePat.TabIndex = 1;
            this.txtApePat.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtApePat_KeyUp);
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(115, 19);
            this.txtNombre.MaxLength = 20;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(486, 23);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyUp);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(519, 486);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 25);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label18.Location = new System.Drawing.Point(85, 489);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(50, 25);
            this.label18.TabIndex = 16;
            this.label18.Text = "0.00";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(14, 497);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 15);
            this.label19.TabIndex = 17;
            this.label19.Text = "DISPONIBLE:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(224, 495);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(134, 15);
            this.label20.TabIndex = 19;
            this.label20.Text = "CON PAGO INCIAL DEL:";
            // 
            // lblPagoIni
            // 
            this.lblPagoIni.AutoSize = true;
            this.lblPagoIni.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagoIni.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPagoIni.Location = new System.Drawing.Point(361, 488);
            this.lblPagoIni.Name = "lblPagoIni";
            this.lblPagoIni.Size = new System.Drawing.Size(39, 25);
            this.lblPagoIni.TabIndex = 18;
            this.lblPagoIni.Text = "0%";
            // 
            // FrmEdicionClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(631, 517);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblPagoIni);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Barra);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEdicionClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edicion de clientes";
            this.Activated += new System.EventHandler(this.FrmEdicionClientes_Activated);
            this.Load += new System.EventHandler(this.FrmEdicionClientes_Load);
            this.Barra.ResumeLayout(false);
            this.Barra.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Barra;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txtCURP;
        private System.Windows.Forms.MaskedTextBox txtTelefono;
        private System.Windows.Forms.MaskedTextBox txtRFC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtApeMat;
        private System.Windows.Forms.TextBox txtApePat;
        private System.Windows.Forms.TextBox txtNumExt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumInt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbCobro;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cbLimite;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudSaldo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.ComboBox cbColonia;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtComplemento;
        private System.Windows.Forms.ToolStripButton btnIngresaBoleta;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblPagoIni;
        private System.Windows.Forms.ToolStripButton btnHuella;
    }
}