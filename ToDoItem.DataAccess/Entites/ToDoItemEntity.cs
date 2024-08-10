namespace ToDoItem.DataAccess.Entites
{
    public class ToDoItemEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateOfCreation { get; set; }
    }
}