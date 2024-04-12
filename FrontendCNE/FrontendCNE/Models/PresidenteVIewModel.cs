using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Models
{
    public class PresidenteVIewModel
    {
        [Display(Name = "Presidente")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int Pre_Id { get; set; }
        [Display(Name = "Votos")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int? Pre_Votos { get; set; }
        [Display(Name = "Fotografia")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public string Pre_ImgUrl { get; set; }

        [Display(Name = "Usua Creacion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int Pre_UsuarioCreacion { get; set; }
        [Display(Name="Fecha Creacion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime Pre_FechaCreacion { get; set; }
        [Display(Name="Usu Modificacion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int? Pre_UsuarioModificacion { get; set; }
        [Display(Name="Fecha Modificacion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime? Pre_FechaModificacion { get; set; }
        [Display(Name="Estado")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public bool? Pre_Estado { get; set; }
        [Display(Name="Partido")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int? Par_id { get; set; }
        [Display(Name="Partido Foto")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [NotMapped]
        public string Par_ImgUrl { get; set; }
        [NotMapped]
        public string Per_Nombre { get; set; }
        [NotMapped]
        public string Per_Apellido { get; set; }
    }
}
