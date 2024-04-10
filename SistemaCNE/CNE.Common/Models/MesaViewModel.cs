using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.Common.Models
{
   public class MesaViewModel
    {

        public int Mes_Id { get; set; }
        public int? Mes_Jurado { get; set; }
        public int? Mes_Custodio1 { get; set; }
        public int? Mes_Custodio2 { get; set; }
        public int Mes_UsuarioCreacion { get; set; }
        public DateTime Mes_FechaCreacion { get; set; }
        public int? Mes_UsuarioModificacion { get; set; }
        public DateTime? Mes_FechaModificacion { get; set; }
        public bool? Mes_Estado { get; set; }
    }
}
