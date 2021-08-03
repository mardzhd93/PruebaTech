using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiPermisos.Models;

namespace WebApiPermisos.Data
{
    public class WebApiPermisosContext : DbContext
    {
        public WebApiPermisosContext (DbContextOptions<WebApiPermisosContext> options)
            : base(options)
        {
        }

        public DbSet<WebApiPermisos.Models.Permiso> Permiso { get; set; }
    }
}
