using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Developers
{
    public partial class FrmImpresora : Form
    {
        public FrmImpresora()
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
        private void cargaImpresora()
        {
            try
            {
                //REVISA
                DataTable tabla = new DataTable();
                String peticion = "SELECT ImpresoraTickets FROM Impresoras WHERE idimpresoras=1";

                using (MySqlConnection conexion = NuevaConexion())
                using (MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion))
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
        private void FrmImpresora_Load(object sender, EventArgs e)
        {
            PopulateInstalledPrintersCombo();
            cbImpresoraTickets.Text = Variable.ImpresoraTickets;
            cargaImpresora();
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
        
        private void actualiza()
        {
            try
            {
                //ACTUALIZA
                String peticion = "UPDATE cajas SET ImpresoraTickets='" + cbImpresoraTickets.Text + "' WHERE ID_Caja='" + Variable.IDCaja + "' AND ID_Sucursal='" + Variable.IDSucursal + "';";
                using (MySqlConnection conn = NuevaConexion())
                using (MySqlCommand cmd = new MySqlCommand(peticion, conn))
                {
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }

                MessageBox.Show("Impresora guardada.", "Impresora guardada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            actualiza();
            this.Close();
        }

        private void cbImpresoraTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the printer to a printer in the combo box when the selection changes. 

            if (cbImpresoraTickets.SelectedIndex != -1)
            {
                // The combo box's Text property returns the selected item's text, which is the printer name.
                //printDoc.PrinterSettings.PrinterName = "XPS";
                Variable.ImpresoraTickets = cbImpresoraTickets.Text;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
