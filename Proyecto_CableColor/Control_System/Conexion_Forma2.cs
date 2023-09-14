using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_CableColor.Control_System
{
    class Conexion_Forma2
    {
        public static string ConnectionString = "Server='LEONARDO-M\\SQLEXPRESS';Database='Proyecto_CableColor';User Id='LeonardoM';Password='LeonardoBDSA';";
        public static SqlConnection ConSQL = new SqlConnection(ConnectionString);

        //Metodo OpenConnection
        //Abrir La Conexion A La Base De Datos
        public static void OpenConnection()
        {
            try
            {
                ConSQL.Open();

            }
            catch (SqlException Error)
            {
                MessageBox.Show(Error.Message);
            }

        }

        //Fin Del Metodo OpenConnection



        //Metodo CloseConnection
        //Cerrar La Conexion A La Base De Datos

        public static void CloseConnection()
        {
            try
            {
                ConSQL.Close();

            }

            catch (SqlException Error)
            {
                MessageBox.Show(Error.Message);


            }

        }
        //Fin CloseConnection


        //Metodo EndsConnection
        //Forzar El Cierre A La Conexion A La Base De Datos

        public static void EndsConnection()
        {
            if (ConSQL.State == ConnectionState.Open)
            {
                ConSQL.Close();

            }
        }
        //Fin Del Metodo EndsConnection
    }
}
