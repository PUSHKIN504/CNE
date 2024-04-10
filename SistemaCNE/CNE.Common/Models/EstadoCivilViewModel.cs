using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.Common.Models
{
  public  class EstadoCivilViewModel
    {
        public int EsC_Id { get; set; }
        public string EsC_Descripcion { get; set; }
        public int EsC_UsuarioCreacion { get; set; }
        public DateTime EsC_FechaCreacion { get; set; }
        public int? EsC_UsuarioModificacion { get; set; }
        public DateTime? EsC_FechaModificacion { get; set; }
        public bool? EsC_Estado { get; set; }
    }
}
