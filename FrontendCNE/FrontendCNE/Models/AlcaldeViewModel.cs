using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendCNE.Models
{
   public class AlcaldeViewModel
    {
        public int Alc_Id { get; set; }
        public int? Alc_Votos { get; set; }
        public string Alc_ImgUrl { get; set; }
        [NotMapped]
        public string Partido { get; set; }

        public int Alc_UsuarioCreacion { get; set; }
        public DateTime Alc_FechaCreacion { get; set; }
        public int? Alc_UsuarioModificacion { get; set; }
        public DateTime? Alc_FechaModificacion { get; set; }
        public bool? Alc_Estado { get; set; }
        public int? Par_id { get; set; }
    }
}
