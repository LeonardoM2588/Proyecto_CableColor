using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CableColor.Model
{
    class NacionalidadModel
    {
        public int Cod_Nacionalidad { get; set; }
        public string Nacionalidad { get; set; }

        public static DataTable ListarNacionalidad { get; set; }
    }
}
