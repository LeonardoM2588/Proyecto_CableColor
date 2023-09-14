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
    public partial class Frm_TipoSector : Form
    {
        Helpers H = new Helpers();
        DataBase D = new DataBase();
        System_Data SE = new System_Data();
        TipoSectorController TSC = new TipoSectorController();
        TipoSectorModel TSM;


        int errors = 0;
        public Frm_TipoSector()
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
                procedimiento = "[sp_TipoSector]";
                indicador = "1";
                values = "'" + TSM.IdTipoSector + "','" + TSM.TipoSector + "'";
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
            TSM = new TipoSectorModel();
            TSM.IdTipoSector = int.Parse(Txt_Cod_TipoSector.Text);
            TSM.TipoSector = Txt_TipoSector.Text;
        }

        public Boolean Validando()
        {
            Boolean Valida = true;

            if (string.IsNullOrEmpty(Txt_TipoSector.Text))
            {
                MessageBox.Show("El campo Tipo Sector no puede quedar vacio");
                Txt_TipoSector.Focus();
                Valida = false;
            }
            return Valida;
        }
        private void Frm_TipoSector_Load(object sender, EventArgs e)
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

            Txt_Cod_TipoSector.Enabled = false;
            Txt_TipoSector.Enabled = false;

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
            columns = "IdTipoSector";
            table = "TipoSector";
            Busqueda = D.GetNextID(columns, table, "");
            Txt_Cod_TipoSector.Text = Busqueda.ToString();

            Txt_TipoSector.Enabled = true;

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
                Txt_Cod_TipoSector.Text = dgv_registros.CurrentRow.Cells["IdTipoSector"].Value.ToString();
                Txt_TipoSector.Text = dgv_registros.CurrentRow.Cells["TipoSector"].Value.ToString();

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
            procedimiento = "[sp_TipoSector]";
            indicador = "4";
            values = "'',''";
            TSC.ListarTipoSector(procedimiento, indicador, values);
            dgv_registros.DataSource = TipoSectorModel.ListarTipoSector;
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
            Txt_Cod_TipoSector.Clear();
            Txt_TipoSector.Clear();
        }

        public new void Update()
        {
            if (H.MsgQuestion("¿Desea Actualizar Este Horario?") == "S")
            {
                Seteo();
                string procedimiento, indicador, values;
                procedimiento = "[sp_TipoSector]";
                indicador = "2";
                values = "'" + TSM.IdTipoSector + "','" + TSM.TipoSector + "'";
                SE.ActualizarDatos(procedimiento, indicador, values);
                dgv_registros.DataSource = TipoSectorModel.ListarTipoSector;
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
            string Procedimiento = "[sp_TipoSector]";
            string indicador = "3";
            string id = "'" + TSM.IdTipoSector + "'";
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
