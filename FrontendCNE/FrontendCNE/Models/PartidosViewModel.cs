using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.Common.Models
{
   public class PartidosViewModel
    {
        public int Par_id { get; set; }
        public string Par_Nombre { get; set; }
   
        public string Par_ImgUrl { get; set; }
        public int Par_UsuarioCreacion { get; set; }
        public DateTime Par_FechaCreacion { get; set; }
        public int? Par_UsuarioModificacion { get; set; }
        public DateTime? Par_FechaModificacion { get; set; }
        public bool? Par_Estado { get; set; }
    }
}
