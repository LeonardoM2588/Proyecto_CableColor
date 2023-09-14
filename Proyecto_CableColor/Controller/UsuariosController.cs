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
    class UsuariosController
    {
        //Propiedades de la clase System
        string query;

        //Metodo Select Usuarios
        public void ListarUsuarios_Activos(string Procedimiento, string indicador, string values, string Estado)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection Con = new Control_System.Conexion_Forma1().GetConexion())
                {
                    Con.Open();
                    query = "Execute dbo." + Procedimiento + " " + indicador + "," + values + "," + Estado + "";

                    using (SqlCommand cmd = new SqlCommand(query, Con))
                    {
                        cmd.CommandTimeout = 300;
                        SqlDataAdapter LeerDatos = new SqlDataAdapter(cmd);

                        LeerDatos.Fill(dt);
                    }
                    Con.Close();
                }

                UsuariosModel.ListarUsuarios = dt;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public void ListarUsuarios2(string Procedimiento, string indicador, string values, string Estado)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection Con = new Control_System.Conexion_Forma1().GetConexion())
                {
                    Con.Open();
                    query = "Execute dbo." + Procedimiento + " " + indicador + "," + values + "," + Estado + "";

                    using (SqlCommand cmd = new SqlCommand(query, Con))
                    {
                        cmd.CommandTimeout = 300;
                        SqlDataAdapter LeerDatos = new SqlDataAdapter(cmd);

                        LeerDatos.Fill(dt);
                    }
                    Con.Close();
                }

                UsuariosModel.Data = dt;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }

        }
    }
}
