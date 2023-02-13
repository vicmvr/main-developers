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
    public partial class FrmEdicionExistencias : Form
    {
        public string id = "";
        public string descripcion = "";
        public string cantidad = "";
        public int idsuc = 0 ;

        public FrmEdicionExistencias()
        {
            InitializeComponent();
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (nuCantidad.Value == 0)
            {
                MessageBox.Show("La cantidada agregar debe ser mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (nuCantidad.Text != string.Empty)
            {
                {
                    int Cantidad = Convert.ToInt32(cantidad) + Convert.ToInt32(nuCantidad.Text);
                    string peticion = "UPDATE existencias SET Existencias='" + Cantidad + "' WHERE ID_Producto= '" + id + "' AND ID_Sucursal= '" + idsuc + "';";
                    try
                    {
                        using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                        {
                            conexion.Open();
                            MySqlCommand commando = new MySqlCommand(peticion, conexion);
                            commando.ExecuteNonQuery();
                        }
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

        private void FrmEdicionExistencias_Load(object sender, EventArgs e)
        {
            lblProducto.Text = descripcion;
            lblExistencias.Text = cantidad;
            nuCantidad.Select();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            string peticion1 = "SELECT Existencias From existencias  WHERE ID_Producto= '" + id + "' AND ID_Sucursal= '" + idsuc + "';";
                DataTable nt=new DataTable();
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion1, conexion);
                    adaptador.Fill(nt);
                }
                if (nt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(nuCantidad.Value) > Convert.ToInt32(nt.Rows[0][0]))
                    {
                        MessageBox.Show("La cantidad ingresada supera las existencias registradas, ingresa un cifra menor o igual a: " + Convert.ToInt32(nt.Rows[0][0]) + "", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        nuCantidad.Focus(); 
                        return;
                    }
                }
            if (nuCantidad.Text != string.Empty)
            {
                {
                    int Cantidad = Convert.ToInt32(cantidad) - Convert.ToInt32(nuCantidad.Text);
                    string peticion2 = "UPDATE existencias SET Existencias='" + Cantidad + "' WHERE ID_Producto= '" + id + "' AND ID_Sucursal= '" + idsuc + "';";
                    try
                    {
                        using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                        {
                            conexion.Open();
                            MySql.Data.MySqlClient.MySqlCommand commando = new MySql.Data.MySqlClient.MySqlCommand(peticion2, conexion);
                            commando.ExecuteNonQuery();
                        }
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

        private void btnCero_Click(object sender, EventArgs e)
        {
            if (nuCantidad.Text != string.Empty)
            {
                {
                    int Cantidad = 0;
                    string peticion = "UPDATE existencias SET Existencias='" + Cantidad + "' WHERE ID_Producto= '" + id + "' AND ID_Sucursal= '" + idsuc + "';";

                    try
                    {
                        using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                        {
                            conexion.Open();
                            MySql.Data.MySqlClient.MySqlCommand commando = new MySql.Data.MySqlClient.MySqlCommand(peticion, conexion);
                            commando.ExecuteNonQuery();
                        }
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnAgregar.PerformClick();
            }  
        }
    }
}
