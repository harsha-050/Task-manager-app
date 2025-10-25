using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly TaskStorage _store;

        public TasksController(TaskStorage store)
        {
            _store = store;
        }

        [HttpGet]
        public ActionResult<List<TaskItem>> GetAll()
        {
            return Ok(_store.GetAll());
        }

        [HttpPost]
        public ActionResult<TaskItem> Create([FromBody] CreateTaskRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Description))
            {
                return BadRequest("Description is required");
            }

            var task = _store.Add(req.Description);
            return CreatedAtAction(nameof(GetAll), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] UpdateTaskRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Description))
            {
                return BadRequest("Description is required");
            }

            var ok = _store.Update(id, req.Description, req.IsCompleted);
            if (!ok)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var ok = _store.Delete(id);
            if (!ok)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

    public class CreateTaskRequest
    {
        public string Description { get; set; } = string.Empty;
    }

    public class UpdateTaskRequest
    {
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}


