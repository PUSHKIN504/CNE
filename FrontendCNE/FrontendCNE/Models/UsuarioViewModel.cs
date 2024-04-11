using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.Common.Models
{
    public class UsuarioViewModel
    {
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int Usuar_Id { get; set; }
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public string Usuar_Usuario { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [NotMapped]
        public string Nombre { get; set; }
        [Display(Name = "Descripcion Rol")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [NotMapped]
        public string Rol_Descripcion { get; set; }

        [NotMapped]
        public string Id_Rol { get; set; }


        [NotMapped]
        public string Usua_Nombre { get; set; }

        [NotMapped]
        public string Usua_Contrasenia { get; set; }

        [NotMapped]
        public string Usua_Administrador { get; set; }

        [NotMapped]
        public string Pant_Descripcion { get; set; }
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
    }
}
