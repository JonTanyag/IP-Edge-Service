using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPEdge.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IPEdge.Api.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly IMediator _mediatr;

        public RoleController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediatr.Send(new GetRolesQuery());
            if (result != null)
                return Ok(result);

            return BadRequest("No record/s found.");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

