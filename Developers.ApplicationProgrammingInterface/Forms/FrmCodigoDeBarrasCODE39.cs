using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Developers.Forms
{
    public partial class FrmCodigoDeBarrasCODE39 : Form
    {
        Int64 codd = 0;
        String NombreF = "";
        private int m_longitud;
        public FrmCodigoDeBarrasCODE39()
        {
            InitializeComponent();
        }

        private void btnGenerarCode39_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo39.Text;
            Code39 code = new Code39(codigo);
            string NombreDeCarpeta = @"c:\\Codigos";
            System.IO.Directory.CreateDirectory(NombreDeCarpeta);
            code.Paint().Save("c:\\Codigos\\" + codigo + ".Png", ImageFormat.Png);


            //var imgPictureBox = new PictureBox();
            //imgPictureBox.Location = new System.Drawing.Point(15, 89);
            //imgPictureBox.Size = new System.Drawing.Size(140, 140);
            //imgPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox391.Image = Image.FromFile(@"C:\\Codigos\\" + codigo + ".png");
            pictureBox392.Image = Image.FromFile(@"C:\\Codigos\\" + codigo + ".png");
            //Controls.Add(imgPictureBox);
            //this.Close();
        }

        private void FrmCodigoDeBarrasCODE39_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage1);
        }
    }
}
