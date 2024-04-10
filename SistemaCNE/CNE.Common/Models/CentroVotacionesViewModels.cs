using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.Common.Models
{
  public  class CentroVotacionesViewModels
    {
        public int CeV_Id { get; set; }
        public string Mun_Id { get; set; }
        public int CeV_UsuarioCreacion { get; set; }
        public DateTime CeV_FechaCreacion { get; set; }
        public int? CeV_UsuarioModificacion { get; set; }
        public DateTime? CeV_FechaModificacion { get; set; }
        public bool? CeV_Estado { get; set; }
        public String CeV_Nombre { get; set; }
    }
}
