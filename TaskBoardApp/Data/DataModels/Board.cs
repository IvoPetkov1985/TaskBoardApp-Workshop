using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstants.DataConstants;

namespace TaskBoardApp.Data.DataModels
{
    [Comment("Board which consists of tasks")]
    public class Board
    {
        [Key]
        [Comment("Board identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(BoardNameMaxLength)]
        [Comment("Board name")]
        public string Name { get; set; } = string.Empty;

        public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}

//•	Id – a unique integer, Primary Key
//•	Name – a string with min length 3 and max length 30 (required)
//•	Tasks – a collection of Task
