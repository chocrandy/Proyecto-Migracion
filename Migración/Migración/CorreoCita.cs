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
        //Conexion con base de datos Google
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
            fechahora = hoy.ToString("yyyy/MM/dd HH:mm:ss");
        }
        //Proceso de envio
        private void button2_Click(object sender, EventArgs e)
        {
            Bitacora();
            string usu = "riskogt6@gmail.com";
            string pass = "Risgt657";
           c.enviarCorreo(usu, pass, TxtMensaje.Text, TxtAsunto.Text, TxtReceptor.Text, TxtRutaArchivo.Text);
              this.Hide();
            FrmMenu nuevo = new FrmMenu(user);
            nuevo.Show();
        }
        //Bitacora
        void Bitacora()
        {
            conn.Close();
            string query = "INSERT INTO `bitacora` (`id_bitacora`, `accion`, `fecha_accion`, `id_usuario`) VALUES (NULL, 'Se Genero Correo de Citacion', '" + fechahora + "', '" + user + "');";
            conn.Open();
            OdbcCommand consulta = new OdbcCommand(query, conn);
            try
            {
                consulta.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("\t Error Bitacora! \n\n " + ex.ToString());
                conn.Close();
            }
        }
        //Carga de archivo
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
        private void FrmCorreoCita_Load(object sender, EventArgs e)
        {

        }
    }
}
