using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Day26_Repo.Interfaces;
using Day26_Repo.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Day26_Repo.API
{
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private IMovieService _service;
        public MovieController(IMovieService service)
        {
            _service = service;
        }


        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAllMovies());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetMovieById(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Movie movie)
        {
            if (ModelState.IsValid)
            {
                _service.SaveMovie(movie);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteMovie(id);
            return Ok();
        }
    }
}
