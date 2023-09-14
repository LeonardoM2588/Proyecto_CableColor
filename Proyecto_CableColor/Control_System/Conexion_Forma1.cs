using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Proyecto_CableColor.Control_System
{
    class Conexion_Forma1
    {
        public SqlConnection GetConexion()
        {
            string NombreConexion = "Proyecto_CableColor.Properties.Settings.CableColor";

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings[NombreConexion].ToString());

            return sqlCon;
        }

        public SqlConnection GetConexion(string Servidor)
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings[Servidor].ToString());

            return sqlCon;
        }
    }
}
