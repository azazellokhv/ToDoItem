namespace ToDoItem.Contracts;

public record ToDoItemsResponse(
    Guid Id,
    string Title,
    string Description,
    DateTime DateOfCreation);
    
