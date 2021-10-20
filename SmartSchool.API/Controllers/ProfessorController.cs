using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {

        // GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Professor Humberto Júnior");
        }

        // GET api/<ProfessorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Professor " + id.ToString();
        }


    }
}
