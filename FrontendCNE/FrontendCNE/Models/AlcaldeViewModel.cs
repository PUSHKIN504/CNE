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
        public string Alc_ImgUrl { get; set; }
        [NotMapped]
        public string Partido { get; set; }
        [Display(Name = "Usuario Creacion")]

        public int Alc_UsuarioCreacion { get; set; }
        [Display(Name = "Fecha Creacion")]

        public DateTime Alc_FechaCreacion { get; set; }
        [Display(Name = "Usuario Modificacion")]

        public int? Alc_UsuarioModificacion { get; set; }
        public DateTime? Alc_FechaModificacion { get; set; }
        public bool? Alc_Estado { get; set; }
        public int? Par_id { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]


        public IFormFile FotoP { get; set; }

        [NotMapped]
        public string Par_Nombre { get; set; }
    }
}
