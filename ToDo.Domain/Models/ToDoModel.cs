namespace ToDo.Domain.Models
{
    public class ToDoModel
    {
        public ToDoModel(string description)
        {
            Id = Guid.NewGuid();
            Description = description;
            IsActive = true;
            CreatedAt = DateTime.Now;
            Deleted = false;
        }

        public void Delete()
        {
            UpdatedAt = DateTime.Now;
            Deleted = true;
        }

        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; private set; }
        public bool Deleted { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
    }
}