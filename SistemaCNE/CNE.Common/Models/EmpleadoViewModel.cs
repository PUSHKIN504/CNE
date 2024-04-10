using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.Common.Models
{
    public class EmpleadoViewModel
    {
        public int Per_Id { get; set; }
        public int Emp_UsuarioCreacion { get; set; }
        public DateTime Emp_FechaCreacion { get; set; }
        public int? Emp_UsuarioModificacion { get; set; }
        public DateTime? Emp_FechaModificacion { get; set; }
        public bool? Emp_Estado { get; set; }

    }
}
