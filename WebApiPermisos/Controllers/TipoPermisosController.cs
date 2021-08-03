using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPermisos.Data;
using WebApiPermisos.Models;

namespace WebApiPermisos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPermisosController : ControllerBase
    {
        private readonly WebApiTipoPermisosContext _context;

        public TipoPermisosController(WebApiTipoPermisosContext context)
        {
            _context = context;
        }

        // GET: api/TipoPermisos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPermiso>>> GetTipoPermiso()
        {
            return await _context.TipoPermiso.ToListAsync();
        }

        // GET: api/TipoPermisos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPermiso>> GetTipoPermiso(int id)
        {
            var tipoPermiso = await _context.TipoPermiso.FindAsync(id);

            if (tipoPermiso == null)
            {
                return NotFound();
            }

            return tipoPermiso;
        }

        // PUT: api/TipoPermisos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoPermiso(int id, TipoPermiso tipoPermiso)
        {
            if (id != tipoPermiso.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoPermiso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoPermisoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TipoPermisos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoPermiso>> PostTipoPermiso(TipoPermiso tipoPermiso)
        {
            _context.TipoPermiso.Add(tipoPermiso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoPermiso", new { id = tipoPermiso.Id }, tipoPermiso);
        }

        // DELETE: api/TipoPermisos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoPermiso>> DeleteTipoPermiso(int id)
        {
            var tipoPermiso = await _context.TipoPermiso.FindAsync(id);
            if (tipoPermiso == null)
            {
                return NotFound();
            }

            _context.TipoPermiso.Remove(tipoPermiso);
            await _context.SaveChangesAsync();

            return tipoPermiso;
        }

        private bool TipoPermisoExists(int id)
        {
            return _context.TipoPermiso.Any(e => e.Id == id);
        }
    }
}
