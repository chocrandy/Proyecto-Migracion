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

namespace Migración
{
    public partial class FrmCita : Form
    {
        OdbcConnection conn = new OdbcConnection("Dsn=migracion");
        string user;
        string solicitud;
        string Cui;
        string Idveri;
        public FrmCita(string usuario, string numero,string cui)
        {
            InitializeComponent();
            user = usuario;
            solicitud = numero;
            Cui = cui;
            TxtCui.Text = Cui;
            //TxtNumeroV.Text = solicitud;
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmCita_Load(object sender, EventArgs e)
        {

        }
        void OPcita()
                {
            conn.Close();

            try
            {

                conn.Open();

                OdbcCommand command = new OdbcCommand("select id_verificacion from verificacion where id_solicitud=" + solicitud, conn);
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                 
                    TxtNumeroV.Text = reader.GetValue(0).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            OPcita();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMenu nuevo = new FrmMenu(user);
    
            nuevo.Show();
        }
    }
}
