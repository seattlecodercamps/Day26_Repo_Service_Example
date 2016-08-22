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
    public class BlogController : Controller
    {
        private IBlogRepository _repo;
        public BlogController(IBlogRepository repo)
        {
            _repo = repo;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var model = _repo.GetBlogs();
            return Ok(model);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = _repo.GetBlogById(id);
            return Ok(model);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Blog data)
        {
            _repo.SaveBlog(data);
            return Ok();
        }

        

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.DeleteBlog(id);
            return Ok();
        }
    }
}
