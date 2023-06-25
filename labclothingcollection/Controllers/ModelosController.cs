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
    [Route("api/modelos")]
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

        [HttpPut("{id}/layout")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutLayout(int id, string layout)
        {

            Modelo modelo = await _context.Modelos.FirstOrDefaultAsync(x => x.Identificador == id).ConfigureAwait(true);

            if (modelo == null)
            {
                return NotFound("Id fornecido não foi encontrado.");
            }

            modelo.LayoutPeca = layout;

            _context.Entry(modelo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

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

            if (_context.Modelos == null)
            {
                return Problem("Entity set 'labclothingcollectionContext.Modelos' is null.");
            }

            if (existeModelo)
            {
                return Conflict("Já existe um modelo criado com o nome informado.");
            }

            if (modelo.TipoPeca != "Bermuda" && modelo.TipoPeca != "Biquini" && modelo.TipoPeca != "Bolsa" && modelo.TipoPeca != "Boné" && modelo.TipoPeca != "Calça"
                && modelo.TipoPeca != "Calçados" && modelo.TipoPeca != "Camisa" && modelo.TipoPeca != "Chapéu" && modelo.TipoPeca != "Saia")
            {
                return BadRequest("O campo TipoPeca deve ser Bermuda, Biquini, Bolsa, Boné, Calça, Calçados, Camisa, Chapéu ou Saia");
            }

            if (modelo.LayoutPeca != "Bordado" && modelo.LayoutPeca != "Estampa" && modelo.LayoutPeca != "Liso")
            {
                return BadRequest("O campo LayoutPeca deve ser Bordado, Estampa ou Liso");
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
