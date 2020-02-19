using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migración
{
    public partial class MDI : Form
    {
        string user;
        public MDI(string usuario)
        {
            InitializeComponent();
            user = usuario;
            toolStripStatusLbUser.Text = usuario;
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
