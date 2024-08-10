using ToDoItem.Core.Models;
using Microsoft.EntityFrameworkCore;
using ToDoItem.DataAccess.Entites;

namespace ToDoItem.DataAccess.Repositories
{
    public class ToDoItemsRepository : IToDoItemsRepository
    {
        private readonly ToDoItemDbContext _context;

        public ToDoItemsRepository(ToDoItemDbContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoItemModel>> GetAll()
        {
            var toDoItemEntities = await _context.ToDoItems
                .AsNoTracking()
                .ToListAsync();

            var toDoItems = toDoItemEntities
                .Select(t => ToDoItemModel.Create(t.Id, t.Title, t.Description, t.DateOfCreation).ToDoItem)
                .ToList();

            return toDoItems;
        }
        
        public async Task<ToDoItemModel> GetById(Guid id)
        {
            var toDoItemEntity = await _context.ToDoItems
                .FirstOrDefaultAsync(t => t.Id == id);
            
            var toDoItem = ToDoItemModel
                .Create(toDoItemEntity!.Id, 
                    toDoItemEntity.Title, 
                    toDoItemEntity.Description, 
                    toDoItemEntity.DateOfCreation).ToDoItem;
            
            return toDoItem;
        }
        
        public async Task<Guid> Create(ToDoItemModel toDoItemModel)
        {
            var toDoItemEntity = new ToDoItemEntity
            {
                Id = toDoItemModel.Id,
                Title = toDoItemModel.Title,
                Description = toDoItemModel.Description,
                DateOfCreation = toDoItemModel.DateOfCreation
            };
            await _context.ToDoItems.AddAsync(toDoItemEntity);
            await _context.SaveChangesAsync();

            return toDoItemEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string title, string description)
        {
            await _context.ToDoItems
                .Where(t => t.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(t => t.Title, t => title)
                    .SetProperty(t => t.Description, t => description ));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.ToDoItems
                .Where(t => t.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}