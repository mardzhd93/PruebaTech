using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiPermisos.Models;

namespace WebApiPermisos.Data
{
    public class WebApiTipoPermisosContext : DbContext
    {
        public WebApiTipoPermisosContext (DbContextOptions<WebApiTipoPermisosContext> options)
            : base(options)
        {
        }

        public DbSet<WebApiPermisos.Models.TipoPermiso> TipoPermiso { get; set; }
    }
}
