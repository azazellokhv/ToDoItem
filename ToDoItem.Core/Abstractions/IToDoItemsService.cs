using ToDoItem.Core.Models;

namespace ToDoItem.Application.Services;

public interface IToDoItemsService
{
    Task<List<ToDoItemModel>> GetAllToDoItems();
    Task<ToDoItemModel> GetByIdToDoItem(Guid id);
    Task<Guid> CreateToDoItem(ToDoItemModel toDoItemModel);
    Task<Guid> UpdateToDoItem(Guid id, string title, string description, DateTime dateOfCreation);
    Task<Guid> DeleteToDoItem(Guid id);
}