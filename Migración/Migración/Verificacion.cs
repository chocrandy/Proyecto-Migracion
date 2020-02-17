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
    public partial class LblCuipP : Form
    {/*Conexion a la base de datos Google Cloud*/
        OdbcConnection conn = new OdbcConnection("Dsn=migracion");
        /*Generador de Fecha*/
        DateTime hoy = DateTime.Now;
        string fechahora;
        string solicitud;
        string Tramite;
        string user;
        string correo;
        string Cui;
        public LblCuipP(string dato, string tipo, string usuario, string email, string cui)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            solicitud = dato;
            user = usuario;
            Cui = cui;
            correo = email;
            llenartbl();
            Tramite = tipo;
            TxtTra.Text = Tramite;
            visualizacion();
            BtnRechazar.Enabled = false;
            fechahora = hoy.ToString("yyyy/MM/dd HH:mm:ss");

        }

        private void button1_Click(object sender, EventArgs e)
        {/*Control de Citas*/
            this.Hide();
            FrmCita nuevo = new FrmCita(user, solicitud, Cui, correo);
            nuevo.Show();
        }
        /*Funcion para optener los datos para Verificar*/
        void llenartbl()
        {
            //codigo para llevar el DataGridView
            OdbcCommand cod = new OdbcCommand();
            cod.Connection = conn;
            cod.CommandText = ("select  nombre_documento, no_documento from documentos where id_solicitud=" + solicitud);
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
        /*Funcion que nos permite controlar los datos para la verificacion*/
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                TxtNombre.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                TxtNoDD.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                
               
                if (TxtNombre.Text == "Boleto de Ornato")
                { //llenarMun();
                    llenarMun();
                }
                else if (TxtNombre.Text == "Boleta de Pago")
                {
                    //llenarBan();
                    llenarBan();
                }
                else if (TxtNombre.Text == "DPI Padre" && Tramite == "Menor de Edad") { llenarRenapP(); }
                else if (TxtNombre.Text == "DPI Madre" && Tramite == "Menor de Edad") { llenarRenapM(); }
            }
            else
            {
                MessageBox.Show("No hay solicitudes");
            }
        }
        //opcion para verificar web service Municipalidad
        void llenarMun()
        {
            //codigo para llevar el DataGridView
            OdbcCommand cod = new OdbcCommand();
            cod.Connection = conn;
            cod.CommandText = ("select Correlativo_ornato,fecha_vencimiento,Monto from municipalidad where correlativo_ornato =" + TxtNoDD.Text);

            try
            {
                OdbcDataAdapter eje = new OdbcDataAdapter();
                eje.SelectCommand = cod;
                DataTable datos = new DataTable();
                eje.Fill(datos);
                dataGridView3.DataSource = datos;
                eje.Update(datos);
                conn.Close();
                TxtCoM.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                TxtfechaEM.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                TxtMontoB.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("!ERROR! No ecxiste boleto de pago ");
                BtnRechazar.Enabled = true;
                e.ToString();
                conn.Close();
            }
        }
        //Validaciones para control de tipo de tramite
        void visualizacion()
        {
            if (Tramite == "Mayor de Edad")
            {
                dataGridView2.Enabled = true;
                dataGridView3.Enabled = true;
                dataGridView4.Enabled = false;
                dataGridView5.Enabled = false;

            }
            else if (Tramite == "Menor de Edad")
            {
                dataGridView2.Enabled = true;
                dataGridView3.Enabled = true;
                dataGridView4.Enabled = true;
                dataGridView5.Enabled = true;
            }
            else if (Tramite == "Mayor de 60")
            {
                dataGridView2.Enabled = true;
                dataGridView3.Enabled = false;
                dataGridView4.Enabled = false;
                dataGridView5.Enabled = false;
            }
            else
            {
                MessageBox.Show("!ERROR! El tipo de tramite es incorecto");
            }
        }
        //Funcion para el control del web service del banco
        void llenarBan()
        {
            //codigo para llevar el DataGridView
            OdbcCommand cod = new OdbcCommand();
            cod.Connection = conn;
            //int auxi = Int32.Parse(TxtNoDD.Text);
            //Console.WriteLine("txtnodd= " + TxtNoDD.Text + "\n auxi= " + auxi);
            cod.CommandText = ("select * from banrural where referencia_boleto =" + TxtNoDD.Text);
            try
            {
                OdbcDataAdapter eje = new OdbcDataAdapter();
                eje.SelectCommand = cod;
                DataTable datos = new DataTable();
                eje.Fill(datos);
                dataGridView2.DataSource = datos;
                eje.Update(datos);
                conn.Close();
                TxtNoB.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                TxtFechaP.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                TxtMonto.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();

            }
            catch (Exception e)
            {
                MessageBox.Show("!ERROR!La boleta de pago no existe");
                BtnRechazar.Enabled = true;
                e.ToString();
                conn.Close();
            }
        }
        //Funcion para el web service de renap 
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
                dataGridView4.DataSource = datos;
                eje.Update(datos);
                conn.Close();
                TxtCuiP.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
                TxtNombreP.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
                TxtApellidoP.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
                TxtCuiPA.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception e)
            {
              MessageBox.Show("!ERROR! El Numero de DPI del Padre es Incorecto");
                BtnRechazar.Enabled = true;
                e.ToString();
                conn.Close();
            }
        }
        //Validaciones para optener datos de renap
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
                dataGridView5.DataSource = datos;
                eje.Update(datos);
                conn.Close();
                TxtCuiMA.Text = dataGridView5.CurrentRow.Cells[0].Value.ToString();
                TxtNombreMA.Text = dataGridView5.CurrentRow.Cells[1].Value.ToString();
                TxtApellidoMA.Text = dataGridView5.CurrentRow.Cells[2].Value.ToString();
                TxtCuiMAA.Text = dataGridView5.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("!ERROR! El Numero de DPI de la Madre es Incorecto");
                BtnRechazar.Enabled = true;
                e.ToString();
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmCorreoRe nuevo = new FrmCorreoRe(correo, solicitud, user);
            nuevo.Show();
        }
        //Validaciones para verificaciones
        void verificacion()
        {
            string query = "INSERT INTO `verificacion` (`id_verificacion`, `cui`, `id_usuario`, `fecha_verificacion`, `id_solicitud`) VALUES (NULL, "+ Cui + ", '" + user + "', '"+ fechahora + "', '"+ solicitud + "'); ";
           
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
        void guardarv()
        {
            conn.Close();
            string query = "UPDATE solicitudes set estado = 2  where  id_solicitud  =" + solicitud;
            conn.Open();
            OdbcCommand consulta = new OdbcCommand(query, conn);
            try
            {
                consulta.ExecuteNonQuery();
                conn.Close();     
            }
            catch (Exception ex)
            {
                MessageBox.Show("\t Error! \n\n " + ex.ToString());
                conn.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMenu nuevo = new FrmMenu(user);
            nuevo.Show();
        }
        //Bitacora para control del sistema 
        void Bitacora()
        {
            conn.Close();
            string query = "INSERT INTO `bitacora` (`id_bitacora`, `accion`, `fecha_accion`, `id_usuario`) VALUES (NULL, 'Se verifico la Documentacion de unt tramite', '" + fechahora + "', '" + user + "');";
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
        private void button1_Click_1(object sender, EventArgs e)
        {   
            if (Tramite == "Mayor de Edad")
            {        
                    if (TxtNoB.Text != "" && TxtCoM.Text != "")
                    {
                    this.Hide();
                    FrmCita nuevo = new FrmCita(user, solicitud, Cui, correo);
                    nuevo.Show();
                 

                    }
                    else
                    {
                        MessageBox.Show("!ERROR! Falta seleccionar Documentos y/o Verificar la documentación");
                        BtnRechazar.Enabled = true;

                    }
                verificacion();
                guardarv();
                Bitacora();
            }
            else if (Tramite == "Menor de Edad")
            {
                if (TxtNoB.Text != "" && TxtCoM.Text != "" && TxtCuiP.Text != "" && TxtCuiMA.Text != "")
                {
                   this.Hide();
                   FrmCita nuevo = new FrmCita(user, solicitud, Cui, correo);
                   nuevo.Show();
                 
                }
                else
                {
                    MessageBox.Show("!ERROR! Falta seleccionar Documentos y/o Verificar la documentación");
                    BtnRechazar.Enabled = true;
                }
                verificacion();
                guardarv();
                Bitacora();
            }
            else if (Tramite == "Mayor de 60")
            {
                if (TxtNoB.Text != "")
                {
                    Bitacora();
                    this.Hide();
                    FrmCita nuevo = new FrmCita(user, solicitud, Cui, correo);
                    nuevo.Show();

                }
                else
                {
                    MessageBox.Show("!ERROR! Falta seleccionar Documentos y/o Verificar la documentación");
                    BtnRechazar.Enabled = true;

                }
                verificacion();
                guardarv();
                Bitacora();
            }
            else
            {
                MessageBox.Show("!ERROR! El tipo de tramite es incorecto");
            }
        }

        private void LblCuipP_Load(object sender, EventArgs e)
        {

        }

        private void LblCuipP_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMenu entrar = new FrmMenu(user);
            entrar.Visible = true;
            Visible = false;
        }
    }
}