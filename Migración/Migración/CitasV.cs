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
    public partial class FrmCitasV : Form
    {
        OdbcConnection conn = new OdbcConnection("Dsn=migracion");
        /*Generador de Fecha*/
        DateTime hoy = DateTime.Now;
        string fechahora;
        string user;
        public FrmCitasV(string usuario)
        {
            InitializeComponent();            
            user = usuario;
            fechahora = hoy.ToString("yyyy/MM/dd HH:mm:ss");
            llenartbl();
            DTimerCita.Format = DateTimePickerFormat.Custom;
            DTimerCita.CustomFormat = "yyyy/MM/dd HH:mm:ss";


        }
        /*Funcion para optener los datos para Verificar*/
        void llenartbl()
        {
            //codigo para llevar el DataGridView
            OdbcCommand cod = new OdbcCommand();
            cod.Connection = conn;
            cod.CommandText = ("SELECT `id_cita`, `id_verificacion`, `cui`, `fecha_cita` from citas where estado =1");
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
        void Bitacora()
        {
            conn.Close();
            string query = "INSERT INTO `bitacora` (`id_bitacora`, `accion`, `fecha_accion`, `id_usuario`) VALUES (NULL, 'Se elimino una cita', '" + fechahora + "', '" + user + "');";
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
        void BorrarC()
        {
            conn.Close();
            string query = "UPDATE `citas` SET `estado` = '0' WHERE `citas`.`id_cita` = " + TxtNOC.Text;
            conn.Open();
            OdbcCommand consulta = new OdbcCommand(query, conn);
            try
            {
                consulta.ExecuteNonQuery();
                MessageBox.Show("La cita se elimino Corectamente");
                conn.Close();
                llenartbl();
            }
            catch (Exception ex)
            {
                MessageBox.Show("\t ErrorBorrar! \n\n " + ex.ToString());
                conn.Close();
            }
        }
        void Modificar()
        {
            conn.Close();
            string query = "UPDATE `citas` SET `fecha_cita` = '"+DTimerCita.Text+"' WHERE `citas`.`id_cita` =" + TxtNOC.Text;
            conn.Open();
            OdbcCommand consulta = new OdbcCommand(query, conn);
            try
            {
                consulta.ExecuteNonQuery();
                conn.Close();
                llenartbl();
            }
            catch (Exception ex)
            {
                MessageBox.Show("\t Error! \n\n " + ex.ToString());
                conn.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Modificar();
            llenartbl();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmCitasV_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TxtNOC.Text = "";
            TxtCui.Text = "";
            TxtNumeroV.Text = "";
            BorrarC();
            Bitacora();
            llenartbl();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
               TxtNOC.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
               TxtNumeroV.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
               TxtCui.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
               DTimerCita.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("No hay Datos");
            }
        }

        private void FrmCitasV_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }
    }
}
