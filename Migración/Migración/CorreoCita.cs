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
    public partial class FrmCorreoCita : Form
    {
        OdbcConnection conn = new OdbcConnection("Dsn=migracion");
        DateTime hoy = DateTime.Now;
        string fechahora;
        string correo;
        string solicitud;
        string user;
        Correo c = new Correo();
        public FrmCorreoCita(string dato, string verifi, string usuario)
        {
            InitializeComponent();
            correo = dato;
            solicitud = verifi;
            user = usuario;
            TxtReceptor.Text = correo;
            TxtAsunto.Text = "Notificacion de Migracion sobre solicitud de Pasaporte Aprobada";
        }

        private void button2_Click(object sender, EventArgs e)
        {
           string usu = "riskogt6@gmail.com";
            string pass = "Risgt657";
           c.enviarCorreo(usu, pass, TxtMensaje.Text, TxtAsunto.Text, TxtReceptor.Text, TxtRutaArchivo.Text);
            Bitacora();
            this.Hide();
            FrmMenu nuevo = new FrmMenu(user);
      
            nuevo.Show();
        }
        void Bitacora()
        {

            conn.Close();
            
            string query = "INSERT INTO `bitacora` (`id_bitacora`, `accion`, `fecha_accion`, `id_usuario`) VALUES (NULL, 'Se envio un Correo de Notificacion ', '" + fechahora + "', '" + user + "');";

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

        private void CorreoCita_Load(object sender, EventArgs e)
        {

        }
    }
}
