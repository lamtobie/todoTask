namespace todoTask.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public long? UserID { get; set; }
        public bool IsComplete { get; set; }
    }
}
