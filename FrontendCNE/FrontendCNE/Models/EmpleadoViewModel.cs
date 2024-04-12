using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.Common.Models
{
    public class EmpleadoViewModel
    {

        [Display(Name = "Codigo")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int Per_Id { get; set; }
        [Display(Name = "Usu Crea")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int Emp_UsuarioCreacion { get; set; }
         [Display(Name = "Fecha Creacion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime Emp_FechaCreacion { get; set; }
         [Display(Name = "Usu Modifica")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int? Emp_UsuarioModificacion { get; set; }
         [Display(Name = "Fecha Modifica")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime? Emp_FechaModificacion { get; set; }
         [Display(Name = "Estado")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public bool? Emp_Estado { get; set; }

    }
}
