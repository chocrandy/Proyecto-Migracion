﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migración
{
    public partial class FrmCita : Form
    {
        string user;
        string solicitud;
        string Cui;
        public FrmCita(string usuario, string numero,string cui)
        {
            InitializeComponent();
            user = usuario;
            solicitud = numero;
            Cui = cui;
            TxtCui.Text = Cui;
            TxtNumeroV.Text = solicitud;
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmCita_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
