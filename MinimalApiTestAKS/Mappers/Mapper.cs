using MinimalApiTestAKS.Models;

namespace MinimalApiTestAKS.Mappers
{
    public static class Mapper
    {
       public static Todo ConverterTo (this TodoModel model)
       {
         return new Todo (model.ID, model.Name ?? "Default", model.IsComplete);
       }

       public static TodoModel ConverterTo (this Todo todo)
       {
         return new TodoModel (todo.ID, todo.Name ?? "Default", todo.IsComplete);
       }

    }
}