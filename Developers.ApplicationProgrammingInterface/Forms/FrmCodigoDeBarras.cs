using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Developers
{
    public partial class FrmCodigoDeBarras : Form
    {
        Int64 codd = 0;
        String NombreF = "";
        private int m_longitud;
        public FrmCodigoDeBarras()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.TextLength < 12)
            {
                MessageBox.Show("Ingresa un codigo de 12 digitos.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //codd =1+ Convert.ToInt64(txtCodigo.Text);
            if ((rbTrece.Checked == true) && (txtCodigo.TextLength == 12))
            {
                string NombreDeCarpeta = @"c:\\Codigos";
                System.IO.Directory.CreateDirectory(NombreDeCarpeta);
                ConvertEAN();
                convertirTextoImagen(txtEnBarra.Text);
                //en la variable Nombre almaceno la ruta donde voy a guardar mi imagen, el nombre que tendrá la imagen y la extensión.
                string Nombre = "c:\\Codigos\\" + NombreF + txtAddon.Text + ".Png";
                //aquí recién guardamos la imagen mandando como parámetro la variable Nombre, colocando la extensión que tendrá la imagen  
                pictureBox1.Image.Save(Nombre, ImageFormat.Png);
            } 
            if ((rbOcho.Checked == true) && (txtCodigo.TextLength == 7))
            {
                ConvertEAN();
                convertirTextoImagen(txtEnBarra.Text);
                //en la variable Nombre almaceno la ruta donde voy a guardar mi imagen, el nombre que tendrá la imagen y la extensión.
                string Nombre = "c:\\Codigos\\" + NombreF + txtAddon.Text + ".Png";
                //aquí recién guardamos la imagen mandando como parámetro la variable Nombre, colocando la extensión que tendrá la imagen  
                pictureBox1.Image.Save(Nombre, ImageFormat.Png);
            }
            //richTextBox1.Text = richTextBox1.Text + NombreF+"\r\n";
            //txtCodigo.Text = codd.ToString();
            //if (codd == 701500600243)
            //{
            //    return;
            //}
            //else {
            //    btnGenerar.PerformClick();
            //}
        }
        private void convertirTextoImagen(string texto)
        {
            //creamos el objeto imagen Bitmap
            Bitmap objBitmap = new Bitmap(1, 1);
            int Width = 0;
            int Height = 0;
            //formateamos la fuente (tipo de letra, tamaño)
            Font objFont = new Font("Code EAN13", 600,
                System.Drawing.FontStyle.Regular,//.Bold,
                System.Drawing.GraphicsUnit.Pixel);

            //creamos un objeto Graphics a partir del Bitmap
            Graphics objGraphics = Graphics.FromImage(objBitmap);

            //establecemos el tamaño según la longitud del texto
            Width = (int)objGraphics.MeasureString(texto, objFont).Width;
            Height = (int)objGraphics.MeasureString(texto, objFont).Height;
            objBitmap = new Bitmap(objBitmap, new Size(Width, Height));

            objGraphics = Graphics.FromImage(objBitmap);

            objGraphics.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.HighQuality;//antialias
            objGraphics.CompositingQuality =
                System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            objGraphics.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;//.High;
            objGraphics.TextRenderingHint =
                System.Drawing.Text.TextRenderingHint.AntiAlias;//.AntiAlias;
            objGraphics.DrawString(texto, objFont,
                new SolidBrush(Color.FromArgb(0, 0, 0)), 0, 0);
            objGraphics.Flush();

            //var imgPictureBox = new PictureBox();
            //imgPictureBox.Location = new System.Drawing.Point(15, 89);
            //imgPictureBox.Size = new System.Drawing.Size(140, 140);
            //imgPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            //imgPictureBox.Image = objBitmap;
            //Controls.Add(imgPictureBox);
            //imgPictureBox.Visible = true;
            pictureBox1.Image = objBitmap;
        } 
        private void rbTrece_CheckedChanged(object sender, EventArgs e)
        {
            m_longitud = 12;
            txtCodigo.MaxLength = 12;
            lblCodigoIndicar.Text = "12 digitos";
        }

        private void rbOcho_CheckedChanged(object sender, EventArgs e)
        {
            m_longitud = 7;
            txtCodigo.MaxLength = 7;
            lblCodigoIndicar.Text = "7 digitos";
        }
        public void ConvertEAN()
        {
            string CodigoBarra;
            CodigoBarra = "";
            if (txtCodigo.Text.Trim().Length > 0)
            {
                int strL = m_longitud - txtCodigo.Text.Trim().Length;
                string str = "";
                for (int i = 1; i <= strL; i++)
                {
                    str = str + "0";
                }
                CodigoBarra = txtCodigo.Text + str;
            }

            string m_final = "";
            if (rbOcho.Checked == true)
                m_final = EANOcho(CodigoBarra) + AddOn(txtAddon.Text.Trim());
            else
                m_final = EANTrece(CodigoBarra) + AddOn(txtAddon.Text.Trim());

            txtEnBarra.Text = m_final;
        }

        public string EANOcho(string valor)
        {
            int i;
            double m_validador;
            string CodigoBarra = "";
            m_validador = 0;
            if (valor.Length == 7)
            {
                for (i = 1; i <= 7; i++)
                {
                    int L1 = Convert.ToChar(valor.Substring(i - 1, 1));
                    if ((L1 < 48) || (L1 > 57))
                    {
                        i = 0;
                        break;
                    }
                }
                if (i == 8)
                {
                    for (i = 7; i > 0; i = i - 2)
                    {
                        m_validador = m_validador + Convert.ToInt32(valor.Substring(i - 1, 1));
                    }
                    m_validador = m_validador * 3;

                    for (i = 6; i > 0; i = i - 2)
                    {
                        m_validador = m_validador + Convert.ToInt32(valor.Substring(i - 1, 1));
                    }
                    valor = valor + (10 - m_validador % 10) % 10;

                    CodigoBarra = ":";

                    for (i = 1; i <= 4; i++)
                    {
                        CodigoBarra = CodigoBarra + Convert.ToChar(65 + Convert.ToInt32(valor.Substring(i - 1, 1)));
                    }
                    CodigoBarra = CodigoBarra + "*";
                    for (i = 5; i <= 8; i++)
                    {
                        CodigoBarra = CodigoBarra + Convert.ToChar(97 + Convert.ToInt32(valor.Substring(i - 1, 1)));
                    }
                    CodigoBarra = CodigoBarra + "+";
                }
            }
            return CodigoBarra;
        }

        public object EANTrece(string valor)
        {
            object functionReturnValue = null;
            int i;
            int m_validador = 0;
            int m_primero;
            string CodigoBarra;
            bool tableA;
            functionReturnValue = "";
            if (valor.Length == 12)
            {
                for (i = 1; i <= 12; i++)
                {
                    int L1 = Convert.ToChar(valor.Substring(i - 1, 1));
                    if (L1 < 48 || L1 > 57)
                    {
                        i = 0;
                        break;
                    }
                }
                if (i == 13)
                {
                    for (i = 12; i >= 1; i += -2)
                    {
                        m_validador = m_validador + Convert.ToInt32(valor.Substring(i - 1, 1));
                    }
                    m_validador = m_validador * 3;
                    for (i = 11; i >= 1; i += -2)
                    {
                        m_validador = m_validador + Convert.ToInt32(valor.Substring(i - 1, 1));
                    }
                    valor = valor + (10 - m_validador % 10) % 10;
                    NombreF = valor;//para poner nombre completo en la imagen final
                    CodigoBarra = valor.Substring(0, 1) + Convert.ToChar(65 + Convert.ToInt32((valor.Substring(1, 1))));
                    m_primero = Convert.ToInt32(valor.Substring(0, 1));

                    for (i = 3; i <= 7; i++)
                    {
                        tableA = false;
                        switch (i)
                        {
                            case 3:
                                switch (m_primero)
                                {
                                    case 0:
                                    case 1:
                                    case 2:
                                    case 3:
                                        tableA = true;
                                        break;
                                }
                                break;
                            case 4:
                                switch (m_primero)
                                {
                                    case 0:
                                    case 4:
                                    case 7:
                                    case 8:
                                        tableA = true;
                                        break;
                                }
                                break;
                            case 5:
                                switch (m_primero)
                                {
                                    case 0:
                                    case 1:
                                    case 4:
                                    case 5:
                                    case 9:
                                        tableA = true;
                                        break;
                                }
                                break;
                            case 6:
                                switch (m_primero)
                                {
                                    case 0:
                                    case 2:
                                    case 5:
                                    case 6:
                                    case 7:
                                        tableA = true;
                                        break;
                                }
                                break;
                            case 7:
                                switch (m_primero)
                                {
                                    case 0:
                                    case 3:
                                    case 6:
                                    case 8:
                                    case 9:
                                        tableA = true;
                                        break;
                                }
                                break;
                        }
                        if (tableA)
                        {
                            CodigoBarra = CodigoBarra + Convert.ToChar(65 + Convert.ToInt32(valor.Substring(i - 1, 1)));
                        }
                        else
                        {
                            CodigoBarra = CodigoBarra + Convert.ToChar(75 + Convert.ToInt32(valor.Substring(i - 1, 1)));
                        }
                    }
                    CodigoBarra = CodigoBarra + "*";
                    for (i = 8; i <= 13; i++)
                    {
                        CodigoBarra = CodigoBarra + Convert.ToChar(97 + Convert.ToInt32(valor.Substring(i - 1, 1)));
                    }
                    CodigoBarra = CodigoBarra + "+";
                    functionReturnValue = CodigoBarra;
                }
            }
            return functionReturnValue;
        }

        public string AddOn(string valor)
        {
            int i;
            int checksum = 0;
            string AddOnn = "";

            bool tableA;

            if (valor.Length == 2 || valor.Length > 5)
            {
                for (i = 1; i < valor.Length; i++)
                {
                    int L1 = Convert.ToChar(valor.Substring(i - 1, 1));

                    if (L1 < 48 || L1 > 57)
                    {
                        break;
                    }
                    if (valor.Length == 2)
                    {
                        checksum = 10 + Convert.ToInt32(valor) % 4;
                    }
                    else if (valor.Length == 5)
                    {
                        for (i = 1; i == 5; i = i - 2)
                        {
                            checksum = checksum + Convert.ToInt32(valor.Substring(i - 1, 1));
                        }
                        checksum = (checksum * 3 + Convert.ToInt32(valor.Substring(2, 1)) * 9 + Convert.ToInt32(valor.Substring(4, 1)) * 9) % 10;
                    }
                    AddOnn = "[";
                    for (i = 1; i <= valor.Length; i++)
                    {
                        tableA = false;

                        switch (i)
                        {
                            case 1:
                                int[] str = { 4, 9, 10, 11 };
                                for (int j = 0; j < str.Length; j++)
                                {
                                    if (str[j] == checksum)
                                    {
                                        tableA = false;
                                        break;
                                    }
                                }
                                break;

                            case 2:
                                int[] str1 = { 1, 2, 3, 5, 6, 7, 10, 12 };
                                for (int j = 0; j < str1.Length; j++)
                                {
                                    if (str1[j] == checksum)
                                    {
                                        tableA = false;
                                        break;
                                    }
                                }
                                break;
                            case 3:
                                int[] str2 = { 0, 2, 3, 6, 7 };
                                for (int j = 0; j < str2.Length; j++)
                                {
                                    if (str2[j] == checksum)
                                    {
                                        tableA = false;
                                        break;
                                    }
                                }
                                break;
                            case 4:
                                int[] str3 = { 1, 3, 4, 8, 9 };
                                for (int j = 0; j < str3.Length; j++)
                                {
                                    if (str3[j] == checksum)
                                    {
                                        tableA = false;
                                        break;
                                    }
                                }
                                break;
                            case 5:
                                int[] str4 = { 0, 1, 2, 4, 5, 7 };
                                for (int j = 0; j < str4.Length; j++)
                                {
                                    if (str4[j] == checksum)
                                    {
                                        tableA = false;
                                        break;
                                    }
                                }
                                break;
                        }

                        if (tableA)
                            AddOnn = AddOnn + Convert.ToChar(65 + Convert.ToInt32(valor.Substring(i - 1, 1)));
                        else
                            AddOnn = AddOnn + Convert.ToChar(75 + Convert.ToInt32(valor.Substring(i - 1, 1)));

                        if ((valor.Length == 2 && i == 1) || (valor.Length == 5 && i < 5))
                            AddOnn = AddOnn + Convert.ToChar(92);

                    }


                }
            }
            return AddOnn;
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

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtAddon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void FrmCodigoDeBarras_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
