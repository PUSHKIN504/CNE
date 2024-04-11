using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendCNE.Models
{
  public  class CentroVotacionesViewModels
    {

        [Display(Name = "Codigo")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int CeV_Id { get; set; }
         [Display(Name = "Municipio")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public string Mun_Id { get; set; }
         [Display(Name = "usu Creacion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int CeV_UsuarioCreacion { get; set; }
         [Display(Name = "Fecha Creacion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime CeV_FechaCreacion { get; set; }
         [Display(Name = "Usuario Modifica")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int? CeV_UsuarioModificacion { get; set; }
         [Display(Name = "Fecha Modifica")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime? CeV_FechaModificacion { get; set; }
         [Display(Name = "Estado")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public bool? CeV_Estado { get; set; }
         [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public string CeV_Nombre { get; set; }
    }
}
