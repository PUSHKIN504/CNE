using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.Common.Models
{
  public  class UsuarioViewModel
    {
        public int Usuar_Id { get; set; }
        public string Usuar_Usuario { get; set; }
        public string Usuar_Contrasena { get; set; }
        public int Per_Id { get; set; }
        public int Roles_Id { get; set; }
        public DateTime? Usuar_UltimaSesion { get; set; }
        public bool? Usuar_Admin { get; set; }
        public int? Usuar_UsuarioCreacion { get; set; }
        public DateTime Usuar_FechaCreacion { get; set; }
        public int? Usuar_UsuarioModificacion { get; set; }
        public DateTime? Usuar_FechaModificacion { get; set; }
        public bool? Usuar_Estado { get; set; }
        [NotMapped]
        public string Usua_Nombre { get; set; }

        [NotMapped]
        public string  Usua_Contrasenia { get; set; }

        [NotMapped]
        public string Usua_Administrador { get; set; }

        [NotMapped]
        public string Pant_Descripcion { get; set; }
    }
}
