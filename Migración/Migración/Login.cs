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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LblContraseña_Click(object sender, EventArgs e)
        {

        }

        private void LblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void BtIngresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMenu nuevo = new FrmMenu();
            nuevo.Show();
        }

        private void BtCalcelar_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
