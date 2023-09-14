using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CableColor.Model
{
    class TurnosModel
    {
        public int Cod_Turno { get; set; }
        public string Turno { get; set; }
        public string Descripcion { get; set; }
        public static DataTable ListarTurnos { get; set; }
    }
}
