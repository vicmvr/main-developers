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

namespace Developers
{
    public partial class FrmAbrirCorte : Form
    {
        public FrmAbrirCorte()
        {
            InitializeComponent();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
           
           
        }
        private void cargaCorteActual()
        {
            try
            {
                //CARGA TIPO DE CAMBIO
                DataTable tabla = new DataTable();
                String peticion = "SELECT ID_Corte FROM cortes WHERE Usuario='" + Variable.UsuarioActivo + "' AND Status='" + 0 + "'  ;";

                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);
                    adaptador.Fill(tabla);
                    if (tabla.Rows.Count > 0)
                    {
                        Variable.CorteAbierto = Convert.ToInt32(tabla.Rows[0][0]);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }  

        private void FrmAbrirCorte_Load(object sender, EventArgs e)
        {
            totalFondo.Select(0, totalFondo.ToString().Length);
            
        }

        private void totalFondo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnAbirCorte.PerformClick();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAbirCorte_Click(object sender, EventArgs e)
        {
            string estado = "0";//0 = abierto // 1 = cerrado
            if (Variable.UsuarioRol == "COBRADOR")
            {
                DateTime hoy = DateTime.Now;
                Decimal fondo = Convert.ToDecimal(totalFondo.Value);
                String query2 = "INSERT INTO cortes (Fondo,Usuario,Status) values ('" + 0 + "','" + Variable.UsuarioActivo + "','" + estado + "');";
                using (MySqlConnection conexion2 = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion2.Open();
                    MySqlCommand commando = new MySqlCommand(query2, conexion2);
                    commando.ExecuteNonQuery();
                }
                cargaCorteActual();
                MessageBox.Show("Corte abierto.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            MySqlDataReader rdr = null;
            string query = "select * from cortes where Usuario ='" + Variable.UsuarioActivo + "'and Status='" + estado + "';";
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                }
                else
                {
                    if (totalFondo.Value != 0)
                    {

                        DateTime hoy = DateTime.Now;
                        Decimal fondo = Convert.ToDecimal(totalFondo.Value);
                        String query2 = "INSERT INTO cortes (Fondo,Usuario,Status) values ('" + totalFondo.Value + "','" + Variable.UsuarioActivo + "','" + estado + "');";
                        using (MySqlConnection conexion2 = new MySqlConnection(Conexion.NuevaConexion()))
                        {
                            conexion2.Open();
                            MySqlCommand commando = new MySqlCommand(query2, conexion2);
                            commando.ExecuteNonQuery();
                        }
                        cargaCorteActual();
                        MessageBox.Show("Corte abierto.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ingrese una cantidad mayor que 0.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        totalFondo.Select();
                    }
                }
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
