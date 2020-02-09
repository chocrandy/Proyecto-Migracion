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
    public partial class FrmCorreoRe : Form
    {
        Correo c = new Correo();
        public FrmCorreoRe()
        {
            InitializeComponent();
        }

        private void CorreoRe_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string usu = "riskogt6@gmail.com";
            string pass = "Risgt657";
            c.enviarCorreo(usu, pass, TxtMensaje.Text, TxtAsunto.Text, TxtReceptor.Text, TxtRutaArchivo.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.openFileDialog1.ShowDialog();
                if (this.openFileDialog1.FileName.Equals("") == false)
                {
                    TxtRutaArchivo.Text = this.openFileDialog1.FileName;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la ruta del archivo: " + ex.ToString());
            }
        }
    }
}
