using labclothingcollection.Context;
using labclothingcollection.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace labclothingcollection.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly labclothingcollectionContext _context;

        public UsuariosController(labclothingcollectionContext context)
        {
            _context = context;
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] string? status)
        {
            List<Usuario> usuarios = await _context.Usuarios.Where(x => status != null ? x.Status == status : x.Status != null).ToListAsync();

            return Ok(usuarios);
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x=> x.Identificador == id).ConfigureAwait(true);

            if (usuario == null)
            {
                return NotFound("Id fornecido não foi encontrado.");
            }

            return Ok(usuario);
        }

        // POST api/<UsuariosController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            bool existeCpf = await _context.Usuarios.AnyAsync(x => x.Cpf == usuario.Cpf);

            if (existeCpf)
            {
                return Conflict("O CPF informado já existe no banco de dados.");
            }

            if (usuario.Tipo != "Administrador" && usuario.Tipo != "Gerente" && usuario.Tipo != "Criador" && usuario.Tipo != "Outro")
            {
                return BadRequest("O campo Tipo deve ser Administrador, Gerente, Criador ou Outro");
            }

            if (usuario.Status != "Ativo" && usuario.Status != "Inativo")
            {
                return BadRequest("O campo Status deve ser Ativo ou Inativo");
            }

            _context.Usuarios.Add(usuario);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new {id = usuario.Identificador}, usuario);
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutDados(int id, [FromBody] UsuarioDados usuario)
        {

            Usuario usuarioUpdate = await _context.Usuarios.FirstOrDefaultAsync(x => x.Identificador == id).ConfigureAwait(true);

            if (usuarioUpdate == null)
            {
                return NotFound("Id fornecido não foi encontrado.");
            }

            if (usuario.Nome != null)
            {
                usuarioUpdate.Nome = usuario.Nome;
            }

            if (usuario.Genero != null)
            {
                usuarioUpdate.Genero = usuario.Genero;
            }

            if (usuario.Nascimento != new DateTime (0001,01,01,00,00,00))
            {
                usuarioUpdate.Nascimento = usuario.Nascimento;
            }

            if (usuario.Telefone != null)
            {
                usuarioUpdate.Telefone = usuario.Telefone;
            }

            if (usuario.Tipo != null)
            {
                usuarioUpdate.Tipo = usuario.Tipo;
            }


            _context.Entry(usuarioUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            Console.WriteLine(usuarioUpdate.Nascimento);

            return NoContent();
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}/status")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutStatus(int id, string status)
        {

            Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Identificador == id).ConfigureAwait(true);

            if (usuario == null)
            {
                return NotFound("Id fornecido não foi encontrado.");
            }

            usuario.Status = status;

            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
