﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace CNE.Entities.Entities
{
    public partial class tbEmpleados
    {
        public tbEmpleados()
        {
            tbMesasMes_Custodio1Navigation = new HashSet<tbMesas>();
            tbMesasMes_Custodio2Navigation = new HashSet<tbMesas>();
            tbMesasMes_JuradoNavigation = new HashSet<tbMesas>();
            tbUsuarios = new HashSet<tbUsuarios>();
        }

        public int Per_Id { get; set; }
        public int Emp_UsuarioCreacion { get; set; }
        public DateTime Emp_FechaCreacion { get; set; }
        public int? Emp_UsuarioModificacion { get; set; }
        public DateTime? Emp_FechaModificacion { get; set; }
        public bool? Emp_Estado { get; set; }

        public virtual tbUsuarios Emp_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios Emp_UsuarioModificacionNavigation { get; set; }
        public virtual tbPersonas Per { get; set; }
        public virtual ICollection<tbMesas> tbMesasMes_Custodio1Navigation { get; set; }
        public virtual ICollection<tbMesas> tbMesasMes_Custodio2Navigation { get; set; }
        public virtual ICollection<tbMesas> tbMesasMes_JuradoNavigation { get; set; }
        public virtual ICollection<tbUsuarios> tbUsuarios { get; set; }
    }
}