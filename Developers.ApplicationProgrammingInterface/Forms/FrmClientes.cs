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
    public partial class FrmClientes : Form
    {
        int idenviar;
        DataTable dt = new DataTable();
        private DialogResult respnuevo = new DialogResult();
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void cargaClientes()
        {
            try
            {
                //CARGA
                DataTable tabla = new DataTable();
                //String peticion = "SELECT ID_Cliente,Nombre,ApePat,ApeMat,LimiteCredito FROM clientes inner join limitedecredito on  WHERE ID_Cliente  NOT LIKE '1' LIMIT 0,100 ";
                String peticion = "SELECT clientes.ID_Cliente,clientes.NombreCompleto,limitedecredito.CantidadLimite FROM clientes INNER JOIN limitedecredito ON clientes.LimiteCredito = limitedecredito.ID_Limite WHERE ID_Cliente  NOT LIKE '1' LIMIT 0,20 ";
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion))
                    adaptador.Fill(tabla);
                    dgv1.DataSource = tabla;
                }
                if (tabla.Rows.Count > 0)
                {
                    dgv1.Columns["ID_Cliente"].HeaderText = "ID";
                    dgv1.Columns["ID_Cliente"].Width = 50;
                    dgv1.Columns["NombreCompleto"].HeaderText = "NOMBRE";
                    dgv1.Columns["NombreCompleto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv1.Columns["CantidadLimite"].HeaderText = "LIMITE DE CREDITO";
                    dgv1.Columns["CantidadLimite"].Width = 220;
                    dgv1.ClearSelection();

                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmEdicionClientes editar = new FrmEdicionClientes();
            editar.ShowDialog();
            editar.isNew = true;
            cargaClientes();
            idenviar = 0;
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
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

        private void actualizarGrid()
        {
            DataTable tablacat = new DataTable();
            string peticion = String.Empty;
            //string peticion = "select ID_Cliente,NombreCompleto,LimiteCredito from clientes where ID_Cliente LIKE'%" + txtNombre.Text + "%' or NombreCompleto like'%" + txtNombre.Text + "%';";
            //String peticion = "SELECT clientes.ID_Cliente,clientes.NombreCompleto,limitedecredito.CantidadLimite FROM clientes INNER JOIN limitedecredito ON clientes.LimiteCredito = limitedecredito.ID_Limite WHERE clientes.clientes.ID_Cliente NOT LIKE '1' AND clientes.ID_Cliente LIKE'%" + txtNombre.Text + "%' or clientes.NombreCompleto like'%" + txtNombre.Text + "%' LIMIT 0,18;";
            //string peticion = "SELECT clientes.ID_Cliente,clientes.NombreCompleto,limitedecredito.CantidadLimite FROM clientes INNER JOIN limitedecredito ON clientes.LimiteCredito = limitedecredito.ID_Limite WHERE clientes.ID_Cliente LIKE'%" + txtNombre.Text + "%' or clientes.ID_Cliente NOT LIKE '1' AND clientes.Nombre REGEXP '^" + txtNombre.Text + "' and clientes.ApePat Regexp '^" + txtApePat.Text + "' and clientes.ApeMat regexp '^" + txtApeMat.Text + "' LIMIT 0,18;;";
            if (txtnumcte.Text == string.Empty)
            {
                peticion = "SELECT ID_Cliente,NombreCompleto,limitedecredito.CantidadLimite FROM clientes INNER JOIN limitedecredito ON clientes.LimiteCredito = limitedecredito.ID_Limite WHERE clientes.Nombre REGEXP '^" + txtNombre.Text + "' and clientes.ApePat Regexp '^" + txtApePat.Text + "' and clientes.ApeMat regexp '^" + txtApeMat.Text + "' LIMIT 0,18;;";
            }
            else
            {
                peticion = "SELECT ID_Cliente,NombreCompleto,limitedecredito.CantidadLimite FROM clientes INNER JOIN limitedecredito ON clientes.LimiteCredito = limitedecredito.ID_Limite WHERE clientes.ID_Cliente =" + txtnumcte.Text + ";";
            }
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);

                    adaptador.Fill(tablacat);
                    dgv1.DataSource = tablacat;
                }
                if (tablacat.Rows.Count > 0)
                {
                    dgv1.Columns["ID_Cliente"].HeaderText = "ID";
                    dgv1.Columns["ID_Cliente"].Width = 50;
                    dgv1.Columns["NombreCompleto"].HeaderText = "NOMBRE";
                    dgv1.Columns["NombreCompleto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv1.Columns["CantidadLimite"].HeaderText = "LIMITE DE CREDITO";
                    dgv1.Columns["CantidadLimite"].Width = 150;
                    dgv1.ClearSelection();
                    txtNombre.Focus();
                }
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (idenviar != 0)
            {
                FrmEdicionClientes edit = new FrmEdicionClientes();
                edit.id = idenviar;
                edit.isNew = false;
                edit.ShowDialog();
                cargaClientes();
                idenviar = 0;
                txtNombre.Focus();
            }
            else
            {
                MessageBox.Show("Selecciona un cliente", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void limpiar()
        {
            txtNombre.Clear();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv1.SelectedRows.Count > 0)
                    {
                        idenviar = Convert.ToInt32(dgv1.SelectedRows[0].Cells[0].Value);
                    }
        }

        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (dataGridView1.CurrentCell != null)
                if (dgv1.SelectedRows.Count > 0)
                {
                    //Variable.idCredito = Convert.ToInt32(dgv1.SelectedRows[0].Cells[0].Value);
                    idenviar = Convert.ToInt32(dgv1.SelectedRows[0].Cells[0].Value);
                    btnEditar.PerformClick();
                }
            }
            catch (ConstraintException ex)
            {
                return;
            }

        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            if ((Variable.UsuarioRol == "CAJERO") || (Variable.UsuarioRol == "COBRADOR"))
            {
                btnNuevo.Visible = false;
                btnEliminar.Visible = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            respnuevo = MessageBox.Show("Estas seguro de eliminar el cliente?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (respnuevo == DialogResult.Yes)
            {
                if ((idenviar != 0) && (idenviar != 1))
                {
                    string peticion = "DELETE FROM clientes WHERE ID_Cliente= '" + idenviar + "';";

                    try
                    {
                        using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                        {
                            conexion.Open();
                            MySql.Data.MySqlClient.MySqlCommand commando = new MySql.Data.MySqlClient.MySqlCommand(peticion, conexion);
                            commando.ExecuteNonQuery();
                        }
                        idenviar = 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo connectar verifique conexion con el servidor " + ex);
                    }
                }
                cargaClientes();
            }
            else
            {
                idenviar = 0;
                dgv1.ClearSelection();
            }
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv1.SelectedRows.Count > 0)
                {
                    idenviar = Convert.ToInt32(dgv1.SelectedRows[0].Cells[0].Value);
                }
            }
            catch (ConstraintException ex)
            {
                return;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBuscar.PerformClick();
            }
            //btnBuscar.PerformClick();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            actualizarGrid();
            txtnumcte.Clear();
            txtNombre.Clear();
            txtApePat.Clear();
            txtApeMat.Clear();
            txtNombre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (dgv1.Rows.Count > 0)
                {
                    dgv1.Rows[0].Selected = true;
                    dgv1.Focus();
                }
                else
                {
                    txtNombre.Focus();
                }
            }
        }

        private void dgv1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                idenviar = Convert.ToInt32(dgv1.SelectedRows[0].Cells[0].Value);//.ToString();
                btnEditar.PerformClick();
            }
        }

        private void txtnumcte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (dgv1.Rows.Count > 0)
                {
                    dgv1.Rows[0].Selected = true;
                    dgv1.Focus();
                }
                else
                {
                    txtNombre.Focus();
                }
            }
        }

    }
}
