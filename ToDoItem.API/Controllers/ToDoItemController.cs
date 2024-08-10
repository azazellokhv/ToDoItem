using Microsoft.AspNetCore.Mvc;
using ToDoItem.Application.Services;
using ToDoItem.Contracts;
using ToDoItem.Core.Models;

namespace ToDoItem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoItemController : ControllerBase
    {
        private readonly IToDoItemsService _toDoItemsService;

        public ToDoItemController(IToDoItemsService toDoItemsService)
        {
            _toDoItemsService = toDoItemsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoItemsResponse>>> GetAllToDoItems()
        {
            var toDoItems = await _toDoItemsService.GetAllToDoItems();
            var response = toDoItems
                .Select(t => 
                    new ToDoItemsResponse(t.Id, t.Title, t.Description, t.DateOfCreation));

            return Ok(response);
        }

        /*[HttpGet("{id:guid}")]
        public async Task<ToDoItemsResponse> GetByIdToDoItem(Guid id)
        {
            var toDoItem = await _toDoItemsService.GetByIdToDoItem(id);

            var response = new ToDoItemsResponse(
                toDoItem.Id,
                toDoItem.Title,
                toDoItem.Description,
                toDoItem.DateOfCreation);

            return Ok(response);
        }*/

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateToDoItem([FromBody] ToDoItemsRequest request)
        {
            var (toDoItem, error) = ToDoItemModel.Create(
                Guid.NewGuid(),
                request.Title,
                request.Description,
                DateTime.UtcNow);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var toDoItemId = await _toDoItemsService.CreateToDoItem(toDoItem);

            return Ok(toDoItemId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateToDoItem(Guid id, [FromBody] ToDoItemsRequest request)
        {
            var toDoItemId = await _toDoItemsService.UpdateToDoItem(id, request.Title, request.Description, request.DateOfCreation);

            return Ok(toDoItemId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteToDoItem(Guid id)
        {
            return Ok(await _toDoItemsService.DeleteToDoItem(id));
        }

    }
    
    
}