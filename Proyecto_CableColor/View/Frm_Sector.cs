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
    public partial class Frm_Sector : Form
    {
        //Clases A Utilizar
        Helpers H = new Helpers();
        DataBase D = new DataBase();
        System_Data SE = new System_Data();
        SectorController SC = new SectorController();
        SectorModel SM;
        DataUser U = new DataUser();

        //Variables Universales
        int errors = 0;
        public Frm_Sector()
        {
            InitializeComponent();
        }

        private void Frm_Sector_Load(object sender, EventArgs e)
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
                procedimiento = "[sp_Sector]";
                indicador = "1";
                values = "'" + SM.IDSECTOR + "','" + SM.SECTOR + "','" + SM.IdTipoSector + "','" + SM.IDMUNICIPIO + "'";
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
            //Get Tipo Sector
            Cmb_TipoSector.DataSource = D.Find("TipoSector", "*", "", "IdTipoSector");
            Cmb_TipoSector.ValueMember = "IdTipoSector";
            Cmb_TipoSector.DisplayMember = "TipoSector";
            Cmb_TipoSector.SelectedIndex = -1;

            //Get Municipio
            Cmb_Municipio.DataSource = D.Find("Municipio", "*", "", "IDMUNICIPIO");
            Cmb_Municipio.ValueMember = "IDMUNICIPIO";
            Cmb_Municipio.DisplayMember = "MUNICIPIO";
            Cmb_Municipio.SelectedIndex = -1;
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

            SM = new SectorModel();
            SM.IDSECTOR = int.Parse(Txt_Cod_Sector.Text);
            SM.SECTOR = Txt_Sector.Text;

            //datos del cmb
            DataTable Busqueda = new DataTable();
            Busqueda = D.Find("TipoSector", "*", "TipoSector = '" + Cmb_TipoSector.Text + "'");

            if (Busqueda.Rows.Count > 0)
            {
                DataRow DATOS = Busqueda.Rows[0];
                SM.IdTipoSector = int.Parse((DATOS["IdTipoSector"].ToString()));
            }

            //Datos Del Cmb
            Busqueda = D.Find("Municipio", "*", "MUNICIPIO = '" + Cmb_Municipio.Text + "'");

            if (Busqueda.Rows.Count > 0)
            {
                DataRow DATOS = Busqueda.Rows[0];
                SM.IDMUNICIPIO = int.Parse((DATOS["IDMUNICIPIO"].ToString()));
            }
        }

        public Boolean Validando()
        {
            Boolean Valida = true;

            if (string.IsNullOrEmpty(Txt_Sector.Text))
            {
                MessageBox.Show("El campo Sector no puede quedar vacio");
                Txt_Sector.Focus();
                Valida = false;
            }
            return Valida;
        }

        private void StarForm()
        {
            Registros();
            Txt_Cod_Sector.Enabled = false;
            Txt_Sector.Enabled = false;
            Cmb_Municipio.Enabled = false;
            Cmb_TipoSector.Enabled = false;

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
            columns = "IDSECTOR";
            table = "Sector";
            Busqueda = D.GetNextID(columns, table, "");
            Txt_Cod_Sector.Text = Busqueda.ToString();

            GetCmb();
            Txt_Cod_Sector.Enabled = false;
            Txt_Sector.Enabled = true;
            Cmb_Municipio.Enabled = true;
            Cmb_TipoSector.Enabled = true;

            Btn_Guardar.Enabled = true;
            Btn_Cancelar.Enabled = true;
            Btn_Eliminar.Enabled = false;
            Btn_Nuevo.Enabled = false;
            Btn_Editar.Enabled = true;
        }

        private void ClearForm()
        {

            Txt_Cod_Sector.Clear();
            Txt_Sector.Clear();
            Cmb_Municipio.Text = "";
            Cmb_TipoSector.Text = "";

            GetCmb();
        }

        public void Registros()
        {
            string procedimiento, indicador, values;
            procedimiento = "[sp_Sector]";
            indicador = "6";
            values = "'','','',''";
            SC.ListarSector(procedimiento, indicador, values);
            dgv_registros.DataSource = SectorModel.ListarSector;
        }

        public new void Update()
        {
            if (H.MsgQuestion("¿Desea Actualizar Este Producto?") == "S")
            {
                Seteo();
                string procedimiento, indicador, values;
                procedimiento = "[sp_Sector]";
                indicador = "2";
                values = "'" + SM.IDSECTOR + "','" + SM.SECTOR + "','" + SM.IdTipoSector + "','" + SM.IDMUNICIPIO + "'";
                SE.ActualizarDatos(procedimiento, indicador, values);
                dgv_registros.DataSource = SectorModel.ListarSector;
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
            string Procedimiento = "[sp_Sector]";
            string indicador = "3";
            string id = "'" + SM.IDSECTOR + "'";
            string values = "'','',''";

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
            string TIPO_SECTOR, MUNICIPIO;

            if (dgv_registros.SelectedRows.Count > 0)
            {
                Nuevo();
                Btn_Nuevo.Enabled = false;
                Txt_Cod_Sector.Text = dgv_registros.CurrentRow.Cells["IDSECTOR"].Value.ToString();
                Txt_Sector.Text = dgv_registros.CurrentRow.Cells["SECTOR"].Value.ToString();

                TIPO_SECTOR = dgv_registros.CurrentRow.Cells["TIPO_SECTOR"].Value.ToString();
                MUNICIPIO = dgv_registros.CurrentRow.Cells["MUNICIPIO"].Value.ToString();

                Btn_Editar.Enabled = true;
                Btn_Eliminar.Enabled = true;
                Btn_Guardar.Enabled = false;

                DataTable ID = new DataTable();

                ID = D.Find("TipoSector", "*", "TipoSector='" + TIPO_SECTOR + "'");

                if (ID.Rows.Count > 0)
                {
                    DataRow info = ID.Rows[0];
                    Cmb_TipoSector.Text = info["TipoSector"].ToString();
                }

                ID = D.Find("Municipio", "*", "MUNICIPIO='" + MUNICIPIO + "'");

                if (ID.Rows.Count > 0)
                {
                    DataRow info = ID.Rows[0];
                    Cmb_Municipio.Text = info["MUNICIPIO"].ToString();
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
