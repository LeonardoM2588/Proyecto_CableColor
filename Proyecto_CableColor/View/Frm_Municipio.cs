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
    public partial class Frm_Municipio : Form
    {
        //Clases A Utilizar
        Helpers H = new Helpers();
        DataBase D = new DataBase();
        System_Data SE = new System_Data();
        MunicipioController MC = new MunicipioController();
        MunicipioModel MM;
        DataUser U = new DataUser();

        //Variables Universales
        int errors = 0;
        public Frm_Municipio()
        {
            InitializeComponent();
        }

        private void Frm_Municipio_Load(object sender, EventArgs e)
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
                procedimiento = "[sp_Municipios]";
                indicador = "1";
                values = "'" + MM.IDMUNICIPIO + "','" + MM.MUNICIPIO + "','" + MM.IDDEPARTAMENTO + "'";
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
            //Get Departamento
            Cmb_Departamento.DataSource = D.Find("Departamento", "*", "", "IDDEPARTAMENTO");
            Cmb_Departamento.ValueMember = "IDDEPARTAMENTO";
            Cmb_Departamento.DisplayMember = "DEPARTAMENTO";
            Cmb_Departamento.SelectedIndex = -1;
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

            MM = new MunicipioModel();
            MM.IDMUNICIPIO = int.Parse(Txt_Cod_Municipio.Text);
            MM.MUNICIPIO = Txt_Municipio.Text;

            //datos del cmb
            DataTable Busqueda = new DataTable();
            Busqueda = D.Find("Departamento", "*", "DEPARTAMENTO = '" + Cmb_Departamento.Text + "'");

            if (Busqueda.Rows.Count > 0)
            {
                DataRow DATOS = Busqueda.Rows[0];
                MM.IDDEPARTAMENTO = int.Parse((DATOS["IDDEPARTAMENTO"].ToString()));
            }
        }

        public Boolean Validando()
        {
            Boolean Valida = true;

            if (string.IsNullOrEmpty(Txt_Municipio.Text))
            {
                MessageBox.Show("El campo Municipio no puede quedar vacio");
                Txt_Municipio.Focus();
                Valida = false;
            }
            return Valida;
        }

        private void StarForm()
        {
            Registros();
            Txt_Cod_Municipio.Enabled = false;
            Txt_Municipio.Enabled = false;
            Cmb_Departamento.Enabled = false;

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
            columns = "IDMUNICIPIO";
            table = "MUNICIPIO";
            Busqueda = D.GetNextID(columns, table, "");
            Txt_Cod_Municipio.Text = Busqueda.ToString();

            GetCmb();
            Txt_Cod_Municipio.Enabled = false;
            Txt_Municipio.Enabled = true;
            Cmb_Departamento.Enabled = true;

            Btn_Guardar.Enabled = true;
            Btn_Cancelar.Enabled = true;
            Btn_Eliminar.Enabled = false;
            Btn_Nuevo.Enabled = false;
            Btn_Editar.Enabled = true;
        }

        private void ClearForm()
        {

            Txt_Cod_Municipio.Clear();
            Txt_Municipio.Clear();
            Cmb_Departamento.Text = "";

            GetCmb();
        }

        public void Registros()
        {
            string procedimiento, indicador, values;
            procedimiento = "[sp_Municipios]";
            indicador = "6";
            values = "'','',''";
            MC.ListarMunicipio(procedimiento, indicador, values);
            dgv_registros.DataSource = MunicipioModel.ListarMunicipios;
        }

        public new void Update()
        {
            if (H.MsgQuestion("¿Desea Actualizar Este Producto?") == "S")
            {
                Seteo();
                string procedimiento, indicador, values;
                procedimiento = "[sp_Municipios]";
                indicador = "2";
                values = "'" + MM.IDMUNICIPIO + "','" + MM.MUNICIPIO + "','" + MM.IDDEPARTAMENTO + "'";
                SE.ActualizarDatos(procedimiento, indicador, values);
                dgv_registros.DataSource = MunicipioModel.ListarMunicipios;
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
            string Procedimiento = "[sp_Municipios]";
            string indicador = "3";
            string id = "'" + MM.IDMUNICIPIO + "'";
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
            string DEPARTAMENTO;

            if (dgv_registros.SelectedRows.Count > 0)
            {
                Nuevo();
                Btn_Nuevo.Enabled = false;
                Txt_Cod_Municipio.Text = dgv_registros.CurrentRow.Cells["IDMUNICIPIO"].Value.ToString();
                Txt_Municipio.Text = dgv_registros.CurrentRow.Cells["MUNICIPIO"].Value.ToString();

                DEPARTAMENTO = dgv_registros.CurrentRow.Cells["DEPARTAMENTO"].Value.ToString();

                Btn_Editar.Enabled = true;
                Btn_Eliminar.Enabled = true;
                Btn_Guardar.Enabled = false;

                DataTable ID = new DataTable();

                ID = D.Find("Departamento", "*", "DEPARTAMENTO='" + DEPARTAMENTO + "'");

                if (ID.Rows.Count > 0)
                {
                    DataRow info = ID.Rows[0];
                    Cmb_Departamento.Text = info["DEPARTAMENTO"].ToString();
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
