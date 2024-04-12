using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Models
{
    public class PresidenteVIewModel
    {
        public int Pre_Id { get; set; }
        public int? Pre_Votos { get; set; }
        public string Pre_ImgUrl { get; set; }
        public int Pre_UsuarioCreacion { get; set; }
        public DateTime Pre_FechaCreacion { get; set; }
        public int? Pre_UsuarioModificacion { get; set; }
        public DateTime? Pre_FechaModificacion { get; set; }
        public bool? Pre_Estado { get; set; }
        public int? Par_id { get; set; }
        [NotMapped]
        public string Par_ImgUrl { get; set; }
        [NotMapped]
        public string partido { get; set; }

        [NotMapped]
        public string Per_Nombre { get; set; }
        [NotMapped]
        public string Per_Apellido { get; set; }

        public IFormFile FotoP { get; set; }

        [NotMapped]
        public string Par_Nombre { get; set; }




        [NotMapped]
        public string Partido { get; set; }


        




        [NotMapped]
        public string Per_Id { get; set; }
    }
}
