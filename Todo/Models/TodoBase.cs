using Todo.Core;

namespace Todo.Entities
{
    public class TodoBase:BaseEntity<int>
    {
        public string? TodoName { get; set; }
        public int TodoTag { get; set; }
        public string? TodoDescription { get; set; }
        public Status TodoStatus { get; set; }
    }
}
