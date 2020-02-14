using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.IO;
using System.Net;
using System.Data.Odbc;
using System.IO;
using System.Net;

namespace Migración
{ 
    class Bitacorac
    {
        OdbcConnection conn = new OdbcConnection("Dsn=migracion");
        public void verificacion()
        {



            conn.Close();

            string query = "INSERT INTO `bitacora` (`id_bitacora`, `accion`, `fecha_accion`, `id_usuario`) VALUES (NULL, 'hola mundo', '2020-02-22 10:34:40', 'jjgb');";

            conn.Open();
            OdbcCommand consulta = new OdbcCommand(query, conn);

            try
            {
                consulta.ExecuteNonQuery();
           



            }
            catch (Exception ex)
            {
               // MessageBox.Show("\t Error! \n\n " + ex.ToString());
                conn.Close();
            }



        }
    }
}
