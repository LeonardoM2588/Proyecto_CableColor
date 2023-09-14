using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Proyecto_CableColor.Model;


namespace Proyecto_CableColor.Reportes
{
    public partial class Frm_Reporteria : Form
    {
        int NumeroReporte = 0;
        string MiReporte = "";
        public Frm_Reporteria()
        {
            InitializeComponent();
        }
        public Frm_Reporteria(int Reporte)
        {
            InitializeComponent();
            NumeroReporte = Reporte;
        }
        public Frm_Reporteria(string NombreReporte)
        {
            InitializeComponent();
            MiReporte = NombreReporte;
        }
        void Reporteria()
        {
            this.reportViewer1.LocalReport.DataSources.Clear();


            if (NumeroReporte == 1)
            {
                MiReporte = "Listado De Usuarios";
                this.Text = MiReporte;
                this.reportViewer1.LocalReport.ReportPath = @"..\..\Reportes\Reporte_Usuarios.rdlc";
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Proyecto_CableColor.Reportes.Reporte_Usuarios.rdlc";
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", UsuariosModel.Data));

            }
            else
            {
                if (NumeroReporte == 2)
                {
                    MiReporte = "Listado De Paquetes";
                    this.Text = MiReporte;
                    this.reportViewer1.LocalReport.ReportPath = @"..\..\Reportes\Reporte_Paquetes.rdlc";
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "Proyecto_CableColor.Reportes.Reporte_Paquetes.rdlc";
                    this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", PaquetesModel.Data));
                }
                else
                {
                    if (NumeroReporte == 3)
                    {
                        MiReporte = "Listado De Clientes";
                        this.Text = MiReporte;
                        this.reportViewer1.LocalReport.ReportPath = @"..\..\Reportes\Reporte_Clientes.rdlc";
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "Proyecto_CableColor.Reportes.Reporte_Clientes.rdlc";
                        this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ClientesModel.Data));
                    }
                    else
                    {

                        if (NumeroReporte == 4)
                        {
                            MiReporte = "Listado De Empleados";
                            this.Text = MiReporte;
                            this.reportViewer1.LocalReport.ReportPath = @"..\..\Reportes\Reporte_Empleados.rdlc";
                            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Proyecto_CableColor.Reportes.Reporte_Empleados.rdlc";
                            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", EmpleadosModel.Data));
                        }
                        else
                        {
                            if (NumeroReporte == 5)
                            {
                                MiReporte = "Listado De Prospectos";
                                this.Text = MiReporte;
                                this.reportViewer1.LocalReport.ReportPath = @"..\..\Reportes\Reporte_Prospectos.rdlc";
                                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Proyecto_CableColor.Reportes.Reporte_Prospectos.rdlc";
                                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ClientesProspectosModel.Data));
                            }
                            else
                            {
                                if (NumeroReporte == 6)
                                {
                                    MiReporte = "Listado De Ordenes";
                                    this.Text = MiReporte;
                                    this.reportViewer1.LocalReport.ReportPath = @"..\..\Reportes\Reporte_Ordenes.rdlc";
                                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "Proyecto_CableColor.Reportes.Reporte_Ordenes.rdlc";
                                    this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", OrdenesModel.Data));
                                }
                                else
                                {
                                    if (NumeroReporte == 7)
                                    {
                                        MiReporte = "Listado De Mantenimiento";
                                        this.Text = MiReporte;
                                        this.reportViewer1.LocalReport.ReportPath = @"..\..\Reportes\Reporte_Mantenimiento.rdlc";
                                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "Proyecto_CableColor.Reportes.Reporte_Mantenimiento.rdlc";
                                        this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", MantenimientoModel.Data));
                                    }
                                    else
                                    {
                                        if (NumeroReporte == 8)
                                        {
                                            MiReporte = "Listado De";
                                            this.Text = MiReporte;
                                            this.reportViewer1.LocalReport.ReportPath = @"..\..\Reportes\ReporteUsuarios.rdlc";
                                            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sistema_AQUAS.A.Reportes.ReporteUsuarios.rdlc";
                                            //this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", UsuariosModel.Data));
                                        }
                                        else
                                        {
                                            MessageBox.Show("No existe esa tabla!");
                                            Close();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void Frm_Reporteria_Load(object sender, EventArgs e)
        {
            Reporteria();
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
