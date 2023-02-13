using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Developers.Forms
{
    public partial class FrmCambiarDepto : Form
    {
        public FrmCambiarDepto()
        {
            InitializeComponent();
        }
        public int idproducto = 0;
        public int iddepto = 0;
        public DataTable dt = new DataTable();
        private void FrmCambiarDepto_Load(object sender, EventArgs e)
        {
            cargadeptos();
        }
        private void cargadeptos()
        {
            //lblEspere.Visible = true;
            this.Enabled = false;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    cnn.Open();
                    string qry = "SELECT ID_Departamento,Nombre FROM departamentos;";
                    MySqlDataAdapter da = new MySqlDataAdapter(qry, cnn);
                    da.Fill(dt);
                    cbDepto.DataSource = dt;
                    cbDepto.DisplayMember = "Nombre";
                    cbDepto.ValueMember = "ID_Departamento";

                    iddepto = Convert.ToInt32(cbDepto.SelectedValue.ToString());
                    //label1.Text = id.ToString();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("" + ex);
            }
            this.Enabled = true;
            //lblEspere.Visible = false;
        }

        private void btnAsignaDepto_Click(object sender, EventArgs e)
        {
            asignaDepto();
        }
        private void asignaDepto()
        {
            this.Enabled = false;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    cnn.Open();
                    string qry = "UPDATE productos SET Departamento='" + cbDepto.Text + "',idDepartamento='" + dt.Rows[cbDepto.SelectedIndex][0].ToString() + "' WHERE ID_Producto='" + idproducto + "';";
                    MySqlCommand cmd = new MySqlCommand(qry, cnn);
                    cmd.ExecuteNonQuery();
                    Variable.returnedDepto = cbDepto.Text;
                    cbDepto.DataSource = null;
                    iddepto = 0;                    
                    dt.Clear();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            this.Enabled = true;
        }
    }
}
