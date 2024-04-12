using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Models
{
    public class PantallasPorRolViewModel
    {

        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Codigo")]
        public int Papro_Id { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name="Pantalla")]
        public int Panta_Id { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name="Rol")]
        public int Roles_Id { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name="Usuario Crea")]
        public int Papro_UsuarioCreacion { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name="Fecha Crea")]
        public DateTime Papro_FechaCreacion { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name="Usu Modifica")]
        public int? Papro_UsuarioModificacion { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name="Fecha Modifica")]
        public DateTime? Papro_FechaModificacion { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name="Estado")]
        public bool? Papro_Estado { get; set; }

    }
}
