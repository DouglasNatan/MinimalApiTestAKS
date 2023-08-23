using MinimalApiTestAKS.Models;
using MinimalApiTestAKS.Mappers;

namespace MinimalApiTestAKS.Services
{
    internal class TodoItemService : ITodoItemService
    {
        private readonly List<Todo> _todoItems = new();

        public Task<Todo> AddTodo(TodoModel model)
        {
           Todo dto = model.ConverterTo();
        
            if (model?.Name?.ToLower() is "douglas natan")
                  return Task.FromResult(dto);

            int id = new Random(0).Next();
            dto = new Todo(id, model?.Name ?? "Xpto", false);
            _todoItems.Add(dto);
            return Task.FromResult(dto);
        }
    }
}