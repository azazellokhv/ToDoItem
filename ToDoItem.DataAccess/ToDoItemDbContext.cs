using Microsoft.EntityFrameworkCore;
using ToDoItem.DataAccess.Entites;

namespace ToDoItem.DataAccess
{
    public class ToDoItemDbContext : DbContext
    {
        public ToDoItemDbContext(DbContextOptions<ToDoItemDbContext> options) : base(options)
        {
            
        }

        public DbSet<ToDoItemEntity> ToDoItems { get; set; }
    }
}