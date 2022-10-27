using Microsoft.AspNetCore.Mvc;
using ToDoLibrary.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        // GET: api/ToDo
        [HttpGet]
        public ActionResult<IEnumerable<ToDoModel>> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/ToDo/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/ToDo
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            throw new NotImplementedException();
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
