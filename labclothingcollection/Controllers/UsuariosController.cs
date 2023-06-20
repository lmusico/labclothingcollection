﻿using labclothingcollection.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace labclothingcollection.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // GET: api/<UsuariosController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Usuario> Get()
        {
            return MockUsuarios.usuario;
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            Usuario usuario = MockUsuarios.usuario.FirstOrDefault(x=> x.Identificador == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // POST api/<UsuariosController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            MockUsuarios.usuario.Add(usuario);

            return CreatedAtAction(nameof(Get), new {id = usuario.Identificador}, usuario);
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Put(int id, [FromBody] Usuario usuario)
        {
            Usuario usuarioUpdate = MockUsuarios.usuario.FirstOrDefault(x => x.Identificador == id);

            if (usuario == null)
            {
                return NotFound();
            }

            var index = MockUsuarios.usuario.IndexOf(usuarioUpdate);

            if (index != -1)
            {
                MockUsuarios.usuario[index] = usuario;
            }
            return NoContent();
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            Usuario usuarioUpdate = MockUsuarios.usuario.FirstOrDefault(x => x.Identificador == id);

            if (usuarioUpdate == null)
            {
                return NotFound();
            }

            MockUsuarios.usuario.Remove(usuarioUpdate);

            return NoContent();


        }
    }
}
