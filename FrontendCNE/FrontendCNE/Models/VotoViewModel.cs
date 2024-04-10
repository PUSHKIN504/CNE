using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Models
{
    public class VotoViewModel
    {
        public int Vot_Id { get; set; }
        public int Mes_Id { get; set; }
        public int? Pre_Id { get; set; }
        public int? Alc_Id { get; set; }
        [NotMapped]
        public string? dni { get; set; }

        [NotMapped]
        public List<int> listaEnteros { get; set; }

    }
}
