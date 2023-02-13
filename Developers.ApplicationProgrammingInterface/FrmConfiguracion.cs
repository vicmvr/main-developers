using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Developers
{
    public partial class FrmConfiguracion : Form
    {
        public FrmConfiguracion()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            actualiza();
        }

        private void actualiza()
        {
            try
            {
                //ACTUALIZA
               
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    String query = "UPDATE impresoras SET ImpresoraTickets='" + cbImpresoraTickets.Text + "' WHERE idimpresoras=1";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.ExecuteNonQuery();
                MessageBox.Show("Impresora guardada.", "Impresora guardada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void tabConfiguracion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabConfiguracion.SelectedIndex == 1)
            {
                PopulateInstalledPrintersCombo();
                cbImpresoraTickets.Text = Variable.ImpresoraTickets;
                cargaImpresora();
            }
        }

        private void PopulateInstalledPrintersCombo()
        {
            String pkInstalledPrinters;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                cbImpresoraTickets.Items.Add(pkInstalledPrinters);
            }
        }
        private void cargaImpresora()
        {
            try
            {
                //REVISA
                DataTable tabla = new DataTable();
                String peticion = "SELECT ImpresoraTickets FROM Impresoras WHERE idimpresoras=1";
                using (MySqlConnection conn2 = new MySqlConnection(Conexion.NuevaConexion()))
                using (MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conn2))
                    adaptador.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    cbImpresoraTickets.Text = tabla.Rows[0][0].ToString();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {

        }
    }
}
