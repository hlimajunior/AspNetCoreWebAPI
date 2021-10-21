using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }


        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null)
                return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não cadastrado");

        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null)
                return BadRequest("Aluno não encontrado!");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não atualizado");

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null)
                return BadRequest("Aluno não encontrado!");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não atualizado");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alunoId = _repo.GetAlunoById(id);
            if (alunoId == null)
                return BadRequest("Aluno não encontrado!");

            _repo.Delete(alunoId);
            if (_repo.SaveChanges())
            {
                return Ok("Aluno excluído");
            }

            return BadRequest("Aluno não excluído");
        }

    }
}
