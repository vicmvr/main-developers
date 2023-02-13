using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Developers.ApplicationProgrammingInterface.Properties;

namespace Developers
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmSplash splash = new FrmSplash();
            FrmLogin Login = new FrmLogin();
            splash.ShowDialog();
            if (splash.DialogResult == DialogResult.OK)
            {
                //Settings.Default.InstPrev=false;
                //Settings.Default.Save();
                
                        Login.ShowDialog();
                        if (Login.DialogResult == DialogResult.OK)
                        {
                            Application.Run(new FrmVentas());
                        }
                    
            }
                 
        }
    }
}
