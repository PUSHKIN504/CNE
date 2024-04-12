using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Models
{
    public class VotoViewModel
    {
        [Display(Name = "Voto")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int Vot_Id { get; set; }
        [Display(Name = "Mesa")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int Mes_Id { get; set; }
        [Display(Name = "Codigo")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int? Pre_Id { get; set; }
        [Display(Name = "Alcalde")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int? Alc_Id { get; set; }
        [Display(Name = "DNI")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [NotMapped]
        public string? dni { get; set; }
       

        [NotMapped]
        public string listaEnteros { get; set; }

    }
}
