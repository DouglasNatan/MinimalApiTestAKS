
namespace MinimalApiTestAKS.Models
{
    public class Todo
    {
        public int ID { get; private set; }
        public string? Name { get; private set; }
        public bool IsComplete { get; private set; }

        public Todo() {}

        public Todo(int id, string name, bool isComplete)
        {
            ID = id;
            Name = name;
            IsComplete = isComplete;
        }

        //Setters
        public void SetID(int id)
        {
            ID = id;
        }
        public void SetName(string? name)
        {
            Name = name ?? "default";
        }
        public void SetIsComplete(bool isComplete)
        {
            IsComplete = isComplete;
        }
    }
}