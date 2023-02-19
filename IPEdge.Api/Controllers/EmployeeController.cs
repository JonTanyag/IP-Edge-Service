using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPEdge.Infrastructure.Commands;
using IPEdge.Core.Models;
using IPEdge.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IPEdge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediatr;

        public EmployeeController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]int page, int pageSize)
        {
            var result = await _mediatr.Send(new GetEmployeesQuery(page, pageSize));
            if (result != null)
                return Ok(result);

            return BadRequest("No record/s found.");
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery]string query)
        {
            var result = await _mediatr.Send(new SearchEmployeeQuery(query));
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
        public async Task<IActionResult> Post([FromBody]AddEmployeeCommand request)
        {
            await _mediatr.Send(request);
            return Ok("Employee added.");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]UpdateEmployeeCommand request)
        {
            await _mediatr.Send(request);
            return Ok("Employee Updated");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediatr.Send(new DeleteEmployeeCommand(id));

            return Ok("Employee delete.");
        }
    }
}

