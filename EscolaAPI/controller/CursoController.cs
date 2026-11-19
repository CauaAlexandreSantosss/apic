using EscolaAPI.Interfaces;
using EscolaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoController(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        // GET: api/curso
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_cursoRepository.ListarTodos()); // 200
        }

        // GET: api/curso/{id}
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Curso? curso = _cursoRepository.BuscarPorId(id);

            if (curso == null)
            {
                return NotFound(); // 404
            }

            return Ok(curso); // 200
        }

        // POST: api/curso
        [HttpPost]
        public IActionResult Cadastrar(Curso curso)
        {
            _cursoRepository.cadastra(curso);

            return StatusCode(201); // 201 Created
        }

        // PUT: api/curso/{id}
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Curso curso)
        {
            if (_cursoRepository.BuscarPorId(id) == null)
            {
                return NotFound(); // 404
            }

            _cursoRepository.Atualizar(id, curso);

            return NoContent(); // 204
        }

        // DELETE: api/curso/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_cursoRepository.BuscarPorId(id) == null)
            {
                return NotFound(); // 404
            }

            _cursoRepository.Delete(id);

            return Ok(); // 200
        }
    }
}