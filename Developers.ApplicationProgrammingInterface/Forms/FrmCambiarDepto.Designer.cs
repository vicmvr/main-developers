namespace Developers.Forms
{
    partial class FrmCambiarDepto
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
            this.cbDepto = new System.Windows.Forms.ComboBox();
            this.btnAsignaDepto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbDepto
            // 
            this.cbDepto.FormattingEnabled = true;
            this.cbDepto.Location = new System.Drawing.Point(22, 27);
            this.cbDepto.Name = "cbDepto";
            this.cbDepto.Size = new System.Drawing.Size(210, 21);
            this.cbDepto.TabIndex = 0;
            // 
            // btnAsignaDepto
            // 
            this.btnAsignaDepto.Location = new System.Drawing.Point(247, 25);
            this.btnAsignaDepto.Name = "btnAsignaDepto";
            this.btnAsignaDepto.Size = new System.Drawing.Size(130, 23);
            this.btnAsignaDepto.TabIndex = 1;
            this.btnAsignaDepto.Text = "Asignar Depto.";
            this.btnAsignaDepto.UseVisualStyleBackColor = true;
            this.btnAsignaDepto.Click += new System.EventHandler(this.btnAsignaDepto_Click);
            // 
            // FrmCambiarDepto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 78);
            this.Controls.Add(this.btnAsignaDepto);
            this.Controls.Add(this.cbDepto);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCambiarDepto";
            this.Text = "Asignar Depto.";
            this.Load += new System.EventHandler(this.FrmCambiarDepto_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDepto;
        private System.Windows.Forms.Button btnAsignaDepto;
    }
}