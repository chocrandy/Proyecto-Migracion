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
    public partial class FrmMenu : Form
    {
        string user;
        public FrmMenu(string usuario)
        {
            InitializeComponent();
            user = usuario;
            LblUsuario.Text = user;
        }
        private void solicitudesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSolictudes nuevo = new  FrmSolictudes(user);
            nuevo.Show();
        }

        private void puestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmPuesto nuevo = new FrmPuesto();
            nuevo.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmUsuario nuevo = new FrmUsuario();
            nuevo.Show();
        }

        private void personalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmPersonal nuevo = new FrmPersonal();
            nuevo.Show();
        }

        private void citasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmCita nuevo = new FrmCita();
            nuevo.Show();

        }
    }
}
