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
    public partial class Frm_TipoPaquetes : Form
    {
        Helpers H = new Helpers();
        DataBase D = new DataBase();
        System_Data SE = new System_Data();
        TipoPaquetesController TPC = new TipoPaquetesController();
        TiposPaquetesModel TPM;


        int errors = 0;

        public Frm_TipoPaquetes()
        {
            InitializeComponent();
        }

        private void Guardar()
        {
            if (errors == 0)
            {
                Validando();
                Seteo();
                string procedimiento, values, indicador;
                procedimiento = "[sp_Tipo_Paquete]";
                indicador = "1";
                values = "'" + TPM.Cod_TipoPaquete + "','" + TPM.Tipo_Paquete + "','" + TPM.Descripcion + "','" + TPM.FechaCreacion + "','"+TPM.UsuarioCreacion+"','',''";
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
            TPM = new TiposPaquetesModel();
            TPM.Cod_TipoPaquete = int.Parse(Txt_Cod_Paquetes.Text);
            TPM.Tipo_Paquete = Txt_TipoPaquete.Text;
            TPM.Descripcion = Txt_Descripcion.Text;
            TPM.FechaCreacion = DateTime.Today;
            TPM.UsuarioCreacion = DataUser.USERNAME;
            TPM.UsuarioModificacion = DataUser.USERNAME;
        }

        public Boolean Validando()
        {
            Boolean Valida = true;

            if (string.IsNullOrEmpty(Txt_TipoPaquete.Text))
            {
                MessageBox.Show("El campo Tipo Paquete no puede quedar vacio");
                Txt_TipoPaquete.Focus();
                Valida = false;
            }
            else
            {
                if (string.IsNullOrEmpty(Txt_Descripcion.Text))
                {
                    MessageBox.Show("El campo Descripcion no puede quedar vacio");
                    Txt_Descripcion.Focus();
                    Valida = false;
                }
            }
            return Valida;
        }

        private void Frm_TipoPaquetes_Load(object sender, EventArgs e)
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

            Txt_Descripcion.Enabled = false;
            Txt_Descripcion.Enabled = false;

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
            columns = "Cod_TipoPaquete";
            table = "Tipo_Paquete";
            Busqueda = D.GetNextID(columns, table, "");
            Txt_Cod_Paquetes.Text = Busqueda.ToString();

            Txt_TipoPaquete.Enabled = true;
            Txt_Descripcion.Enabled = true;

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
                Txt_Cod_Paquetes.Text = dgv_registros.CurrentRow.Cells["Cod_TipoPaquete"].Value.ToString();
                Txt_TipoPaquete.Text = dgv_registros.CurrentRow.Cells["Tipo_Paquete"].Value.ToString();
                Txt_Descripcion.Text = dgv_registros.CurrentRow.Cells["Descripcion"].Value.ToString();

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
            procedimiento = "[sp_Tipo_Paquete]";
            indicador = "4";
            values = "'','','','','','',''";
            TPC.ListarPaquetes(procedimiento, indicador, values);
            dgv_registros.DataSource = TiposPaquetesModel.ListarTipoPaquetes;
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
            Txt_Cod_Paquetes.Clear();
            Txt_TipoPaquete.Clear();
            Txt_Descripcion.Clear();
        }

        public new void Update()
        {
            if (H.MsgQuestion("¿Desea Actualizar Este Horario?") == "S")
            {
                Seteo();
                string procedimiento, indicador, values;
                procedimiento = "[sp_Tipo_Paquete]";
                indicador = "2";
                values = "'" + TPM.Cod_TipoPaquete + "','" + TPM.Tipo_Paquete + "','" + TPM.Descripcion + "','" + TPM.FechaCreacion + "','" + TPM.UsuarioCreacion + "','" + TPM.FechaModificacion + "','" + TPM.UsuarioModificacion + "'";
                SE.ActualizarDatos(procedimiento, indicador, values);
                dgv_registros.DataSource = TiposPaquetesModel.ListarTipoPaquetes;
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
            string Procedimiento = "[sp_Tipo_Paquete]";
            string indicador = "3";
            string id = "'" + TPM.Cod_TipoPaquete + "'";
            string values = "'','','','','',''";

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
