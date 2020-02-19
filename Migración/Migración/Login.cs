using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migración
{
   
    public partial class FrmLogin : Form
    {       /*Generador de Fecha*/
        DateTime hoy = DateTime.Now;
        string fechahora;
        string usuario;
        OdbcConnection conn = new OdbcConnection("Dsn=migracion");
        public FrmLogin()
        {
            InitializeComponent();
            fechahora = hoy.ToString("yyyy/MM/dd HH:mm:ss");
        }       

        private void BtIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                //variables para Log In
                int pass;
                usuario = TxtUsuario.Text;
                pass = Int32.Parse(TxtContraseña.Text);              
                //Query para Log In
                OdbcCommand cod = new OdbcCommand();
                cod.Connection = conn;
                cod.CommandText = ("SELECT * FROM usuarios WHERE `id_usuario`= '" + usuario + "' AND `password`=" + pass + " AND `estado`= 1; ");                
                try
                {
                    //ejecutamos el Query
                    OdbcDataAdapter eje = new OdbcDataAdapter();
                    eje.SelectCommand = cod;
                    //Obtenemos datos
                    DataTable datos = new DataTable();
                    eje.Fill(datos);
                    //Si tiene resultados muestra la siguiente ventaja
                    if (datos.Rows.Count == 1)
                    {
                        this.Hide();
                        //if (datos.Rows[0][0].ToString() == )                              
                        MDI nuevo = new MDI(usuario);
                        nuevo.Show();                        
                        Bitacora();
                    } //En caso contrario, el usuario y/o contraseña no existe!
                    else
                    {
                        MessageBox.Show("Usuario y/o Contraseña Incorrecta", "DATOS INCORRECTOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Usuario y/o Contraseña Incorrecta", "DATOS INCORRECTOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Cerramos la conexión a la BD
                    ex.ToString();
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Usuario y/o Contraseña Incorrecta", "DATOS INCORRECTOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ex.ToString();
            }
        }

        private void BtCalcelar_Click(object sender, EventArgs e)
        {            
            Application.ExitThread();
        }
        //Bitacora para control del sistema 
        void Bitacora()
        {
            conn.Close();
            string query = "INSERT INTO `bitacora` (`id_bitacora`, `accion`, `fecha_accion`, `id_usuario`) VALUES (NULL, 'Inicio seccion al Sistema', '" + fechahora + "', '" + TxtUsuario.Text + "');";
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
        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
