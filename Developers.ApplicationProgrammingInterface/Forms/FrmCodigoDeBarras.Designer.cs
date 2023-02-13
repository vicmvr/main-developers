namespace Developers
{
    partial class FrmCodigoDeBarras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCodigoDeBarras));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCodigoIndicar = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rbTrece = new System.Windows.Forms.RadioButton();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.rbOcho = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEnBarra = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox392 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGenerarCode39 = new System.Windows.Forms.Button();
            this.txtCodigo39 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox391 = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox392)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox391)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCodigoIndicar);
            this.groupBox1.Controls.Add(this.btnGenerar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rbTrece);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.rbOcho);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtAddon);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 48);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // lblCodigoIndicar
            // 
            this.lblCodigoIndicar.AutoSize = true;
            this.lblCodigoIndicar.Location = new System.Drawing.Point(280, 22);
            this.lblCodigoIndicar.Name = "lblCodigoIndicar";
            this.lblCodigoIndicar.Size = new System.Drawing.Size(58, 15);
            this.lblCodigoIndicar.TabIndex = 9;
            this.lblCodigoIndicar.Text = "12 dígitos";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerar.Image")));
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(348, 15);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(100, 25);
            this.btnGenerar.TabIndex = 1;
            this.btnGenerar.Text = "Generar ";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "EAN";
            this.label3.Visible = false;
            // 
            // rbTrece
            // 
            this.rbTrece.AutoSize = true;
            this.rbTrece.Checked = true;
            this.rbTrece.Enabled = false;
            this.rbTrece.Location = new System.Drawing.Point(237, 95);
            this.rbTrece.Name = "rbTrece";
            this.rbTrece.Size = new System.Drawing.Size(37, 19);
            this.rbTrece.TabIndex = 4;
            this.rbTrece.TabStop = true;
            this.rbTrece.Text = "13";
            this.rbTrece.UseVisualStyleBackColor = true;
            this.rbTrece.Visible = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(132, 18);
            this.txtCodigo.MaxLength = 12;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(142, 23);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // rbOcho
            // 
            this.rbOcho.AutoSize = true;
            this.rbOcho.Enabled = false;
            this.rbOcho.Location = new System.Drawing.Point(164, 95);
            this.rbOcho.Name = "rbOcho";
            this.rbOcho.Size = new System.Drawing.Size(31, 19);
            this.rbOcho.TabIndex = 3;
            this.rbOcho.TabStop = true;
            this.rbOcho.Text = "8";
            this.rbOcho.UseVisualStyleBackColor = true;
            this.rbOcho.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Precio de contado";
            this.label2.Visible = false;
            // 
            // txtAddon
            // 
            this.txtAddon.Location = new System.Drawing.Point(132, 52);
            this.txtAddon.MaxLength = 12;
            this.txtAddon.Name = "txtAddon";
            this.txtAddon.Size = new System.Drawing.Size(142, 23);
            this.txtAddon.TabIndex = 1;
            this.txtAddon.Visible = false;
            this.txtAddon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddon_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Código";
            // 
            // txtEnBarra
            // 
            this.txtEnBarra.Enabled = false;
            this.txtEnBarra.Font = new System.Drawing.Font("Code EAN13", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.txtEnBarra.HideSelection = false;
            this.txtEnBarra.Location = new System.Drawing.Point(7, 61);
            this.txtEnBarra.Name = "txtEnBarra";
            this.txtEnBarra.ReadOnly = true;
            this.txtEnBarra.Size = new System.Drawing.Size(452, 87);
            this.txtEnBarra.TabIndex = 12;
            this.txtEnBarra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEnBarra.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(14, 14);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(473, 248);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.txtEnBarra);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(465, 220);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Estandar EAN13";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Código final de 13 dígitos";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Location = new System.Drawing.Point(6, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(453, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox392);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.pictureBox391);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(465, 220);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CODE39";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox392
            // 
            this.pictureBox392.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox392.Location = new System.Drawing.Point(7, 188);
            this.pictureBox392.Name = "pictureBox392";
            this.pictureBox392.Size = new System.Drawing.Size(460, 190);
            this.pictureBox392.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox392.TabIndex = 13;
            this.pictureBox392.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGenerarCode39);
            this.groupBox2.Controls.Add(this.txtCodigo39);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(7, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 55);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // btnGenerarCode39
            // 
            this.btnGenerarCode39.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGenerarCode39.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerarCode39.Image")));
            this.btnGenerarCode39.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarCode39.Location = new System.Drawing.Point(307, 15);
            this.btnGenerarCode39.Name = "btnGenerarCode39";
            this.btnGenerarCode39.Size = new System.Drawing.Size(146, 28);
            this.btnGenerarCode39.TabIndex = 9;
            this.btnGenerarCode39.Text = "Generar ";
            this.btnGenerarCode39.UseVisualStyleBackColor = true;
            this.btnGenerarCode39.Click += new System.EventHandler(this.btnGenerarCode39_Click);
            // 
            // txtCodigo39
            // 
            this.txtCodigo39.Location = new System.Drawing.Point(61, 18);
            this.txtCodigo39.MaxLength = 20;
            this.txtCodigo39.Name = "txtCodigo39";
            this.txtCodigo39.Size = new System.Drawing.Size(238, 23);
            this.txtCodigo39.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "Código";
            // 
            // pictureBox391
            // 
            this.pictureBox391.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox391.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox391.Location = new System.Drawing.Point(7, 69);
            this.pictureBox391.Name = "pictureBox391";
            this.pictureBox391.Size = new System.Drawing.Size(459, 111);
            this.pictureBox391.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox391.TabIndex = 5;
            this.pictureBox391.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(398, 266);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(89, 25);
            this.btnCancelar.TabIndex = 33;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(35, 324);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(308, 96);
            this.richTextBox1.TabIndex = 34;
            this.richTextBox1.Text = "";
            // 
            // FrmCodigoDeBarras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(499, 296);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCodigoDeBarras";
            this.Text = "Código de barras";
            this.Load += new System.EventHandler(this.FrmCodigoDeBarras_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox392)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox391)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCodigoIndicar;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbTrece;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.RadioButton rbOcho;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEnBarra;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCodigo39;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox391;
        private System.Windows.Forms.PictureBox pictureBox392;
        private System.Windows.Forms.Button btnGenerarCode39;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}