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
using Proyecto_CableColor.Controller;
using Proyecto_CableColor.Control_System;
using Proyecto_CableColor.Clases_System;
using System.Net;
using System.Net.Mail;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Proyecto_CableColor.View
{
    public partial class Frm_DepartamentoPais : Form
    {

        //Clases A Utilizar
        Helpers H = new Helpers();
        DataBase D = new DataBase();
        System_Data SE = new System_Data();
        DepartamentoPaisController DPC = new DepartamentoPaisController();
        DepartamentoPaisModel DPM;
        DataUser U = new DataUser();

        //Variables Universales
        int errors = 0;
        public Frm_DepartamentoPais()
        {
            InitializeComponent();
        }

        private void Frm_DepartamentoPais_Load(object sender, EventArgs e)
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

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            if (H.MsgQuestion("¿Desea Cancelar La Operacion?") == "S")
            {
                StarForm();
                ClearForm();
            }
        }

        private void Guardar()
        {
            if (errors == 0)
            {
                Validando();
                Seteo();
                string procedimiento, values, indicador;
                procedimiento = "[sp_DepartamentoPais]";
                indicador = "1";
                values = "'" + DPM.IDDEPARTAMENTO + "','" + DPM.DEPARTAMENTO + "','" + DPM.IDPAIS + "'";
                if (SE.Save(procedimiento, indicador, values) > 0)
                {
                    H.MsgSuccess("Se Guardo El Registro De Forma Satisfactoria!");
                    StarForm();
                    ClearForm();
                }
            }
        }

        public void GetCmb()
        {
            //Get nivel user
            Cmb_Pais.DataSource = D.Find("Pais", "*", "", "IDPAIS");
            Cmb_Pais.ValueMember = "IDPAIS";
            Cmb_Pais.DisplayMember = "PAIS";
            Cmb_Pais.SelectedIndex = -1;
        }

        private void Btn_Editar_Click(object sender, EventArgs e)
        {
            Update();
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

        public void Seteo()
        {

            DPM = new DepartamentoPaisModel();
            DPM.IDDEPARTAMENTO = int.Parse(Txt_Cod_Departamento.Text);
            DPM.DEPARTAMENTO = Txt_Departamento.Text;

            //datos del cmb
            DataTable Busqueda = new DataTable();
            Busqueda = D.Find("Pais", "*", "PAIS = '"+Cmb_Pais.Text+"'");

            if (Busqueda.Rows.Count > 0)
            {
                DataRow DATOS = Busqueda.Rows[0];
                DPM.IDPAIS = int.Parse((DATOS["IDPAIS"].ToString()));
            }
        }

        public Boolean Validando()
        {
            Boolean Valida = true;

            if (string.IsNullOrEmpty(Txt_Departamento.Text))
            {
                MessageBox.Show("El campo Departamento no puede quedar vacio");
                Txt_Departamento.Focus();
                Valida = false;
            }
            return Valida;
        }

        private void StarForm()
        {
            Registros();
            Txt_Cod_Departamento.Enabled = false;
            Txt_Departamento.Enabled = false;
            Cmb_Pais.Enabled = false;

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
            ClearForm();
            string Busqueda;
            string columns, table;
            columns = "IDDEPARTAMENTO";
            table = "Departamento";
            Busqueda = D.GetNextID(columns, table, "");
            Txt_Cod_Departamento.Text = Busqueda.ToString();

            GetCmb();
            Txt_Cod_Departamento.Enabled = false;
            Txt_Departamento.Enabled = true;
            Cmb_Pais.Enabled = true;

            Btn_Guardar.Enabled = true;
            Btn_Cancelar.Enabled = true;
            Btn_Eliminar.Enabled = false;
            Btn_Nuevo.Enabled = false;
            Btn_Editar.Enabled = true;
        }

        private void ClearForm()
        {

            Txt_Cod_Departamento.Clear();
            Txt_Departamento.Clear();
            Cmb_Pais.Text = "";

            GetCmb();
        }

        public void Registros()
        {
            string procedimiento, indicador, values;
            procedimiento = "[sp_DepartamentoPais]";
            indicador = "6";
            values = "'','',''";
            DPC.ListarDepartamentoPaises(procedimiento, indicador, values);
            dgv_registros.DataSource = DepartamentoPaisModel.ListarDepartamentosPaises;
        }

        public new void Update()
        {
            if (H.MsgQuestion("¿Desea Actualizar Este Producto?") == "S")
            {
                Seteo();
                string procedimiento, indicador, values;
                procedimiento = "[sp_DepartamentoPais]";
                indicador = "2";
                values = "'"+DPM.IDDEPARTAMENTO+"','" + DPM.DEPARTAMENTO + "','" + DPM.IDPAIS + "'";
                SE.ActualizarDatos(procedimiento, indicador, values);
                dgv_registros.DataSource = DepartamentoPaisModel.ListarDepartamentosPaises;
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
            string Procedimiento = "[sp_DepartamentoPais]";
            string indicador = "3";
            string id = "'" + DPM.IDDEPARTAMENTO + "'";
            string values = "'',''";

            SE.Eliminar(Procedimiento, indicador, id, values);
            H.MsgSuccess("Registro Eliminado Con Exito!");
            ClearForm();
            StarForm();
            Registros();
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (H.MsgQuestion("¿Desea Eliminar Este Registro?") == "S")
            {
                Delete();
            }
        }

        private void dgv_registros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string PAIS;

            if (dgv_registros.SelectedRows.Count > 0)
            {
                Nuevo();
                Btn_Nuevo.Enabled = false;
                Txt_Cod_Departamento.Text = dgv_registros.CurrentRow.Cells["IDDEPARTAMENTO"].Value.ToString();
                Txt_Departamento.Text = dgv_registros.CurrentRow.Cells["DEPARTAMENTO"].Value.ToString();

                PAIS = dgv_registros.CurrentRow.Cells["PAIS"].Value.ToString();

                Btn_Editar.Enabled = true;
                Btn_Eliminar.Enabled = true;
                Btn_Guardar.Enabled = false;

                DataTable ID = new DataTable();

                ID = D.Find("Pais", "*", "PAIS='" + PAIS + "'");

                if (ID.Rows.Count > 0)
                {
                    DataRow info = ID.Rows[0];
                    Cmb_Pais.Text = info["PAIS"].ToString();
                }

                ID.Dispose();
            }
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
