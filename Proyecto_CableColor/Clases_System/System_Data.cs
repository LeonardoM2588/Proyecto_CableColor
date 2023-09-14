using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using Proyecto_CableColor.Model;

namespace Proyecto_CableColor.Clases_System
{
    class System_Data
    {

        //Propiedades de la clase System
        SqlCommand com;
        string query;

        //Metodo Save
        //inserta registros en la base de datos
        public int Save(string Procedimiento, string indicador, string values)
        {
            int ra = 0;
            query = "Execute dbo." + Procedimiento + " " + indicador + "," + values + "";
            try
            {
                com = new SqlCommand(query, Control_System.Conexion_Forma2.ConSQL);
                Control_System.Conexion_Forma2.OpenConnection();

                ra = com.ExecuteNonQuery();

                com.Dispose();
                Control_System.Conexion_Forma2.CloseConnection();

            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                Control_System.Conexion_Forma2.EndsConnection();
            }
            return ra;
        }

        //fin Metodo Save



        //metodo update
        public bool ActualizarDatos(string Procedimiento, string indicador, string values)
        {
            try
            {
                using (SqlConnection Con = new Control_System.Conexion_Forma1().GetConexion())
                {
                    Con.Open();
                    query = "Execute dbo." + Procedimiento + " " + indicador + "," + values + "";

                    using (SqlCommand cmd = new SqlCommand(query, Con))
                    {
                        cmd.CommandTimeout = 300;
                        cmd.ExecuteNonQuery();
                    }
                    Con.Close();
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }



        public bool Eliminar(string Procedimiento, string indicador, string Id, string values)
        {
            try
            {
                using (SqlConnection Con = new Control_System.Conexion_Forma1().GetConexion())
                {
                    Con.Open();


                    query = "Execute dbo." + Procedimiento + " " + indicador + "," + Id + "," + values + "";

                    using (SqlCommand cmd = new SqlCommand(query, Con))
                    {
                        cmd.CommandTimeout = 300;
                        cmd.ExecuteNonQuery();
                    }
                    Con.Close();
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
    }
}
