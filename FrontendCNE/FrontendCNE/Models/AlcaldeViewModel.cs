using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendCNE.Models
{
   public class AlcaldeViewModel
    {

        [Display(Name = "Id")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int Alc_Id { get; set; }
        [Display(Name = "Votos")]

        public int? Alc_Votos { get; set; }
        [Display(Name = "Fotografia")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public string Alc_ImgUrl { get; set; }
        [NotMapped]
        public string Partido { get; set; }
        [Display(Name = "Usuario Creacion")]

        public int Alc_UsuarioCreacion { get; set; }
        [Display(Name = "Fecha Creacion")]

        public DateTime Alc_FechaCreacion { get; set; }
        [Display(Name = "Usuario Modificacion")]

        public int? Alc_UsuarioModificacion { get; set; }
        [Display(Name = "Fecha Modifica")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime? Alc_FechaModificacion { get; set; }
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public bool? Alc_Estado { get; set; }
        [Display(Name = "Partido")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int? Par_id { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]


        public IFormFile FotoP { get; set; }

        [Display(Name = "Nombre")]
  
        [NotMapped]
        public string partido { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]


        [NotMapped]
        public string Par_Nombre { get; set; }
        [NotMapped]
        public string Per_Id { get; set; }
        [NotMapped]
        public string Per_Nombre { get; set; }
    }
}
