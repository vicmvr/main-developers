namespace Series
{
    partial class Series
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Series));
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtSerieFinal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnPCActual = new System.Windows.Forms.Button();
            this.btnManual = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(113, 66);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(482, 23);
            this.txtID.TabIndex = 1;
            this.txtID.Text = "3FEBFBFF00000F24-IUMV20421042";
            // 
            // txtSerieFinal
            // 
            this.txtSerieFinal.Location = new System.Drawing.Point(113, 95);
            this.txtSerieFinal.Name = "txtSerieFinal";
            this.txtSerieFinal.ReadOnly = true;
            this.txtSerieFinal.Size = new System.Drawing.Size(482, 23);
            this.txtSerieFinal.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Serie Final:";
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(14, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(605, 2);
            this.label7.TabIndex = 0;
            this.label7.Text = "Linea";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(180, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(271, 21);
            this.label8.TabIndex = 0;
            this.label8.Text = "GENERADOR DE NUMEROS DE SERIE";
            // 
            // btnCopiar
            // 
            this.btnCopiar.Image = ((System.Drawing.Image)(resources.GetObject("btnCopiar.Image")));
            this.btnCopiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopiar.Location = new System.Drawing.Point(411, 137);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(184, 24);
            this.btnCopiar.TabIndex = 6;
            this.btnCopiar.Text = "COPIAR Y SALIR";
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // btnPCActual
            // 
            this.btnPCActual.Location = new System.Drawing.Point(208, 138);
            this.btnPCActual.Name = "btnPCActual";
            this.btnPCActual.Size = new System.Drawing.Size(75, 23);
            this.btnPCActual.TabIndex = 7;
            this.btnPCActual.Text = "PC actual";
            this.btnPCActual.UseVisualStyleBackColor = true;
            this.btnPCActual.Click += new System.EventHandler(this.btnPCActual_Click);
            // 
            // btnManual
            // 
            this.btnManual.Location = new System.Drawing.Point(127, 138);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(75, 23);
            this.btnManual.TabIndex = 8;
            this.btnManual.Text = "Manual";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // Series
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 182);
            this.Controls.Add(this.btnManual);
            this.Controls.Add(this.btnPCActual);
            this.Controls.Add(this.btnCopiar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSerieFinal);
            this.Controls.Add(this.txtID);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Series";
            this.Text = "GENERADOR DE NUMEROS DE SERIE V1";
            this.Load += new System.EventHandler(this.Series_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtSerieFinal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.Button btnPCActual;
        private System.Windows.Forms.Button btnManual;
    }
}

