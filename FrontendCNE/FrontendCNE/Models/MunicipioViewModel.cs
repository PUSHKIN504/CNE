using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendCNE.Models
{
   public  class MunicipioViewModel
    {

         [Display(Name = "Codigo")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public string Mun_Id { get; set; }
         [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public string Mun_Descripcion { get; set; }
         [Display(Name = "Departamento")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public string Dep_Id { get; set; }
         [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [NotMapped]
        public string Dep_Descripcion { get; set; }
         [Display(Name = "Usuario1")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [NotMapped]
        public string Usuario1 { get; set; }
         [Display(Name = "usuario2")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [NotMapped]
        public string Usuario2 { get; set; }
        [Display(Name = "Usu Crea")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]

        public int Mun_UsuarioCreacion { get; set; }
         [Display(Name = "Fecha Crea")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime Mun_FechaCreacion { get; set; }
         [Display(Name = "Usu Modifica")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int? Mun_UsuarioModificacion { get; set; }
         [Display(Name = "Fecha Modificacion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime? Mun_FechaModificacion { get; set; }
         [Display(Name = "Estado")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public bool? Mun_Estado { get; set; }

    }
}
