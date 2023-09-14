using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CableColor.Model
{
    class SectorModel
    {
        public int IDSECTOR { get; set; }
        public string SECTOR { get; set; }
        public int IdTipoSector { get; set; }
        public int IDMUNICIPIO { get; set; }
        public static DataTable ListarSector { get; set; }
    }
}
