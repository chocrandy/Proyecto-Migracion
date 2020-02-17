using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using System.IO;
using System.Net;
using System.Threading;

namespace Migración
{
    public partial class FrmMenuPrincipal : Form
    {       
        OdbcConnection conn = new OdbcConnection("Dsn=migracion");
        DateTime hoy = DateTime.Now;
        string user;
        string fechahora;
        public FrmMenuPrincipal(string usuario)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            user = usuario;
            LblUsuario.Text = user;
            fechahora = hoy.ToString("yyyy/MM/dd HH:mm:ss");
            Bitacora();
        }

        private void solicitudesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmSolictudes entrar = new FrmSolictudes(user);
            entrar.Visible = true;
            Visible = false;
        }
        void Bitacora()
        {

            conn.Close();

            string query = "INSERT INTO `bitacora` (`id_bitacora`, `accion`, `fecha_accion`, `id_usuario`) VALUES (NULL, 'Ingreso al menu', '" + fechahora + "', '" + user + "');";

            conn.Open();
            OdbcCommand consulta = new OdbcCommand(query, conn);

            try
            {
                consulta.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("\t Error! \n\n " + ex.ToString());
                conn.Close();
            }
        }

        private void pesonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmEmpleado nuevo = new FrmEmpleado(user);
            nuevo.Show();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmUsuario nuevo = new FrmUsuario(user);
            nuevo.Show();
        }


        private void citaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmCitasV nuevo = new FrmCitasV(user);
            nuevo.Show();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmBitacora nuevo = new FrmBitacora(user);
            nuevo.Show();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
