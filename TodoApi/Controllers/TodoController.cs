
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Controllers
{
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository todoRepository;
        public TodoController(ITodoRepository todoRepository) 
            => this.todoRepository = todoRepository;


        [HttpGet("/api/todo")]
        public IActionResult GetAllTodos()
        {
            return Ok(todoRepository.GetAll());
        }

        [HttpGet("/api/todo/{id}")]
        public IActionResult GetTodoById(int id)
        {
            var todo = todoRepository.GetById(id);
            if (todo == null)
                return NotFound();

            return Ok(todo);
        }

        [HttpPost("/api/todo")]
        public IActionResult CreateTodo([FromBody] Todo todo)
        {
            var existingTodo = todoRepository.GetById(todo.Id);
            if (existingTodo != null)
                return Conflict(existingTodo);

            todo = todoRepository.Create(todo);
            return Created();
        }

        [HttpPut("/api/todo/{id}")]
        public IActionResult UpdateTodo([FromBody] Todo todo, int id)
        {
            if (id != todo.Id)
                return BadRequest();

            var existingTodo = todoRepository.GetById(todo.Id);
            if (existingTodo == null)
                return NotFound();

            var retorno = todoRepository.Update(existingTodo, todo);
            return Ok(retorno);
        }

        [HttpDelete("/api/todo/{id}")]
        public IActionResult Delete(int id)
        {
            var existingTodo = todoRepository.GetById(id);
            if (existingTodo == null)
                return NotFound();

            todoRepository.Delete(id);
            return NoContent();
        }
    }
}
