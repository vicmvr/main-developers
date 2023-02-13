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
    public partial class FrmBusquedaCorte : Form
    {
        public int IDCorte = 0;
        public FrmBusquedaCorte()
        {
            InitializeComponent();
        }

        private void FrmBusquedaCorte_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'VentasDataSetCorteCaja1.DataTable1' table. You can move, or remove it, as needed.
            
           // this.dataTable1TableAdapter.Fill(this.VentasDataSetCorteCaja1.DataTable1);
            //this.dataTable1TableAdapter.Fill(this.Corte
            cargarCajeros();
            comboBox1.Text = "";
            DateTime fecha = new DateTime();
            fecha = DateTime.Now.AddDays(-7);
            dateTimePicker1.Value = fecha;
        }

        public void cargarCajeros()
        {
            using(MySqlConnection cnn = new MySqlConnection(Conexion.NuevaConexion()))
            {
                cnn.Open();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT Nombre,Rol FROM usuarios WHERE Rol = 'CAJERO' or Rol='SUPERVISOR' or Rol='COBRADOR'", cnn);
                //se indica el nombre de la tabla
                da.Fill(ds);
                comboBox1.DataSource = ds.Tables[0].DefaultView;
                //se especifica el campo de la tabla
                comboBox1.DisplayMember = "Nombre";
                comboBox1.ValueMember = "Rol";
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }

        private void cargarGrid()
        {
            using (MySqlConnection cnn = new MySqlConnection(Conexion.NuevaConexion()))
            {
                cnn.Open();
                DataTable dt = new DataTable();
                string f1;
                string f2;
                f1 = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
                f2 = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT ID_Corte,Fecha_Apertura,Fecha_Cierre,Ingreso_Real FROM cortes WHERE Usuario = '" + comboBox1.Text + "' AND Fecha_Apertura BETWEEN '" + f1 + "' AND '" + f2 + "' AND Status= 1 ORDER BY ID_Corte DESC", cnn);
                //se indica el nombre de la tabla
                da.Fill(dt);
                dgv1.DataSource = dt;

                if (dt.Rows.Count > 0)
                {
                    dgv1.Columns["ID_Corte"].HeaderText = "Corte";
                    dgv1.Columns["ID_Corte"].Width = 50;
                    dgv1.Columns["Fecha_Apertura"].HeaderText = "Fecha Apertura";
                    dgv1.Columns["Fecha_Cierre"].HeaderText = "Fecha Cierre";
                    dgv1.Columns["Ingreso_Real"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv1.Columns["Ingreso_Real"].HeaderText = "Total Cobrado";
                    dgv1.ClearSelection();

                }

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue.ToString() == "COBRADOR")
            {

                //XtraReport2 report = new XtraReport2();
                //Parameter param1 = new Parameter();
                //Parameter param2 = new Parameter();
                //param1.Name = "Corte_ID";
                //param2.Name = "CorteAbono";
                //param1.Type = typeof(System.Int32);
                //param2.Type = typeof(System.Int32);
                //param1.Value = IDCorte;
                //param2.Value = ID
                //param1.Description = "Corte ID: ";
                //param1.Visible = true;

                // Add the parameter to the report.
                //report.Parameters.Add(param1);
                //report.FilterString = "[ID_Corte] = [Parameters.Corte_ID]";
                //report.RequestParameters = false;

                //ReportPrintTool pt = new ReportPrintTool(report);
                //pt.AutoShowParametersPanel = false;
                //pt.ShowPreviewDialog();
            }
            else
            {
                //RepCortedeCaja report = new RepCortedeCaja();
                //Parameter param1 = new Parameter();
                //param1.Name = "Corte_ID";
                //param1.Type = typeof(System.Int32);
                //param1.Value = IDCorte;
                //param1.Description = "Corte ID: ";
                //param1.Visible = true;

                //// Add the parameter to the report.
                //report.Parameters.Add(param1);
                //report.FilterString = "[ID_Corte] = [Parameters.Corte_ID]";
                //report.RequestParameters = false;

                //ReportPrintTool pt = new ReportPrintTool(report);
                //pt.AutoShowParametersPanel = false;
                //pt.ShowPreviewDialog();
            }

        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv1.SelectedRows.Count > 0)
                {
                    IDCorte = Convert.ToInt32(dgv1.SelectedRows[0].Cells[0].Value);
                }
            }
            catch (ConstraintException ex)
            {
                return;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgv1.Rows.Clear();
        }

        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            toolStripButton1.PerformClick();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //RepHistorialTicketCredito report = new RepHistorialTicketCredito();
            //Parameter param1 = new Parameter();
            //param1.Name = "Corte_ID";
            //param1.Type = typeof(System.Int32);
            //param1.Value = IDCorte;
            //param1.Description = "Corte ID: ";
            //param1.Visible = true;

            //// Add the parameter to the report.
            //report.Parameters.Add(param1);
            //report.FilterString = "[Corte] = [Parameters.Corte_ID]";
            //report.RequestParameters = false;

            //ReportPrintTool pt = new ReportPrintTool(report);
            //pt.AutoShowParametersPanel = false;
            //pt.ShowPreviewDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //ReporteAbonos report = new ReporteAbonos();
            //Parameter param1 = new Parameter();
            //param1.Name = "Corte_ID";
            //param1.Type = typeof(System.Int32);
            //param1.Value = IDCorte;
            //param1.Description = "Corte ID: ";
            //param1.Visible = true;

            //// Add the parameter to the report.
            //report.Parameters.Add(param1);
            //report.FilterString = "[ID_Corte] = [Parameters.Corte_ID]";
            //report.RequestParameters = false;

            //ReportPrintTool pt = new ReportPrintTool(report);
            //pt.AutoShowParametersPanel = false;
            //pt.ShowPreviewDialog();

        }
       
    }
}
