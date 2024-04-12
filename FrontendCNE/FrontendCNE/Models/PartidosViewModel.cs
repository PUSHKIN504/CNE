using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.Common.Models
{
   public class PartidosViewModel
    {
        [Display(Name = "Codigo")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int Par_id { get; set; }

        [Display(Name = "Partido")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public string Par_Nombre { get; set; }
        [Display(Name="Bandera")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
   
        public string Par_ImgUrl { get; set; }
        [Display(Name="Usu Crea")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int Par_UsuarioCreacion { get; set; }
        [Display(Name="Fecha Crea")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime Par_FechaCreacion { get; set; }
        [Display(Name="Usua Modificacion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int? Par_UsuarioModificacion { get; set; }
        [Display(Name="Fecha Modifica")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime? Par_FechaModificacion { get; set; }
        [Display(Name="Estado")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public bool? Par_Estado { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name="Elija una imagen")]
        public IFormFile FotoP { get; set; }
    
    }
}
