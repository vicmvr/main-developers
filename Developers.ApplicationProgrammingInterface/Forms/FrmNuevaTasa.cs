using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Developers
{
    public partial class FrmNuevaTasa : Form
    {
        private DialogResult respnuevo = new DialogResult();
        public string id = "";
        public string descripcion = "";
        public string valor = "";        
        public bool isNew = true;
        public FrmNuevaTasa()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            respnuevo = MessageBox.Show("Salir sin guardar cambios?", " ", MessageBoxButtons.YesNo);
            if (respnuevo == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text != string.Empty)
            {
                
                if (txtValor.Text != "")
                {
                    if(isNew==true)
                    {
                        try
                        {
                            //GUARDAR
                        
                            String connstring;
                            String peticion;
                            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                            ConnectionStringsSection css = conf.ConnectionStrings;
                            connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;

                            peticion = "INSERT into tasas (Descripcion,Valor) values ('" + txtDescripcion.Text + "','" + txtValor.Text + "');";
                            MySql.Data.MySqlClient.MySqlConnection conexion = new MySql.Data.MySqlClient.MySqlConnection(connstring);
                            conexion.Open();
                            MySql.Data.MySqlClient.MySqlCommand commando = new MySql.Data.MySqlClient.MySqlCommand(peticion, conexion);
                            commando.ExecuteNonQuery();
                            conexion.Close();
                            MessageBox.Show("Guardado con éxito", "Guardado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error " + ex);
                        }
                    }
                    else if (isNew == false)
                    {
                        //ACTUALIZAR
                        String connstring;
                        String peticion;

                        Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                        ConnectionStringsSection css = conf.ConnectionStrings;
                        connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;
                        peticion = "UPDATE tasas SET Valor='" + txtValor.Text + "' WHERE ID_Tasa= '" + id + "';";

                        try
                        {
                            MySql.Data.MySqlClient.MySqlConnection conexion = new MySql.Data.MySqlClient.MySqlConnection(connstring);
                            conexion.Open();
                            MySql.Data.MySqlClient.MySqlCommand commando = new MySql.Data.MySqlClient.MySqlCommand(peticion, conexion);

                            commando.ExecuteNonQuery();

                            conexion.Close();
                            id = "";
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo connectar verifique conexion con el servidor " + ex);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Faltan Datos");
                }                
            }
            else
            {
                MessageBox.Show("Faltan Datos");
            }
        }

        private void FrmNuevaTasa_Load(object sender, EventArgs e)
        {
            if (isNew == false)
            {
                txtDescripcion.Text = descripcion;
                txtDescripcion.Enabled = false;
                txtValor.Text = valor;
                txtValor.SelectAll();
            }
            else
            {
                txtDescripcion.Enabled = true;
                txtDescripcion.Focus();
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnGuardar.PerformClick();
            } 
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtValor.Text.Length; i++)
            {
                if (txtValor.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
             
        } 
    }
}
