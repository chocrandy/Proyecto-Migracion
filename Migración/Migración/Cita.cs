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
        DateTime hoy = DateTime.Now;
        string fechahora;
        string user;
        string solicitud;
        string Cui;
        string correo;
        string Idveri;
        public FrmCita(string usuario, string numero,string cui,string email)
        {
            InitializeComponent();
            user = usuario;
            solicitud = numero;
            TxtNumeroV.Text = solicitud;
            correo = email;
            Cui = cui;
            TxtCui.Text = Cui;
            fechahora = hoy.ToString("yyyy/MM/dd HH:mm:ss");
            TxtFecha.Text = fechahora;
          


        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }
        void Bitacora()
        {

            conn.Close();

            string query = "INSERT INTO `bitacora` (`id_bitacora`, `accion`, `fecha_accion`, `id_usuario`) VALUES (NULL, 'Se genero una cita  ', '" + fechahora + "', '" + user + "');";

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

        void Generarcita()
        {

            conn.Close();

            string query = "INSERT INTO `citas` (`id_cita`, `id_verificacion`, `cui`, `fecha_cita`, `estado`) VALUES (NULL, '"+ Idveri + "', '"+Cui+"', '" + fechahora + "', '1');";
              

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
        private void FrmCita_Load(object sender, EventArgs e)
        {

        }
        void OPcita()
                {
       

            try
            {

                conn.Open();

                OdbcCommand command = new OdbcCommand("select id_verificacion from verificacion where id_solicitud=" + solicitud, conn);
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Idveri = reader.GetValue(0).ToString();
                    LblEstado.Text = "Verificacion Validada";
                    BtnGenerar.Enabled = true;
                    BtnVerificar.Enabled = false;
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
            Bitacora();
            Generarcita();
            this.Hide();
           FrmCorreoCita nuevo = new FrmCorreoCita(correo ,solicitud, user);

            nuevo.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            FrmMenu nuevo = new FrmMenu(user);
           
            nuevo.Show();
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtNumeroV_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OPcita();
            
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
