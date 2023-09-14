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
    public partial class Frm_Empleados : Form
    {
        //Clases A Utilizar
        Helpers H = new Helpers();
        DataBase D = new DataBase();
        System_Data SE = new System_Data();
        EmpleadosController EC = new EmpleadosController();
        EmpleadosModel EM;
        DataUser U = new DataUser();

        //Variables Universales
        int errors = 0;
        public Frm_Empleados()
        {
            InitializeComponent();
        }

        private void Frm_Empleados_Load(object sender, EventArgs e)
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
                procedimiento = "[sp_Empleados]";
                indicador = "1";
                values = "'" + EM.Cod_Empleado + "','" + EM.Identidad_Empleado + "','" + EM.Nombre_Empleado + "','" + EM.Edad + "','" + EM.Fecha_Nacimiento + "','" + EM.Cod_Genero + "','" + EM.Email + "','" + EM.Telefono + "','" + EM.Cod_EstadoCivil + "','" + EM.IDMUNICIPIO + "','" + EM.Num_Contador + "','" + EM.Propietario_Vivienda + "','" + EM.Cod_Cargo + "','" + EM.Cod_Turno + "','" + EM.Estado + "','" + EM.UsuarioCreacion + "',NULL";
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

            //Get Municipio
            Cmb_Municipio.DataSource = D.Find("Municipio", "*", "", "MUNICIPIO");
            Cmb_Municipio.ValueMember = "IDMUNICIPIO";
            Cmb_Municipio.DisplayMember = "MUNICIPIO";
            Cmb_Municipio.SelectedIndex = -1;

            //Get Cargo
            Cmb_Cargo.DataSource = D.Find("Cargos", "*", "", "Cargo");
            Cmb_Cargo.ValueMember = "Cod_Cargo";
            Cmb_Cargo.DisplayMember = "Cargo";
            Cmb_Cargo.SelectedIndex = -1;

            //Get Turno
            Cmb_Turno.DataSource = D.Find("Turnos", "*", "", "Turno");
            Cmb_Turno.ValueMember = "Cod_Turno";
            Cmb_Turno.DisplayMember = "Turno";
            Cmb_Turno.SelectedIndex = -1;
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
            //Estado,Propietario_Vivienda
            EM = new EmpleadosModel();
            EM.Cod_Empleado = int.Parse(Txt_CodeMPLEADO.Text);
            EM.Identidad_Empleado = Txt_IdentidadEmpleado.Text;
            EM.Nombre_Empleado = Txt_NombreEmpleado.Text;
            EM.Edad = int.Parse(Txt_Edad.Text);
            EM.Fecha_Nacimiento = Dtp_FechaNacimiento.Value;
            EM.Email = Txt_Email.Text;
            EM.Telefono = Txt_CelularEmpleado.Text;
            EM.Num_Contador = Txt_NumContador.Text;
            EM.FechaCreacion = DateTime.Today;
            EM.UsuarioCreacion = DataUser.USERNAME;
            EM.FechaModificacion = DateTime.Today;
            EM.UsuarioModificacion = DataUser.USERNAME;


            //Almacenado De Datos De Los ComboBox
            DataTable Busqueda = new DataTable();

            //ComboBox Genero
            Busqueda = D.Find("Generos", "*", "Genero='" + Cmb_Genero.Text + "'");

            if (Busqueda.Rows.Count > 0)
            {
                DataRow DATOS = Busqueda.Rows[0];
                if (Cmb_Genero.Text == (DATOS["Genero"].ToString()))
                {
                    EM.Cod_Genero = int.Parse((DATOS["Cod_Genero"].ToString()));
                }
            }

            //ComboBox Estado Civil
            Busqueda = D.Find("Estado_Civil", "*", "Estado_Civil='" + Cmb_EstadoCivil.Text + "'");

            if (Busqueda.Rows.Count > 0)
            {
                DataRow DATOS = Busqueda.Rows[0];
                if (Cmb_EstadoCivil.Text == (DATOS["Estado_Civil"].ToString()))
                {
                    EM.Cod_EstadoCivil = int.Parse((DATOS["Cod_EstadoCivil"].ToString()));
                }
            }

            //ComboBox Municipio
            Busqueda = D.Find("Municipio", "*", "MUNICIPIO='" + Cmb_Municipio.Text + "'");

            if (Busqueda.Rows.Count > 0)
            {
                DataRow DATOS = Busqueda.Rows[0];
                if (Cmb_Municipio.Text == (DATOS["MUNICIPIO"].ToString()))
                {
                    EM.IDMUNICIPIO = int.Parse((DATOS["IDMUNICIPIO"].ToString()));
                }
            }

            //ComboBox Cargos
            Busqueda = D.Find("Cargos", "*", "Cargo='" + Cmb_Cargo.Text + "'");

            if (Busqueda.Rows.Count > 0)
            {
                DataRow DATOS = Busqueda.Rows[0];
                if (Cmb_Cargo.Text == (DATOS["Cargo"].ToString()))
                {
                    EM.Cod_Cargo = int.Parse((DATOS["Cod_Cargo"].ToString()));
                }
            }

            //ComboBox Paquete
            Busqueda = D.Find("Turnos", "*", "Turno='" + Cmb_Turno.Text + "'");

            if (Busqueda.Rows.Count > 0)
            {
                DataRow DATOS = Busqueda.Rows[0];
                if (Cmb_Turno.Text == (DATOS["Turno"].ToString()))
                {
                    EM.Cod_Turno = int.Parse((DATOS["Cod_Turno"].ToString()));
                }
            }


            //Almacenado De Datos De Los CheckBox

            //CheckBox Contrato Anual
            if (Check_PropietarioVivienda.Checked == true)
            {
                EM.Propietario_Vivienda = true;
            }
            else
            {
                EM.Propietario_Vivienda = false;
            }
            //CheckBox Estado
            if (Check_Estado.Checked == true)
            {
                EM.Estado = true;
            }
            else
            {
                EM.Estado = false;
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
                Reportes.Frm_Reporteria Reporte = new Reportes.Frm_Reporteria(4);
                Reporte.Show();
            }
        }

        public Boolean Validando()
        {
            Boolean Valida = true;

            if (string.IsNullOrEmpty(Txt_NombreEmpleado.Text))
            {
                MessageBox.Show("El campo Nombre Del Empleado no puede quedar vacio");
                Txt_NombreEmpleado.Focus();
                Valida = false;
            }
            else
            {
                if (string.IsNullOrEmpty(Txt_IdentidadEmpleado.Text))
                {
                    MessageBox.Show("El campo Identidad Empleado no puede quedar vacio");
                    Txt_IdentidadEmpleado.Focus();
                    Valida = false;
                }

                if (string.IsNullOrEmpty(Txt_CelularEmpleado.Text))
                {
                    MessageBox.Show("El campo Celular no puede quedar vacio");
                    Txt_CelularEmpleado.Focus();
                    Valida = false;
                }
                if (Dtp_FechaNacimiento.Value == DateTime.Today)
                {
                    MessageBox.Show("El campo Fecha De Nacimiento no puede tener la fecha actual");
                    Valida = false;
                }
                if (Txt_Edad.Text == "")
                {
                    MessageBox.Show("El campo Edad no puede quedar vacio");
                    Txt_Edad.Focus();
                    Valida = false;
                }
                if (string.IsNullOrEmpty(Txt_Email.Text))
                {
                    MessageBox.Show("El campo Email no puede quedar vacio");
                    Txt_Email.Focus();
                    Valida = false;
                }
                if (string.IsNullOrEmpty(Txt_NumContador.Text))
                {
                    MessageBox.Show("El campo Numero De Contador no puede quedar vacio");
                    Txt_NumContador.Focus();
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

            //Numeric
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is NumericUpDown)
                {
                    ctrl.Enabled = false;
                }
            }

            Txt_UsuarioLogeado.Text = DataUser.USERNAME;
            Check_Estado.Enabled = false;
            Check_PropietarioVivienda.Enabled = false;


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
            columns = "Cod_Empleado";
            table = "Empleados";
            Busqueda = D.GetNextID(columns, table, "");
            Txt_CodeMPLEADO.Text = Busqueda.ToString();

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

            //Numeric
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is NumericUpDown)
                {
                    ctrl.Enabled = true;
                }
            }


            Txt_UsuarioLogeado.Text = DataUser.USERNAME;
            Check_Estado.Enabled = true;
            Check_PropietarioVivienda.Enabled = true;

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

            //Numeric
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is NumericUpDown)
                {
                    ctrl.Text = "";
                }
            }


            GetCmb();
            Check_Estado.Enabled = false;
            Check_Estado.Checked = false;

            Check_PropietarioVivienda.Enabled = false;
            Check_PropietarioVivienda.Checked = false;
        }

        public void Registros()
        {
            string procedimiento, Estado, indicador, values;
            procedimiento = "[sp_Empleados]";
            indicador = "6";
            Estado = "true";
            values = "'','','','','','','','','','','','','','','" + Estado + "',''";
            EC.ListarEmpleados(procedimiento, indicador, values, Estado);
            dgv_registros.DataSource = EmpleadosModel.ListarEmpleados;
            Data();
        }

        public void Data()
        {
            string procedimiento, indicador, values, Estado;
            procedimiento = "[sp_Empleados]";
            indicador = "4";
            Estado = "true";
            values = "'','','','','','','','','','','','','','','" + Estado + "',''";
            EC.ListarEmpleados2(procedimiento, indicador, values, Estado);
            dgv_Data.DataSource = EmpleadosModel.Data;
        }

        public void Enviarcorreo()
        {
            string CuerpoCorreo = "LISTADO DE EMPLEADOS" + "<br>" + "<br>";
            CuerpoCorreo = CuerpoCorreo + "<table border= '1' cellpadding= '5' cellspacing='0'>";
            CuerpoCorreo = CuerpoCorreo + "<thead>";
            CuerpoCorreo = CuerpoCorreo + "<tr style='' background: blue; color: White; fontweight: bold;''>";
            CuerpoCorreo = CuerpoCorreo + "<th>Cod_Empleado</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Identidad_Empleado</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Nombre_Empleado</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Edad</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Fecha_Nacimiento</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Genero</th>";
            CuerpoCorreo = CuerpoCorreo + "<th>Telefono</th>";
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
                CuerpoCorreo = CuerpoCorreo + "<td>" + Fila.Cells[7].Value.ToString() + "</td>";

                CuerpoCorreo = CuerpoCorreo + "</tr>";
            }
            CuerpoCorreo = CuerpoCorreo + "</tbody>";
            CuerpoCorreo = CuerpoCorreo + "</table>";
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(DataUser.CORREO));
            //-------------------------------------------------------------
            email.From = new MailAddress("LeonardoMolinaEnvia@outlook.com", "REPORTE DE EMPLEADOS");
            email.Subject = "LISTADO DE EMPLEADOS ";
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

            xlWorkBook.SaveAs("Reporte_Empleados.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
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
                save.FileName = "Lista_Empleados.pdf";
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
                            float[] widths = new float[] { 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f };
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
                    Papelera = D.Find("Empleados", "*", "Estado='False'");

                    if (Papelera.Rows.Count > 0)
                    {
                        string procedimiento, Estado, indicador, values;
                        procedimiento = "[sp_Empleados]";
                        indicador = "6";
                        Estado = "False";
                        values = "'','','','','','','','','','','','','','','" + Estado + "',''";
                        EC.ListarEmpleados(procedimiento, indicador, values, Estado);
                        dgv_registros.DataSource = EmpleadosModel.ListarEmpleados;
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
                procedimiento = "[sp_Empleados]";
                indicador = "2";
                values = "'" + EM.Cod_Empleado + "','" + EM.Identidad_Empleado + "','" + EM.Nombre_Empleado + "','" + EM.Edad + "','" + EM.Fecha_Nacimiento + "','" + EM.Cod_Genero + "','" + EM.Email + "','" + EM.Telefono + "','" + EM.Cod_EstadoCivil + "','" + EM.IDMUNICIPIO + "','" + EM.Num_Contador + "','" + EM.Propietario_Vivienda + "','" + EM.Cod_Cargo + "','" + EM.Cod_Turno + "','" + EM.Estado + "','" + EM.UsuarioCreacion + "','" + EM.UsuarioModificacion + "'";
                SE.ActualizarDatos(procedimiento, indicador, values);
                dgv_registros.DataSource = EmpleadosModel.ListarEmpleados;
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
            if (D.Update("Empleados", "Estado='true'", "Cod_Empleado='" + EM.Cod_Empleado + "'") > 0)
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
            if (D.Update("Empleados", "Estado='false'", "Cod_Empleado='" + EM.Cod_Empleado + "'") > 0)
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
                EmpleadosModel.ListarEmpleados.DefaultView.RowFilter = $"Nombre_Empleado like '%{txt_buscar.Text}%'";
            }
            else if (rbn_Identidad.Checked == true)
            {
                EmpleadosModel.ListarEmpleados.DefaultView.RowFilter = $"Identidad_Empleado like '%{txt_buscar.Text}%'";
            }
            else if (rbn_Celular.Checked == true)
            {
                EmpleadosModel.ListarEmpleados.DefaultView.RowFilter = $"Telefono like '%{txt_buscar.Text}%'";
            }
        }

        private void Deleteall()
        {
            Seteo();
            string Procedimiento = "[sp_Empleados]";
            string indicador = "3";
            string id = "'" + EM.Cod_Empleado + "'";
            string values = "'','','','','','','','','','','','','','','',''";

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
            string Cod_Genero, Cod_EstadoCivil, IDMUNICIPIO, Cod_Cargo, Cod_Turno;
            string Propietario_Vivienda, Estado;

            if (dgv_registros.SelectedRows.Count > 0)
            {
                Nuevo();
                Btn_Nuevo.Enabled = false;
                Txt_CodeMPLEADO.Text = dgv_registros.CurrentRow.Cells["Cod_Empleado"].Value.ToString();
                Txt_IdentidadEmpleado.Text = dgv_registros.CurrentRow.Cells["Identidad_Empleado"].Value.ToString();
                Txt_NombreEmpleado.Text = dgv_registros.CurrentRow.Cells["Nombre_Empleado"].Value.ToString();
                Txt_Edad.Text = dgv_registros.CurrentRow.Cells["Edad"].Value.ToString();
                Dtp_FechaNacimiento.Text = dgv_registros.CurrentRow.Cells["Fecha_Nacimiento"].Value.ToString();
                Txt_Email.Text = dgv_registros.CurrentRow.Cells["Email"].Value.ToString();
                Txt_CelularEmpleado.Text = dgv_registros.CurrentRow.Cells["Telefono"].Value.ToString();
                Txt_NumContador.Text = dgv_registros.CurrentRow.Cells["Num_Contador"].Value.ToString();

                Cod_Genero = dgv_registros.CurrentRow.Cells["Genero"].Value.ToString();
                Cod_EstadoCivil = dgv_registros.CurrentRow.Cells["Estado_Civil"].Value.ToString();
                IDMUNICIPIO = dgv_registros.CurrentRow.Cells["Municipio"].Value.ToString();
                Cod_Cargo = dgv_registros.CurrentRow.Cells["Cargo"].Value.ToString();
                Cod_Turno = dgv_registros.CurrentRow.Cells["Turno"].Value.ToString();
                Propietario_Vivienda = dgv_registros.CurrentRow.Cells["Propietario_Vivienda"].Value.ToString();
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
                if (Propietario_Vivienda == "True")
                {
                    Check_PropietarioVivienda.Checked = true;
                }
                else if (Propietario_Vivienda == "False")
                {
                    Check_PropietarioVivienda.Checked = false;
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

                //ComboBox Municipio
                ID = D.Find("Municipio", "*", "MUNICIPIO='" + IDMUNICIPIO + "'");

                if (ID.Rows.Count > 0)
                {
                    DataRow info = ID.Rows[0];
                    Cmb_Municipio.Text = info["MUNICIPIO"].ToString();
                }

                //ComboBox Cargos
                ID = D.Find("Cargos", "*", "Cargo='" + Cod_Cargo + "'");

                if (ID.Rows.Count > 0)
                {
                    DataRow info = ID.Rows[0];
                    Cmb_Cargo.Text = info["Cargo"].ToString();
                }

                //ComboBox Turnos
                ID = D.Find("Turnos", "*", "Turno='" + Cod_Turno + "'");

                if (ID.Rows.Count > 0)
                {
                    DataRow info = ID.Rows[0];
                    Cmb_Turno.Text = info["Turno"].ToString();
                }
                ID.Dispose();

                Txt_CodeMPLEADO.Enabled = false;
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
