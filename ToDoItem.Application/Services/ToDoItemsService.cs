using ToDoItem.Core.Models;
using ToDoItem.DataAccess.Repositories;

namespace ToDoItem.Application.Services
{
    public class ToDoItemsService : IToDoItemsService
    {
        private readonly IToDoItemsRepository _toDoItemsRepository;

        public ToDoItemsService(IToDoItemsRepository toDoItemsRepository)
        {
            _toDoItemsRepository = toDoItemsRepository;
        }

        public async Task<List<ToDoItemModel>> GetAllToDoItems()
        {
            return await _toDoItemsRepository.GetAll();
        }

        public async Task<ToDoItemModel> GetByIdToDoItem(Guid id)
        {
            return await _toDoItemsRepository.GetById(id);
        }

        public async Task<Guid> CreateToDoItem(ToDoItemModel toDoItemModel)
        {
            return await _toDoItemsRepository.Create(toDoItemModel);
        }

        public async Task<Guid> UpdateToDoItem(Guid id, string title, string description, DateTime dateOfCreation)
        {
            return await _toDoItemsRepository.Update(id, title, description);
        }

        public async Task<Guid> DeleteToDoItem(Guid id)
        {
            return await _toDoItemsRepository.Delete(id);
        }

    }
    
}