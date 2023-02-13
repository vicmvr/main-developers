using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Timers;
using System.IO;
using FirebirdSql.Data.FirebirdClient;
using Developers.LayerEntities;
using Developers.BusinessLogicLayer;
using System.Data.Common;

namespace Developers
{
    public partial class FrmLogin : Form
    {
        //Creamos las instancias de la clase Eproducto y ProductoBol
        private EUsuario _usuario;
        private readonly UsuarioBol _usuarioBol = new UsuarioBol();
        double opy=.05;
        int FormX; int FormY; int PBX; int PBY;
        public static string NombreDeCaja { get; set; }
        private DialogResult respnuevo = new DialogResult();

        public FrmLogin()
        {
            InitializeComponent();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public class CursorWait : IDisposable
        {
            public CursorWait(bool appStarting = false, bool applicationCursor = false)
            {
                // Wait
                Cursor.Current = appStarting ? Cursors.AppStarting : Cursors.WaitCursor;
                if (applicationCursor) Application.UseWaitCursor = true;

            }
            public void Dispose()
            {
                // Reset
                Cursor.Current = Cursors.Default;
                Application.UseWaitCursor = false;
            }
        }

        private string TraerPorId(int id)
        {
            try
            {
                _usuario = _usuarioBol.TraerPorId(id, Conexion.Nueva());

                if (_usuario != null)
                {
                    //txtId.Text = Convert.ToString(_alumno.id);
                    return _usuario.clave;
                }
                else
                    MessageBox.Show("El usuario solicitado no existe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado1");
            }
                return null;
        }
        private void TraerTodos()
        {
        List<EUsuario> usuarios = _usuarioBol.Todos(Conexion.Nueva());                

           // if (usuarios.Count > 0)
            //{

            cbUser.DataSource = usuarios;
            cbUser.DisplayMember = "usuario";
            cbUser.ValueMember = "idusuario";
       // }
           // else
         //       MessageBox.Show("No existe usuario registrado");
        }
        
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            
            //Traer todos los usuarios
            using (new CursorWait())
            {
                    TraerTodos(); 
            }

        //    FbConnection conectar = new FbConnection(Conexion.Nueva());
        //    //MySqlConnection conectar2 = new MySQLConnection(Conexion.Nueva());
        //    try
        //    {
        //        conectar.Open();
        //        //MessageBox.Show("Coneccion exitosa");
        //        FbDataAdapter datos = new FbDataAdapter("SELECT * FROM usuarios", conectar);
        //        DataTable ds = new DataTable();
        //        ds = new DataTable();
        //        datos.Fill(ds);
        //        cbUser.DataSource = ds;
        //        cbUser.DisplayMember = "username";
        //        cbUser.ValueMember = "IDUsuario";

        //        conectar.Close();
        //        //this.DialogResult = DialogResult.OK;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error de Conexion");
        //    }
        /////////
        //cargaDatosCaja();
            if (NombreDeCaja == "SLDEVELOPERS")
            {
                txtPass.Text = "CAJERO";
            }
            this.Opacity = .01;
            //ESTABLECE FECHA ACTUAL
            DateTime Hoy = DateTime.Today;            
            Variable.Fecha = Hoy.ToString("dd/MM/yyyy");//Variable.Fecha = DateTime.Now.ToShortDateString();
            
            timerOpacity.Enabled = true;
            timerOpacity.Start();
        }
        private void cargaDatosCaja()
        {
            try
            {
                NombreDeCaja = Environment.MachineName;
                DataTable tabla = new DataTable();
                String peticion = "SELECT IDCaja,Nombre FROM cajas WHERE idcaja ='" + 1 + "'";
                using (FbConnection cn = new FbConnection(Conectar.NuevaConexion()))
                {
                    cn.Open();
                    FbDataAdapter adaptador = new FbDataAdapter(peticion, cn);
                    adaptador.Fill(tabla);
                    if (tabla.Rows.Count > 0)
                    {
                        Variable.IDCaja = Convert.ToInt32(tabla.Rows[0][0]);
                        //Variable.IDSucursal = Convert.ToInt32(tabla.Rows[0][1]);
                        Variable.NombreCaja = tabla.Rows[0][1].ToString();

                        MessageBox.Show("Error " + Variable.NombreCaja);
                        //Variable.NombreSucursal = tabla.Rows[0][3].ToString();
                        //Variable.ImpresoraTickets = tabla.Rows[0][4].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            //string Pass = "";
            //FbConnection conectar = new FbConnection(Conexion.Nueva());
            try
            { //
                int cteId = 0;
                if (cbUser.SelectedValue != null)
                {
                    cteId = Convert.ToInt32(cbUser.SelectedValue);
                }
                //
                //conectar.Open();
                //MessageBox.Show("Coneccion exitosa");
                //DataTable ds = new DataTable();
                //ds = new DataTable();
                //datos.Fill(ds);
                //conectar.Close();
                //Pass = ds.Rows[0][0].ToString();
                //FbDataAdapter datos = new FbDataAdapter("SELECT password FROM usuarios where idusuario=" + cteId + "", conectar);

                
                if (txtPass.Text == TraerPorId(cteId).ToString())
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta, intenta de nuevo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexion");
            }
            

        }        
        private void iniciaSesion(int idusuario)
        {
            try
            {
                String peticion = "UPDATE usuarios SET Sesion='" + 0 + "' WHERE ID_Usuario= '" + idusuario + "';";
                using (MySqlConnection cn = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    cn.Open();
                    MySqlCommand cmd = new MySqlCommand(peticion, cn);
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtPass.Focus();
            }
        }        
        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnEntrar.Focus();
                btnEntrar.PerformClick();
            }
        }
        private void txtUsuario_MouseHover(object sender, EventArgs e)
        {
            ToolTip tp = new ToolTip();
            //Para que sea un globo y no un simple rectangulo
            tp.IsBalloon = true;
            //Le agregamos un icono informativo, recuerda que
            tp.ToolTipIcon = ToolTipIcon.Info;
            //Colocamos un titulo
            tp.ToolTipTitle = "Usuario";
            tp.SetToolTip(cbUser, "Ingresa tu nombre de usuario");
        }
        private void txtPass_MouseHover(object sender, EventArgs e)
        {
            ToolTip tp = new ToolTip();
            //Para que sea un globo y no un simple rectangulo
            tp.IsBalloon = true;
            //Le agregamos un icono informativo, recuerda que
            //hay otros 2 o bien sin icono
            tp.ToolTipIcon = ToolTipIcon.Info;
            //Colocamos un titulo
            tp.ToolTipTitle = "Contraseña";
            tp.SetToolTip(this.txtPass, "Ingresa tu contraseña");
        }
        private void cargaTipoCambio()
        {
            try
            {
                //CARGA TIPO DE CAMBIO
                DataTable tabla = new DataTable();
                String peticion = "SELECT tipoDeCambio FROM tipodecambio WHERE fecha='" + Variable.Fecha + "';";
                using (MySqlConnection cn = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    cn.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, cn);
                    adaptador.Fill(tabla);
                    if (tabla.Rows.Count > 0)
                    {
                        Variable.TipoCambio = Convert.ToDouble(tabla.Rows[0][0]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        //private void cargaImpresora()
        //{
        //    try
        //    {
        //        DataTable tabla = new DataTable();
        //        String peticion = "SELECT ImpresoraTickets FROM cajas WHERE ID_Caja=" + Variable.IDCaja + " AND ID_Sucursal=" + Variable.IDSucursal + ";";


        //        using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
        //        {
        //            conexion.Open();
        //            MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);
        //            adaptador.Fill(tabla);

        //            if (tabla.Rows.Count > 0)
        //            {
        //                Variable.ImpresoraTickets = tabla.Rows[0][0].ToString();

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error " + ex);
        //    }
        //}
        private void cargaCorteActual()
        {
            try
            {
                //CARGA TIPO DE CAMBIO
                DataTable tabla = new DataTable();
                String peticion = "SELECT ID_Corte FROM cortes WHERE Usuario='" + Variable.UsuarioActivo + "' AND Status='" + 0 + "'  ;";

                using (MySqlConnection cn = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    cn.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, cn);
                    adaptador.Fill(tabla);
                    if (tabla.Rows.Count > 0)
                    {
                        Variable.CorteAbierto = Convert.ToInt32(tabla.Rows[0][0]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void timerArrastra_Tick(object sender, EventArgs e)
        {
            this.Left = MousePosition.X - PBX;
            this.Top = MousePosition.Y - PBY;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                FormX = this.Location.X;
                FormY = this.Location.Y;
                PBX = e.X+1;
                PBY = e.Y+1;
                timerArrastra.Start();
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {            
        timerArrastra.Stop();
        }
        private void lblAcceso_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                FormX = this.Location.X;
                FormY = this.Location.Y;
                PBX = e.X+50;
                PBY = e.Y+19;
                timerArrastra.Start();
            }
        }
        private void lblAcceso_MouseUp(object sender, MouseEventArgs e)
        {
            timerArrastra.Stop();
        }
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                FormX = this.Location.X;
                FormY = this.Location.Y;
                PBX = e.X+14;
                PBY = e.Y+14;
                timerArrastra.Start();
            }
        }
        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            timerArrastra.Stop();
        }
        private void timerOpacity_Tick(object sender, EventArgs e)
        {
            opy = opy + 0.5;
            this.Opacity = opy;
            Console.WriteLine("Opacidad opy= " + opy);
            if (this.Opacity == 1)
            timerOpacity.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString =
          "User=SYSDBA;" +
          "Password=MyN1970x;" +
          "Database=C:\\Users\\Victor\\source\\repos\\_Ventas 20170119\\fdb.fdb;" +
          "DataSource=localhost;" +
          "Port=3050;" +
          "Dialect=3;" +
          "Charset=NONE;" +
          "Role=;" +
          "Connection lifetime=15;" +
          "Pooling=true;" +
          "MinPoolSize=0;" +
          "MaxPoolSize=50;" +
          "Packet Size=8192;" +
          "ServerType=0";

            FbConnection conectar = new FbConnection(connectionString);
            try
            { //
                int cteId = 0;
                if (cbUser.SelectedValue != null)
                {
                    cteId = Convert.ToInt32(cbUser.SelectedValue);
                }
                //
                conectar.Open();
                //MessageBox.Show("Coneccion exitosa");
                FbDataAdapter datos = new FbDataAdapter("SELECT password FROM usuarios where id="+ cteId + "", conectar);
                DataTable ds = new DataTable();
                ds = new DataTable();
                datos.Fill(ds);
                    if (ds.Rows.Count > 0)
                    {
                        string Pass = ds.Rows[0][0].ToString();
                        if (txtPass.Text == Pass)
                        {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta");
                    }
                }

                conectar.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexion");
            }
            ///////
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("http://facebook.com/SanLuisDevelopers/");
        }
    }
}
