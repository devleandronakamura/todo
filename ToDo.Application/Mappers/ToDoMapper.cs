using ToDo.Application.ViewModels;
using ToDo.Domain.Models;

namespace ToDo.Application.Mappers
{
    public class ToDoMapper
    {
        public static List<ToDoViewModel> ToDoViewModelList (List<ToDoModel> toDoModelList)
        {
            var toDoViewModelList = new List<ToDoViewModel>();

            foreach (var toDoModel in toDoModelList) 
            {
                toDoViewModelList.Add(
                    new ToDoViewModel() 
                    { 
                        Id = toDoModel.Id, 
                        Description = toDoModel.Description,
                        IsActive = toDoModel.IsActive
                    });
            }

            return toDoViewModelList;
        }

        public static ToDoViewModel ToDoViewModel(ToDoModel toDoModel)
        {
            if (toDoModel is null) 
                return new ToDoViewModel();

            return  new ToDoViewModel()
                    {
                        Id = toDoModel.Id,
                        Description = toDoModel.Description,
                        IsActive = toDoModel.IsActive
                    };
        }
    }
}
