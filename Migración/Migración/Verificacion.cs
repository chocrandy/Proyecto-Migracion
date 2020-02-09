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
    
    public partial class FrmVerificacion : Form
    {/*Conexion a la base de datos Google Cloud*/
        OdbcConnection conn = new OdbcConnection("Dsn=migracion");

        string solicitud;
        string Tramite;
        public FrmVerificacion(string dato,string tipo)
        {

            InitializeComponent();
           solicitud = dato;
            llenartbl();
            Tramite = tipo;
            TxtTra.Text = Tramite;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmCita nuevo = new FrmCita();
            nuevo.Show();
        }
        void llenartbl()
        {
            //codigo para llevar el DataGridView
            OdbcCommand cod = new OdbcCommand();
            cod.Connection = conn;
            cod.CommandText = ("select id_documento, nombre_documento, no_documento from documentos " +
                "where estado=1");
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
        

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                TxtNoD.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                TxtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                TxtNoDD.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                llenarBan();
                /* if (TxtNombre.Text == "Boleto de Ornato")
                 {
                     llenarMun();
                 }
                 else if(TxtNombre.Text == "Boleta de Pago") { 

                     llenarBan(); 
                 }*/



            }
            else
            {
                MessageBox.Show("No hay solicitudes");

            }
        }
        void llenarMun()
        {
            //codigo para llevar el DataGridView
            OdbcCommand cod = new OdbcCommand();
            cod.Connection = conn;
            /*  cod.CommandText = ("select Correlativo_ornato,fecha_vencimiento,Monto from municipalidad " +
                      "where correlativo_ornato =" + TxtNoDD.Text);*/
            cod.CommandText = ("select referencia_boleto,Fecha_pago,monto from banrural" +
            "where referencia_boleto =" + TxtNoDD.Text);
            try
            {
                OdbcDataAdapter eje = new OdbcDataAdapter();
                eje.SelectCommand = cod;
                DataTable datos = new DataTable();
                eje.Fill(datos);
                dataGridView2.DataSource = datos;
                eje.Update(datos);
                conn.Close();
               /* TxtCuiR.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                TxtNombres.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                TxtApellido.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                TxtFechaN.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                TxtSexo.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                TxtLugarN.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                TxtCuiRP.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                TxtCuiPM.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();

                BtnRecha.Enabled = false;
                BtnSig.Enabled = true;
                LblProgreso.Text = "Aprobado";*/

            }
            catch (Exception e)
            {


                MessageBox.Show("!ERROR! El Numero de DPI es Incorecto");
                e.ToString();
                conn.Close();
               /* BtnRecha.Enabled = true;
                BtnSig.Enabled = false;
                LblProgreso.Text = "Rechazado";*/
            }
        }

        void llenarBan()
        {
            //codigo para llevar el DataGridView
            OdbcCommand cod = new OdbcCommand();
            cod.Connection = conn;
            cod.CommandText = ("select referencia_boleto,fecha_pago,monto from banrural" +
                    "where referencia_boleto =" + TxtNoDD.Text);
            try
            {
                OdbcDataAdapter eje = new OdbcDataAdapter();
                eje.SelectCommand = cod;
                DataTable datos = new DataTable();
                eje.Fill(datos);
                dataGridView2.DataSource = datos;
                eje.Update(datos);
                conn.Close();
                /* TxtCuiR.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                 TxtNombres.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                 TxtApellido.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                 TxtFechaN.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                 TxtSexo.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                 TxtLugarN.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                 TxtCuiRP.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                 TxtCuiPM.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();

                 BtnRecha.Enabled = false;
                 BtnSig.Enabled = true;
                 LblProgreso.Text = "Aprobado";*/

            }
            catch (Exception e)
            {


                MessageBox.Show("!ERROR! El Numero de DPI es Incorecto");
                e.ToString();
                conn.Close();
                /* BtnRecha.Enabled = true;
                 BtnSig.Enabled = false;
                 LblProgreso.Text = "Rechazado";*/
            }
        }
        void llenarRenapP()
        {
            //codigo para llevar el DataGridView
            OdbcCommand cod = new OdbcCommand();
            cod.Connection = conn;
            cod.CommandText = ("select Cui,Nombres,Apellidos,Cui_padre from renap " +
                    "where cui_padre=" + TxtNoDD.Text);
            try
            {
                OdbcDataAdapter eje = new OdbcDataAdapter();
                eje.SelectCommand = cod;
                DataTable datos = new DataTable();
                eje.Fill(datos);
                dataGridView2.DataSource = datos;
                eje.Update(datos);
                conn.Close();
              /*  TxtCuiR.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                TxtNombres.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                TxtApellido.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                TxtFechaN.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                TxtSexo.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                TxtLugarN.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                TxtCuiRP.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                TxtCuiPM.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();

                BtnRecha.Enabled = false;
                BtnSig.Enabled = true;
                LblProgreso.Text = "Aprobado";*/

            }
            catch (Exception e)
            {


                MessageBox.Show("!ERROR! El Numero de DPI es Incorecto");
                e.ToString();
                conn.Close();
               /* BtnRecha.Enabled = true;
                BtnSig.Enabled = false;
                LblProgreso.Text = "Rechazado";*/
            }
        }
        void llenarRenapM()
        {
            //codigo para llevar el DataGridView
            OdbcCommand cod = new OdbcCommand();
            cod.Connection = conn;
            cod.CommandText = ("select Cui,Nombres,Apellidos,Cui_Madre from renap " +
                    "where cui_madre=" + TxtNoDD.Text);
            try
            {
                OdbcDataAdapter eje = new OdbcDataAdapter();
                eje.SelectCommand = cod;
                DataTable datos = new DataTable();
                eje.Fill(datos);
                dataGridView2.DataSource = datos;
                eje.Update(datos);
                conn.Close();
                /*  TxtCuiR.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                  TxtNombres.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                  TxtApellido.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                  TxtFechaN.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                  TxtSexo.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                  TxtLugarN.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                  TxtCuiRP.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                  TxtCuiPM.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();

                  BtnRecha.Enabled = false;
                  BtnSig.Enabled = true;
                  LblProgreso.Text = "Aprobado";*/

            }
            catch (Exception e)
            {


                MessageBox.Show("!ERROR! El Numero de DPI es Incorecto");
                e.ToString();
                conn.Close();
                /* BtnRecha.Enabled = true;
                 BtnSig.Enabled = false;
                 LblProgreso.Text = "Rechazado";*/
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmVerificacion_Load(object sender, EventArgs e)
        {

        }
    }
}
