using ToDoItem.Core.Models;

namespace ToDoItem.DataAccess.Repositories;

public interface IToDoItemsRepository
{
    Task<List<ToDoItemModel>> GetAll();
    Task<ToDoItemModel> GetById(Guid id);
    Task<Guid> Create(ToDoItemModel toDoItemModel);
    Task<Guid> Update(Guid id, string title, string description);
    Task<Guid> Delete(Guid id);
}