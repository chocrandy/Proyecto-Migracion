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
    public partial class FrmSolictudes : Form
    {
        public FrmSolictudes()
        {
            InitializeComponent();
        }

        private void BtSigiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmVerificacion nuevo = new FrmVerificacion();
            nuevo.Show();

        }
    }
}
