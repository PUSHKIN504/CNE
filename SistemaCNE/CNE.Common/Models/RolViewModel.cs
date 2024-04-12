using CNE.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.Common.Models
{
   public class RolViewModel
    {
        public int Roles_Id { get; set; }
        public string Roles_Descripcion { get; set; }

        public int Roles_UsuarioCreacion { get; set; }
        public DateTime Roles_FechaCreacion { get; set; }
        public int? Roles_UsuarioModificacion { get; set; }
        public DateTime? Roles_FechaModificacion { get; set; }
        public bool? Roles_Estado { get; set; }
        //[NotMapped]
        //public List<tbPantallas> pantallas { get; set; }

        [NotMapped]
        public List<PantallaViewModel> pantallas { get; set; }

        [NotMapped]
        public List<int> PantallasID { get; set; }

        [NotMapped]
        public int Resultado { get; set; }
        [NotMapped]
        public string Panta_Descripcion { get; set; }

        [NotMapped]
        public int Panta_Id { get; set; }
    }
}
