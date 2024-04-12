using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.Common.Models
{
   public class MesaViewModel
    {

        [Display(Name = "Mesa")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int Mes_Id { get; set; }
         [Display(Name = "Jurado")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int? Mes_Jurado { get; set; }
         [Display(Name = "Custodio 1")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int? Mes_Custodio1 { get; set; }
         [Display(Name = "Custodio 2")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int? Mes_Custodio2 { get; set; }
         [Display(Name = "Usu Crea")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int Mes_UsuarioCreacion { get; set; }
         [Display(Name = "Fecha Crea")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime Mes_FechaCreacion { get; set; }
         [Display(Name = "Usu Modifica")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int? Mes_UsuarioModificacion { get; set; }
         [Display(Name = "Fecha Modifica")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime? Mes_FechaModificacion { get; set; }
         [Display(Name = "Estado")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public bool? Mes_Estado { get; set; }
    }
}
