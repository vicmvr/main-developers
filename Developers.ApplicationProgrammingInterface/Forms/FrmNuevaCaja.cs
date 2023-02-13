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
    public partial class FrmNuevaCaja : Form
    {
        private DialogResult respnuevo = new DialogResult();
        public string id = "";
        public string nombre = "";
        public string cantidad = "";
        public string tiempo = "";
        public string atraso = "";
        public string interes = "";        
        public bool isNew = true;
        public FrmNuevaCaja()
        {
            InitializeComponent();
        }
        static MySqlConnection NuevaConexion()
        {
            String connstring;
            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConnectionStringsSection css = conf.ConnectionStrings;
            connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;

            var conexion = new MySqlConnection(connstring);
            try
            {
                conexion.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conexion! " + ex, "Error de conexion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return conexion;
        }
        public void consultaSucursal()
        {
            try
            {
                //Consulta
                DataTable tabla = new DataTable();
                String peticion = "SELECT ID_Sucursal,NombreComercial FROM sucursales";

                using (MySqlConnection conexion = NuevaConexion())
                using (MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion))
                    adaptador.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    cbIDSucursal.DataSource = tabla;
                    cbIDSucursal.DisplayMember = "ID_Sucursal";
                    txtNombreSucursal.Text = tabla.Rows[0][1].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        public void cargaCaja(String IDS)
        {
            try
            {
                //Consulta
                DataTable tabla = new DataTable();
                String peticion = "SELECT ID_Caja,NombreCaja,ID_Sucursal,NombreSucursal FROM cajas WHERE ID_Caja='" + IDS + "';";

                using (MySqlConnection conexion = NuevaConexion())
                using (MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion))
                    adaptador.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    txtIDCaja.Text = tabla.Rows[0][0].ToString();
                    txtNombreCaja.Text = tabla.Rows[0][1].ToString();
                    cbIDSucursal.Text = tabla.Rows[0][2].ToString();
                    txtNombreSucursal.Text = tabla.Rows[0][3].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        public void cargaSucursal(String IDS)
        {
            try
            {
                //Consulta
                DataTable tabla = new DataTable();
                String peticion = "SELECT ID_Sucursal,NombreComercial FROM sucursales WHERE ID_Sucursal='" + IDS + "';";

                using (MySqlConnection conexion = NuevaConexion())
                using (MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion))
                    adaptador.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    cbIDSucursal.Text = tabla.Rows[0][0].ToString();
                    txtNombreSucursal.Text = tabla.Rows[0][1].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
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
            if (txtNombreSucursal.Text != string.Empty)
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

                            peticion = "INSERT into cajas (Id_Sucursal,NombreCaja,NombreSucursal) values ('" + cbIDSucursal.Text + "','" + txtNombreCaja.Text + "','" + txtNombreSucursal.Text + "');";
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
                        peticion = "UPDATE cajas SET NombreCaja='" + txtNombreCaja.Text + "',ID_Sucursal='" + cbIDSucursal.Text + "',NombreSucursal='" + txtNombreSucursal.Text + "' WHERE ID_Caja= '" + id + "';";

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

        private void FrmNuevaTasa_Load(object sender, EventArgs e)
        {         
            consultaSucursal();
            if (isNew == false)
            {
                cargaCaja(id);
            }
            txtNombreCaja.Focus();            
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

            //for (int i = 0; i < txtValor.Text.Length; i++)//CHECAR BIEN PARA MONEDAS
            //{
            //    if (txtValor.Text[i] == '.')
            //        IsDec = true;

            //    if (IsDec && nroDec++ >= 2)
            //    {
            //        e.Handled = true;
            //        return;
            //    }
            //}
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
             
        }

        private void cbIDSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargaSucursal(cbIDSucursal.Text);
        }

        private void cbIDSucursal_SelectedValueChanged(object sender, EventArgs e)
        {
            cargaSucursal(cbIDSucursal.Text);
        }
    }
}
