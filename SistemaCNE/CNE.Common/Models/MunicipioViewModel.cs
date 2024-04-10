using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.Common.Models
{
   public  class MunicipioViewModel
    {
        public string Mun_Id { get; set; }
        public string Mun_Descripcion { get; set; }
        [NotMapped]
        public string Dep_Descripcion { get; set; }

        [NotMapped]
        public string Usuario1 { get; set; }
        [NotMapped]
        public string Usuario2 { get; set; }

        public string Dep_Id { get; set; }
        public int Mun_UsuarioCreacion { get; set; }
        public DateTime Mun_FechaCreacion { get; set; }
        public int? Mun_UsuarioModificacion { get; set; }
        public DateTime? Mun_FechaModificacion { get; set; }
        public bool? Mun_Estado { get; set; }

    }
}
