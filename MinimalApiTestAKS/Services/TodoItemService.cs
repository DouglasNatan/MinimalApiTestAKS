using MinimalApiTestAKS.Models;

namespace MinimalApiTestAKS.Services
{
    internal class TodoItemService : ITodoItemService
    {
        private readonly List<Todo> _todoItems = new();

        public Task<Todo> AddTodo(string? name)
        {
            int id = new Random (0).Next();
            var todoItem = new Todo(id, name ?? "", false);
            _todoItems.Add(todoItem);
            return Task.FromResult(todoItem);
        }
    }
}