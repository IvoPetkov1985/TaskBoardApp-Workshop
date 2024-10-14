using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstants.DataConstants;

namespace TaskBoardApp.Models.ViewModels
{
    public class TaskFormViewModel
    {
        [Required]
        [StringLength(TaskTitleMaxLength, MinimumLength = TaskTitleMinLength, ErrorMessage = TaskInputErrorMsg)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(TaskDescrMaxLength, MinimumLength = TaskDescrMinLength, ErrorMessage = TaskInputErrorMsg)]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<TaskBoardViewModel> Boards { get; set; } = new List<TaskBoardViewModel>();
    }
}
