using Microsoft.AspNetCore.Mvc;using Microsoft.AspNetCore.Mvc;

using TaskManagerAPI.Models;using TaskManagerAPI.Models;



namespace TaskManagerAPI.Controllersnamespace TaskManagerAPI.Controllers

{{

    [ApiController]    [ApiController]

    [Route("api/tasks")]    [Route("api/tasks")]

    public class TasksController : ControllerBase    public class TasksController : ControllerBase

    {    {

        private readonly TaskStorage _store;        private readonly TaskStorage _store;



        public TasksController(TaskStorage store)        public TasksController(TaskStorage store)

        {        {

            _store = store;            _store = store;

        }        }



        [HttpGet]        [HttpGet]

        public ActionResult<List<TaskItem>> GetAll()        public ActionResult<List<TaskItem>> GetAll()

        {        {

            return Ok(_store.GetAll());            return Ok(_store.GetAll());

        }        }



        [HttpPost]        [HttpPost]

        public ActionResult<TaskItem> Create([FromBody] CreateTaskRequest req)        public ActionResult<TaskItem> Create([FromBody] CreateTaskRequest req)

        {        {

            if (string.IsNullOrWhiteSpace(req.Description))            if (string.IsNullOrWhiteSpace(req.Description))

            {            {

                return BadRequest("Description is required");                return BadRequest("Description is required");

            }            }



            var task = _store.Add(req.Description);            var task = _store.Add(req.Description);

            return CreatedAtAction(nameof(GetAll), new { id = task.Id }, task);            return CreatedAtAction(nameof(GetAll), new { id = task.Id }, task);

        }        }



        [HttpPut("{id}")]        [HttpPut("{id}")]

        public ActionResult Update(int id, [FromBody] UpdateTaskRequest req)        public ActionResult Update(int id, [FromBody] UpdateTaskRequest req)

        {        {

            if (string.IsNullOrWhiteSpace(req.Description))            if (string.IsNullOrWhiteSpace(req.Description))

            {            {

                return BadRequest("Description is required");                return BadRequest("Description is required");

            }            }



            var ok = _store.Update(id, req.Description, req.IsCompleted);            var ok = _store.Update(id, req.Description, req.IsCompleted);

            if (!ok)            if (!ok)

            {            {

                return NotFound();                return NotFound();

            }            }



            return NoContent();            return NoContent();

        }        }



        [HttpDelete("{id}")]        [HttpDelete("{id}")]

        public ActionResult Delete(int id)        public ActionResult Delete(int id)

        {        {

            var ok = _store.Delete(id);            var ok = _store.Delete(id);

            if (!ok)            if (!ok)

            {            {

                return NotFound();                return NotFound();

            }            }



            return NoContent();            return NoContent();

        }        }

    }    }



    public class CreateTaskRequest    public class CreateTaskRequest

    {    {

        public string Description { get; set; } = string.Empty;        public string Description { get; set; } = string.Empty;

    }    }



    public class UpdateTaskRequest    public class UpdateTaskRequest

    {    {

        public string Description { get; set; } = string.Empty;        public string Description { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }        public bool IsCompleted { get; set; }

    }    }

}}

