namespace ToDoItem.Contracts;

public record ToDoItemsRequest(
    string Title,
    string Description,
    DateTime DateOfCreation);