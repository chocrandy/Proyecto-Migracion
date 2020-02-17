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
    public partial class FrmEmpleado : Form
    {
        OdbcConnection conn = new OdbcConnection("Dsn=migracion");
        DateTime hoy = DateTime.Now;
        string fechahora;
        string user;
        public FrmEmpleado(string usuario)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            user = usuario;
            fechahora = hoy.ToString("yyyy/MM/dd HH:mm:ss");
            llenartbl();
        }
        void Borrar()
        {
            string query = "UPDATE `empleados` SET `estado` = '0' WHERE `empleados`.`id_empleado` = "+TxtNoEM.Text+"; ";
            conn.Open();
            OdbcCommand consulta = new OdbcCommand(query, conn);
            try
            {
                consulta.ExecuteNonQuery();
                llenartbl();
            }
            catch (Exception ex)
            {
                MessageBox.Show("\t Error! \n\n " + ex.ToString());
                conn.Close();
            }
        }

        void Modificar()
        {
            string query = "UPDATE `empleados` SET `nombres` = '"+TxtNombres.Text+"', `apellidos` = '"+TxtApellidos.Text+ "', `fecha_nacimiento` = '"+DataFecha.Text+ "', `telefono` = '"+TxtTelefono.Text+ "', `correo` = '"+TxtCorreo.Text+ "', `puesto` = '"+TxtPuesto.Text+"' WHERE `empleados`.`id_empleado` = " + TxtNoEM.Text+";" ;

            conn.Open();
            OdbcCommand consulta = new OdbcCommand(query, conn);
            try
            {
                consulta.ExecuteNonQuery();
                llenartbl();
            }
            catch (Exception ex)
            {
                MessageBox.Show("\t Error! \n\n " + ex.ToString());
                conn.Close();
            }
        }
        
        void Insertar()
        {
            conn.Close();
            string query = "INSERT INTO `empleados` (`id_empleado`, `nombres`, `apellidos`, `fecha_nacimiento`, `sexo`, `telefono`, `correo`, `puesto`, `estado`) VALUES (NULL, '"+TxtNombres.Text+"', '"+TxtApellidos.Text+"', '"+DataFecha.Text+"', '"+TxtSexo.Text+"', '"+TxtTelefono.Text+"', '"+TxtCorreo.Text+"', '"+TxtPuesto.Text+"', '1')";

            conn.Open();
            OdbcCommand consulta = new OdbcCommand(query, conn);
            try
            {
                consulta.ExecuteNonQuery();
                MessageBox.Show("El Empleado se Registro Corectamente");
                llenartbl(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("\t Error! \n\n " + ex.ToString());
                conn.Close();
            }
        }
        void Bitaciora()
        {
            conn.Close();

            string query = "INSERT INTO `bitacora` (`id_bitacora`, `accion`, `fecha_accion`, `id_usuario`) VALUES (NULL, 'Se Registro a un Empleado nuevo', '" + fechahora + "', '" + user + "');";

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

        void llenartbl()
        {
            //codigo para llevar el DataGridView
            OdbcCommand cod = new OdbcCommand();
            cod.Connection = conn;
            cod.CommandText = ("SELECT `id_empleado`, `nombres`, `apellidos`, `fecha_nacimiento`, `sexo`, `telefono`, `correo`, `puesto` FROM empleados WHERE estado=1");
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

        private void button3_Click(object sender, EventArgs e)
        {
            Insertar();
            TxtNoEM.Text = "";
            TxtNombres.Text = "";
            TxtApellidos.Text = "";
            DataFecha.Text = "";
            TxtSexo.Text = "";
            TxtTelefono.Text = "";
            TxtCorreo.Text = "";
            TxtPuesto.Text = "";
            llenartbl();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                TxtNoEM.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                TxtNombres.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                TxtApellidos.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                DataFecha .Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                TxtSexo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                TxtTelefono.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                TxtCorreo.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                TxtPuesto.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();               
            }
            else
            {
                MessageBox.Show("No hay solicitudes");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Borrar();
            
            TxtNoEM.Text = "";
            TxtNombres.Text = "";
            TxtApellidos.Text = "";
            DataFecha.Text = "";
            TxtSexo.Text = "";
            TxtTelefono.Text = "";
            TxtCorreo.Text = "";
            TxtPuesto.Text = "";
            llenartbl();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Modificar();
            llenartbl();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmMenu entrar = new FrmMenu(user);
            entrar.Visible = true;
            Visible = false;
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmEmpleado_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMenu entrar = new FrmMenu(user);
            entrar.Visible = true;
            Visible = false;
        }
    }
}
