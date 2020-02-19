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
    public partial class MDI : Form
    {
        OdbcConnection conn = new OdbcConnection("Dsn=migracion");
        string user;
        public MDI(string usuario)
        {
            InitializeComponent();
            user = usuario;
            permisos();
            toolStripStatusLbUser.Text = usuario;
        }

        void permisos()
        {
            try
            {
                OdbcCommand cod = new OdbcCommand();
                cod.Connection = conn;
                cod.CommandText = ("SELECT `empleados`.`puesto` FROM `usuarios`, `empleados` WHERE " +
                            "`usuarios`.`id_usuario` = '" + user + "' AND " +
                            "`usuarios`.`id_empleado` = `empleados`.`id_empleado` AND" +
                            "`usuarios`.`estado`= 1;");
                try
                {
                    //ejecutamos el Query
                    OdbcDataAdapter eje = new OdbcDataAdapter();
                    eje.SelectCommand = cod;
                    //Obtenemos datos
                    DataTable datos = new DataTable();
                    eje.Fill(datos);
                    //Si tiene Operador va bloquear los botones siguientes
                    if (datos.Rows.Count == 1)
                    {
                        if (datos.Rows[0][0].ToString() == "Operador")
                        {
                            administraciónToolStripMenuItem.Enabled = false;
                            bitácoraToolStripMenuItem.Enabled = false;
                        }

                    } //En caso contrario, es Administrador
                    else
                    {
                        MessageBox.Show("Error al obtener Permisos", "PERMISOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al ejecutar Query de Permisos.", "PERMISOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error al Asignar Permisos.", "PERMISOS", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                conn.Close();
            }
        }

        private void PersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmpleado nuevo = new FrmEmpleado(user);
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario nuevo = new FrmUsuario(user);
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void SolicitudesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSolictudes nuevo = new FrmSolictudes(user);
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void CitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCitasV nuevo = new FrmCitasV(user);
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void BitácoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBitacora nuevo = new FrmBitacora(user);
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void MDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            FrmLogin nuevo = new FrmLogin();            
            nuevo.Show();
        }

        private void MDI_Load(object sender, EventArgs e)
        {

        }

        private void CerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin nuevo = new FrmLogin();
            nuevo.Show();
        }
    }
}
