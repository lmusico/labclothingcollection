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
    public class ColecoesController : ControllerBase
    {
        private readonly labclothingcollectionContext _context;

        public ColecoesController(labclothingcollectionContext context)
        {
            _context = context;
        }

        // GET: api/Colecoes
        [HttpGet]
        public async Task<IActionResult> GetColecoes([FromQuery] string? status)
        {

          List<Colecao> colecoes = await _context.Colecoes.Where(x => status != null ? x.Status == status : x.Status != null).ToListAsync();
          

          if (_context.Colecoes == null)
          {
              return NotFound();
          }
            return Ok(colecoes);
        }

        // GET: api/Colecoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Colecao>> GetColecao(int id)
        {
          if (_context.Colecoes == null)
          {
              return NotFound();
          }
            var colecao = await _context.Colecoes.FindAsync(id);

            if (colecao == null)
            {
                return NotFound();
            }

            return colecao;
        }

        // PUT: api/Colecoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColecao(int id, Colecao colecao)
        {
            if (id != colecao.Identificador)
            {
                return BadRequest();
            }

            _context.Entry(colecao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColecaoExists(id))
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

        [HttpPut("{id}/status")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutStatus(int id, string status)
        {

            Colecao colecao = await _context.Colecoes.FirstOrDefaultAsync(x => x.Identificador == id).ConfigureAwait(true);

            if (colecao == null)
            {
                return NotFound("Id fornecido não foi encontrado.");
            }

            colecao.Status = status;

            _context.Entry(colecao).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Colecoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Colecao>> PostColecao(Colecao colecao)
        {
          if (_context.Colecoes == null)
          {
              return Problem("Entity set 'labclothingcollectionContext.Colecoes'  is null.");
          }
            _context.Colecoes.Add(colecao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColecao", new { id = colecao.Identificador }, colecao);
        }

        // DELETE: api/Colecoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColecao(int id)
        {
            if (_context.Colecoes == null)
            {
                return NotFound();
            }
            var colecao = await _context.Colecoes.FindAsync(id);
            if (colecao == null)
            {
                return NotFound();
            }

            if (colecao.Status == "Ativa")
            {
                return StatusCode(403, "Essa coleção está ativa portanto não pode ser deletada");
            }

            bool existeModelo = await _context.Modelos.AnyAsync(x => x.ColecaoId == colecao.Identificador);

            if (existeModelo)
            {
                return StatusCode(403, "Essa coleção possui modelos atrelados e não pode ser deletada");
            }

            _context.Colecoes.Remove(colecao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColecaoExists(int id)
        {
            return (_context.Colecoes?.Any(e => e.Identificador == id)).GetValueOrDefault();
        }
    }
}
