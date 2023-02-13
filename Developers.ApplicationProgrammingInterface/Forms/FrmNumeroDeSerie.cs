using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using Developers.ApplicationProgrammingInterface.Properties;
using System.Configuration;

namespace Developers
{
    public partial class FrmNumeroDeSerie : Form
    {
        public FrmNumeroDeSerie()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int ID = 0;
        private void FrmClaveDeRegistro_Load(object sender, EventArgs e)
        {
            txtSerie.Text = Settings.Default.Serial;
            String UID = GetProcessorID() + GetMotherBoardID();
            char[] Valor = UID.ToArray();
            // Recorrer el array buscando numeros.
            for (int i = 0; i < Valor.Length; i++)
            {
                // Tomar caracter del array.
                string letter = Valor[i].ToString();
                // Agregar valor si
                if ((letter == "0") || (letter == "1") || (letter == "2") || (letter == "3")
                    || (letter == "4") || (letter == "5") || (letter == "6") || (letter == "7")
                     || (letter == "8") || (letter == "9"))
                {
                    txtID.Text = txtID.Text + letter;
                    ID = ID + Convert.ToInt32(letter);
                }
            }
            Valida();
        }

        private void Valida()
        {            
            int Serial = Convert.ToInt32(Settings.Default.Serial);
            int SU = Serial / 2;
            if (Math.Sqrt(Convert.ToInt32(Serial / 2)) == ID)
            {
                txtSerie.Text = Serial.ToString();
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Su producto esta activado.", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //this.Close(); 
            }
            else
            {
                txtSerie.Text = "Ingresa Serial";
            }
        }
        public static string GetProcessorID()
        {
            string sProcessorID = "";
            string sQuery = "SELECT ProcessorId FROM Win32_Processor";
            ManagementObjectSearcher oManagementObjectSearcher = new ManagementObjectSearcher(sQuery);
            ManagementObjectCollection oCollection = oManagementObjectSearcher.Get();
            foreach (ManagementObject oManagementObject in oCollection)
            {
                sProcessorID = (string)oManagementObject["ProcessorId"];
            }
            return (sProcessorID);
        }
        public static string GetMotherBoardID()
        {
            string mbInfo = String.Empty;
            ManagementScope scope = new ManagementScope("\\\\" + Environment.MachineName + "\\root\\cimv2");
            scope.Connect();
            ManagementObject wmiClass = new ManagementObject(scope, new ManagementPath("Win32_BaseBoard.Tag=\"Base Board\""), new ObjectGetOptions());

            foreach (PropertyData propData in wmiClass.Properties)
            {
                if (propData.Name == "SerialNumber")
                    //mbInfo = String.Format("{0,-25}{1}", propData.Name, Convert.ToString(propData.Value));
                    mbInfo = Convert.ToString(propData.Value);
            }
            return mbInfo;
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            Settings set = Settings.Default;
            string str = set.Serial;
            set.Serial = txtSerie.Text;
            set.Save();
            Valida();
        }
    }
}
