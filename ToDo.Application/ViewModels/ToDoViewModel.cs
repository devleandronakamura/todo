namespace ToDo.Application.ViewModels
{
    public class ToDoViewModel
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}