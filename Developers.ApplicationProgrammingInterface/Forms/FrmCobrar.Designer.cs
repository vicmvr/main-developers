namespace Developers
{
    partial class FrmCobrar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCobrar));
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblpago = new System.Windows.Forms.Label();
            this.lblcambio = new System.Windows.Forms.Label();
            this.txtPago = new System.Windows.Forms.TextBox();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblpago2 = new System.Windows.Forms.Label();
            this.txtpagod = new System.Windows.Forms.TextBox();
            this.timerPago = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbldlls = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total a cobrar";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTotal.Location = new System.Drawing.Point(299, 36);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(110, 40);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "150.00";
            // 
            // lblpago
            // 
            this.lblpago.AutoSize = true;
            this.lblpago.BackColor = System.Drawing.Color.Transparent;
            this.lblpago.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpago.Location = new System.Drawing.Point(170, 163);
            this.lblpago.Name = "lblpago";
            this.lblpago.Size = new System.Drawing.Size(128, 20);
            this.lblpago.TabIndex = 3;
            this.lblpago.Text = "Pagó con pesos: $";
            // 
            // lblcambio
            // 
            this.lblcambio.AutoSize = true;
            this.lblcambio.BackColor = System.Drawing.Color.Transparent;
            this.lblcambio.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcambio.Location = new System.Drawing.Point(150, 232);
            this.lblcambio.Name = "lblcambio";
            this.lblcambio.Size = new System.Drawing.Size(148, 20);
            this.lblcambio.TabIndex = 4;
            this.lblcambio.Text = "Cambio (en pesos): $";
            // 
            // txtPago
            // 
            this.txtPago.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPago.Location = new System.Drawing.Point(305, 160);
            this.txtPago.MaxLength = 10;
            this.txtPago.Name = "txtPago";
            this.txtPago.Size = new System.Drawing.Size(116, 27);
            this.txtPago.TabIndex = 0;
            this.txtPago.Text = "0";
            this.txtPago.TextChanged += new System.EventHandler(this.txtPago_TextChanged);
            this.txtPago.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPago_KeyDown);
            this.txtPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPago_KeyPress);
            // 
            // txtCambio
            // 
            this.txtCambio.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCambio.Location = new System.Drawing.Point(305, 229);
            this.txtCambio.MaxLength = 10;
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.ReadOnly = true;
            this.txtCambio.Size = new System.Drawing.Size(116, 27);
            this.txtCambio.TabIndex = 2;
            this.txtCambio.Text = "0";
            // 
            // btnCobrar
            // 
            this.btnCobrar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCobrar.Enabled = false;
            this.btnCobrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCobrar.Image")));
            this.btnCobrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCobrar.Location = new System.Drawing.Point(208, 325);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(182, 39);
            this.btnCobrar.TabIndex = 3;
            this.btnCobrar.Text = "COBRAR";
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(208, 370);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(182, 39);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblpago2
            // 
            this.lblpago2.AutoSize = true;
            this.lblpago2.BackColor = System.Drawing.Color.Transparent;
            this.lblpago2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpago2.Location = new System.Drawing.Point(169, 193);
            this.lblpago2.Name = "lblpago2";
            this.lblpago2.Size = new System.Drawing.Size(129, 20);
            this.lblpago2.TabIndex = 3;
            this.lblpago2.Text = "Pagó con dollar: $";
            // 
            // txtpagod
            // 
            this.txtpagod.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpagod.Location = new System.Drawing.Point(305, 190);
            this.txtpagod.MaxLength = 10;
            this.txtpagod.Name = "txtpagod";
            this.txtpagod.Size = new System.Drawing.Size(116, 27);
            this.txtpagod.TabIndex = 1;
            this.txtpagod.Text = "0";
            this.txtpagod.TextChanged += new System.EventHandler(this.txtpagod_TextChanged);
            this.txtpagod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpagod_KeyDown);
            this.txtpagod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpagod_KeyPress);
            // 
            // timerPago
            // 
            this.timerPago.Enabled = true;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbldlls);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCambio);
            this.panel1.Controls.Add(this.btnCobrar);
            this.panel1.Controls.Add(this.txtpagod);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.txtPago);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.lblpago2);
            this.panel1.Controls.Add(this.lblpago);
            this.panel1.Controls.Add(this.lblcambio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(590, 424);
            this.panel1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(193, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 30);
            this.label4.TabIndex = 7;
            this.label4.Text = "En USD$:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(183, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = "En MNX$:";
            // 
            // lbldlls
            // 
            this.lbldlls.AutoSize = true;
            this.lbldlls.BackColor = System.Drawing.Color.Transparent;
            this.lbldlls.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldlls.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbldlls.Location = new System.Drawing.Point(299, 74);
            this.lbldlls.Name = "lbldlls";
            this.lbldlls.Size = new System.Drawing.Size(110, 40);
            this.lbldlls.TabIndex = 5;
            this.lbldlls.Text = "150.00";
            // 
            // FrmCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(590, 424);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmCobrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cobrar";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmCobrar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblpago;
        private System.Windows.Forms.Label lblcambio;
        private System.Windows.Forms.TextBox txtPago;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblpago2;
        private System.Windows.Forms.TextBox txtpagod;
        private System.Windows.Forms.Timer timerPago;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbldlls;
    }
}