using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CableColor.Model
{
    class MunicipioModel
    {
        public int IDMUNICIPIO { get; set; }
        public string MUNICIPIO { get; set; }
        public int IDDEPARTAMENTO { get; set; }
        public static DataTable ListarMunicipios { get; set; }
    }
}
