using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
//C:\Archivos de programa\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\System.Management.dll

namespace Series
{
    public partial class Series : Form
    {
        public Series()
        {
            InitializeComponent();
        }
        public int UUID = 0;
        private void Series_Load(object sender, EventArgs e)
        {
            
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

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            //Clipboard.SetText(string.Join(",",texto));
            Clipboard.SetText(txtSerieFinal.Text);
            this.Close();
        }

        private void btnPCActual_Click(object sender, EventArgs e)
        {
            UUID = 0;
            String UID = GetProcessorID() + GetMotherBoardID();
            txtID.Text = UID;
            ///////////////////////////////////////////////////////////////////////////////////////////////
            // ID de entrada.
            string ID = txtID.Text;
            // Usar ToCharArray para convertir ID de entrada en array.
            char[] Valor = ID.ToArray();
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
                    UUID = UUID + Convert.ToInt32(letter);
                }
            }
            txtSerieFinal.Text = ((UUID * UUID) * 2).ToString();
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            UUID = 0;
            string ID = txtID.Text;
            // Usar ToCharArray para convertir ID de entrada en array.
            char[] Valor = ID.ToArray();
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
                    UUID = UUID + Convert.ToInt32(letter);
                }
            }
            txtSerieFinal.Text = ((UUID * UUID) * 2).ToString();
        }
    }
}
