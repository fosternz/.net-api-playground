using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoLibrary.DataAccess;
using ToDoLibrary.Models;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        private readonly ITodoData _data;

        public ToDoController(ITodoData data)
        {
            _data = data;            
        }

        private int GetUserId()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return int.Parse(userId);
        }

        // GET: api/ToDo
        [HttpGet]
        public async Task<ActionResult<List<ToDoModel>>> Get()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var response =  await _data.GetAllAssigned(GetUserId());

            return Ok(response);
        }

        // GET api/ToDo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoModel>> Get(int todoId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var response = await _data.GetOneAssigned(GetUserId(), todoId);

            return Ok(response);
        }

        // POST api/ToDo
        [HttpPost]
        public async Task<ActionResult<ToDoModel>> Post([FromBody] string task)
        {
            var response = await _data.Create(GetUserId(), task);
            return Ok(response);
        }

        // PUT api/ToDo
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/ToDo
        [HttpPut("{id}/complete")]
        public IActionResult Complete(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/ToDo
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
