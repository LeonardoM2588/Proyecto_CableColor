using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using Proyecto_CableColor.Model;

namespace Proyecto_CableColor.Controller
{
    class NacionalidadController
    {
        //Propiedades de la clase System
        string query;

        //Controller Listar Nacionalidades
        public void ListarNacionalidad(string Procedimiento, string indicador, string values)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection Con = new Control_System.Conexion_Forma1().GetConexion())
                {
                    Con.Open();
                    query = "Execute dbo." + Procedimiento + " " + indicador + "," + values + "";

                    using (SqlCommand cmd = new SqlCommand(query, Con))
                    {
                        cmd.CommandTimeout = 300;
                        SqlDataAdapter LeerDatos = new SqlDataAdapter(cmd);

                        LeerDatos.Fill(dt);
                    }
                    Con.Close();
                }

                NacionalidadModel.ListarNacionalidad = dt;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }

        }
    }
}
