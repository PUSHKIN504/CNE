using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.Common.Models
{
   public class DiputadoViewModel
    {

        [Display(Name = "Codigo")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int Dip_Id { get; set; }
         [Display(Name = "Voto")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int? Dip_Votos { get; set; }
         [Display(Name = "Fotografia")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public string Dip_ImgUrl { get; set; }
         [Display(Name = "Usu Crea")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int Dip_UsuarioCreacion { get; set; }
         [Display(Name = "Fecha Crea")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime Dip_FechaCreacion { get; set; }
         [Display(Name = "Usu Modifica")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int? Dip_UsuarioModificacion { get; set; }
         [Display(Name = "Fecha Modifica")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime? Dip_FechaModificacion { get; set; }
         [Display(Name = "Estado")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public bool? Dip_Estado { get; set; }
         [Display(Name = "Partido")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int? Par_id { get; set; }
         [Display(Name = "Partido")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [NotMapped]
        public string Partido { get; set; }
    }
}
