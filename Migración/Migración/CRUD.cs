using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migración
{
    class CRUD
    {
        OdbcConnection conn = new OdbcConnection("Dsn=migracion");
        public void obtenerLista(ListBox listBox)
        {
            //codigo para llevar el DataGridView
            OdbcCommand cod = new OdbcCommand();
            cod.Connection = conn;
            cod.CommandText = ("SELECT * FROM `empleados` WHERE estado=1");
            List<string> listaemp = new List<string>();

            try
            {
                OdbcDataAdapter eje = new OdbcDataAdapter();
                eje.SelectCommand = cod;
                DataTable datos = new DataTable();
                eje.Fill(datos);
                string nombreCom;

                foreach (DataRow row in datos.Rows)
                {
                    nombreCom = row["id_empleado"].ToString() + " - Nombre: " + row["nombres"].ToString()
                        + " " + row["apellidos"].ToString();
                    listaemp.Add(nombreCom);
                }

                for (int i = 0; i < listaemp.Count; i++)
                {
                    listBox.Items.Insert(i, listaemp[i].ToString());
                }
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al Llenar Lista de Empleados", "USUARIOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conn.Close();
            }
        }
    }
}
