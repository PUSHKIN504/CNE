using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.Common.Models
{
  public   class PantallaPorRolViewModel
    {
        public int Papro_Id { get; set; }
        public int Panta_Id { get; set; }
        public int Roles_Id { get; set; }
        public int Papro_UsuarioCreacion { get; set; }
        public DateTime Papro_FechaCreacion { get; set; }
        public int? Papro_UsuarioModificacion { get; set; }
        public DateTime? Papro_FechaModificacion { get; set; }
        public bool? Papro_Estado { get; set; }
        [NotMapped]
        public string Rol_Descripcion { get; set; }

    }
}
