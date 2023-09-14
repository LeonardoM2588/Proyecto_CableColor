using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CableColor.Model
{
    class GenerosModel
    {
        public int Cod_Genero { get; set; }
        public string Genero { get; set; }

        public static DataTable ListarGeneros { get; set; }
    }
}
