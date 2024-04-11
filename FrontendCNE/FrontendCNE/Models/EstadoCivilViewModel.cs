using System;
using System.ComponentModel.DataAnnotations;

namespace FrontendCNE.Models
{
    public class EstadoCivilViewModel
    {
        [Display(Name = "Id")]

        public int EsC_Id { get; set; }
        [Display(Name = "Descripcion")]

        public string EsC_Descripcion { get; set; }

        [Display(Name = "Usu Crea")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int EsC_UsuarioCreacion { get; set; }
         [Display(Name = "Fecha Crea")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime EsC_FechaCreacion { get; set; }
         [Display(Name = "Usu Modifica")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int? EsC_UsuarioModificacion { get; set; }
         [Display(Name = "Fecha Modifica")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime? EsC_FechaModificacion { get; set; }
         [Display(Name = "Estado")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public bool? EsC_Estado { get; set; }



    }
}
