using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_CableColor.Control_System
{
    class Helpers
    {
        //Metodo MsgWarning
        //Envía una advertencia a pantalla en un cuadro de dialogo
        public void MsgWarning(string msg)
        {
            MessageBox.Show(msg, "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        //Fin MsgWarning

        //Metodo MsgSuccess
        //Envia un cuadro de dialogo a pantalla indicando que un proceso se completó con exito
        public void MsgSuccess(string msg)
        {
            MessageBox.Show(msg, "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Fin MsgSuccess

        //Metodo MsgQuestion
        //Envia un cuadro de dialogo con las opciones si y no
        public string MsgQuestion(string msg)
        {
            string Op = "N";
            if (MessageBox.Show(msg, "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Op = "S";
            }
            return Op;
        }
        //Fin MsgQuestion

        public string SanitizeStr(string str)
        {
            string strout = ""; //Cadena de salida
            //Arreglo caracteres prohibidos
            string[] forbiddenchars = { "'", "=", "<", ">", ";", "/", "!" };
            int i, j; //variables para iterar ciclos
            int coinc; //coincidencias

            for (i = 0; i < str.Length; i++)
            {

                for (j = 0; j < forbiddenchars.Length; j++)
                {
                    coinc = 0;
                    for (j = 0; j < forbiddenchars.Length; j++)
                    {
                        coinc = str.Substring(i, 1) == forbiddenchars[j] ? coinc + 1 : coinc + 0;
                    }
                    strout = coinc == 0 ? strout + str.Substring(i, 1) : strout;
                }

            }

            return strout;
        }


        //Metodo GetOnlyNumbers
        //Bloquear cualquier caracter que no sea numero
        public Boolean GetOnlyNumbers(KeyPressEventArgs e)
        {
            Boolean resp = false;
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == (char)8)
            {
                resp = true;
            }
            return resp;

        }
        //Fin GetOnlyNumbers

        //Metodo GetNumericValue
        //Devolver el valor numerico de un numero
        public double GetNumericValue(string str)
        {
            double value = 0;
            if (double.TryParse(str, out value))
            {
                value = Convert.ToDouble(str);
            }
            else
            {
                MsgWarning("ERROR AL OBTENER EL VALOR NUMERICO DE " + str);
                value = 0;
            }
            return value;
        }
        //Fin GetNumericValue
    }
}
