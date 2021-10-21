using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;
using System.Linq;


namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllProfessores(true));
        }


        // GET api/<ProfessorController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Professor = _repo.GetProfessorById(id);
            if (Professor == null)
                return BadRequest("Professor não encontrado");

            return Ok(Professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não cadastrado.");
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null)
                return BadRequest("Professor não encontrado!");

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não atualizado.");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null)
                return BadRequest("Professor não encontrado!");

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não atualizado.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null)
                return BadRequest("Professor não encontrado!");

            _repo.Delete(prof);
            if (_repo.SaveChanges())
            {
                return Ok("Professor excluído.");
            }

            return BadRequest("Professor não excluído.");
        }

    }
}
