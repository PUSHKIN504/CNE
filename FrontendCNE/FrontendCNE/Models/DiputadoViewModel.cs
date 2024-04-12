using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.Common.Models
{
   public class DiputadoViewModel
    {
        public int Dip_Id { get; set; }
        public int? Dip_Votos { get; set; }
        public string Dip_ImgUrl { get; set; }
        public int Dip_UsuarioCreacion { get; set; }
        public DateTime Dip_FechaCreacion { get; set; }
        public int? Dip_UsuarioModificacion { get; set; }
        public DateTime? Dip_FechaModificacion { get; set; }
        public bool? Dip_Estado { get; set; }
        public int? Par_id { get; set; }
        [NotMapped]
        public string Partido { get; set; }
        [NotMapped]
        public string partido { get; set; }




        public IFormFile FotoP { get; set; }

        [NotMapped]
        public string Par_Nombre { get; set; }




        [NotMapped]
        public string Per_Id { get; set; }
    }
}
