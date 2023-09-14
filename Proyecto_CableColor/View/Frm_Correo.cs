using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_CableColor.View
{
    public partial class Frm_Correo : Form
    {
        public Frm_Correo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_correo.Text.Length > 0)
            {
                Control_System.DataUser.CORREO = txt_correo.Text;
                Close();
            }
            else if (txt_correo.Text == "")
            {
                MessageBox.Show("Ingrese Un Correo Eletronico Valido!");
                txt_correo.Select();
            }
        }

        private void Btn_Aceptar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Btn_Aceptar.PerformClick();
            }
        }
    }
}
