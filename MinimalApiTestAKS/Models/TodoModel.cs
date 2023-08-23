
namespace MinimalApiTestAKS.Models
{
    public class TodoModel
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }

        public TodoModel(int id, string name, bool isComplete)
        {
            ID = id;
            Name = name;
            IsComplete = isComplete;
        }
    }
}