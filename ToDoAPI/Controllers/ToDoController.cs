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
        private readonly ILogger<ToDoController> _logger;

        public ToDoController(ITodoData data, ILogger<ToDoController> logger)
        {
            _data = data;
            _logger = logger;
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
            try
            {
                var output = await _data.GetAllAssigned(GetUserId());
                return Ok(output);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GET api/todos failed");
                return BadRequest();
            }
        }

        // GET api/ToDo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoModel>> Get(int todoId)
        {
            try
            {
                var output = await _data.GetOneAssigned(GetUserId(), todoId);
                return Ok(output);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "GET api/todos/[id] failed", todoId);
                return BadRequest();
            }
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
