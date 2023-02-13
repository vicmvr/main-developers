using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Reflection;
using MySql.Data.MySqlClient;
using System.Management;
using Developers.ApplicationProgrammingInterface.Properties;
using System.Diagnostics;

namespace Developers
{
    public partial class FrmSplash : Form
    {
        public string connstring; 
        public static string NombreDeCaja { get; set; }
        Double opy=1;
        public FrmSplash()
        {
            InitializeComponent();
        }
        private static bool getPrevInstance()
        {
            //get the name of current process, i,e the process 
            //name of this current application

            string currPrsName = Process.GetCurrentProcess().ProcessName;

            //Get the name of all processes having the 
            //same name as this process name 
            Process[] allProcessWithThisName
                         = Process.GetProcessesByName(currPrsName);

            //if more than one process is running return true.
            //which means already previous instance of the application 
            //is running
            if (allProcessWithThisName.Length > 1)
            {
               // MessageBox.Show("Already Running");
                return true; // Yes Previous Instance Exist
            }
            else
            {
                return false; //No Prev Instance Running
            }
        }
        private void FrmSplash_Load(object sender, EventArgs e)
        {
            //this.Opacity = .01;
            if (getPrevInstance() == false)
            {
                this.Visible = true;
                //LoadSerial();
                //if (Valida() == true)
                //{
                ////int pauseTime = 2000;
                ////System.Threading.Thread.Sleep(pauseTime);
                ////this.DialogResult = DialogResult.OK;
                ////this.Close();
                //}
                //else
                //{
                //    FrmNumeroDeSerie NuSerie = new FrmNumeroDeSerie();
                //    NuSerie.WindowState = FormWindowState.Normal;
                //    NuSerie.StartPosition = FormStartPosition.CenterScreen;
                //    NuSerie.TopMost = true;
                //    NuSerie.ShowDialog();
                //    if (NuSerie.DialogResult == DialogResult.OK)
                //    {
                

                timerOpacity2.Enabled = true;
                timerOpacity2.Start();
                    //}
                    //else
                    //{
                    //    Application.Exit();
                    //}
                //}
            }
            else
            {
                Application.Exit();
                MessageBox.Show("No es posible abrir mas de una vez el sistema!", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Information);                 
            }
        }
        public int ID = 0;
        private void LoadSerial()
        {
            String txtSerie = Settings.Default.Serial;
            Variable.ImpresoraTickets = Settings.Default.Impresora;
            String txtID = "";
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
                    txtID = txtID + letter;
                    ID = ID + Convert.ToInt32(letter);
                }
            }           
        }
        private bool Valida()
        {
            int Serial = Convert.ToInt32(Settings.Default.Serial);
            if (Math.Sqrt(Convert.ToInt32(Serial / 2)) == ID)
            {
               return true;
            }
            else
            {
                return false;
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
        private void timerOpacity2_Tick(object sender, EventArgs e)
        {
            opy = opy - 0.05;
            this.Opacity = opy;
            Console.WriteLine("Opacidad opy= " + opy);
            if (this.Opacity == 0)
            {
                //int pauseTime = 500;
                //System.Threading.Thread.Sleep(pauseTime);             
                this.DialogResult = DialogResult.OK;
                timerOpacity2.Stop();
                this.Close();
            }
        }
    }
}
