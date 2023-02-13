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
    public partial class FrmEdicionUsuarios : Form
    {
        private DialogResult respnuevo = new DialogResult();
        public int id;
        public bool isNew = true;
        public FrmEdicionUsuarios()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            lblNombre.Text = txtNombreCompleto.Text;
        }

        private void FrmEdicionEmpleados_Load(object sender, EventArgs e)
        {
            cargaRoles();
            llenarDatos();
        }
        private void llenarDatos()
        {
            String connstring;
            String peticion;
            DataTable tabla = new DataTable();
            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConnectionStringsSection css = conf.ConnectionStrings;
            connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;

            peticion = "SELECT * FROM usuarios where ID_Usuario='" + id + "';";
            //MOSTRAR DATOS
            MySqlConnection conexion = new MySqlConnection(connstring);
            conexion.Open();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);

            adaptador.Fill(tabla);
            if (tabla.Rows.Count > 0)
            {
                txtNombreCompleto.Text = tabla.Rows[0][1].ToString();
                txtNombre.Text = tabla.Rows[0][2].ToString();
                txtContrasena1.Text = tabla.Rows[0][3].ToString();
                txtContrasena2.Text = tabla.Rows[0][4].ToString();
                cbRol.Text = tabla.Rows[0][5].ToString();
                txtCURP.Text = tabla.Rows[0][6].ToString();
                txtRFC.Text = tabla.Rows[0][7].ToString();
                txtTelefono.Text = tabla.Rows[0][8].ToString();
                txtCorreo.Text = tabla.Rows[0][9].ToString();
                txtDireccion.Text = tabla.Rows[0][10].ToString();
                //cbSucursal.Text = tabla.Rows[0][11].ToString();
                lblNombre.Text = txtNombre.Text;
            }
        }

        private void cargaRoles()
        {
            String connstring;
            String peticion;
            DataTable tablacat = new DataTable();

            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConnectionStringsSection css = conf.ConnectionStrings;
            connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;

            peticion = "select Nombre from roles;";

            try
            {
                MySql.Data.MySqlClient.MySqlConnection conexion = new MySql.Data.MySqlClient.MySqlConnection(connstring);
                conexion.Open();
                MySql.Data.MySqlClient.MySqlDataAdapter adaptador = new MySql.Data.MySqlClient.MySqlDataAdapter(peticion, conexion);
                //Rellenamos tabla   tabla.Rows[0][1].ToString();
                adaptador.Fill(tablacat);
                cbRol.DataSource = tablacat;
                cbRol.DisplayMember = "Nombre";

                conexion.Close();
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (isNew == false)
            {
                if (txtContrasena1.Text != txtContrasena2.Text)
                {
                    MessageBox.Show("Las contraseñas no sol iguales");
                    txtContrasena1.Focus();
                }
                else
                {
                    try
                    {
                        //GUARDAR
                        String connstring;
                        String peticion;
                        Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                        ConnectionStringsSection css = conf.ConnectionStrings;
                        connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;

                        peticion = "UPDATE usuarios set NombreCompleto='" + txtNombreCompleto.Text + "',Nombre='" + txtNombre.Text + "',Contrasena='" + txtContrasena1.Text + "',Contrasena2='" + txtContrasena2.Text + "',Rol='" + cbRol.Text + "',CURP='" + txtCURP.Text + "',RFC='" + txtRFC.Text + "',Tel='" + txtTelefono.Text + "',Correo='" + txtCorreo.Text + "',Direccion='" + txtDireccion.Text + "' WHERE ID_Usuario= '" + id + "';";
                        MySql.Data.MySqlClient.MySqlConnection conexion = new MySql.Data.MySqlClient.MySqlConnection(connstring);
                        conexion.Open();
                        MySql.Data.MySqlClient.MySqlCommand commando = new MySql.Data.MySqlClient.MySqlCommand(peticion, conexion);
                        commando.ExecuteNonQuery();
                        conexion.Close();
                        MessageBox.Show("Guardado con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex);
                    }
                }
            }
            else
            {
                try
                {
                    //GUARDAR
                    String connstring;
                    String peticion;
                    Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                    ConnectionStringsSection css = conf.ConnectionStrings;
                    connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;

                    peticion = "INSERT INTO usuarios(NombreCompleto,Nombre,Contrasena,Contrasena2,Rol,CURP,RFC,Tel,Correo,Direccion) values('" + txtNombreCompleto.Text + "','" + txtNombre.Text + "','" + txtContrasena1.Text + "','" + txtContrasena2.Text + "','" + cbRol.Text + "','" + txtCURP.Text + "','" + txtRFC.Text + "','" + txtTelefono.Text + "','" + txtCorreo.Text + "','" + txtDireccion.Text + "');";
                    MySql.Data.MySqlClient.MySqlConnection conexion = new MySql.Data.MySqlClient.MySqlConnection(connstring);
                    conexion.Open();
                    MySql.Data.MySqlClient.MySqlCommand commando = new MySql.Data.MySqlClient.MySqlCommand(peticion, conexion);
                    commando.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Guardado con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
