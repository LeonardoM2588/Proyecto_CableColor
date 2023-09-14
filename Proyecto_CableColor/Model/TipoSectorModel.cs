using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CableColor.Model
{
    class TipoSectorModel
    {
        public int IdTipoSector { get; set; }
        public string TipoSector { get; set; }

        public static DataTable ListarTipoSector { get; set; }
    }
}
