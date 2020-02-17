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
    public partial class FrmCorreoRe : Form
    {
        //Conexion a la base de datos google cloud
        OdbcConnection conn = new OdbcConnection("Dsn=migracion");
        DateTime hoy = DateTime.Now;
        string fechahora;
        string correo;
        string solicitud;
        string user;
        Correo c = new Correo();

        public FrmCorreoRe(string dato ,string verifi , string usuario)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            correo = dato;
            solicitud = verifi;
            user = usuario;
            TxtReceptor.Text = correo;
           TxtAsunto.Text = "Notificacion de Migracion sobre solicitud de Pasaporte Rechazada";
            fechahora = hoy.ToString("yyyy/MM/dd HH:mm:ss");
        }

        //Bitacora
        void Bitacora()
        {
            conn.Close();
            string query = "INSERT INTO `bitacora` (`id_bitacora`, `accion`, `fecha_accion`, `id_usuario`) VALUES (NULL, 'Envio de mensaje de cancelacion', '" + fechahora + "', '" + user + "');";
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
        //Envio de correo
        private void button2_Click(object sender, EventArgs e)
        {
            string usu = "riskogt6@gmail.com";
            string pass = "Risgt657";
            c.enviarCorreo(usu, pass, TxtMensaje.Text, TxtAsunto.Text, TxtReceptor.Text, TxtRutaArchivo.Text);        
                string query = "UPDATE solicitudes set estado = 0  where  id_solicitud  =" + solicitud ;
                conn.Open();
                OdbcCommand consulta = new OdbcCommand(query, conn);
                try
                {
                    consulta.ExecuteNonQuery();  
                    MessageBox.Show("La Slolicitud fue calcelada exitosa mente");

                Bitacora();
                    conn.Close();
                this.Hide();
                FrmMenu nuevo = new FrmMenu(user);
                nuevo.Show();
            }
                catch (Exception ex)
                {
                    MessageBox.Show("\t Error! \n\n " + ex.ToString());
                    conn.Close();
                }
        }
        //Validacion sobre el archivo a enviar
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

        private void FrmCorreoRe_Load(object sender, EventArgs e)
        {

        }

        private void FrmCorreoRe_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMenu entrar = new FrmMenu(user);
            entrar.Visible = true;
            Visible = false;
        }
    }
}
