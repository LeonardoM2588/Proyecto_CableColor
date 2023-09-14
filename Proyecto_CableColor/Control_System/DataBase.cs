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
    class DataBase
    {
        //Propiedades de la clase Atom
        SqlCommand com;
        SqlDataReader reader;
        DataTable recordset;
        string query;

        //Metodo Find
        //consulta la base de datos
        public DataTable Find(string table, string fields, string condition = "", string orderby = "")
        {
            recordset = new DataTable();

            if (condition == "" && orderby == "")
            {
                query = "Select " + fields + " from " + table;
            }
            else if (condition != "" && orderby == "")
            {
                query = "Select " + fields + " from " + table + " where " + condition;
            }
            else if (condition == "" && orderby != "")
            {
                query = "Select " + fields + " from " + table + " order by " + orderby;
            }
            else if (condition != "" && orderby != "")
            {
                query = "Select " + fields + " from " + table + " where " + condition + " order by " + orderby;
            }

            try
            {
                com = new SqlCommand(query, Control_System.Conexion_Forma2.ConSQL);
                Control_System.Conexion_Forma2.OpenConnection();

                reader = com.ExecuteReader();
                recordset.Load(reader);

                reader.Close();
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
            return recordset;
        }
        //Fin Metodo Find

        //Metodo Save
        //inserta registros en la base de datos
        public int Save(string table, string fields, string values)
        {
            int ra = 0; //rowsaffected
            query = "Insert into " + table + "(" + fields + ") values(" + values + ")";
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

        //Metodo Update
        //Actualizar los registros de la base de datos
        public int Update(string table, string values, string condition = "")
        {
            int ra = 0; //rowsaffected
            if (condition == "")
            {
                query = "Update " + table + " set " + values;
            }
            else
            {
                query = "Update " + table + " set " + values + " where " + condition;
            }

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
        //Actualiza registros existentes
        //Fin Metodo Update

        //Metodo Destroy
        //Elimina registros de la base de datos
        public int Destroy(string table, string condition = "")
        {
            int ra = 0;
            if (condition == "")
            {
                query = "Delete from " + table;
            }
            else
            {
                query = "Delete from " + table + " where " + condition;
            }

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
        //Fin Metodo Destroy

        //METODO JOINTABLES (JOIN SIGNIFICA UNIR) (UNE DOS O MAS TABLAS)
        public DataTable JOINTABLE(string data, string condition = "", string orderby = "")
        {
            recordset = new DataTable();
            if (condition == "" && orderby == "")
            {
                query = "Select " + data;
            }
            else if (condition != "" && orderby == "")
            {
                query = "Select " + data + " where " + condition;
            }
            else if (condition != "" && orderby != "")
            {
                query = "Select " + data + " where " + condition + " order by " + orderby;
            }
            else if (condition == "" && orderby != "")
            {
                query = "Select " + data + " order by " + orderby;
            }

            try
            {
                com = new SqlCommand(query, Control_System.Conexion_Forma2.ConSQL);
                Control_System.Conexion_Forma2.OpenConnection();

                reader = com.ExecuteReader();
                recordset.Load(reader);

                reader.Close();
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
            return recordset;

        }
        //FIN DEL METODO JOINTABLE

        //METODO GET NEXT ID
        //GENERA UN NUEVO IDENTIFICADOR
        public string GetNextID(string columns, string table, string condition = "")
        {
            string NextID = "";
            query = "SELECT MAX(" + columns + "+1) AS NEXTID FROM " + table + "";
            Int64 x = 0;
            try
            {
                com = new SqlCommand(query, Control_System.Conexion_Forma2.ConSQL);
                Control_System.Conexion_Forma2.OpenConnection();
                reader = com.ExecuteReader();

                if (reader.Read())
                {
                    x = Convert.ToInt64(reader["NEXTID"].ToString());
                }
                else
                {
                    MessageBox.Show("ERROR AL GENERAL IDENTIFICADOR!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                reader.Close();
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
            if (x > 0 && x <= 9)
            {
                NextID = "00000" + x.ToString();
            }
            else if (x >= 10 && x <= 99)
            {
                NextID = "0000" + x.ToString();
            }
            else if (x >= 100 && x <= 999)
            {
                NextID = "000" + x.ToString();
            }
            else if (x >= 1000 && x <= 9999)
            {
                NextID = "00" + x.ToString();
            }
            else if (x >= 10000 && x <= 99999)
            {
                NextID = "0" + x.ToString();
            }
            else if (x >= 100000 && x <= 999999)
            {
                NextID = x.ToString();
            }
            else
            {
                MessageBox.Show("HA LLEGADO AL LIMITE, CONTACTAR AL ADMINISTRADOR", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return NextID;
        }

        //FIN GET NEXT ID

        //METODO SET LAST ID
        //ACTUALIZA CORRELATIVO
        public void SetLastID(String idmod)
        {
            query = "UPDATE CORRELATIVOS SET ULTIMO=ULTIMO +1 WHERE IDMOD='" + idmod + "'";
            try
            {
                com = new SqlCommand(query, Control_System.Conexion_Forma2.ConSQL);
                Control_System.Conexion_Forma2.OpenConnection();
                com.ExecuteNonQuery();

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
        }
        //FIN METDO SET LAST ID
        //METODO HOOK
        //RECUPERA UN SOLO DATO DE LA BASE DE DATOS
        public string Hook(string table, string FIELD, string condition)
        {
            string target = "";
            query = " SELECT " + FIELD + " AS TARGET FROM " + table + " WHERE " + condition;

            try
            {
                com = new SqlCommand(query, Control_System.Conexion_Forma2.ConSQL);
                Control_System.Conexion_Forma2.OpenConnection();
                reader = com.ExecuteReader();
                if (reader.Read())
                {
                    target = reader["TARGET"].ToString();
                }
                else
                {
                    MessageBox.Show("ERROR AL RECUPERAR EL DATO ESPECIFICADO");
                }

                reader.Close();
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
            return target;
        }
        //FIN HOOK
    }
}
