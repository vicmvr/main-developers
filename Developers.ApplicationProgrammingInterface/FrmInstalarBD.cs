using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Developers.ApplicationProgrammingInterface.Properties;

namespace Developers
{
    public partial class FrmInstalarBD : Form
    {
        public FrmInstalarBD()
        {
            InitializeComponent();
        }

        private void btnInstalar_Click(object sender, EventArgs e)
        {
                //Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                //ConnectionStringsSection css = conf.ConnectionStrings;
                //css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString = cadena;
                //conf.Save();


            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            AppSettingsSection ass = config.AppSettings;
            //AppSettingsSection ass = config.Sections.;
            //InstPrev=true;
            //Developers.Properties.Settings.Default//.//.Default.InstPrev;
            //ass["Developers.Properties.Settings.InstPrev"].InstPrev = false;
            //ass.CurrentConfiguration.AppSettings["Developers.Properties.Settings.Default"].InstPrev = false;
            //ass.SectionInformation//.Settings["Developers.Properties.Settings.InstPrev"].InstPrev = true;
            //config.Save();

            Settings set = Settings.Default;
            set.InstPrev = true;
            set.Save();
            Settings.Default.InstPrev = true;
            Settings.Default.Save();
            String query1 = "INSERT INTO usuarios (Nombre,Contrasena,Contrasena2,Rol) values ('" + textBox5.Text + "','" + textBox6.Text + "','" + textBox6.Text + "','ADMIN');";
            using (MySqlConnection conexion1 = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion1.Open();
                MySqlCommand commando = new MySqlCommand(query1, conexion1);
                commando.ExecuteNonQuery();
            }
            MessageBox.Show("Instalacion de base de datos finalizada", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
            this.DialogResult = DialogResult.OK; 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; 
            this.Close();
        }

        private void FrmInstalarBD_Load(object sender, EventArgs e)
        {

        }
    }
}
