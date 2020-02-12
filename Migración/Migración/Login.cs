using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migración
{
   
    public partial class FrmLogin : Form
    {
        string usuario;
        OdbcConnection conn = new OdbcConnection("Dsn=migracion");
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LblContraseña_Click(object sender, EventArgs e)
        {

        }

        private void LblUsuario_Click(object sender, EventArgs e)
        {

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
                        FrmMenu nuevo = new FrmMenu(usuario);
                        nuevo.Show();
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
                    conn.Close();
                }

            }
            catch (Exception eex)
            {
                MessageBox.Show("Usuario y/o Contraseña Incorrecta", "DATOS INCORRECTOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtCalcelar_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
