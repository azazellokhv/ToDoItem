namespace ToDoItem.Core.Models
{
    public class ToDoItemModel
    {
        private ToDoItemModel(Guid id, string title, string description, DateTime dateOfCreation)
        {
            Id = id;
            Title = title;
            Description = description;
            DateOfCreation = DateTime.UtcNow;
        }

        public Guid Id { get; }
        public string Title { get; }
        public string Description { get; }
        public DateTime DateOfCreation { get; }

        public static (ToDoItemModel ToDoItem, string Error) Create(Guid id, string title, string description, DateTime dateOfCreation)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
            {
                error = "Необходимо заполнить заголовок и описание";
            }

            var toDoItem = new ToDoItemModel(id, title, description, dateOfCreation);

            return (toDoItem, error);
        }
    }
}