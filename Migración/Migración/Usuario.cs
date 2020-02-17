using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migración
{
    public partial class FrmUsuario : Form
    {
        OdbcConnection conn = new OdbcConnection("Dsn=migracion");
        CRUD listae = new CRUD();
        string user;
        public FrmUsuario(string usuario)
        {
            InitializeComponent();
            listae.obtenerLista(listEmpleado);
            llenartbl();
            user = usuario;
        }

        void llenartbl()
        {
            //codigo para llevar el DataGridViewUser
            OdbcCommand cod = new OdbcCommand();
            cod.Connection = conn;
            cod.CommandText = ("SELECT `id_usuario`, `password`, `id_empleado` FROM `usuarios` WHERE `estado`=1");
            try
            {
                OdbcDataAdapter eje = new OdbcDataAdapter();
                eje.SelectCommand = cod;
                DataTable datos = new DataTable();
                eje.Fill(datos);
                dataGridViewUser.DataSource = datos;
                eje.Update(datos);
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al Llenar Tabla! ", "USUARIOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conn.Close();
            }
        }

        void Insertar()
        {
            conn.Close();
            try
            {
                if (txtUser.Text != "" && txtPass.Text != "" && txtAux.Text != "")
                {
                    string query = "INSERT INTO `usuarios`(`id_usuario`, `password`, `id_empleado`, `estado`) VALUES " +
                        "('" + txtUser.Text + "', " + txtPass.Text + ", " + Int32.Parse(txtAux.Text) + ", 1)";
                    conn.Open();
                    OdbcCommand consulta = new OdbcCommand(query, conn);
                    try
                    {
                        consulta.ExecuteNonQuery();
                        MessageBox.Show("Usuario Registrado Corectamente");
                        llenartbl();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ya se registro un Empleado con el mismo Usuario!", "USUARIOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                      
                        conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Llene todos los campos", "USUARIOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al Insertar Usuario", "USUARIOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conn.Close();
            }
        }

        void Borrar()
        {
            string query = "UPDATE `usuarios` SET `estado`=0 WHERE `id_usuario`= '" + txtUser.Text + "';";
            conn.Open();
            OdbcCommand consulta = new OdbcCommand(query, conn);
            try
            {
                consulta.ExecuteNonQuery();
                llenartbl();
            }
            catch (Exception)
            {
                MessageBox.Show("Error Borrar Usuario", "USUARIOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conn.Close();
            }
        }

        void Modificar()
        {
            string query = "UPDATE `usuarios` SET `password`=" + txtPass.Text + 
                ",`id_empleado`=" + Int32.Parse(txtAux.Text) + ",`estado`=1 WHERE `id_usuario`='" + txtUser.Text +"';";
            conn.Open();
            OdbcCommand consulta = new OdbcCommand(query, conn);
            try
            {
                consulta.ExecuteNonQuery();
                llenartbl();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al Modificar Usuario", "USUARIOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conn.Close();
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            FrmMenuPrincipal entrar = new FrmMenuPrincipal(user);
            entrar.Visible = true;
            Visible = false;
        }

        private void ListEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //para guardar datos jaja
            String listaAux = listEmpleado.SelectedItem.ToString();
            txtAux.Text = listaAux;
            string[] numero = listaAux.Split(' ');
            try
            {
                int auxid = Int32.Parse(numero[0]);
                if (int.TryParse(auxid.ToString(), out auxid))
                {
                    txtAux.Text = auxid.ToString();
                }
                else
                {
                    txtAux.Text = "No es #";
                }
            }
            catch (Exception)
            {
                txtAux.Text = "Error";
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Insertar();
            txtUser.Text = "";
            txtPass.Text = "";
            txtAux.Text = "";
            llenartbl();

        }

        private void DataGridViewUser_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewUser.SelectedRows.Count == 1)
            {
                txtUser.Text = dataGridViewUser.CurrentRow.Cells[0].Value.ToString();
                txtPass.Text = dataGridViewUser.CurrentRow.Cells[1].Value.ToString();
                txtAux.Text = dataGridViewUser.CurrentRow.Cells[2].Value.ToString();
            }
            else
            {
                MessageBox.Show("Error al Seleccionar Registro!! \n\n Seleccione la flecha que esta al lado izquierdo del registro. ", "USUARIOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Borrar();
            txtUser.Text = "";
            txtPass.Text = "";
            txtAux.Text = "";
            llenartbl();
        }

        private void FrmUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMenuPrincipal entrar = new FrmMenuPrincipal(user);
            entrar.Visible = true;
            Visible = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Modificar();
            txtUser.Text = "";
            txtPass.Text = "";
            txtAux.Text = "";
            llenartbl();
        }
    }
}