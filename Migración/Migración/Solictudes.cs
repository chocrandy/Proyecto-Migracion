﻿using System;
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
    public partial class FrmSolictudes : Form
    {
        /*Conexion a la base de datos Google Cloud*/
        OdbcConnection conn = new OdbcConnection("Dsn=migracion");
        DateTime hoy = DateTime.Now;
        string fechahora;
        string solicitud;
        string TTramite;
        string correo;
        string user;
        string Cui;
        public FrmSolictudes(string usuario)
        {
            InitializeComponent();
            /*Carga de la tabla solicitudes*/
            this.WindowState = FormWindowState.Maximized;
            user = usuario;
            LblUsuario.Text = user;
            fechahora = hoy.ToString("yyyy/MM/dd HH:mm:ss");
            llenartbl();
              }

        /*Funcion para llenar las tablas de solicitudes*/
        void llenartbl()
        {
            //codigo para llevar el DataGridView
            OdbcCommand cod = new OdbcCommand();
            cod.Connection = conn;
            cod.CommandText = ("SELECT id_solicitud,cui,tipo_solicitud,fecha_solicitud,correo FROM solicitudes " +
                "WHERE estado=1");
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
        /*llenado y verificación de tabla DPI*/
        void llenartblR()
        {
            //codigo para llevar el DataGridView
            OdbcCommand cod = new OdbcCommand();
            cod.Connection = conn;
            cod.CommandText = ("select Cui,Nombres,Apellidos,Fecha_Nacimiento,Sexo,Lugar_Nacimiento,Cui_padre,Cui_Madre from renap " +
                    "where Cui=" + TxtCui.Text);
            try
            {
                OdbcDataAdapter eje = new OdbcDataAdapter();
                eje.SelectCommand = cod;
                DataTable datos = new DataTable();
                eje.Fill(datos);
                dataGridView2.DataSource = datos;
                eje.Update(datos);
                conn.Close();
                TxtCuiR.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                PicUser.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                TxtApellido.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                TxtFechaN.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                TxtSexo.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                TxtLugarN.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                TxtCuiRP.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                TxtCuiPM.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
              
                BtnRecha.Enabled = false;
                BtnSig.Enabled = true;
                LblProgreso.Text = "Aprobado";
               
            }
            catch (Exception e)
            {
                MessageBox.Show("!ERROR! El Numero de DPI es Incorecto" );
                e.ToString();
                conn.Close();
                BtnRecha.Enabled = true;
                BtnSig.Enabled = false;
                LblProgreso.Text = "Rechazado";
            }
        }
        /*Opcion de seleccion de de solicitudes*/
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            TxtCuiR.Text = "";
            PicUser.Text = "";
            TxtApellido.Text = "";
            TxtCuiR.Text = "";
            TxtFechaN.Text = "";
            TxtSexo.Text = "";
            TxtLugarN.Text = "";
            TxtCuiRP.Text = "";
            TxtCuiPM.Text = "";
            if (dataGridView1.SelectedRows.Count == 1)
            {
                TxtSolicitud.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                solicitud= dataGridView1.CurrentRow.Cells[0].Value.ToString();
                TxtCui.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                Cui = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                TxtTramite.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                TTramite = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                TxtFecha.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                TxtCorreo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                correo = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                llenartblR();

              }
            else
            {
                MessageBox.Show("No hay solicitudes");
                BtnRecha.Enabled = true;
            }
           }

        private void BtnSig_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bitacora();
            LblCuipP nuevo = new LblCuipP(solicitud ,TTramite,user,correo,Cui);
            nuevo.Show();
        }
        void Bitacora()
        {
            conn.Close();
            string query = "INSERT INTO `bitacora` (`id_bitacora`, `accion`, `fecha_accion`, `id_usuario`) VALUES (NULL, 'verifiacion de DPI de una solicitud ', '"+ fechahora + "', '"+ user + "');";
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
        //Bitacora
        void BitacoraA()
        {
            conn.Close();
            string query = "INSERT INTO `bitacora` (`id_bitacora`, `accion`, `fecha_accion`, `id_usuario`) VALUES (NULL, 'Canselacion de solicitud', '" + fechahora + "', '" + user + "');";
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
     
        private void BtnRecha_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmCorreoRe nuevo = new FrmCorreoRe(correo, solicitud,user);
            nuevo.Show();
        }
        //Rechazo de solicitud
        private void BtnCancelar_Click(object sender, EventArgs e)
        {                        
            BitacoraA();
            TxtCuiR.Text = "";
            PicUser.Text = "";
            TxtApellido.Text = "";
            TxtCuiR.Text = "";
            TxtFechaN.Text = "";
            TxtSexo.Text = "";
            TxtLugarN.Text = "";
            TxtCuiRP.Text = "";
            TxtCuiPM.Text = "";
            TxtSolicitud.Text = "";
            TxtCui.Text = "";
            TxtTramite.Text = "";
            TxtFecha.Text = "";
            TxtCorreo.Text = "";
            this.Hide();
        }

        private void FrmSolictudes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void FrmSolictudes_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, " Migracion ayuda/AyudaM.chm", "Verificaciones.html");
        }
    }
}
