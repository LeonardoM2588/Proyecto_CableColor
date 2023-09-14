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
    public partial class Frm_Paquetes : Form
    {

        //Clases A Utilizar
        Helpers H = new Helpers();
        DataBase D = new DataBase();
        System_Data SE = new System_Data();
        PaquetesController PC = new PaquetesController();
        PaquetesModel PM;
        DataUser U = new DataUser();

        //Variables Universales
        int errors = 0;
        public Frm_Paquetes()
        {
            InitializeComponent();
        }

        private void Frm_Paquetes_Load(object sender, EventArgs e)
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
                procedimiento = "[sp_Paquetes]";
                indicador = "1";
                values = "'" + PM.Cod_Paquete + "','" + PM.Cod_TipoPaquete + "','" + PM.Paquete + "','" + PM.Precio_Paquete + "','" + PM.Estado + "'";
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
            cmb_TiposPaquetes.DataSource = D.Find("Tipo_Paquete", "*", "", "Tipo_Paquete");
            cmb_TiposPaquetes.ValueMember = "Cod_TipoPaquete";
            cmb_TiposPaquetes.DisplayMember = "Tipo_Paquete";
            cmb_TiposPaquetes.SelectedIndex = -1;
        }

        private void Btn_Editar_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void Btn_Regresar_Click(object sender, EventArgs e)
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

            PM = new PaquetesModel();
            PM.Cod_Paquete = int.Parse(Txt_Cod_Paquetes.Text);
            PM.Paquete = Txt_Paquetes.Text;
            PM.Precio_Paquete = Txt_Precio.Text;

            //datos del cmb
            DataTable Busqueda = new DataTable();
            Busqueda = D.Find("Tipo_Paquete", "*", "Tipo_Paquete='" + cmb_TiposPaquetes.Text + "'");

            if (Busqueda.Rows.Count > 0)
            {
                DataRow DATOS = Busqueda.Rows[0];
                if (cmb_TiposPaquetes.Text == (DATOS["Tipo_Paquete"].ToString()))
                {
                    PM.Cod_TipoPaquete = int.Parse((DATOS["Cod_TipoPaquete"].ToString()));
                }
            }

            //datos del checkbox
            if (Check_Estado.Checked == true)
            {
                PM.Estado = true;
            }
            else
            {
                PM.Estado = false;
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
                Reportes.Frm_Reporteria Reporte = new Reportes.Frm_Reporteria(2);
                Reporte.Show();
            }
        }


        public Boolean Validando()
        {
            Boolean Valida = true;

            if (string.IsNullOrEmpty(Txt_Paquetes.Text))
            {
                MessageBox.Show("El campo Paquete no puede quedar vacio");
                Txt_Paquetes.Focus();
                Valida = false;
            }
            else
            {
                if (string.IsNullOrEmpty(Txt_Precio.Text))
                {
                    MessageBox.Show("El campo Precio no puede quedar vacio");
                    Txt_Precio.Focus();
                    Valida = false;
                }

            }
            return Valida;
        }

        private void StarForm()
        {
            txt_buscar.Select();
            Registros();

            Txt_Cod_Paquetes.Enabled = false;
            Txt_Paquetes.Enabled = false;
            Txt_Precio.Enabled = false;
            Check_Estado.Enabled = false;

            cmb_TiposPaquetes.Enabled = false;

            lbl_Mensaje.Visible = false;
            Check_Estado.Enabled = false;

            //Botones Principales
            Btn_Regresar.Enabled = true;

            Btn_Guardar.Enabled = false;
            Btn_Cancelar.Enabled = false;
            Btn_Eliminar.Enabled = false;
            Btn_Datos.Enabled = true;
            Btn_Papelera.Enabled = true;
            Btn_Nuevo.Enabled = true;
            Btn_Editar.Enabled = false;
            Btn_Destruir.Visible = false;
            Btn_Restaurar.Visible = false;

            Lbl_Registros.Text = dgv_registros.Rows.Count.ToString();
            dgv_registros.DefaultCellStyle.ForeColor = Color.Black;
            Lbl_Registros.ForeColor = Color.Black;
            Btn_Papelera.Text = "Papelera";
        }

        private void Btn_Papelera_Click(object sender, EventArgs e)
        {
            Papelera();
        }

        private void Nuevo()
        {
            ClearForm();
            string Busqueda;
            string columns, table;
            columns = "Cod_Paquete";
            table = "Paquetes";
            Busqueda = D.GetNextID(columns, table, "");
            Txt_Cod_Paquetes.Text = Busqueda.ToString();

            GetCmb();
            Txt_Cod_Paquetes.Enabled = false;
            Txt_Paquetes.Enabled = true;
            Txt_Precio.Enabled = true;
            Check_Estado.Enabled = true;

            cmb_TiposPaquetes.Enabled = true;

            lbl_Mensaje.Visible = false;
            Check_Estado.Checked = true;
            Check_Estado.Enabled = true;

            //Botones Principales
            Btn_Regresar.Enabled = false;

            Btn_Guardar.Enabled = true;
            Btn_Cancelar.Enabled = true;
            Btn_Eliminar.Enabled = false;
            Btn_Datos.Enabled = false;
            Btn_Papelera.Enabled = false;
            Btn_Nuevo.Enabled = false;
            Btn_Editar.Enabled = true;
        }

        private void Btn_Restaurar_Click(object sender, EventArgs e)
        {
            if (H.MsgQuestion("¿Desea Restaurar Este Objeto?") == "S")
            {
                Restaurar();
            }
        }

        private void Btn_Destruir_Click(object sender, EventArgs e)
        {
            if (H.MsgQuestion("ELIMINAR INFORMACION DE LA BASE DE DATOS ES UNA OPERACION IRREVERSIBLE Y NO SE RECOMIENDA!\n\n" + "¿DESEA CONTINUAR Y ELIMINAR DEFINITIVAMENTE DE LA BASE DE DATOS EL REGISTRO SELECCIONADO?") == "S")
            {
                Deleteall();
            }
        }

        private void ClearForm()
        {

            txt_buscar.Select();
            Txt_Cod_Paquetes.Clear();
            Txt_Paquetes.Clear();
            Txt_Precio.Clear();
            cmb_TiposPaquetes.Text = "";

            GetCmb();
            lbl_Mensaje.Visible = false;
            Check_Estado.Enabled = false;
            Check_Estado.Checked = false;
        }

        public void Registros()
        {
            string procedimiento, Estado, indicador, values;
            procedimiento = "[sp_Paquetes]";
            indicador = "6";
            Estado = "true";
            values = "'','','','"+Estado+"'";
            PC.ListarPaquetes(procedimiento, indicador, values, Estado);
            dgv_registros.DataSource = PaquetesModel.ListarPaquetes;
            Data();
        }
        public void Data()
        {
            string procedimiento, Estado, indicador, values;
            procedimiento = "[sp_Paquetes]";
            indicador = "4";
            Estado = "true";
            values = "'','','','" + Estado + "'";
            PC.ListarPaquetes2(procedimiento, indicador, values, Estado);
            dgv_Data.DataSource = PaquetesModel.Data;
        }

        public void Enviarcorreo()
        {
            string CuerpoCorreo = "LISTADO DE PAQUETES" + "<br>" + "<br>";
            CuerpoCorreo = CuerpoCorreo + "<table border= '1' cellpadding= '5' cellspacing='0'>";
            CuerpoCorreo = CuerpoCorreo + "<thead>";
            CuerpoCorreo = CuerpoCorreo + "<tr style='' background: blue; color: White; fontweight: bold;''>";
            CuerpoCorreo = CuerpoCorreo + "<th>Cod_Paquete</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Tipo_Paquetes</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Paquete</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Precio_Paquete</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Estado</th>";
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

                CuerpoCorreo = CuerpoCorreo + "</tr>";
            }
            CuerpoCorreo = CuerpoCorreo + "</tbody>";
            CuerpoCorreo = CuerpoCorreo + "</table>";
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(DataUser.CORREO));
            //-------------------------------------------------------------
            email.From = new MailAddress("LeonardoMolinaEnvia@outlook.com", "REPORTE DE USUARIOS");
            email.Subject = "LISTADO DE USUARIOS ";
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

            xlWorkBook.SaveAs("Reporte_Paquetes.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
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
                save.FileName = "Lista_Paquetes.pdf";
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
                            float[] widths = new float[] { 80f, 80f, 80f, 80f, 80f };
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

        private void Papelera()
        {
            if (Btn_Papelera.Text == "Volver")
            {
                ClearForm();
                StarForm();
                Registros();
                Btn_Papelera.Text = "Papelera";
            }
            else if (Btn_Papelera.Text == "Papelera")
            {
                if (H.MsgQuestion("¿Desea revisar los registros borrados?") == "S")
                {
                    DataTable Papelera = new DataTable();
                    Papelera = D.Find("Paquetes", "*", "Estado='False'");

                    if (Papelera.Rows.Count > 0)
                    {
                        string procedimiento, Estado, indicador, values;
                        procedimiento = "[sp_Paquetes]";
                        indicador = "6";
                        Estado = "False";
                        values = "'','','','" + Estado + "'";
                        PC.ListarPaquetes(procedimiento, indicador, values, Estado);
                        dgv_registros.DataSource = PaquetesModel.ListarPaquetes;
                        dgv_registros.DefaultCellStyle.ForeColor = Color.Red;
                        Lbl_Registros.Text = dgv_registros.Rows.Count.ToString();
                        Lbl_Registros.ForeColor = Color.Red;
                        Btn_Papelera.Text = "Volver";
                    }
                    else
                    {
                        H.MsgWarning("No Existen Registros Eliminados!");
                        Btn_Papelera.Text = "Papelera";
                        StarForm();
                        Registros();
                    }
                    Papelera.Dispose();
                }
            }

        }

        public new void Update()
        {
            if (H.MsgQuestion("¿Desea Actualizar Este Producto?") == "S")
            {
                Seteo();
                string procedimiento, indicador, values;
                procedimiento = "[sp_Paquetes]";
                indicador = "2";
                values = "'" + PM.Cod_Paquete + "','" + PM.Cod_TipoPaquete + "','" + PM.Paquete + "','" + PM.Precio_Paquete + "','" + PM.Estado + "'";
                SE.ActualizarDatos(procedimiento, indicador, values);
                dgv_registros.DataSource = PaquetesModel.ListarPaquetes;
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

        public void Restaurar()
        {
            Seteo();
            if (D.Update("Paquetes", "Estado='true'", "Cod_Paquete='" + PM.Cod_Paquete + "'") > 0)
            {
                H.MsgSuccess("Registro Restaurado Con Exito!");
                ClearForm();
                StarForm();
                Registros();
            }
        }

        public void Delete()
        {
            Seteo();
            if (D.Update("Paquetes", "Estado='false'", "Cod_Paquete='" + PM.Cod_Paquete + "'") > 0)
            {
                H.MsgSuccess("Registro Eliminado Con Exito!");
                ClearForm();
                StarForm();
                Registros();
            }
        }

        private void Busqueda()
        {

            if (rbn_nombre.Checked == true)
            {
                PaquetesModel.ListarPaquetes.DefaultView.RowFilter = $"Paquete like '%{txt_buscar.Text}%'";
            }
        }

        private void Deleteall()
        {
            Seteo();
            string Procedimiento = "[sp_Paquetes]";
            string indicador = "3";
            string id = "'" + PM.Cod_Paquete + "'";
            string values = "'','','',''";

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
            string Estado, Cod_TipoPaquete;

            if (dgv_registros.SelectedRows.Count > 0)
            {
                Nuevo();
                Btn_Nuevo.Enabled = false;
                Txt_Cod_Paquetes.Text = dgv_registros.CurrentRow.Cells["Cod_Paquete"].Value.ToString();
                Txt_Paquetes.Text = dgv_registros.CurrentRow.Cells["Paquete"].Value.ToString();
                Txt_Precio.Text = dgv_registros.CurrentRow.Cells["Precio_Paquete"].Value.ToString();

                Cod_TipoPaquete = dgv_registros.CurrentRow.Cells["Tipo_Paquetes"].Value.ToString();

                Btn_Editar.Enabled = true;
                Btn_Eliminar.Enabled = true;
                Btn_Guardar.Enabled = false;

                Estado = dgv_registros.CurrentRow.Cells["Estado"].Value.ToString();
                if (Estado == "True")
                {
                    Check_Estado.Checked = true;
                }
                else if (Estado == "False")
                {
                    Check_Estado.Checked = false;
                    Check_Estado.Enabled = false;
                    lbl_Mensaje.Visible = true;
                    Btn_Restaurar.Visible = true;
                    Btn_Destruir.Visible = true;
                    Btn_Guardar.Enabled = false;
                    Btn_Eliminar.Enabled = false;
                }

                DataTable ID = new DataTable();
                ID = D.Find("Tipo_Paquete", "*", "Tipo_Paquete='" + Cod_TipoPaquete + "'");

                if (ID.Rows.Count > 0)
                {
                    DataRow info = ID.Rows[0];
                    cmb_TiposPaquetes.Text = info["Tipo_Paquete"].ToString();
                }

                ID.Dispose();
            }
        }

        private void correoToolStripMenuItem_Click_1(object sender, EventArgs e)
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
    }
}
