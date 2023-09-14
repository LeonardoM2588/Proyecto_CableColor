using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CableColor.Model
{
    class DepartamentoPaisModel
    {
        public int IDDEPARTAMENTO { get; set; }
        public string DEPARTAMENTO { get; set; }
        public int IDPAIS { get; set; }
        public static DataTable ListarDepartamentosPaises { get; set; }
    }
}
