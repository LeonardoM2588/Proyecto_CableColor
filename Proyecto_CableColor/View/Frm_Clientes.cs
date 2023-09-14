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
    public partial class Frm_Clientes : Form
    {
        //Clases A Utilizar
        Helpers H = new Helpers();
        DataBase D = new DataBase();
        System_Data SE = new System_Data();
        ClientesController CC = new ClientesController();
        ClientesModel CM;
        DataUser U = new DataUser();

        //Variables Universales
        int errors = 0;
        public Frm_Clientes()
        {
            InitializeComponent();
        }

        private void Frm_Clientes_Load(object sender, EventArgs e)
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
        //Metodo De Guardado    
        private void Guardar()
        {
            if (errors == 0)
            {
                Validando();
                Seteo();
                string procedimiento, values, indicador;
                procedimiento = "[sp_Clientes]";
                indicador = "1";
                values = "'" + CM.Cod_Cliente + "','" + CM.Nombre_Cliente + "','" + CM.Identidad_Cliente + "','" + CM.Celular + "','" + CM.Fecha_Nacimiento + "','" + CM.Cod_Genero + "','" + CM.Cod_EstadoCivil + "','" + CM.Cod_Nacionalidad + "','" + CM.IDSECTOR + "','" + CM.Referencia_Direccion + "','" + CM.Referencia_Personal + "','" + CM.Numero_Referencia + "','" + CM.Cod_Paquete + "','" + CM.Contrato_Anual + "','" + CM.Observacion + "','" + CM.Contrato_Fisico + "','" + CM.Factura_Fisica + "','" + CM.Fecha_Maxima_Pago + "','" + CM.Vendedor + "','" + CM.Fecha_Elaborado + "','" + CM.Estado + "',NULL,'" + CM.UsuarioCreacion + "'";
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
            //Get Genero
            Cmb_Genero.DataSource = D.Find("Generos", "*", "", "Genero");
            Cmb_Genero.ValueMember = "Cod_Genero";
            Cmb_Genero.DisplayMember = "Genero";
            Cmb_Genero.SelectedIndex = -1;

            //Get Estado Civil
            Cmb_EstadoCivil.DataSource = D.Find("Estado_Civil", "*", "", "Estado_Civil");
            Cmb_EstadoCivil.ValueMember = "Cod_EstadoCivil";
            Cmb_EstadoCivil.DisplayMember = "Estado_Civil";
            Cmb_EstadoCivil.SelectedIndex = -1;

            //Get Sector
            Cmb_Sector.DataSource = D.Find("Sector", "*", "", "SECTOR");
            Cmb_Sector.ValueMember = "IDSECTOR";
            Cmb_Sector.DisplayMember = "SECTOR";
            Cmb_Sector.SelectedIndex = -1;

            //Get Nacionalidad
            Cmb_Nacionalidad.DataSource = D.Find("Nacionalidad", "*", "", "Nacionalidad");
            Cmb_Nacionalidad.ValueMember = "Cod_Nacionalidad";
            Cmb_Nacionalidad.DisplayMember = "Nacionalidad";
            Cmb_Nacionalidad.SelectedIndex = -1;

            //Get Paquete
            Cmb_Paquete.DataSource = D.Find("Paquetes", "*", "", "Paquete");
            Cmb_Paquete.ValueMember = "Cod_Paquete";
            Cmb_Paquete.DisplayMember = "Paquete";
            Cmb_Paquete.SelectedIndex = -1;
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
            CM = new ClientesModel();
            CM.Cod_Cliente = int.Parse(Txt_CodCliente.Text);
            CM.Nombre_Cliente = Txt_NombreCliente.Text;
            CM.Identidad_Cliente = Txt_IdentidadCliente.Text;
            CM.Celular = Txt_CelularCliente.Text;
            CM.Fecha_Nacimiento = Dtp_FechaNacimiento.Value;
            CM.Referencia_Direccion = Txt_Direccion.Text;
            CM.Referencia_Personal = Txt_Referencia.Text;
            CM.Numero_Referencia = Txt_TelefonoReferencia.Text;
            CM.Observacion = Txt_Observacion.Text;
            CM.Contrato_Fisico = Txt_NumContrato.Text;
            CM.Factura_Fisica = Txt_NumFactura.Text;
            CM.Fecha_Maxima_Pago = Cmb_FechaMaximaPago.Text;
            CM.Vendedor = Txt_Vendedor.Text;
            CM.Fecha_Elaborado = Dtp_FechaElavorado.Value;
            CM.FechaCreacion = DateTime.Today;
            CM.UsuarioCreacion = DataUser.USERNAME;
            CM.FechaModificacion = DateTime.Today;
            CM.UsuarioModificacion = DataUser.USERNAME;


            //Almacenado De Datos De Los ComboBox
            DataTable Busqueda = new DataTable();

            //ComboBox Genero
            Busqueda = D.Find("Generos", "*", "Genero='" + Cmb_Genero.Text + "'");

            if (Busqueda.Rows.Count > 0)
            {
                DataRow DATOS = Busqueda.Rows[0];
                if (Cmb_Genero.Text == (DATOS["Genero"].ToString()))
                {
                    CM.Cod_Genero = int.Parse((DATOS["Cod_Genero"].ToString()));
                }
            }

            //ComboBox Estado Civil
            Busqueda = D.Find("Estado_Civil", "*", "Estado_Civil='" + Cmb_EstadoCivil.Text + "'");

            if (Busqueda.Rows.Count > 0)
            {
                DataRow DATOS = Busqueda.Rows[0];
                if (Cmb_EstadoCivil.Text == (DATOS["Estado_Civil"].ToString()))
                {
                    CM.Cod_EstadoCivil = int.Parse((DATOS["Cod_EstadoCivil"].ToString()));
                }
            }

            //ComboBox Nacionalidad
            Busqueda = D.Find("Nacionalidad", "*", "Nacionalidad='" + Cmb_Nacionalidad.Text + "'");

            if (Busqueda.Rows.Count > 0)
            {
                DataRow DATOS = Busqueda.Rows[0];
                if (Cmb_Nacionalidad.Text == (DATOS["Nacionalidad"].ToString()))
                {
                    CM.Cod_Nacionalidad = int.Parse((DATOS["Cod_Nacionalidad"].ToString()));
                }
            }

            //ComboBox Sector
            Busqueda = D.Find("Sector", "*", "SECTOR='" + Cmb_Sector.Text + "'");

            if (Busqueda.Rows.Count > 0)
            {
                DataRow DATOS = Busqueda.Rows[0];
                if (Cmb_Sector.Text == (DATOS["SECTOR"].ToString()))
                {
                    CM.IDSECTOR = int.Parse((DATOS["IDSECTOR"].ToString()));
                }
            }

            //ComboBox Paquete
            Busqueda = D.Find("Paquetes", "*", "Paquete='" + Cmb_Paquete.Text + "'");

            if (Busqueda.Rows.Count > 0)
            {
                DataRow DATOS = Busqueda.Rows[0];
                if (Cmb_Paquete.Text == (DATOS["Paquete"].ToString()))
                {
                    CM.Cod_Paquete = int.Parse((DATOS["Cod_Paquete"].ToString()));
                }
            }


            //Almacenado De Datos De Los CheckBox

            //CheckBox Contrato Anual
            if (Check_ContratoAnual.Checked == true)
            {
                CM.Contrato_Anual = true;
            }
            else
            {
                CM.Contrato_Anual = false;
            }
            //CheckBox Estado
            if (Check_Estado.Checked == true)
            {
                CM.Estado = true;
            }
            else
            {
                CM.Estado = false;
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
                Reportes.Frm_Reporteria Reporte = new Reportes.Frm_Reporteria(3);
                Reporte.Show();
            }
        }


        public Boolean Validando()
        {
            Boolean Valida = true;

            if (string.IsNullOrEmpty(Txt_NombreCliente.Text))
            {
                MessageBox.Show("El campo Nombre Del Cliente no puede quedar vacio");
                Txt_NombreCliente.Focus();
                Valida = false;
            }
            else
            {
                if (string.IsNullOrEmpty(Txt_IdentidadCliente.Text))
                {
                    MessageBox.Show("El campo Identidad Cliente no puede quedar vacio");
                    Txt_IdentidadCliente.Focus();
                    Valida = false;
                }

                if (string.IsNullOrEmpty(Txt_CelularCliente.Text))
                {
                    MessageBox.Show("El campo Celular no puede quedar vacio");
                    Txt_CelularCliente.Focus();
                    Valida = false;
                }
                if (Dtp_FechaNacimiento.Value == DateTime.Today)
                {
                    MessageBox.Show("El campo Fecha De Nacimiento no puede tener la fecha actual");
                    Valida = false;
                }
                if (string.IsNullOrEmpty(Txt_Direccion.Text))
                {
                    MessageBox.Show("El campo Direccion no puede quedar vacio");
                    Txt_Direccion.Focus();
                    Valida = false;
                }
                if (string.IsNullOrEmpty(Txt_Referencia.Text))
                {
                    MessageBox.Show("El campo Referencia Personal no puede quedar vacio");
                    Txt_Referencia.Focus();
                    Valida = false;
                }
                if (string.IsNullOrEmpty(Txt_TelefonoReferencia.Text))
                {
                    MessageBox.Show("El campo Numero De Referencia no puede quedar vacio");
                    Txt_TelefonoReferencia.Focus();
                    Valida = false;
                }
                if (string.IsNullOrEmpty(Txt_Observacion.Text))
                {
                    MessageBox.Show("El campo Observacion no puede quedar vacio");
                    Txt_Observacion.Focus();
                    Valida = false;
                }
                if (string.IsNullOrEmpty(Txt_NumContrato.Text))
                {
                    MessageBox.Show("El campo Contrato Fisico no puede quedar vacio");
                    Txt_NumContrato.Focus();
                    Valida = false;
                }
                if (string.IsNullOrEmpty(Txt_NumFactura.Text))
                {
                    MessageBox.Show("El campo Factura Fisica no puede quedar vacio");
                    Txt_NumFactura.Focus();
                    Valida = false;
                }
                if (string.IsNullOrEmpty(Txt_Vendedor.Text))
                {
                    MessageBox.Show("El campo Vendedor no puede quedar vacio");
                    Txt_Vendedor.Focus();
                    Valida = false;
                }
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


            //MaskedTextBox
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is MaskedTextBox)
                {
                    ctrl.Enabled = false;
                }
            }

            Txt_UsuarioLogeado.Text = DataUser.USERNAME;
            Check_Estado.Enabled = false;
            Check_ContratoAnual.Enabled = false;


            //Botones Principales

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
            columns = "Cod_Cliente";
            table = "Clientes";
            Busqueda = D.GetNextID(columns, table, "");
            Txt_CodCliente.Text = Busqueda.ToString();

            GetCmb();
            //Cajas De Texto
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is TextBox)
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


            //MaskedTextBox
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is MaskedTextBox)
                {
                    ctrl.Enabled = true;
                }
            }

            Txt_UsuarioLogeado.Text = DataUser.USERNAME;
            Check_Estado.Enabled = true;
            Check_ContratoAnual.Enabled = true;

            Check_Estado.Checked = true;
            Check_Estado.Enabled = true;

            //Botones Principales

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

            //Cajas De Texto
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is TextBox)
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


            //MaskedTextBox
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is MaskedTextBox)
                {
                    ctrl.Text = "";
                }
            }

            GetCmb();
            Check_Estado.Enabled = false;
            Check_Estado.Checked = false;

            Check_ContratoAnual.Enabled = false;
            Check_ContratoAnual.Checked = false;
        }

        public void Registros()
        {
            string procedimiento, Estado, indicador, values;
            procedimiento = "[sp_Clientes]";
            indicador = "6";
            Estado = "true";
            values = "'','','','','','','','','','','','','','','','','','','','','"+Estado+"',''";
            CC.ListarClientes(procedimiento, indicador, values, Estado);
            dgv_registros.DataSource = ClientesModel.ListarClientes;
            Data();
        }
        public void Data()
        {
            string procedimiento, indicador, values, Estado;
            procedimiento = "[sp_Clientes]";
            indicador = "4";
            Estado = "true";
            values = "'','','','','','','','','','','','','','','','','','','','','" + Estado + "',''";
            CC.ListarClientes2(procedimiento, indicador, values, Estado);
            dgv_Data.DataSource = ClientesModel.Data;
        }

        public void Enviarcorreo()
        {
            string CuerpoCorreo = "LISTADO DE CLIENTES" + "<br>" + "<br>";
            CuerpoCorreo = CuerpoCorreo + "<table border= '1' cellpadding= '5' cellspacing='0'>";
            CuerpoCorreo = CuerpoCorreo + "<thead>";
            CuerpoCorreo = CuerpoCorreo + "<tr style='' background: blue; color: White; fontweight: bold;''>";
            CuerpoCorreo = CuerpoCorreo + "<th>Cod_Cliente</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Nombre_Cliente</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Identidad_Cliente</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Celular</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Paquete</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Contrato Fisico</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Factura</th>";
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
                CuerpoCorreo = CuerpoCorreo + "<td>" + Fila.Cells[12].Value.ToString() + "</td>";
                CuerpoCorreo = CuerpoCorreo + "<td>" + Fila.Cells[15].Value.ToString() + "</td>";
                CuerpoCorreo = CuerpoCorreo + "<td>" + Fila.Cells[16].Value.ToString() + "</td>";

                CuerpoCorreo = CuerpoCorreo + "</tr>";
            }
            CuerpoCorreo = CuerpoCorreo + "</tbody>";
            CuerpoCorreo = CuerpoCorreo + "</table>";
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(DataUser.CORREO));
            //-------------------------------------------------------------
            email.From = new MailAddress("LeonardoMolinaEnvia@outlook.com", "REPORTE DE CLIENTES");
            email.Subject = "LISTADO DE CLIENTES ";
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

            xlWorkBook.SaveAs("Reporte_Clientes.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
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
                save.FileName = "Lista_Clientes.pdf";
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
                            float[] widths = new float[] { 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f };
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
                    Papelera = D.Find("Clientes", "*", "Estado='False'");

                    if (Papelera.Rows.Count > 0)
                    {
                        string procedimiento, Estado, indicador, values;
                        procedimiento = "[sp_Clientes]";
                        indicador = "6";
                        Estado = "False";
                        values = "'','','','','','','','','','','','','','','','','','','','','" + Estado + "',''";
                        CC.ListarClientes(procedimiento, indicador, values,Estado);
                        dgv_registros.DataSource = ClientesModel.ListarClientes;
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
                procedimiento = "[sp_Clientes]";
                indicador = "2";
                values = "'" + CM.Cod_Cliente + "','" + CM.Nombre_Cliente + "','" + CM.Identidad_Cliente + "','" + CM.Celular + "','" + CM.Fecha_Nacimiento + "','" + CM.Cod_Genero + "','" + CM.Cod_EstadoCivil + "','" + CM.Cod_Nacionalidad + "','" + CM.IDSECTOR + "','" + CM.Referencia_Direccion + "','" + CM.Referencia_Personal + "','" + CM.Numero_Referencia + "','" + CM.Cod_Paquete + "','" + CM.Contrato_Anual + "','" + CM.Observacion + "','" + CM.Contrato_Fisico + "','" + CM.Factura_Fisica + "','" + CM.Fecha_Maxima_Pago + "','" + CM.Vendedor + "','" + CM.Fecha_Elaborado + "','" + CM.Estado + "','" + CM.UsuarioCreacion + "','" + CM.UsuarioModificacion + "'";
                SE.ActualizarDatos(procedimiento, indicador, values);
                dgv_registros.DataSource = ClientesModel.ListarClientes;
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
            if (D.Update("Clientes", "Estado='true'", "Cod_Cliente='" + CM.Cod_Cliente + "'") > 0)
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
            if (D.Update("Clientes", "Estado='false'", "Cod_Cliente='" + CM.Cod_Cliente + "'") > 0)
            {
                H.MsgSuccess("Registro Eliminado Con Exito!");
                ClearForm();
                StarForm();
                Registros();
            }
        }

        private void Busqueda()
        {

            if (rbn_Nombre.Checked == true)
            {
                ClientesModel.ListarClientes.DefaultView.RowFilter = $"Nombre_Cliente like '%{txt_buscar.Text}%'";
            }
            else if (rbn_Identidad.Checked == true)
            {
                ClientesModel.ListarClientes.DefaultView.RowFilter = $"Identidad_Cliente like '%{txt_buscar.Text}%'";
            }
            else if (rbn_Celular.Checked == true)
            {
                ClientesModel.ListarClientes.DefaultView.RowFilter = $"Celular like '%{txt_buscar.Text}%'";
            }
            else if (rbn_Factura.Checked == true)
            {
                ClientesModel.ListarClientes.DefaultView.RowFilter = $"Factura_Fisica like '%{txt_buscar.Text}%'";
            }
            else if (rbn_Contrato.Checked == true)
            {
                ClientesModel.ListarClientes.DefaultView.RowFilter = $"Contrato_Fisico like '%{txt_buscar.Text}%'";
            }
        }

        private void Deleteall()
        {
            Seteo();
            string Procedimiento = "[sp_Clientes]";
            string indicador = "3";
            string id = "'" + CM.Cod_Cliente + "'";
            string values = "'','','','','','','','','','','','','','','','','','','','','',''";

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
            string Cod_Genero, Cod_EstadoCivil, Cod_Nacionalidad, IDSECTOR, Cod_Paquete;
            string Contrato_Anual, Estado;

            if (dgv_registros.SelectedRows.Count > 0)
            {
                Nuevo();
                Btn_Nuevo.Enabled = false;
                Txt_CodCliente.Text = dgv_registros.CurrentRow.Cells["Cod_Cliente"].Value.ToString();
                Txt_NombreCliente.Text = dgv_registros.CurrentRow.Cells["Nombre_Cliente"].Value.ToString();
                Txt_IdentidadCliente.Text = dgv_registros.CurrentRow.Cells["Identidad_Cliente"].Value.ToString();
                Txt_CelularCliente.Text = dgv_registros.CurrentRow.Cells["Celular"].Value.ToString();
                Dtp_FechaNacimiento.Text = dgv_registros.CurrentRow.Cells["Fecha_Nacimiento"].Value.ToString();
                Txt_Direccion.Text = dgv_registros.CurrentRow.Cells["Referencia_Direccion"].Value.ToString();
                Txt_Referencia.Text = dgv_registros.CurrentRow.Cells["Referencia_Personal"].Value.ToString();
                Txt_TelefonoReferencia.Text = dgv_registros.CurrentRow.Cells["Numero_Referencia"].Value.ToString();
                Txt_Observacion.Text = dgv_registros.CurrentRow.Cells["Observacion"].Value.ToString();
                Txt_NumContrato.Text = dgv_registros.CurrentRow.Cells["Contrato_Fisico"].Value.ToString();
                Txt_NumFactura.Text = dgv_registros.CurrentRow.Cells["Factura_Fisica"].Value.ToString();
                Cmb_FechaMaximaPago.Text = dgv_registros.CurrentRow.Cells["Fecha_Maxima_Pago"].Value.ToString();
                Txt_Vendedor.Text = dgv_registros.CurrentRow.Cells["Vendedor"].Value.ToString();
                Dtp_FechaElavorado.Text = dgv_registros.CurrentRow.Cells["Fecha_Elaborado"].Value.ToString();

                Cod_Genero = dgv_registros.CurrentRow.Cells["Genero"].Value.ToString();
                Cod_EstadoCivil = dgv_registros.CurrentRow.Cells["Estado_Civil"].Value.ToString();
                Cod_Nacionalidad = dgv_registros.CurrentRow.Cells["Nacionalidad"].Value.ToString();
                IDSECTOR = dgv_registros.CurrentRow.Cells["Sector"].Value.ToString();
                Cod_Paquete = dgv_registros.CurrentRow.Cells["Paquete"].Value.ToString();
                Contrato_Anual = dgv_registros.CurrentRow.Cells["Contrato_Anual"].Value.ToString();
                Estado = dgv_registros.CurrentRow.Cells["Estado"].Value.ToString();


                Btn_Editar.Enabled = true;
                Btn_Eliminar.Enabled = true;
                Btn_Guardar.Enabled = false;

                //ComboBox 

                //Estado
                if (Estado == "True")
                {
                    Check_Estado.Checked = true;
                    Check_Estado.Enabled = false;
                }
                else if (Estado == "False")
                {
                    Check_Estado.Checked = false;
                    Check_Estado.Enabled = false;
                    Btn_Restaurar.Visible = true;
                    Btn_Destruir.Visible = true;
                    Btn_Guardar.Enabled = false;
                    Btn_Eliminar.Enabled = false;
                }

                //Contrato_Anual
                if (Contrato_Anual == "True")
                {
                    Check_ContratoAnual.Checked = true;
                }
                else if (Contrato_Anual == "False")
                {
                    Check_ContratoAnual.Checked = false;
                }

                //Datos De ComboBox
                DataTable ID = new DataTable();

                //ComboBox Genero
                ID = D.Find("Generos", "*", "Genero='" + Cod_Genero + "'");

                if (ID.Rows.Count > 0)
                {
                    DataRow info = ID.Rows[0];
                    Cmb_Genero.Text = info["Genero"].ToString();
                }

                //ComboBox Estado Civil
                ID = D.Find("Estado_Civil", "*", "Estado_Civil='" + Cod_EstadoCivil + "'");

                if (ID.Rows.Count > 0)
                {
                    DataRow info = ID.Rows[0];
                    Cmb_EstadoCivil.Text = info["Estado_Civil"].ToString();
                }

                //ComboBox Nacionalidad
                ID = D.Find("Nacionalidad", "*", "Nacionalidad='" + Cod_Nacionalidad + "'");

                if (ID.Rows.Count > 0)
                {
                    DataRow info = ID.Rows[0];
                    Cmb_Nacionalidad.Text = info["Nacionalidad"].ToString();
                }

                //ComboBox Sector
                ID = D.Find("Sector", "*", "SECTOR='" + IDSECTOR + "'");

                if (ID.Rows.Count > 0)
                {
                    DataRow info = ID.Rows[0];
                    Cmb_Sector.Text = info["SECTOR"].ToString();
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

        private void exportarPorPDFToolStripMenuItem_Click_1(object sender, EventArgs e)
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

        private void exportarPorExcelToolStripMenuItem_Click_1(object sender, EventArgs e)
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
