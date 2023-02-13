namespace Developers
{
    partial class FrmAbrirCorte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbrirCorte));
            this.label1 = new System.Windows.Forms.Label();
            this.totalFondo = new System.Windows.Forms.NumericUpDown();
            this.btnAbirCorte = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.totalFondo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(85, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "TOTAL EFECTIVO EN CAJA:";
            // 
            // totalFondo
            // 
            this.totalFondo.DecimalPlaces = 2;
            this.totalFondo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.totalFondo.Location = new System.Drawing.Point(125, 77);
            this.totalFondo.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.totalFondo.Name = "totalFondo";
            this.totalFondo.Size = new System.Drawing.Size(115, 29);
            this.totalFondo.TabIndex = 0;
            this.totalFondo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.totalFondo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.totalFondo_KeyPress);
            // 
            // btnAbirCorte
            // 
            this.btnAbirCorte.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbirCorte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbirCorte.Location = new System.Drawing.Point(46, 133);
            this.btnAbirCorte.Name = "btnAbirCorte";
            this.btnAbirCorte.Size = new System.Drawing.Size(125, 28);
            this.btnAbirCorte.TabIndex = 16;
            this.btnAbirCorte.Text = "Abrir Corte";
            this.btnAbirCorte.UseVisualStyleBackColor = true;
            this.btnAbirCorte.Click += new System.EventHandler(this.btnAbirCorte_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(205, 133);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(125, 28);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // FrmAbrirCorte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(365, 184);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAbirCorte);
            this.Controls.Add(this.totalFondo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbrirCorte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Abrir Corte";
            this.Load += new System.EventHandler(this.FrmAbrirCorte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.totalFondo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown totalFondo;
        private System.Windows.Forms.Button btnAbirCorte;
        private System.Windows.Forms.Button btnCancelar;
    }
}