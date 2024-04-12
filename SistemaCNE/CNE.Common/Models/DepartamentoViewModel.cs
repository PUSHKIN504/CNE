using CNE.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.Common.Models
{
    public class DepartamentoViewModel
    {
        public string Dep_Id { get; set; }
        public string Dep_Descripcion { get; set; }
        public int Dep_UsuarioCreacion { get; set; }
        public DateTime Dep_FechaCreacion { get; set; }
        public int? Dep_UsuarioModificacion { get; set; }
        public DateTime? Dep_FechaModificacion { get; set; }
        public bool? Dep_Estado { get; set; }

        public  ICollection<tbMunicipios> tbMunicipios { get; set; }

    }
}
