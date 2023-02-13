using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Developers
{
    public partial class FrmCerrarCorte : Form
    {
        Decimal dolar;
        Decimal Efectivo;
        int cant = 0;
        private DialogResult respnuevo = new DialogResult();
        public FrmCerrarCorte()
        {
            InitializeComponent();
        }
        private void txt1_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt1.Text))
            {
                txt1.Text = "0"; 
            }
            Decimal s = Convert.ToDecimal(this.txt1.Text) * 1000;
            label15.Text = s.ToString("c");
            suma();
        }
        private void txt2_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt2.Text))
            {
                txt2.Text = "0";
            }
            Decimal s = Convert.ToDecimal(this.txt2.Text) * 500;
            label17.Text = s.ToString("c");
            suma();
        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt3.Text))
            {
                txt3.Text = "0";
            }
            Decimal s = Convert.ToDecimal(this.txt3.Text) * 200;
            label18.Text = s.ToString("c");
            suma();
        }

        private void txt4_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt4.Text))
            {
                txt4.Text = "0";
            }
            Decimal s = Convert.ToDecimal(this.txt4.Text) * 100;
            label19.Text = s.ToString("c");
            suma();
        }

        private void txt5_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt5.Text))
            {
                txt5.Text = "0";
            }
            Decimal s = Convert.ToDecimal(this.txt5.Text) * 50;
            label20.Text = s.ToString("c");
            suma();
        }

        private void txt6_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt6.Text))
            {
                txt6.Text = "0";
            }
            Decimal s = Convert.ToDecimal(this.txt6.Text) * 20;
            label21.Text = s.ToString("c");
            suma();
        }

        private void txt7_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt7.Text))
            {
                txt7.Text = "0";
            }
            Decimal s = Convert.ToDecimal(this.txt7.Text) * 100;
            label22.Text = s.ToString("c");
            suma();
        }

        private void txt8_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt8.Text))
            {
                txt8.Text = "0";
            }
            Decimal s = Convert.ToDecimal(this.txt8.Text) * 10;
            label23.Text = s.ToString("c");
            suma();
        }

        private void txt9_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt9.Text))
            {
                txt9.Text = "0";
            }
            Decimal s = Convert.ToDecimal(this.txt9.Text) * 5;
            label24.Text = s.ToString("c");
            suma();
        }

        private void txt10_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt10.Text))
            {
                txt10.Text = "0";
            }
            Decimal s = Convert.ToDecimal(this.txt1.Text) * 2;
            label25.Text = s.ToString("c");
            suma();
        }

        private void txt11_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt11.Text))
            {
                txt11.Text = "0";
            }
            Decimal s = Convert.ToDecimal(this.txt1.Text) * 1;
            label26.Text = s.ToString("c");
            suma();
        }

        private void txt12_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt12.Text))
            {
                txt12.Text = "0";
            }
            Decimal s = Convert.ToDecimal(this.txt1.Text) * Convert.ToDecimal(.50);
            label27.Text = s.ToString("c");
            suma();
        }
        private void suma()
        {
           
            Decimal txt1000 = Convert.ToDecimal(this.txt1.Text) * 1000;
            Decimal txt500 = Convert.ToDecimal(this.txt2.Text) * 500;
            Decimal txt200 = Convert.ToDecimal(this.txt3.Text) * 200;
            Decimal txt100 = Convert.ToDecimal(this.txt4.Text) * 100;
            Decimal txt50 = Convert.ToDecimal(this.txt5.Text) * 50;
            Decimal tx20 = Convert.ToDecimal(this.txt6.Text) * 20;
            Decimal txtM100 = Convert.ToDecimal(this.txt7.Text) * 100;
            Decimal txt10 = Convert.ToDecimal(this.txt8.Text) * 10;
            Decimal txt5 = Convert.ToDecimal(this.txt9.Text) * 5;
            Decimal txt2 = Convert.ToDecimal(this.txt10.Text) * 2;
            Decimal txt1 = Convert.ToDecimal(this.txt11.Text) * 1;
            Decimal txtM50 = Convert.ToDecimal(this.txt12.Text) * Convert.ToDecimal(.50);
            Decimal txtM20 = Convert.ToDecimal(this.textBox1.Text) * Convert.ToDecimal(.20);
            Decimal txtM10 = Convert.ToDecimal(this.textBox2.Text) * Convert.ToDecimal(.10);
            Decimal dolarMonedas = Convert.ToDecimal(numericUpDown1.Value) * dolar;
            Decimal dolarBilletes = Convert.ToDecimal(this.textBox3.Text) * dolar;
            //txtEfectivo.Text =  (txt1000 + txt500 + txt200 + txt100 + txt50 + tx20 + txtM100 + txt10 + txt5 + txt2 + txt1 + txtM50 + txtM20 + txtM10 + dolarMonedas + dolarBilletes).ToString("c");
            Efectivo = Convert.ToDecimal(txt1000 + txt500 + txt200 + txt100 + txt50 + tx20 + txtM100 + txt10 + txt5 + txt2 + txt1 + txtM50 + txtM20 + txtM10 + dolarMonedas + dolarBilletes);
            numEfectivo.Value = Efectivo;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                txt12.Text = "0";
            }
            Decimal s = Convert.ToDecimal(this.textBox1.Text) * Convert.ToDecimal(.20);
            label31.Text = s.ToString("c");
            suma();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Text = "0";
            }
            Decimal s = Convert.ToDecimal(this.textBox2.Text) * Convert.ToDecimal(.10);
            label30.Text = s.ToString("c");
            suma();
        }

      

        //private decimal SumaCorteAbonos(int p)
        //{
        //    DataTable tabla = new DataTable();
        //    String peticion = "SELECT sum(CantidadAbonada) as total, count(ID_AbonoHistorial) as cant FROM abonoshistorial where CorteAbono ='" + p + "' AND Estado = 0";
        //    Decimal totalC = 0;
            
        //    using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
        //    {
        //        conexion.Open();
        //        MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);
        //        adaptador.Fill(tabla);
        //    }
        //    if (tabla.Rows.Count > 0)
        //    {
        //        if (tabla.Rows[0][0].ToString() != "")
        //        {
        //            totalC += Convert.ToDecimal(tabla.Rows[0][0].ToString());
        //        }
        //        if (tabla.Rows[0][1].ToString() != "")
        //        {
        //            cant = Convert.ToInt32(tabla.Rows[0][1].ToString());
        //        }
        //        return totalC;
        //    }
        //    return 0;
        //}

        private decimal ConsultaFondo(int CorteID)
        {
            
                //CONSULTA FONDO
                String peticion = "SELECT fondo FROM cortes WHERE ID_Corte='" + CorteID + "'";
                DataTable tabla = new DataTable();
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                conexion.Open();
                MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);
                adaptador.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    return Convert.ToDecimal(tabla.Rows[0][0]);
                }
                else
                {
                    return 0;
                }
                }
        }
        private decimal SumaCorteTickets(int CorteID)
        {
                DataTable tabla = new DataTable();
                String peticion = "SELECT sum(Total) as totalTickets from tickets where Corte ='" + CorteID + "' and Estado=0";
                Decimal totalC = 0;
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);
                    adaptador.Fill(tabla);
                }
                if (tabla.Rows.Count > 0)
                {
                    if (tabla.Rows[0][0].ToString()!= "")
                    {
                        totalC += Convert.ToDecimal(tabla.Rows[0][0].ToString());
                    }
                    return totalC;
                }
                return 0;
        }
        private void SoloNumero(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
        }

        private void txt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
        }

        private void txt3_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
        }

        private void txt4_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
        }

        private void txt5_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
        }

        private void txt6_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
        }

        private void txt7_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
        }

        private void txt8_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
        }

        private void txt9_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
        }

        private void txt10_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
        }

        private void txt11_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
        }

        private void txt12_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            Decimal s = Convert.ToDecimal(numericUpDown1.Value) * dolar;
            label34.Text = s.ToString("c");
            suma();
        }
        
        private void FrmCerrarCorte_Load(object sender, EventArgs e)
        {
            DataTable tablacat = new DataTable();
            string peticion = "select * from tipodecambio where fecha ='"+Variable.Fecha+"';";

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);
                    adaptador.Fill(tablacat);
                }
            if (tablacat.Rows.Count > 0)
            {
                dolar = Convert.ToDecimal(tablacat.Rows[0][1].ToString());
            }
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
            }
            numEfectivo.Select();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Text = "0";
            }
            Decimal s = Convert.ToDecimal(this.textBox3.Text) * dolar;
            label33.Text = s.ToString("c");
            suma();
        }

        private void btnCerrarCorte_Click(object sender, EventArgs e)
        {
            respnuevo = MessageBox.Show("Cerrar Corte?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respnuevo == DialogResult.Yes)
            {
                string estado = "0";//0 = abierto // 1 = cerrado

                string query = "select * from cortes where Usuario ='" + Variable.UsuarioActivo + "'and Status='" + estado + "';";

                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    MySqlDataReader rdr = null;
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        Decimal Fondo = ConsultaFondo(Variable.CorteAbierto);
                        Decimal vales = Convert.ToDecimal(numVales.Value);
                        Decimal tarjetas = Convert.ToDecimal(numTarjetas.Value);
                        Decimal cheques = Convert.ToDecimal(numCheques.Value);
                        Decimal efect = Convert.ToDecimal(numEfectivo.Value);
                        Decimal Total = efect + vales + tarjetas + cheques;
                        Decimal IngresoRealTickets = SumaCorteTickets(Variable.CorteAbierto);
                        //Decimal IngresoRealAbonos = SumaCorteAbonos(Variable.CorteAbierto);
                        Decimal IngresoReal = IngresoRealTickets;
                        Decimal Diferencia = Total - (IngresoReal + Fondo);

                        string estadoCierre = "1";
                        string query2 = "update cortes set Status='" + estadoCierre + "', Ingreso_Capturado='" + Total + "', Ingreso_Real='" + IngresoReal + "' where Usuario ='" + Variable.UsuarioActivo + "'and Status='" + estado + "';";
                        //MessageBox.Show("Diferencia: " + Diferencia, "Diferencia!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        using (MySqlConnection cn = new MySqlConnection(Conexion.NuevaConexion()))
                        {
                            MySqlCommand cmdo = new MySqlCommand(query2, cn);
                            cn.Open();
                            cmdo.ExecuteNonQuery();
                            cn.Close();
                            Variable.CorteAbierto = 0;
                        }
                        this.Close();
                    }
                }
            }
            //respnuevo = MessageBox.Show("Cerrar Corte?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (respnuevo == DialogResult.Yes)
            //{
            //    string estado = "0";//0 = abierto // 1 = cerrado

            //    string query = "select * from cortes where Usuario ='" + Variable.UsuarioActivo + "'and Status='" + estado + "';";

            //    using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            //    {
            //        MySqlDataReader rdr = null;
            //        conexion.Open();
            //        MySqlCommand cmd = new MySqlCommand(query, conexion);
            //        rdr = cmd.ExecuteReader();
            //        if (rdr.Read())
            //        {
            //            Decimal Fondo = ConsultaFondo(Variable.CorteAbierto);
            //            Decimal vales = Convert.ToDecimal(numVales.Value);
            //            Decimal tarjetas = Convert.ToDecimal(numTarjetas.Value);
            //            Decimal cheques = Convert.ToDecimal(numCheques.Value);
            //            Decimal efect = Convert.ToDecimal(numEfectivo.Value);
            //            Decimal Total = efect + vales + tarjetas + cheques;
            //            //Decimal IngresoReal = SumaCorte(Variable.CorteAbierto);
            //            Decimal Diferencia = Total - (IngresoReal + Fondo);

            //            string estadoCierre = "1";
            //            String date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //            string query2 = "update cortes set Fecha_Cierre='" + date + "',Status='" + estadoCierre + "', Ingreso_Capturado='" + Total + "', Ingreso_Real='" + IngresoReal + "' where Usuario ='" + Variable.UsuarioActivo + "'and Status='" + estado + "';";
            //            //MessageBox.Show("Diferencia: " + Diferencia, "Diferencia!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //            using (MySqlConnection cn = new MySqlConnection(Conexion.NuevaConexion()))
            //            {
            //                MySqlCommand cmdo = new MySqlCommand(query2, cn);
            //                cn.Open();
            //                cmdo.ExecuteNonQuery();
            //                cn.Close();
            //                Variable.CorteAbierto = 0;
            //            }
            //            this.Close();
            //        }
            //    }
            //}
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
    }
}
