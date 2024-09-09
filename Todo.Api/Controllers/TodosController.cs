using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Api.Mappers;
using Todo.Api.Models;
using Todo.Api.Services;

namespace Todo.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {

        private readonly ITodoService _TodoService;

        public TodosController(ITodoService todoService)
        {
            _TodoService = todoService;
        }

        [HttpGet]
        public async Task<List<TodoItemModel>> GetTodoItemsAsync()
        {
            var items = await _TodoService.GetTodoItemsAsync();

            return items.Select(ti => ti.ToModel()).ToList();
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult<TodoItemModel>> GetTodoItemAsync(int Id)
        {
            var item = await _TodoService.GetTodoItemAsync(Id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemModel>> CreateTodoAsync(CreateTodoItemModel model)
        {
            var item = model.ToEntity();

            item = await _TodoService.CreateTodoItemAsync(item);

            return Ok(item.ToModel());
        }

        [HttpPut]
        [Route("{Id}")]
        public async Task<ActionResult<TodoItemModel>> SetTodoItemAsync(int Id, EditTodoItemModel model)
        {
            var item = model.ToEntity();
            item.TodoItemId = Id;

            item = await _TodoService.SetTodoItemAsync(item);

            if (item == null)
            {
                return BadRequest();
            }

            return Ok(item.ToModel());
        }

    }
}
