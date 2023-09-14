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
    public partial class Frm_ProspectosClientes : Form
    {
        //Clases A Utilizar
        Helpers H = new Helpers();
        DataBase D = new DataBase();
        System_Data SE = new System_Data();
        ProspectosController PC = new ProspectosController();
        ClientesProspectosModel CPM;
        DataUser U = new DataUser();

        //Variables Universales
        int errors = 0;
        public Frm_ProspectosClientes()
        {
            InitializeComponent();
        }

        private void Frm_ProspectosClientes_Load(object sender, EventArgs e)
        {
            StarForm();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Guardar();
            StarForm();
            Registros();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
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
                procedimiento = "[sp_ClientesProspectos]";
                indicador = "1";
                values = "'" + CPM.Cod_Cliente_Prospecto + "','" + CPM.Nombre + "','" + CPM.Cod_Paquete + "','" + CPM.Fecha_Estimada_Contratar + "','"+CPM.Celular+"','" + CPM.Cod_Empleado + "','" + CPM.UsuarioCreacion + "',NULL";
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
            Cmb_Paquete.DataSource = D.Find("Paquetes", "*", "", "Paquete");
            Cmb_Paquete.ValueMember = "Cod_Paquete";
            Cmb_Paquete.DisplayMember = "Paquete";
            Cmb_Paquete.SelectedIndex = -1;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
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
            CPM = new ClientesProspectosModel();
            CPM.Cod_Cliente_Prospecto = int.Parse(Txt_CodProspecto.Text);
            CPM.Nombre = Txt_Nombre.Text;
            CPM.Fecha_Estimada_Contratar = Dtp_FechaEstimada.Value;
            CPM.Celular = Txt_Celular.Text;
            CPM.FechaCreacion = DateTime.Today;
            CPM.UsuarioCreacion = DataUser.USERNAME;
            CPM.FechaModificacion = DateTime.Today;
            CPM.UsuarioModificacion = DataUser.USERNAME;


            //Almacenado De Datos De Los ComboBox
            DataTable Busqueda = new DataTable();

            //ComboBox Paquetes
            Busqueda = D.Find("Paquetes", "*", "Paquete='" + Cmb_Paquete.Text + "'");

            if (Busqueda.Rows.Count > 0)
            {
                DataRow DATOS = Busqueda.Rows[0];
                if (Cmb_Paquete.Text == (DATOS["Paquete"].ToString()))
                {
                    CPM.Cod_Paquete = int.Parse((DATOS["Cod_Paquete"].ToString()));
                }
            }

            //ComboBox Empleado
            Busqueda = D.Find("Empleados", "*", "Nombre_Empleado='" + Cmb_Empleado.Text + "'");

            if (Busqueda.Rows.Count > 0)
            {
                DataRow DATOS = Busqueda.Rows[0];
                if (Cmb_Empleado.Text == (DATOS["Nombre_Empleado"].ToString()))
                {
                    CPM.Cod_Empleado = int.Parse((DATOS["Cod_Empleado"].ToString()));
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
                Reportes.Frm_Reporteria Reporte = new Reportes.Frm_Reporteria(5);
                Reporte.Show();
            }
        }

        public Boolean Validando()
        {
            Boolean Valida = true;

            if (string.IsNullOrEmpty(Txt_Nombre.Text))
            {
                MessageBox.Show("El campo Nombre Del Cliente no puede quedar vacio");
                Txt_Nombre.Focus();
                Valida = false;
            }
            else if (string.IsNullOrEmpty(Txt_Celular.Text))
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
            columns = "Cod_Cliente_Prospecto";
            table = "Clientes_Prospectos";
            Busqueda = D.GetNextID(columns, table, "");
            Txt_CodProspecto.Text = Busqueda.ToString();

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
            Txt_CodProspecto.Enabled = false;

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
                procedimiento = "[sp_ClientesProspectos]";
                indicador = "7";
                Usuario = DataUser.USERNAME;
                values = "'','','','','','',''";
                PC.ListarProspectos(procedimiento, indicador, values, Usuario);
                dgv_registros.DataSource = ClientesProspectosModel.ListarProspectos;
                Data();
            }
            else
            {
                procedimiento = "[sp_ClientesProspectos]";
                indicador = "6";
                Usuario = DataUser.USERNAME;
                values = "'','','','','','','" + Usuario + "'";
                PC.ListarProspectos(procedimiento, indicador, values, Usuario);
                dgv_registros.DataSource = ClientesProspectosModel.ListarProspectos;
                Data();
            }

        }
        public void Data()
        {
            string procedimiento, Usuario, indicador, values;

            if (DataUser.ROLE == "Administrador" || DataUser.ROLE == "Supervisor Residencial")
            {
                procedimiento = "[sp_ClientesProspectos]";
                indicador = "7";
                Usuario = DataUser.USERNAME;
                values = "'','','','','','',''";
                PC.ListarProspectos2(procedimiento, indicador, values, Usuario);
                dgv_Data.DataSource = ClientesProspectosModel.Data;
            }
            else
            {
                procedimiento = "[sp_ClientesProspectos]";
                indicador = "4";
                Usuario = DataUser.USERNAME;
                values = "'','','','','','','" + Usuario + "'";
                PC.ListarProspectos2(procedimiento, indicador, values, Usuario);
                dgv_Data.DataSource = ClientesProspectosModel.Data;
            }

        }

        public void Enviarcorreo()
        {
            string CuerpoCorreo = "LISTADO DE PROSPECTOS" + "<br>" + "<br>";
            CuerpoCorreo = CuerpoCorreo + "<table border= '1' cellpadding= '5' cellspacing='0'>";
            CuerpoCorreo = CuerpoCorreo + "<thead>";
            CuerpoCorreo = CuerpoCorreo + "<tr style='' background: blue; color: White; fontweight: bold;''>";
            CuerpoCorreo = CuerpoCorreo + "<th>Cod_Cliente_Prospecto</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Nombre</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Paquete</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Fecha_Estimada_Contratar</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Telefono</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Empleado</th>";
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
                CuerpoCorreo = CuerpoCorreo + "<td>" + Fila.Cells[7].Value.ToString() + "</td>";

                CuerpoCorreo = CuerpoCorreo + "</tr>";
            }
            CuerpoCorreo = CuerpoCorreo + "</tbody>";
            CuerpoCorreo = CuerpoCorreo + "</table>";
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(DataUser.CORREO));
            //-------------------------------------------------------------
            email.From = new MailAddress("LeonardoMolinaEnvia@outlook.com", "REPORTE DE PROSPECTOS");
            email.Subject = "LISTADO DE PROSPECTOS ";
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

            xlWorkBook.SaveAs("Reporte_Prospectos.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
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
                save.FileName = "Lista_Prospectos.pdf";
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
                            float[] widths = new float[] { 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f , 80f };
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
                procedimiento = "[sp_ClientesProspectos]";
                indicador = "2";
                values = "'" + CPM.Cod_Cliente_Prospecto + "','" + CPM.Nombre + "','" + CPM.Cod_Paquete + "','" + CPM.Fecha_Estimada_Contratar + "','" + CPM.Celular + "','" + CPM.Cod_Empleado + "','" + CPM.UsuarioCreacion + "','" + CPM.UsuarioModificacion + "'";
                SE.ActualizarDatos(procedimiento, indicador, values);
                dgv_registros.DataSource = ClientesProspectosModel.ListarProspectos;
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
                ClientesProspectosModel.ListarProspectos.DefaultView.RowFilter = $"Nombre like '%{txt_buscar.Text}%'";
            }
            else if (rbn_Empleado.Checked == true)
            {
                ClientesProspectosModel.ListarProspectos.DefaultView.RowFilter = $"Nombre_Empleado like '%{txt_buscar.Text}%'";
            }
        }

        private void Deleteall()
        {
            Seteo();
            string Procedimiento = "[sp_ClientesProspectos]";
            string indicador = "3";
            string id = "'" + CPM.Cod_Cliente_Prospecto + "'";
            string values = "'','','','','','',''";

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
            string Cod_Paquete, Cod_Empleado;

            if (dgv_registros.SelectedRows.Count > 0)
            {
                Nuevo();
                Btn_Nuevo.Enabled = false;
                Txt_CodProspecto.Text = dgv_registros.CurrentRow.Cells["Cod_Cliente_Prospecto"].Value.ToString();
                Txt_Nombre.Text = dgv_registros.CurrentRow.Cells["Nombre"].Value.ToString();
                Dtp_FechaEstimada.Text = dgv_registros.CurrentRow.Cells["Fecha_Estimada_Contratar"].Value.ToString();
                Txt_Celular.Text = dgv_registros.CurrentRow.Cells["Celular"].Value.ToString();
                Cod_Paquete = dgv_registros.CurrentRow.Cells["Paquete"].Value.ToString();
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
                ID = D.Find("Paquetes", "*", "Paquete='" + Cod_Paquete + "'");

                if (ID.Rows.Count > 0)
                {
                    DataRow info = ID.Rows[0];
                    Cmb_Paquete.Text = info["Paquete"].ToString();
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

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
