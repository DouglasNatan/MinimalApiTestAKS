using MinimalApiTestAKS.Models;

namespace MinimalApiTestAKS.Services
{
    public interface ITodoItemService
    {
      Task<Todo> AddTodo(string? name);
    }
}