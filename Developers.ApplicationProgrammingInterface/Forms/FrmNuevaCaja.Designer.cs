namespace Developers
{
    partial class FrmNuevaCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNuevaCaja));
            this.Barra = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbIDSucursal = new System.Windows.Forms.ComboBox();
            this.txtNombreCaja = new System.Windows.Forms.TextBox();
            this.txtIDCaja = new System.Windows.Forms.TextBox();
            this.txtNombreSucursal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Barra.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Barra
            // 
            this.Barra.BackColor = System.Drawing.SystemColors.Control;
            this.Barra.ImageScalingSize = new System.Drawing.Size(15, 15);
            this.Barra.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.btnGuardar,
            this.toolStripSeparator4,
            this.btnCancel});
            this.Barra.Location = new System.Drawing.Point(0, 0);
            this.Barra.Name = "Barra";
            this.Barra.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Barra.Size = new System.Drawing.Size(472, 25);
            this.Barra.TabIndex = 14;
            this.Barra.Text = "toolStrip1";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 22);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.ToolTipText = "Ventas ";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 22);
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.ToolTipText = "Editar";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbIDSucursal);
            this.groupBox1.Controls.Add(this.txtNombreCaja);
            this.groupBox1.Controls.Add(this.txtIDCaja);
            this.groupBox1.Controls.Add(this.txtNombreSucursal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 202);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // cbIDSucursal
            // 
            this.cbIDSucursal.FormattingEnabled = true;
            this.cbIDSucursal.Location = new System.Drawing.Point(138, 109);
            this.cbIDSucursal.Name = "cbIDSucursal";
            this.cbIDSucursal.Size = new System.Drawing.Size(294, 23);
            this.cbIDSucursal.TabIndex = 2;
            this.cbIDSucursal.SelectedIndexChanged += new System.EventHandler(this.cbIDSucursal_SelectedIndexChanged);
            this.cbIDSucursal.SelectedValueChanged += new System.EventHandler(this.cbIDSucursal_SelectedValueChanged);
            // 
            // txtNombreCaja
            // 
            this.txtNombreCaja.Location = new System.Drawing.Point(138, 78);
            this.txtNombreCaja.MaxLength = 10;
            this.txtNombreCaja.Name = "txtNombreCaja";
            this.txtNombreCaja.Size = new System.Drawing.Size(294, 23);
            this.txtNombreCaja.TabIndex = 1;
            // 
            // txtIDCaja
            // 
            this.txtIDCaja.Location = new System.Drawing.Point(138, 49);
            this.txtIDCaja.Name = "txtIDCaja";
            this.txtIDCaja.ReadOnly = true;
            this.txtIDCaja.Size = new System.Drawing.Size(294, 23);
            this.txtIDCaja.TabIndex = 0;
            // 
            // txtNombreSucursal
            // 
            this.txtNombreSucursal.Location = new System.Drawing.Point(138, 142);
            this.txtNombreSucursal.Name = "txtNombreSucursal";
            this.txtNombreSucursal.ReadOnly = true;
            this.txtNombreSucursal.Size = new System.Drawing.Size(294, 23);
            this.txtNombreSucursal.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "ID Caja:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre Sucursal:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nombre de Caja:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID sucursal:";
            // 
            // FrmNuevaCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(472, 247);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Barra);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNuevaCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edicion de Cajas";
            this.Load += new System.EventHandler(this.FrmNuevaTasa_Load);
            this.Barra.ResumeLayout(false);
            this.Barra.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Barra;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreSucursal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbIDSucursal;
        private System.Windows.Forms.TextBox txtNombreCaja;
        private System.Windows.Forms.TextBox txtIDCaja;
        private System.Windows.Forms.Label label2;
    }
}