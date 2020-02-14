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
    public partial class FrmBitacora : Form
    {
        OdbcConnection conn = new OdbcConnection("Dsn=migracion");
        string user;
        public FrmBitacora(string usuario)
        {
            InitializeComponent();
            user = usuario;
            llenartbl();
            LblUsuario.Text = user;
        }
        void llenartbl()
        {
            //codigo para llevar el DataGridView
            OdbcCommand cod = new OdbcCommand();
            cod.Connection = conn;
            cod.CommandText = ("select * from bitacora ");
            try
            {
                OdbcDataAdapter eje = new OdbcDataAdapter();
                eje.SelectCommand = cod;
                DataTable datos = new DataTable();
                eje.Fill(datos);
                dataGridView1.DataSource = datos;
                eje.Update(datos);
                conn.Close();

            }
            catch (Exception e)
            {

                MessageBox.Show("ERROR" + e.ToString());
                conn.Close();
            }

        }
        private void FrmBitacora_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMenu nuevo = new FrmMenu(user);
            nuevo.Show();
        }
    }
}
