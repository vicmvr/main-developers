using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using MySql.Data.MySqlClient;
using System.Drawing.Imaging;

namespace Developers
{
    public partial class FrmEdicionSucursal : Form
    {
        public FrmEdicionSucursal()
        {
            InitializeComponent();
        }
        private DialogResult respnuevo = new DialogResult();
        public int id;
        public bool isNew = true;
       
        String Ubicacion = "";
        bool subimg = false;
        byte[] img;


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if ((txtNombre.Text == string.Empty) || (txtNombre.Text == " ") || (txtNombre.TextLength  < 6))
            {
                MessageBox.Show("El campo nombre no puede estar vacio! y debe contener al menos 6 caracteres ","Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Clear();
                txtNombre.Focus();
                return;
            }
            if (isNew == false)
            {
                try
                {
                    using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                    {
                        conexion.Open();
                        using (MySqlCommand commando = new MySqlCommand())
                        {
                            commando.Connection = conexion;
                            commando.CommandText = "UPDATE sucursales SET NombreComercial='" + txtNombre.Text + "',NombrePropietario='" + txtPropietario.Text + "',Telefono='" + txtTelefono.Text + "',RFC='" + txtRFC.Text + "',Leyenda='" + txtLeyenda.Text + "',DireccionSucursal='" + txtDireccion.Text + "',Correo='" + txtWEB.Text + "',Curp='" + txtCURP.Text + "' WHERE ID_Sucursal=" + id + ";";
                            commando.ExecuteNonQuery();
                            commando.Connection.Close();
                        }
                        MessageBox.Show("Guardado con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else   
            {
                try
                {
                    using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                    {
                        conexion.Open();
                        using (MySqlCommand commando = new MySqlCommand())
                        {
                            commando.Connection = conexion;
                            commando.CommandText = "INSERT INTO sucursales(NombreComercial) values('" + txtNombre.Text + "');";
                            //commando.CommandText = "INSERT INTO sucursal SET NombreComercial='" + txtNombre.Text + "',NombrePropietario='" + txtPropietario.Text + "',Telefono='" + txtTelefono.Text + "',RFC='" + txtRFC.Text + "',Leyenda='" + txtLeyenda.Text + "',Direccion='" + txtDireccion.Text + "',DireccionWEB='" + txtWEB.Text + "',Curp='" + txtCURP.Text + "' WHERE ID_Sucursal=" + id + ";";
                            commando.ExecuteNonQuery();
                            commando.Connection.Close();
                        }
                    }
                    MessageBox.Show("Guardado con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }

            if (subimg == true)
            {
                //////////////PARA GUARDAR IMAGEN EN ZISE ORIGINAL/////////////////
                //img = ImgABytes(Ubicacion);
                //GuardarImagen(BytesAImg(img));
                ///////////////////////////////////////////////////////////////////
                ///////GUARDA REDIMENSIONADA 135,85 CON LA FUNCION Redimensionar()
                //Redimensionar(pictureBox1.Image, "imgNombre");
                img = ImgABytes(Redimensionar(pictureBox1.Image, "imgNombre"));
                GuardarImagen(BytesAImg(img));
                ///////////////////////////////////////////////////////////////////
            }
        }
        

        public void GuardarImagen(Image imagen)
        {                         
            img = ImgABytes(Ubicacion);
            pictureBox1.Image = BytesAImg(img);

            using (MemoryStream ms = new MemoryStream())
            {
                imagen.Save(ms, ImageFormat.Png);
                byte[] imgArr = ms.ToArray();
                using (MySqlConnection conn = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.Parameters.AddWithValue("@imgArr", imgArr);
                        cmd.CommandText = "UPDATE sucursales SET Imagen = (@imgArr) WHERE ID_Sucursal=" + id + ";";
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            respnuevo = MessageBox.Show("Esta informacion aparecera en el ticket, desea salir sin guardar cambios?", " ", MessageBoxButtons.YesNo);
            if (respnuevo == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void FrmDatosNegocio_Load(object sender, EventArgs e)
        { 
            String peticion = "SELECT * FROM sucursales where ID_Sucursal="+id+";"; 
            DataTable tabla = new DataTable();
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion))
                        adaptador.Fill(tabla);
                        if (tabla.Rows.Count > 0)
                        {
                            txtNombre.Text = tabla.Rows[0][1].ToString();
                            txtPropietario.Text = tabla.Rows[0][2].ToString();
                            txtCURP.Text = tabla.Rows[0][7].ToString();
                            txtRFC.Text = tabla.Rows[0][4].ToString();
                            txtTelefono.Text = tabla.Rows[0][3].ToString();
                            txtWEB.Text = tabla.Rows[0][6].ToString();
                            txtDireccion.Text = tabla.Rows[0][8].ToString();
                            txtLeyenda.Text = tabla.Rows[0][5].ToString();
                            if (CargarImagen() != null)
                            {
                                pictureBox1.Image = CargarImagen();
                            }
                        }
                }
                lblNombre.Text = txtNombre.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        public Image CargarImagen()
        {
            using (MySqlConnection conn = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Imagen FROM sucursales WHERE ID_Sucursal=" + id + ";";
                    try
                    {
                        byte[] imgArr = (byte[])cmd.ExecuteScalar();
                        using (var stream = new MemoryStream(imgArr))
                        {
                            Image img = Image.FromStream(stream);
                            return img;
                        }
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //DIRECTORIO POR DEFECTO DONDE SE BUSCARA LA IMAGEN
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.RestoreDirectory = true;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    txtImagen.Text = openFileDialog1.FileName;
                    Ubicacion = openFileDialog1.FileName;
                    img = ImgABytes(Ubicacion);
                    pictureBox1.Image = BytesAImg(img);
                    subimg = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: No se pudo encontrar el archivo: " + ex);
                }
            }
            else
            {
                subimg = false;
            }
        }
        //METODO PARA REDIMENSIONAR LA IMAGEN
        public String Redimensionar(Image Imagen_Original, string nombre)
        {

            //RUTA DEL DIRECTORIO TEMPORAL
            String DirTemp = Path.GetTempPath() + @"\" + nombre + ".jpg";

            //IMAGEN ORIGINAL A REDIMENSIONAR
            Bitmap imagen = new Bitmap(Imagen_Original);

            //CREAMOS UN MAPA DE BIT CON LAS DIMENSIONES QUE QUEREMOS PARA LA NUEVA IMAGEN
            //Bitmap nuevaImagen = new Bitmap(Imagen_Original.Width, Imagen_Original.Height);
            Bitmap nuevaImagen = new Bitmap(135, 85);

            //CREAMOS UN NUEVO GRAFICO
            Graphics gr = Graphics.FromImage(nuevaImagen);

            //DIBUJAMOS LA NUEVA IMAGEN
            gr.DrawImage(imagen, 0, 0, nuevaImagen.Width, nuevaImagen.Height);

            //LIBERAMOS RECURSOS
            gr.Dispose();

            //GUARDAMOS LA NUEVA IMAGEN ESPECIFICAMOS LA RUTA Y EL FORMATO
            nuevaImagen.Save(DirTemp, System.Drawing.Imaging.ImageFormat.Jpeg);

            //LIBERAMOS RECURSOS
            nuevaImagen.Dispose();

            imagen.Dispose();

            return DirTemp;

        }
        //IMG A BYTES
        public Byte[] ImgABytes(String ruta)
        {
            FileStream img = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Byte[] arreglo = new Byte[img.Length];
            BinaryReader reader = new BinaryReader(img);
            arreglo = reader.ReadBytes(Convert.ToInt32(img.Length));
            img.Close();
            return arreglo;
        }
        //BYTES A IMG
        public Image BytesAImg(Byte[] ImgBytes)
        {
            Bitmap img = null;
            Byte[] bytes = (Byte[])(ImgBytes);
            MemoryStream ms = new MemoryStream(bytes);
            img = new Bitmap(ms);
            return img;
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            lblNombre.Text = txtNombre.Text;
        }
    }
}
