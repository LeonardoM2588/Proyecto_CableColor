using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CableColor.Model
{
    class CargosModel
    {
        public int Cod_Cargo { get; set; }
        public int Cod_Depto_Emp { get; set; }
        public string Cargo { get; set; }

        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public static DataTable ListarCargos { get; set; }
    }
}
