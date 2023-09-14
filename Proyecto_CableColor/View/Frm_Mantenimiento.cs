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
    public partial class Frm_Mantenimiento : Form
    {
        //Clases A Utilizar
        Helpers H = new Helpers();
        DataBase D = new DataBase();
        System_Data SE = new System_Data();
        MantenimientoController MC = new MantenimientoController();
        MantenimientoModel MM;
        DataUser U = new DataUser();

        //Variables Universales
        int errors = 0;
        public Frm_Mantenimiento()
        {
            InitializeComponent();
        }

        private void Frm_Mantenimiento_Load(object sender, EventArgs e)
        {
            StarForm();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
        //Metodo De Guardado    
        private void Guardar()
        {
            if (errors == 0)
            {
                Validando();
                Seteo();
                string procedimiento, values, indicador;
                procedimiento = "[sp_Mantenimiento]";
                indicador = "1";
                values = "'" + MM.Cod_Orden_Mant + "','" + MM.Cod_Cliente + "','" + MM.Fecha_Mantenimiento + "','" + MM.Cod_Empleado + "','" + MM.Telefono + "','" + MM.UsuarioCreacion + "',NULL";
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
            //Get Empleado
            Cmb_Empleado.DataSource = D.Find("Empleados", "*", "Cod_Cargo = '2'", "Nombre_Empleado");
            Cmb_Empleado.ValueMember = "Cod_Empleado";
            Cmb_Empleado.DisplayMember = "Nombre_Empleado";
            Cmb_Empleado.SelectedIndex = -1;

            //Get Paquete
            Cmb_Cliente.DataSource = D.Find("Clientes", "*", "UsuarioCreacion='" + DataUser.USERNAME + "'", "Nombre_Cliente");
            Cmb_Cliente.ValueMember = "Cod_Cliente";
            Cmb_Cliente.DisplayMember = "Nombre_Cliente";
            Cmb_Cliente.SelectedIndex = -1;
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
            MM = new MantenimientoModel();
            MM.Cod_Orden_Mant = int.Parse(Txt_CodMantenimiento.Text);
            MM.Fecha_Mantenimiento = Dtp_FechaMantenimiento.Value;
            MM.Telefono = Txt_Celular.Text;
            MM.FechaCreacion = DateTime.Today;
            MM.UsuarioCreacion = DataUser.USERNAME;
            MM.FechaModificacion = DateTime.Today;
            MM.UsuarioModificacion = DataUser.USERNAME;


            //Almacenado De Datos De Los ComboBox
            DataTable Busqueda = new DataTable();

            //ComboBox Paquetes
            Busqueda = D.Find("Clientes", "*", "Nombre_Cliente='" + Cmb_Cliente.Text + "'");

            if (Busqueda.Rows.Count > 0)
            {
                DataRow DATOS = Busqueda.Rows[0];
                if (Cmb_Cliente.Text == (DATOS["Nombre_Cliente"].ToString()))
                {
                    MM.Cod_Cliente = int.Parse((DATOS["Cod_Cliente"].ToString()));
                }
            }

            //ComboBox Empleado
            Busqueda = D.Find("Empleados", "*", "Nombre_Empleado='" + Cmb_Empleado.Text + "'");

            if (Busqueda.Rows.Count > 0)
            {
                DataRow DATOS = Busqueda.Rows[0];
                if (Cmb_Empleado.Text == (DATOS["Nombre_Empleado"].ToString()))
                {
                    MM.Cod_Empleado = int.Parse((DATOS["Cod_Empleado"].ToString()));
                }
            }
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            if (txt_buscar.Text == "")
            {
                Registros();
                StarForm();
            }
        }

        private void Btn_CancelarBusqueda_Click(object sender, EventArgs e)
        {
            if (H.MsgQuestion("¿Desea Cancelar La Busqueda?") == "S")
            {
                txt_buscar.Text = "";
                txt_buscar.Select();
            }
        }

        private void Btn_Imprimir_Click(object sender, EventArgs e)
        {
            if (H.MsgQuestion("¿Desea Generar Un Reporte?") == "S")
            {
                Reportes.Frm_Reporteria Reporte = new Reportes.Frm_Reporteria(7);
                Reporte.Show();
            }
        }

        public Boolean Validando()
        {
            Boolean Valida = true;

            if (string.IsNullOrEmpty(Txt_Celular.Text))
            {
                MessageBox.Show("El campo Telefono Del Cliente no puede quedar vacio");
                Txt_Celular.Focus();
                Valida = false;
            }
            return Valida;
        }

        private void StarForm()
        {
            txt_buscar.Select();
            Registros();

            //Cajas De Texto
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Enabled = false;
                }
            }

            //Cajas De MaskedTexbox
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is MaskedTextBox)
                {
                    ctrl.Enabled = false;
                }
            }

            //ComboBox
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is ComboBox)
                {
                    ctrl.Enabled = false;
                }
            }

            //DateTimePicker
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is DateTimePicker)
                {
                    ctrl.Enabled = false;
                }
            }

            Txt_UsuarioLogeado.Text = DataUser.USERNAME;


            //Botones Principales

            Btn_Guardar.Enabled = false;
            Btn_Cancelar.Enabled = false;
            Btn_Eliminar.Enabled = false;
            Btn_Datos.Enabled = true;
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
            columns = "Cod_Orden_Mant";
            table = "Ordenes_Mantenimiento";
            Busqueda = D.GetNextID(columns, table, "");
            Txt_CodMantenimiento.Text = Busqueda.ToString();

            GetCmb();
            //Cajas De Texto
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Enabled = true;
                }
            }

            //Cajas De MaskedTexbox
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is MaskedTextBox)
                {
                    ctrl.Enabled = true;
                }
            }
            //ComboBox
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is ComboBox)
                {
                    ctrl.Enabled = true;
                }
            }

            //DateTimePicker
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is DateTimePicker)
                {
                    ctrl.Enabled = true;
                }
            }

            Txt_UsuarioLogeado.Text = DataUser.USERNAME;

            //Botones Principales
            Txt_CodMantenimiento.Enabled = false;

            Btn_Guardar.Enabled = true;
            Btn_Cancelar.Enabled = true;
            Btn_Eliminar.Enabled = false;
            Btn_Datos.Enabled = false;
            Btn_Nuevo.Enabled = false;
            Btn_Editar.Enabled = true;
        }

        private void ClearForm()
        {

            txt_buscar.Select();

            //Cajas De Texto
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = "";
                }
            }

            //Cajas De MaskedTexbox
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is MaskedTextBox)
                {
                    ctrl.Text = "";
                }
            }

            //ComboBox
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is ComboBox)
                {
                    ctrl.Text = "";
                }
            }

            //DateTimePicker
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is DateTimePicker)
                {
                    ctrl.ResetText();
                }
            }

            GetCmb();
        }

        public void Registros()
        {
            string procedimiento, Usuario, indicador, values;

            if (DataUser.ROLE == "Administrador" || DataUser.ROLE == "Supervisor Residencial")
            {
                procedimiento = "[sp_Mantenimiento]";
                indicador = "7";
                Usuario = DataUser.USERNAME;
                values = "'','','','','',''";
                MC.ListarMantenimientos(procedimiento, indicador, values, Usuario);
                dgv_registros.DataSource = MantenimientoModel.ListarMantenimientos;
                Data();
            }
            else
            {
                procedimiento = "[sp_Mantenimiento]";
                indicador = "6";
                Usuario = DataUser.USERNAME;
                values = "'','','','','','" + Usuario + "'";
                MC.ListarMantenimientos(procedimiento, indicador, values, Usuario);
                dgv_registros.DataSource = MantenimientoModel.ListarMantenimientos;
                Data();
            }
        }
        public void Data()
        {
            string procedimiento, Usuario, indicador, values;
            if (DataUser.ROLE == "Administrador" || DataUser.ROLE == "Supervisor Residencial")
            {
                procedimiento = "[sp_Mantenimiento]";
                indicador = "7";
                Usuario = DataUser.USERNAME;
                values = "'','','','','',''";
                MC.ListarMantenimientos2(procedimiento, indicador, values, Usuario);
                dgv_Data.DataSource = MantenimientoModel.Data;
            }
            else
            {
                procedimiento = "[sp_Mantenimiento]";
                indicador = "4";
                Usuario = DataUser.USERNAME;
                values = "'','','','','','" + Usuario + "'";
                MC.ListarMantenimientos2(procedimiento, indicador, values, Usuario);
                dgv_Data.DataSource = MantenimientoModel.Data;
            }
           
        }

        public void Enviarcorreo()
        {
            string CuerpoCorreo = "LISTADO DE MANTENIMIENTO" + "<br>" + "<br>";
            CuerpoCorreo = CuerpoCorreo + "<table border= '1' cellpadding= '5' cellspacing='0'>";
            CuerpoCorreo = CuerpoCorreo + "<thead>";
            CuerpoCorreo = CuerpoCorreo + "<tr style='' background: blue; color: White; fontweight: bold;''>";
            CuerpoCorreo = CuerpoCorreo + "<th>Cod_Orden_Mant</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Nombre_Cliente</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Fecha_Mantenimiento</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Empleado</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Telefono</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>FechaCreacion</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>UsuarioCreacion</th>";
            CuerpoCorreo = CuerpoCorreo + "</tr>";
            CuerpoCorreo = CuerpoCorreo + "</thead>";
            CuerpoCorreo = CuerpoCorreo + "<tbody>";
            foreach (DataGridViewRow Fila in dgv_registros.Rows)
            {
                CuerpoCorreo = CuerpoCorreo + "<tr>";
                CuerpoCorreo = CuerpoCorreo + "<td>" + Fila.Cells[0].Value.ToString() + "</td>";
                CuerpoCorreo = CuerpoCorreo + "<td>" + Fila.Cells[1].Value.ToString() + "</td>";
                CuerpoCorreo = CuerpoCorreo + "<td>" + Fila.Cells[2].Value.ToString() + "</td>";
                CuerpoCorreo = CuerpoCorreo + "<td>" + Fila.Cells[3].Value.ToString() + "</td>";
                CuerpoCorreo = CuerpoCorreo + "<td>" + Fila.Cells[4].Value.ToString() + "</td>";
                CuerpoCorreo = CuerpoCorreo + "<td>" + Fila.Cells[5].Value.ToString() + "</td>";
                CuerpoCorreo = CuerpoCorreo + "<td>" + Fila.Cells[6].Value.ToString() + "</td>";

                CuerpoCorreo = CuerpoCorreo + "</tr>";
            }
            CuerpoCorreo = CuerpoCorreo + "</tbody>";
            CuerpoCorreo = CuerpoCorreo + "</table>";
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(DataUser.CORREO));
            //-------------------------------------------------------------
            email.From = new MailAddress("LeonardoMolinaEnvia@outlook.com", "REPORTE DE MANTENIMIENTO");
            email.Subject = "LISTADO DE MANTENIMIENTO ";
            email.Body = CuerpoCorreo;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp-mail.outlook.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("LeonardoMolinaEnvia@outlook.com", "123456ann");

            smtp.Send(email);
            email.Dispose();
        }

        void ExportarExcel()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


            for (int i = 1; i < dgv_registros.Columns.Count + 1; i++)
            {
                xlWorkSheet.Cells[1, i] = dgv_registros.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i <= dgv_registros.RowCount - 1; i++)
            {
                for (int j = 0; j <= dgv_registros.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dgv_registros[j, i];
                    xlWorkSheet.Cells[i + 2, j + 1] = dgv_registros.Rows[i].Cells[j].Value.ToString();
                }
            }

            xlWorkBook.SaveAs("Reporte_Mantenimiento.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            MessageBox.Show("Guardado en documentos");
        }

        void ExportarPdf()
        {
            if (dgv_registros.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "Lista_Mantenimiento.pdf";
                bool ErrorMessage = false;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage = true;
                            MessageBox.Show("Unable to wride data in disk" + ex.Message);
                        }
                    }
                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable pTable = new PdfPTable(dgv_registros.Columns.Count);
                            pTable.DefaultCell.Padding = 5;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_CENTER;
                            float[] widths = new float[] { 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f };
                            pTable.SetWidths(widths);
                            iTextSharp.text.Font font = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, BaseColor.Black);
                            iTextSharp.text.Font font2 = FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, BaseColor.Black);
                            foreach (DataGridViewColumn col in dgv_registros.Columns)
                            {
                                PdfPCell cell = new PdfPCell(); //create object from the pdfpcell
                                cell.BackgroundColor = BaseColor.White;//set color of cells
                                cell.AddElement(new Chunk(col.HeaderText.ToUpper(), font));
                                pTable.AddCell(cell);
                            }
                            foreach (DataGridViewRow viewRow in dgv_registros.Rows)
                            {
                                foreach (DataGridViewCell dcell in viewRow.Cells)
                                {
                                    PdfPCell cell = new PdfPCell(); //create object from the pdfpcell
                                    cell.BackgroundColor = BaseColor.White;//set color of cells
                                    cell.AddElement(new Chunk(dcell.Value.ToString(), font2));
                                    pTable.AddCell(cell);
                                }
                            }
                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.Letter, 8f, 16f, 16f, 8f);
                                PdfWriter.GetInstance(document, fileStream);
                                document.Open();
                                document.Add(pTable);
                                document.Close();
                                fileStream.Close();
                            }
                            MessageBox.Show("Documento guardado", "Atencion");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hubo un error" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record Found", "Info");
            }
        }

        public new void Update()
        {
            if (H.MsgQuestion("¿Desea Actualizar Este Producto?") == "S")
            {
                Seteo();
                string procedimiento, indicador, values;
                procedimiento = "[sp_Mantenimiento]";
                indicador = "2";
                values = "'" + MM.Cod_Orden_Mant + "','" + MM.Cod_Cliente + "','" + MM.Fecha_Mantenimiento + "','" + MM.Cod_Empleado + "','" + MM.Telefono + "','" + MM.UsuarioCreacion + "','" + MM.UsuarioModificacion + "'";
                SE.ActualizarDatos(procedimiento, indicador, values);
                dgv_registros.DataSource = MantenimientoModel.ListarMantenimientos;
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

        private void Busqueda()
        {

            if (rbn_Nombre.Checked == true)
            {
                MantenimientoModel.ListarMantenimientos.DefaultView.RowFilter = $"Nombre_Cliente like '%{txt_buscar.Text}%'";
            }
            else if (rbn_Empleado.Checked == true)
            {
                MantenimientoModel.ListarMantenimientos.DefaultView.RowFilter = $"Nombre_Empleado like '%{txt_buscar.Text}%'";
            }
        }

        private void Deleteall()
        {
            Seteo();
            string Procedimiento = "[sp_Mantenimiento]";
            string indicador = "3";
            string id = "'" + MM.Cod_Orden_Mant + "'";
            string values = "'','','','','',''";

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
                Deleteall();
            }
        }

        private void dgv_registros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string Cod_Cliente, Cod_Empleado;

            if (dgv_registros.SelectedRows.Count > 0)
            {
                Nuevo();
                Btn_Nuevo.Enabled = false;
                Txt_CodMantenimiento.Text = dgv_registros.CurrentRow.Cells["Cod_Orden_Mant"].Value.ToString();
                Dtp_FechaMantenimiento.Text = dgv_registros.CurrentRow.Cells["Fecha_Mantenimiento"].Value.ToString();
                Txt_Celular.Text = dgv_registros.CurrentRow.Cells["Telefono"].Value.ToString();
                Cod_Cliente = dgv_registros.CurrentRow.Cells["Nombre_Cliente"].Value.ToString();
                Cod_Empleado = dgv_registros.CurrentRow.Cells["Nombre_Empleado"].Value.ToString();


                Btn_Editar.Enabled = true;
                Btn_Eliminar.Enabled = true;
                Btn_Guardar.Enabled = false;

                //Datos De ComboBox
                DataTable ID = new DataTable();

                //ComboBox Empleado
                ID = D.Find("Empleados", "*", "Nombre_Empleado='" + Cod_Empleado + "'");

                if (ID.Rows.Count > 0)
                {
                    DataRow info = ID.Rows[0];
                    Cmb_Empleado.Text = info["Nombre_Empleado"].ToString();
                }

                //ComboBox Paquetes
                ID = D.Find("Clientes", "*", "Nombre_Cliente='" + Cod_Cliente + "'");

                if (ID.Rows.Count > 0)
                {
                    DataRow info = ID.Rows[0];
                    Cmb_Cliente.Text = info["Nombre_Cliente"].ToString();
                }
                ID.Dispose();
            }
        }

        private void correoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de enviar la informacion?", "Sistma", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Frm_Correo Correo = new Frm_Correo();
                Correo.ShowDialog();

                Enviarcorreo();
                MessageBox.Show("Registro Enviado Exitosamente");
            }
            else
            {
                StarForm();
                Registros();
                txt_buscar.Clear();
                txt_buscar.Select();
            }
        }

        private void exportarPorPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Desea exportar a PDF", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (r == DialogResult.Yes)
            {
                ExportarPdf();
            }
            else
            {
                return;
            }
        }

        private void exportarPorExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Desea exportar a Excel", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (r == DialogResult.Yes)
            {
                ExportarExcel();
            }
            else
            {
                return;
            }
        }
    }
}
