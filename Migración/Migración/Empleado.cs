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
        string fecha;
        public FrmEmpleado(string usuario)
        {
            InitializeComponent();            
            //this.WindowState = FormWindowState.Maximized;
            user = usuario;
            lbUser.Text = usuario;
            fechahora = hoy.ToString("yyyy/MM/dd HH:mm:ss");            
            llenartbl();
        }
        void Borrar()
        {          
            string query = "UPDATE `empleados` SET `estado`= 0 WHERE `id_empleado`=" + TxtNoEM.Text +";";
            conn.Open();
            OdbcCommand consulta = new OdbcCommand(query, conn);
            try
            {
                consulta.ExecuteNonQuery();
                llenartbl();
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione un Registro!", "EMPLEADOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
        }

        void Modificar()
        {
            fecha = DataFecha.Value.ToString("dd/MM/yyyy");            
            string query = "UPDATE `empleados` SET `nombres`= '" + TxtNombres.Text + "', `apellidos`= '" + TxtApellidos.Text + "', " +
                "`fecha_nacimiento`='" + txtFaux.Text + "',`sexo`='" + comboSexo.SelectedItem.ToString() + 
                "',`telefono`=" + TxtTelefono.Text + ",`correo`='" + TxtCorreo.Text + "', `puesto`='" + comboPuesto.SelectedItem.ToString() + 
                "',`estado`=1 WHERE `id_empleado`=" + TxtNoEM.Text + ";";
            conn.Open();
            OdbcCommand consulta = new OdbcCommand(query, conn);
            try
            {                
                consulta.ExecuteNonQuery();
                MessageBox.Show("El Registro se modifico correctamente" );
                llenartbl();
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione un Registro!", "EMPLEADOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
        }
        
        void Insertar()
        {
            conn.Close();
            string query = "INSERT INTO `empleados` (`nombres`, `apellidos`, `fecha_nacimiento`, `sexo`, `telefono`, `correo`, `puesto`, `estado`) " +
                "VALUES ('" + TxtNombres.Text + "', '" + TxtApellidos.Text + "', '" + txtFaux.Text + "', '" + comboSexo.SelectedItem.ToString() + "', " + 
                "" + TxtTelefono.Text + ", '" + TxtCorreo.Text + "', '" + comboPuesto.SelectedItem.ToString() + "', 1);";

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

        void bitacora()
        {
            conn.Close();
            string query = "INSERT INTO `bitacora` (`id_bitacora`, `accion`, `fecha_accion`, `id_usuario`) VALUES (NULL, 'Se Registro un Empleado Nuevo', '" + fechahora + "', '" + user + "');";
            conn.Open();
            OdbcCommand consulta = new OdbcCommand(query, conn);
            try
            {
                consulta.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al Ingresar Registro en Bitácora!", "EMPLEADOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conn.Close();
            }
        }

        void llenartbl()
        {
            //codigo para llenar el DataGridView
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
            catch (Exception)
            {
                MessageBox.Show("Error al Llenar Lista!", "EMPLEADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Insertar();
            TxtNoEM.Text = "";
            TxtNombres.Text = "";
            TxtApellidos.Text = "";
            txtFaux.Text = "";
            comboSexo.ResetText();
            comboPuesto.ResetText();
            TxtTelefono.Text = "";
            TxtCorreo.Text = "";            
            llenartbl();
        }
        
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                TxtNoEM.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                TxtNombres.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                TxtApellidos.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();                                
                DataFecha.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();                       
                comboSexo.SelectedItem = dataGridView1.CurrentRow.Cells[4].Value.ToString();                
                TxtTelefono.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                TxtCorreo.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();                     
                comboPuesto.SelectedItem = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un Registro!", "EMPLEADOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Borrar();
            
            TxtNoEM.Text = "";
            TxtNombres.Text = "";
            TxtApellidos.Text = "";
            txtFaux.Text = "";
            comboSexo.ResetText();
            comboPuesto.ResetText();
            TxtTelefono.Text = "";
            TxtCorreo.Text = "";
            DataFecha.ResetText();
            llenartbl();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Modificar();
            TxtNoEM.Text = "";
            TxtNombres.Text = "";
            TxtApellidos.Text = "";
            txtFaux.Text = "";
            comboSexo.ResetText();
            comboPuesto.ResetText();            
            TxtTelefono.Text = "";
            TxtCorreo.Text = "";
            DataFecha.ResetText();
            llenartbl();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
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
            this.Hide();
        }

        private void DataFecha_ValueChanged(object sender, EventArgs e)
        {
            txtFaux.Text = DataFecha.Value.ToString("yyyy/MM/dd");
        }

        private void TableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
