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
using Developers.Forms;
using System.IO;

namespace Developers
{
    public partial class FrmEdicionClientes : Form
    {
        private DialogResult respnuevo = new DialogResult();
        int idLimite = 0;
        public int id=0;
        public int bloqControl = 0;
        public bool isNew=true;
        private int identificador=1;
        int limAux = 0;
        public FrmEdicionClientes()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            respnuevo = MessageBox.Show("Salir sin guardar cambios?", " ", MessageBoxButtons.YesNo);
            if (respnuevo == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
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
        private void FrmEdicionClientes_Load(object sender, EventArgs e)
        {
            //if ((Variable.UsuarioRol == "ADMIN") || (Variable.UsuarioRol == "SUPERVISOR"))
            //{
            //} 
            if ((Variable.UsuarioRol == "CAJERO") || (Variable.UsuarioRol == "COBRADOR"))
            {
                btnNuevo.Visible = false;
                btnIngresaBoleta.Visible = false;
            }
            cargarColonias();
            //cargarLimites();
            if (id > 0)
            {
                llenarDatos();
            }
            if (bloqControl == 1)//Cuando cliente sin saldo viene a comprar
            {
                txtNombre.Enabled = false;
                txtApePat.Enabled = false;
                txtApeMat.Enabled = false;
                nudSaldo.Enabled = false;
            }
            if (identificador == 1)//Cuando es una busqueda normal y el cliente tiene saldo
            {
                txtNombre.Enabled = false;
                txtApePat.Enabled = false;
                txtApeMat.Enabled = false;
                cbLimite.Enabled = false;
                nudSaldo.Enabled = false;
                //cargarLimitecliente(limAux);
            }
            else if (identificador == 0)//Cargar el limite Cuando es una busqueda normal
            {
                btnIngresaBoleta.Enabled = true;
                //txtNombre.Enabled = false;
                //txtApePat.Enabled = false;
                //txtApeMat.Enabled = false;
                txtCiudad.Text = "SAN LUIS RIO COLORADO";
            }
            if (isNew)//Cuando es un cliente nuevo
            {
                txtNombre.Enabled = true;
                txtApePat.Enabled = true;
                txtApeMat.Enabled = true;
                cbLimite.Enabled = false;
                nudSaldo.Enabled = false;
                cbLimite.Visible = false;
                nudSaldo.Visible = false;
                label14.Visible = false;
                label8.Visible = false;
                cbColonia.Text = "";
                cbCobro.Text = "";
               
            }
            
        }
        public DataTable dt = new DataTable();
        private void cargarColonias()
        {
            using (MySqlConnection cnn = new MySqlConnection(Conexion.NuevaConexion()))
            {
                String query;
                cnn.Open();
                query = "select ID_Colonia,NombreColonia from colonias WHERE zona = 0;";
                MySqlDataAdapter adaptador = new MySqlDataAdapter(query, cnn);
                adaptador.Fill(dt);
                cbColonia.DataSource = dt;
                cbColonia.DisplayMember = "NombreColonia";
                cbColonia.ValueMember = "ID_Colonia";
            }
        }
        private int cargarSemanasCliente(int limAux)
        {
            using (MySqlConnection cnn = new MySqlConnection(Conexion.NuevaConexion()))
            {
                cnn.Open();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT TiempoLimite FROM limitedecredito WHERE ID_Limite=" + limAux + ";", cnn);
                da.Fill(dt);
                int v = Convert.ToInt32(dt.Rows[0][0]);
                return v;
                
            }
        }
        private void cargarLimitecliente(int limAux)
        {
            using (MySqlConnection cnn = new MySqlConnection(Conexion.NuevaConexion()))
            {
                cnn.Open();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT CantidadLimite FROM limitedecredito WHERE ID_Limite="+limAux+";", cnn);
                //se indica el nombre de la tabla
                da.Fill(ds);

                cbLimite.DataSource = ds.Tables[0].DefaultView;
                //se especifica el campo de la tabla
                cbLimite.DisplayMember = "CantidadLimite";
                cbLimite.ValueMember = "ID_Limite";
            }
        }

        public void cargarLimites()
        {
            using (MySqlConnection cnn = new MySqlConnection(Conexion.NuevaConexion()))
            {
                cnn.Open();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT ID_Limite,CantidadLimite,PagoInicial FROM limitedecredito", cnn);
                //se indica el nombre de la tabla
                da.Fill(ds);
               
                cbLimite.DataSource = ds.Tables[0].DefaultView;
                //se especifica el campo de la tabla
                cbLimite.DisplayMember = "CantidadLimite";
                cbLimite.ValueMember = "ID_Limite";
            }

        }
        private void llenarDatos()
        {
            DataTable tabla = new DataTable();
            double PorcPagoIni = 0;
            double saldo = 0;
            double limite = 0;
            string peticion = "SELECT * FROM clientes inner join limitedecredito on clientes.LimiteCredito = limitedecredito.ID_Limite WHERE ID_Cliente=" + id + ";";
            //MOSTRAR DATOS
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);
                adaptador.Fill(tabla);
            }
            if (tabla.Rows.Count > 0)
            {
                txtNombre.Text = tabla.Rows[0][1].ToString();
                txtApePat.Text = tabla.Rows[0][2].ToString();
                txtApeMat.Text = tabla.Rows[0][3].ToString();
                //limAux = Convert.ToInt32(tabla.Rows[0][13].ToString());
                txtCalle.Text = tabla.Rows[0][4].ToString();
                cbColonia.Text = tabla.Rows[0][5].ToString();
                txtNumExt.Text = tabla.Rows[0][6].ToString();
                txtNumInt.Text = tabla.Rows[0][7].ToString();
                txtCiudad.Text = tabla.Rows[0][8].ToString();
                txtTelefono.Text = tabla.Rows[0][9].ToString();
                txtRFC.Text = tabla.Rows[0][10].ToString();
                txtCURP.Text = tabla.Rows[0][11].ToString();
                txtCorreo.Text = tabla.Rows[0][12].ToString();
                nudSaldo.Text = tabla.Rows[0][14].ToString();
                saldo = Convert.ToDouble(tabla.Rows[0][14].ToString());
                cbCobro.Text = tabla.Rows[0][15].ToString();
                txtInfo.Text = tabla.Rows[0][17].ToString();
                identificador = Convert.ToInt32(tabla.Rows[0][18]);
                txtComplemento.Text = tabla.Rows[0][20].ToString();
               
                cbLimite.Text = tabla.Rows[0][24].ToString();
                limite = Convert.ToDouble(tabla.Rows[0][24].ToString());
                PorcPagoIni = Convert.ToDouble(tabla.Rows[0][27].ToString());
                label18.Text = (limite - saldo).ToString("c");
                lblPagoIni.Text = ((PorcPagoIni * 100)+"%").ToString();
                lblNombre.Text = txtNombre.Text+" "+txtApePat.Text+" "+txtApeMat.Text;
                //cbLimite.Text = txtLimite.Text;
            }
        }
        public Image CargarImagen()
        {
            using (MySqlConnection conn = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Huella FROM clientes WHERE ID_Cliente=" + id + ";";
                    try
                    {
                        byte[] imgArr = (byte[])cmd.ExecuteScalar();
                        using (var stream = new MemoryStream(imgArr))
                        {
                            Image img = Image.FromStream(stream);
                            return img;
                        }
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (cbCobro.Text == "")
            {
                MessageBox.Show("El campo Dia de Cobro no puede estar vacio.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbCobro.Focus();
                return;
            }
            if (txtNombre.Text == "")
            {
                MessageBox.Show("El campo Nombre no puede estar vacio.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
                return;
            }
            if (txtApePat.Text == "")
            {
                MessageBox.Show("El campo Apellido paterno no puede estar vacio.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtApePat.Focus();
                return;
            }
            if (txtApeMat.Text == "")
            {
                MessageBox.Show("El campo Apellido materno no puede estar vacio.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtApeMat.Focus();
                return;
            }
            if (txtCalle.Text == "")
            {
                MessageBox.Show("El campo calle no puede estar vacio.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCalle.Focus();
                return;
            }
            if (cbColonia.Text == "")
            {
                MessageBox.Show("El campo colonia no puede estar vacio.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbColonia.Focus();
                return;
            }
            if (txtNumExt.Text == "")
            {
                MessageBox.Show("El campo numero exterior no puede estar vacio.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumExt.Focus();
                return;
            }
            if (isNew == false)
            {
                //idLimite = Convert.ToInt32(cbLimite.SelectedValue.ToString());
                string peticion = "update clientes set Nombre='"+txtNombre.Text+"',ApePat='"+txtApePat.Text+"',ApeMat='"+txtApeMat.Text+"',Calle='" + txtCalle.Text + "',Colonia='" + cbColonia.Text + "',NumExt='" + txtNumExt.Text + "',NumInt='" + txtNumInt.Text + "',Ciudad='" + txtCiudad.Text + "',Telefono='" + txtTelefono.Text + "',RFC='" + txtRFC.Text + "',CURP='" + txtCURP.Text + "',Correo='" + txtCorreo.Text + "',DiaCobro='" + cbCobro.Text + "',Info='" + txtInfo.Text + "',Complemento='" + txtComplemento.Text + "',Identificador=1 WHERE ID_Cliente= '" + id + "';";
                using (MySqlConnection cnn = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    cnn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(peticion, cnn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Actualizado con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                //if (identificador == 0)//Cargar el limite Cuando es una busqueda normal
                //{
                //    if (nudSaldo.Value > 0)
                //    {
                //        if (nudSaldo.Value <= 50)
                //        {
                //            Calculo calculo = new Calculo();
                //            calculo.insertarSoloUnAbono(id, Convert.ToDouble(nudSaldo.Value));
                //        }
                //        else
                //        {
                //        int sem = cargarSemanasCliente(idLimite);
                //        Calculo calculo = new Calculo();
                //        calculo.calculaAbonoClienteMigrado(id, Convert.ToDouble(nudSaldo.Value), sem);
                //        }
                        
                //    }
                //}
                this.Close();
            }
            else
            {
                String peticion = "insert into clientes(Nombre,ApePat,ApeMat,Calle,Colonia,NumExt,NumInt,Ciudad,Telefono,RFC,CURP,Correo,DiaCobro,Complemento) values('" + txtNombre.Text + "','" + txtApePat.Text + "','" + txtApeMat.Text + "','" + txtCalle.Text + "','" + cbColonia.Text + "','" + txtNumExt.Text + "','" + txtNumInt.Text + "','" + txtCiudad.Text + "','" + txtTelefono.Text + "','" + txtRFC.Text + "','" + txtCURP.Text + "','" + txtCorreo.Text + "','" + cbCobro.Text + "','"+ txtComplemento.Text + "');";
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    using (MySqlCommand cmmd = new MySqlCommand(peticion, conexion))
                    {
                        cmmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Guardado con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            lblNombre.Text = txtNombre.Text + " " + txtApePat.Text + " " + txtApeMat.Text;
        }
        private void txtApePat_KeyUp(object sender, KeyEventArgs e)
        {
            lblNombre.Text = txtNombre.Text + " " + txtApePat.Text + " " + txtApeMat.Text;
        }
        private void txtApeMat_KeyUp(object sender, KeyEventArgs e)
        {
            lblNombre.Text = txtNombre.Text + " " + txtApePat.Text + " " + txtApeMat.Text;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEdicionClientes_Activated(object sender, EventArgs e)
        {
            if (bloqControl == 1)
            {
                txtCalle.Focus();
            }
        }

        private void cbCobro_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbLimite_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
