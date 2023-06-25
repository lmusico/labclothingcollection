using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using labclothingcollection.Context;
using labclothingcollection.Models;

namespace labclothingcollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelosController : ControllerBase
    {
        private readonly labclothingcollectionContext _context;

        public ModelosController(labclothingcollectionContext context)
        {
            _context = context;
        }

        // GET: api/Modelos
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetModelos([FromQuery] string? layout)
        {

          List<Modelo> modelos = await _context.Modelos.Where(x => layout != null ? x.LayoutPeca == layout : x.LayoutPeca != null).ToListAsync();

          if (_context.Modelos == null)
          {
              return NotFound();
          }
            return Ok(modelos);
        }

        // GET: api/Modelos/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Modelo>> GetModelo(int id)
        {
          if (_context.Modelos == null)
          {
              return NotFound();
          }
            var modelo = await _context.Modelos.FindAsync(id);

            if (modelo == null)
            {
                return NotFound();
            }

            return modelo;
        }

        // PUT: api/Modelos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutModelo(int id, Modelo modelo)
        {
            if (id != modelo.Identificador)
            {
                return BadRequest();
            }

            _context.Entry(modelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloExists(id))
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

        // POST: api/Modelos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostModelo(Modelo modelo)
        {
            bool existeModelo = await _context.Modelos.AnyAsync(x => x.Nome == modelo.Nome);

            if (existeModelo)
            {
                return Conflict("Já existe um modelo criado com o nome informado.");
            }
            if (_context.Modelos == null)
          {
              return Problem("Entity set 'labclothingcollectionContext.Modelos' is null.");
          }
            _context.Modelos.Add(modelo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModelo", new { id = modelo.Identificador }, modelo);
        }

        // DELETE: api/Modelos/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteModelo(int id)
        {
            if (_context.Modelos == null)
            {
                return NotFound();
            }
            var modelo = await _context.Modelos.FindAsync(id);
            if (modelo == null)
            {
                return NotFound();
            }

            _context.Modelos.Remove(modelo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModeloExists(int id)
        {
            return (_context.Modelos?.Any(e => e.Identificador == id)).GetValueOrDefault();
        }
    }
}
