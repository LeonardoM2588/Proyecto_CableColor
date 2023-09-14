using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_CableColor.Model;
using Proyecto_CableColor.Control_System;
using Proyecto_CableColor.Clases_System;
using Proyecto_CableColor.Controller;
using System.Net;
using System.Net.Mail;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Proyecto_CableColor.View
{
    public partial class Frm_Nacionalidad : Form
    {
        Helpers H = new Helpers();
        DataBase D = new DataBase();
        System_Data SE = new System_Data();
        NacionalidadController NC = new NacionalidadController();
        NacionalidadModel NM;


        int errors = 0;

        public Frm_Nacionalidad()
        {
            InitializeComponent();
        }

        //Metodo De Guardar
        private void Guardar()
        {
            if (errors == 0)
            {
                Validando();
                Seteo();
                string procedimiento, values, indicador;
                procedimiento = "[sp_Nacionalidad]";
                indicador = "1";
                values = "'" + NM.Cod_Nacionalidad + "','" + NM.Nacionalidad + "'";
                if (SE.Save(procedimiento, indicador, values) > 0)
                {
                    H.MsgSuccess("Se Guardo El Registro De Forma Satisfactoria!");
                    StarForm();
                    ClearForm();
                }

            }
        }

        public void Seteo()
        {
            NM = new NacionalidadModel();
            NM.Cod_Nacionalidad = int.Parse(Txt_Cod_Nacionalidad.Text);
            NM.Nacionalidad = Txt_Nacionalidad.Text;
        }

        public Boolean Validando()
        {
            Boolean Valida = true;

            if (string.IsNullOrEmpty(Txt_Nacionalidad.Text))
            {
                MessageBox.Show("El campo Nacionalidad no puede quedar vacio");
                Txt_Nacionalidad.Focus();
                Valida = false;
            }
            return Valida;
        }

        private void Frm_Nacionalidad_Load(object sender, EventArgs e)
        {
            StarForm();
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            Guardar();
            StarForm();
            Registros();
        }

        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {

            if (H.MsgQuestion("¿Desea Cerrar Esta Ventana?") == "S")
            {
                Frm_Panel Panel = new Frm_Panel();
                this.Hide();
                Panel.ShowDialog();
            }
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            if (H.MsgQuestion("¿Desea Cancelar La Operacion?") == "S")
            {
                StarForm();
                ClearForm();
            }
        }

        private void StarForm()
        {

            Registros();

            Txt_Cod_Nacionalidad.Enabled = false;
            Txt_Nacionalidad.Enabled = false;

            //Botones Principales
            Btn_Guardar.Enabled = false;
            Btn_Cancelar.Enabled = false;
            Btn_Eliminar.Enabled = false;
            Btn_Nuevo.Enabled = true;
            Btn_Editar.Enabled = false;

            Lbl_Registros.Text = dgv_registros.Rows.Count.ToString();
            dgv_registros.DefaultCellStyle.ForeColor = Color.Black;
            Lbl_Registros.ForeColor = Color.Black;

        }

        private void Nuevo()
        {

            string Busqueda;
            string columns, table;
            columns = "Cod_Nacionalidad";
            table = "Nacionalidad";
            Busqueda = D.GetNextID(columns, table, "");
            Txt_Cod_Nacionalidad.Text = Busqueda.ToString();

            Txt_Nacionalidad.Enabled = true;

            //Botones Principales
            Btn_Guardar.Enabled = true;
            Btn_Cancelar.Enabled = true;
            Btn_Eliminar.Enabled = false;
            Btn_Nuevo.Enabled = false;
            Btn_Editar.Enabled = true;
        }

        private void dgv_registros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_registros.SelectedRows.Count > 0)
            {
                Nuevo();
                Btn_Nuevo.Enabled = false;
                Txt_Cod_Nacionalidad.Text = dgv_registros.CurrentRow.Cells["Cod_Nacionalidad"].Value.ToString();
                Txt_Nacionalidad.Text = dgv_registros.CurrentRow.Cells["Nacionalidad"].Value.ToString();

                Btn_Editar.Enabled = true;
                Btn_Eliminar.Enabled = true;
                Btn_Guardar.Enabled = false;
            }
        }

        private void Btn_Editar_Click(object sender, EventArgs e)
        {
            Update();
        }

        public void Registros()
        {
            string procedimiento, indicador, values;
            procedimiento = "[sp_Nacionalidad]";
            indicador = "4";
            values = "'',''";
            NC.ListarNacionalidad(procedimiento, indicador, values);
            dgv_registros.DataSource = NacionalidadModel.ListarNacionalidad;
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (H.MsgQuestion("¿Desea Eliminar Este Registro?") == "S")
            {
                Delete();
            }
        }

        private void ClearForm()
        {
            Txt_Cod_Nacionalidad.Clear();
            Txt_Nacionalidad.Clear();
        }

        public new void Update()
        {
            if (H.MsgQuestion("¿Desea Actualizar Este Horario?") == "S")
            {
                Seteo();
                string procedimiento, indicador, values;
                procedimiento = "[sp_Nacionalidad]";
                indicador = "2";
                values = "'" + NM.Cod_Nacionalidad + "','" + NM.Nacionalidad + "'";
                SE.ActualizarDatos(procedimiento, indicador, values);
                dgv_registros.DataSource = NacionalidadModel.ListarNacionalidad;
                H.MsgSuccess("Registro Actualizado Con Exito!");
                ClearForm();
                StarForm();
                Registros();
            }
            else
            {
                StarForm();
                ClearForm();
            }
        }

        public void Delete()
        {
            Seteo();
            string Procedimiento = "[sp_Nacionalidad]";
            string indicador = "3";
            string id = "'" + NM.Cod_Nacionalidad + "'";
            string values = "''";

            SE.Eliminar(Procedimiento, indicador, id, values);
            H.MsgSuccess("Registro Eliminado Con Exito!");
            ClearForm();
            StarForm();
            Registros();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
