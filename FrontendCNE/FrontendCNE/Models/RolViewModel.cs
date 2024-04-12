using FrontendCNE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.Common.Models
{
   public class RolViewModel
    {
        [Display(Name = "Roles")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int Roles_Id { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public string Roles_Descripcion { get; set; }
        [Display(Name = "Usu Creacion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int Roles_UsuarioCreacion { get; set; }
        [Display(Name = "Fecha Creacion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime Roles_FechaCreacion { get; set; }
        [Display(Name = "Usu mod ")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int? Roles_UsuarioModificacion { get; set; }
        [Display(Name = "Fecha Mod")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime? Roles_FechaModificacion { get; set; }
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public bool? Roles_Estado { get; set; }
        [NotMapped]
        [Display(Name = "Pantallas")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public List<PantallaViewModel> pantallas { get; set; }
        [Display(Name = "Pantallas ")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [NotMapped]
        public List<int> PantallasID { get; set; }
        public virtual ICollection<PantallasPorRolViewModel> PantallasPorRolViewModel { get; set; }

    }
}
