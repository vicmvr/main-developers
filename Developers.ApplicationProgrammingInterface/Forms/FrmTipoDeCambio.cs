using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace Developers
{
    public partial class FrmTipoDeCambio : Form
    {
        string connstring;
        public FrmTipoDeCambio()
        {
            InitializeComponent();
            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConnectionStringsSection css = conf.ConnectionStrings;
            connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;
        }        
        private bool revisa(string fecha)        
        {
            try
            {
            //REVISA
            DataTable tabla = new DataTable();
            String peticion = "SELECT * FROM tipodecambio WHERE fecha ='" + fecha + "'";
            
                using (MySqlConnection conexion = new MySqlConnection(connstring))
                {
                conexion.Open();
                MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);
                adaptador.Fill(tabla);
                }
                if (tabla.Rows.Count > 0)
                {
                    lblTipoDeCambio.Text = String.Format("$ {0:0.00}", Convert.ToDouble(tabla.Rows[0][1]));
                    return true;   
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            return false;       
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void actualiza(string fecha)
        {
            try
            {
                //ACTUALIZA
                Variable.TipoCambio = Convert.ToDouble(txtTipoDeCambio.Text);
                String peticion = "UPDATE tipodecambio SET tipoDeCambio='" + txtTipoDeCambio.Text + "',fecha='" + dtFecha.Text + "',registro='" + Developers.ApplicationProgrammingInterface.Properties.Settings.Default.Usuario_Activo + "' WHERE fecha= '" + fecha + "';";
                using (MySqlConnection conexion = new MySqlConnection(connstring))
                {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(peticion,conexion);
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                }

                MessageBox.Show("Tipo de cambio actualizado.", "Tipo de cambio actualizado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        private void guarda()
        { 
            try
            {
                //GUARDA
                Variable.TipoCambio = Convert.ToDouble(txtTipoDeCambio.Text);
                String peticion = "INSERT INTO tipodecambio(tipoDeCambio,fecha,registro) VALUES('" + txtTipoDeCambio.Text + "','" + dtFecha.Text + "','" + Developers.ApplicationProgrammingInterface.Properties.Settings.Default.Usuario_Activo + "');";
                using (MySqlConnection conexion = new MySqlConnection(connstring))
                {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(peticion, conexion);
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                }

                MessageBox.Show("Tipo de cambio guardado.", "Tipo de cambio guardado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(revisa(dtFecha.Text)==false)
            {
                guarda();
                this.Close();
            }
            else
            {
                actualiza(dtFecha.Text);
            }
        }

        private void FrmTipoDeCambio_Load(object sender, EventArgs e)
        {
            revisa(dtFecha.Text);
        }

        private void txtTipoDeCambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtTipoDeCambio.Text.Length; i++)
            {
                if (txtTipoDeCambio.Text[i] == '.')
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
            if (e.KeyChar == 13)
            {
                if (txtTipoDeCambio.Text == "")
                    txtTipoDeCambio.Text = "0.0";
                btnGuardar.PerformClick();
            }  
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmReporteTipoDeCambio")
                {
                    //MessageBox.Show("entro2");
                    frm.Activate();
                    return;
                }
            }
            //FrmReporteTipoDeCambio formulario = new FrmReporteTipoDeCambio();
            ////formulario.MdiParent = this;
            //formulario.WindowState = FormWindowState.Normal;
            //formulario.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
