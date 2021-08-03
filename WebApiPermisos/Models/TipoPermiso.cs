using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiPermisos.Models
{
    public partial class TipoPermiso
    {
        public TipoPermiso()
        {
            Permisos = new HashSet<Permiso>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Permiso> Permisos { get; set; }
    }
}
